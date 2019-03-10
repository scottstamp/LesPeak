using LesPeak;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

public class LocalService : WebSocketBehavior
{
    private MainFrm main;

    public LocalService() : this(null) { }
    public LocalService(MainFrm _main)
    {
        main = _main;
    }

    protected override void OnOpen()
    {
        main.LocalConnected();
    }

    protected override void OnMessage(MessageEventArgs e)
    {   
        Task.Run(() => main.OnWebDataOutgoing(e));
    }
}