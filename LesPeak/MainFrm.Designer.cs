namespace LesPeak
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.tssWebsocketLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstInventoryItems = new System.Windows.Forms.ListBox();
            this.grpInventory = new System.Windows.Forms.GroupBox();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblInfoPosition = new System.Windows.Forms.Label();
            this.lblInfoRoom = new System.Windows.Forms.Label();
            this.lblInfoUsername = new System.Windows.Forms.Label();
            this.chkWalkToBlacksmith = new System.Windows.Forms.CheckBox();
            this.ssMain.SuspendLayout();
            this.grpInventory.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssWebsocketLabel});
            this.ssMain.Location = new System.Drawing.Point(0, 173);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(324, 22);
            this.ssMain.TabIndex = 0;
            // 
            // tssWebsocketLabel
            // 
            this.tssWebsocketLabel.Name = "tssWebsocketLabel";
            this.tssWebsocketLabel.Size = new System.Drawing.Size(93, 17);
            this.tssWebsocketLabel.Text = "<Socket Status>";
            // 
            // lstInventoryItems
            // 
            this.lstInventoryItems.FormattingEnabled = true;
            this.lstInventoryItems.Items.AddRange(new object[] {
            "Slot 1",
            "Slot 2",
            "Slot 3",
            "Slot 4",
            "Slot 5",
            "Slot 6",
            "Slot 7",
            "Slot 8"});
            this.lstInventoryItems.Location = new System.Drawing.Point(6, 19);
            this.lstInventoryItems.Name = "lstInventoryItems";
            this.lstInventoryItems.Size = new System.Drawing.Size(120, 108);
            this.lstInventoryItems.TabIndex = 1;
            // 
            // grpInventory
            // 
            this.grpInventory.Controls.Add(this.lstInventoryItems);
            this.grpInventory.Location = new System.Drawing.Point(12, 12);
            this.grpInventory.Name = "grpInventory";
            this.grpInventory.Size = new System.Drawing.Size(134, 135);
            this.grpInventory.TabIndex = 2;
            this.grpInventory.TabStop = false;
            this.grpInventory.Text = "Inventory";
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.lblInfoPosition);
            this.grpInfo.Controls.Add(this.lblInfoRoom);
            this.grpInfo.Controls.Add(this.lblInfoUsername);
            this.grpInfo.Location = new System.Drawing.Point(152, 12);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(160, 135);
            this.grpInfo.TabIndex = 3;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Information";
            // 
            // lblInfoPosition
            // 
            this.lblInfoPosition.AutoSize = true;
            this.lblInfoPosition.Location = new System.Drawing.Point(6, 45);
            this.lblInfoPosition.Name = "lblInfoPosition";
            this.lblInfoPosition.Size = new System.Drawing.Size(82, 13);
            this.lblInfoPosition.TabIndex = 2;
            this.lblInfoPosition.Text = "Position: not set";
            // 
            // lblInfoRoom
            // 
            this.lblInfoRoom.AutoSize = true;
            this.lblInfoRoom.Location = new System.Drawing.Point(6, 32);
            this.lblInfoRoom.Name = "lblInfoRoom";
            this.lblInfoRoom.Size = new System.Drawing.Size(73, 13);
            this.lblInfoRoom.TabIndex = 1;
            this.lblInfoRoom.Text = "Room: not set";
            // 
            // lblInfoUsername
            // 
            this.lblInfoUsername.AutoSize = true;
            this.lblInfoUsername.Location = new System.Drawing.Point(6, 19);
            this.lblInfoUsername.Name = "lblInfoUsername";
            this.lblInfoUsername.Size = new System.Drawing.Size(93, 13);
            this.lblInfoUsername.TabIndex = 0;
            this.lblInfoUsername.Text = "Username: not set";
            // 
            // chkWalkToBlacksmith
            // 
            this.chkWalkToBlacksmith.AutoSize = true;
            this.chkWalkToBlacksmith.Location = new System.Drawing.Point(12, 153);
            this.chkWalkToBlacksmith.Name = "chkWalkToBlacksmith";
            this.chkWalkToBlacksmith.Size = new System.Drawing.Size(117, 17);
            this.chkWalkToBlacksmith.TabIndex = 4;
            this.chkWalkToBlacksmith.Text = "Walk to Blacksmith";
            this.chkWalkToBlacksmith.UseVisualStyleBackColor = true;
            this.chkWalkToBlacksmith.CheckedChanged += new System.EventHandler(this.chkWalkToBlacksmith_CheckedChanged);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 195);
            this.Controls.Add(this.chkWalkToBlacksmith);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.grpInventory);
            this.Controls.Add(this.ssMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.Text = "LesPeak";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.grpInventory.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel tssWebsocketLabel;
        private System.Windows.Forms.ListBox lstInventoryItems;
        private System.Windows.Forms.GroupBox grpInventory;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblInfoPosition;
        private System.Windows.Forms.Label lblInfoRoom;
        private System.Windows.Forms.Label lblInfoUsername;
        private System.Windows.Forms.CheckBox chkWalkToBlacksmith;
    }
}

