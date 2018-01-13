namespace FB_Analyze
{
    partial class FB_Analyze
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
            this.btnFacebookLogin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFacebookLogin
            // 
            this.btnFacebookLogin.Location = new System.Drawing.Point(411, 174);
            this.btnFacebookLogin.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnFacebookLogin.Name = "btnFacebookLogin";
            this.btnFacebookLogin.Size = new System.Drawing.Size(371, 55);
            this.btnFacebookLogin.TabIndex = 1;
            this.btnFacebookLogin.Text = "Login to Facebook";
            this.btnFacebookLogin.UseVisualStyleBackColor = true;
            this.btnFacebookLogin.Click += new System.EventHandler(this.btnFacebookLogin_Click);
            // 
            // btnLogout
            // 
            //this.btnLogout.Location = new System.Drawing.Point(488, 254);
            //this.btnLogout.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            //this.btnLogout.Name = "btnLogout";
            //this.btnLogout.Size = new System.Drawing.Size(200, 55);
            //this.btnLogout.TabIndex = 0;
            //this.btnLogout.Text = "Log out";
            //this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // FB_Analyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 346);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnFacebookLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FB_Analyze";
            this.Text = "Facebook C# SDK - FB_Analyze";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnFacebookLogin;
        private System.Windows.Forms.Button btnLogout;
    }
}

