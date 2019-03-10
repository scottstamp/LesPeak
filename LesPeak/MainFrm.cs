using Newtonsoft.Json;
using Sulakore.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tangine;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace LesPeak
{
    [Module("LesPeak", "Swiss-army knife for PeakRP")]
    [Author("Scott Stamp", HabboName = "seagulls", Hotel = Sulakore.Habbo.HHotel.Com)]
    public partial class MainFrm : ExtensionForm
    {
        //public override bool IsRemoteModule => true;
        private WebSocketServer Local = new WebSocketServer(9090);
        private WebSocket Remote = new WebSocket("wss://server.peakrp.com/ws");
        private Log log;
        private bool walkingToBlacksmith = false;
        private int RoomId = 0, PosX = 0, PosY = 0;
        private string Username = "";

        public MainFrm()
        {
            InitializeComponent();
            Local.AddWebSocketService("/ws", () => new LocalService(this));
            Local.Start();

            Remote.OnMessage += (sender, e) =>
            {
                Task.Run(() => OnWebDataIncoming(e));
            };
        }

        public void LocalConnected()
        {
            //if (log != null) log.Dispose();
            //log = new Log();
            //log.Show();

            Remote.Connect();
        }

        public void OnWebDataOutgoing(MessageEventArgs e)
        {
            bool blocked = false;
            string raw = e.Data;

            if (raw.StartsWith("finish-sso "))
            {
                raw = "finish-sso \"function(){n.a.embedSWF(this.gordonUrl+this.swfName,\\\"client\\\",\\\"100 %\\\",\\\"100 %\\\",\\\"11.1.0\\\",\\\"//game.peakrp.com/expressInstall.swf\\\",this.flashVariables,this.flashParams,null,null)}\"";
            }
            else if (raw.StartsWith("chat"))
            {
                dynamic data = JsonConvert.DeserializeObject(raw.Substring(5));
                if (data.Message == ":sell")
                {
                    blocked = true;
                    walkingToBlacksmith = true;
                    Task.Run(() => RoomChanged(RoomId));
                    SendMessageToLiveFeed("Walking to Blacksmith...");
                }
                else if (data.Message == ":stop")
                {
                    blocked = true;
                    walkingToBlacksmith = false;
                    SendMessageToLiveFeed("Cancelling walk to Blacksmith...");
                }
            }

            if (!blocked)
                Remote.Send(raw);
        }

        public void SendMessageToLiveFeed(string message)
        {
            Local.WebSocketServices.Broadcast($"{{\"Html\":\"<span class=\\\"green bold\\\">{message}</span>\",\"Name\":\"live-feed\"}}");
        }

        public void OnWebDataIncoming(MessageEventArgs e)
        {
            bool blocked = false;

            try
            {
                dynamic data = JsonConvert.DeserializeObject(e.Data);
                if (data.Name != null)
                {
                    switch ((string)data.Name)
                    {
                        case "my-name":
                            Username = data.Arguments[0];
                            SendMessageToLiveFeed("Connected! Got Username: " + Username);
                            break;
                        case "change-pos":
                            PositionChanged((int)data.x, (int)data.y);
                            break;
                        case "change-room":
                            RoomChanged((int)data.roomId);
                            break;
                        case "store":
                            if (data.type == "overlays/open" && data.payload == "weapon-store")
                            {
                                walkingToBlacksmith = false;
                                Remote.Send("weapon-store-sell 49");
                                Remote.Send("weapon-store-sell 51");
                                Connection.SendToServerAsync(1737, 25, 15);
                                SendMessageToLiveFeed("Ka-ching! Sold ores to Blacksmith");
                                blocked = true;
                            }
                            break;
                    }
                }

                if (!blocked)
                    Local.WebSocketServices.Broadcast(e.Data);
            }
            catch { }

            //log.Invoke((MethodInvoker)delegate
            //{
            //log.rtbLog.AppendText($"In: {e.Data}\r\n");
            //});
        }

        public void PositionChanged(int x, int y)
        {
            PosX = x;
            PosY = y;
        }

        public void RoomChanged(int roomId)
        {
            RoomId = roomId;

            if (walkingToBlacksmith)
            {
                if (roomId == 27)
                    Connection.SendToServerAsync(1737, 11, 1);
                else if (roomId == 26)
                    Connection.SendToServerAsync(1737, 1, 15);
                else if (roomId == 9)
                    Connection.SendToServerAsync(1737, 19, 1);
                else if (roomId == 3)
                    Connection.SendToServerAsync(1737, 25, 19);
                else if (roomId == 22)
                    Connection.SendToServerAsync(1737, 9, 7);
                else if (roomId == 25)
                    Connection.SendToClientAsync(1737, 22, 18);
            }
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Remote.Close();
            Local.Stop();
        }

        private void chkWalkToBlacksmith_CheckedChanged(object sender, EventArgs e)
        {
            walkingToBlacksmith = chkWalkToBlacksmith.Checked;
            RoomChanged(RoomId);
        }
    }
}
