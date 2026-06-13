namespace MyTiger
{
    partial class PetPartyForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblRoomCode = new System.Windows.Forms.Label();
            txtRoomCode = new System.Windows.Forms.TextBox();
            btnCreate = new System.Windows.Forms.Button();
            btnJoin = new System.Windows.Forms.Button();
            lblStatus = new System.Windows.Forms.Label();
            lblVisitorName = new System.Windows.Forms.Label();
            visitorPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)visitorPic).BeginInit();
            SuspendLayout();

            // lblRoomCode
            lblRoomCode.Location = new System.Drawing.Point(12, 20);
            lblRoomCode.Size = new System.Drawing.Size(80, 23);
            lblRoomCode.Text = "Room Code:";

            // txtRoomCode
            txtRoomCode.Location = new System.Drawing.Point(100, 17);
            txtRoomCode.Size = new System.Drawing.Size(100, 23);

            // btnCreate
            btnCreate.Location = new System.Drawing.Point(12, 55);
            btnCreate.Size = new System.Drawing.Size(120, 30);
            btnCreate.Text = "Create Room";
            btnCreate.Click += btnCreate_Click;

            // btnJoin
            btnJoin.Location = new System.Drawing.Point(145, 55);
            btnJoin.Size = new System.Drawing.Size(120, 30);
            btnJoin.Text = "Join Room";
            btnJoin.Click += btnJoin_Click;

            // lblStatus
            lblStatus.Location = new System.Drawing.Point(12, 100);
            lblStatus.Size = new System.Drawing.Size(360, 23);
            lblStatus.Text = "Create a room or enter a code to join one.";

            // lblVisitorName
            lblVisitorName.Location = new System.Drawing.Point(12, 130);
            lblVisitorName.Size = new System.Drawing.Size(360, 23);
            lblVisitorName.Text = "";

            // visitorPic
            visitorPic.Location = new System.Drawing.Point(12, 160);
            visitorPic.Size = new System.Drawing.Size(200, 150);
            visitorPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            visitorPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(400, 330);
            Controls.Add(lblRoomCode);
            Controls.Add(txtRoomCode);
            Controls.Add(btnCreate);
            Controls.Add(btnJoin);
            Controls.Add(lblStatus);
            Controls.Add(lblVisitorName);
            Controls.Add(visitorPic);
            Text = "Pet Party";
            ((System.ComponentModel.ISupportInitialize)visitorPic).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblRoomCode;
        private System.Windows.Forms.TextBox txtRoomCode;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblVisitorName;
        private System.Windows.Forms.PictureBox visitorPic;
    }
}
