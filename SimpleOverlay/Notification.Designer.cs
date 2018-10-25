namespace SimpleOverlay
{
    partial class Notification
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
            this.lb_Header = new System.Windows.Forms.Label();
            this.lb_Body = new System.Windows.Forms.Label();
            this.pb_Logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Header
            // 
            this.lb_Header.AutoSize = true;
            this.lb_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Header.Location = new System.Drawing.Point(9, 9);
            this.lb_Header.Name = "lb_Header";
            this.lb_Header.Size = new System.Drawing.Size(154, 20);
            this.lb_Header.TabIndex = 0;
            this.lb_Header.Text = "SPACE HOLDER";
            // 
            // lb_Body
            // 
            this.lb_Body.AutoSize = true;
            this.lb_Body.Location = new System.Drawing.Point(79, 38);
            this.lb_Body.Name = "lb_Body";
            this.lb_Body.Size = new System.Drawing.Size(268, 65);
            this.lb_Body.TabIndex = 1;
            this.lb_Body.Text = "EXAMPLE TEXT FOR MULTIPLE LINES \r\nSO I HOPE THIS WILL FIT TO MAKE \r\nSURE I JUST T" +
    "YPE SOME TEXT IN HERE\r\n SO TO SEE WHAT HAPPENS LOL OMGKASDJKASJ\r\n HDKJASHDKASLJ " +
    "DHSKLDJSA";
            // 
            // pb_Logo
            // 
            this.pb_Logo.ImageLocation = "";
            this.pb_Logo.Location = new System.Drawing.Point(12, 38);
            this.pb_Logo.Name = "pb_Logo";
            this.pb_Logo.Size = new System.Drawing.Size(61, 65);
            this.pb_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Logo.TabIndex = 2;
            this.pb_Logo.TabStop = false;
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 124);
            this.Controls.Add(this.pb_Logo);
            this.Controls.Add(this.lb_Body);
            this.Controls.Add(this.lb_Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Notification";
            this.Text = "Notification";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Notification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Header;
        private System.Windows.Forms.Label lb_Body;
        private System.Windows.Forms.PictureBox pb_Logo;
    }
}