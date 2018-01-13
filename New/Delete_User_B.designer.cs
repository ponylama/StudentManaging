namespace New
{
    partial class Delete_User_B
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Delete_User_B));
            this.Delete_Button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Refresh_Button = new System.Windows.Forms.Button();
            this.User_List = new System.Windows.Forms.ListBox();
            this.Are_You_Shure = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Delete_Button
            // 
            this.Delete_Button.Location = new System.Drawing.Point(12, 176);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(75, 23);
            this.Delete_Button.TabIndex = 26;
            this.Delete_Button.Text = "Delete User";
            this.Delete_Button.UseVisualStyleBackColor = true;
            this.Delete_Button.Visible = false;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_User_click_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(226, 176);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 27;
            this.button2.Text = "Hide";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_Yellow1_Click);
            // 
            // Refresh_Button
            // 
            this.Refresh_Button.Location = new System.Drawing.Point(238, 31);
            this.Refresh_Button.Name = "Refresh_Button";
            this.Refresh_Button.Size = new System.Drawing.Size(75, 23);
            this.Refresh_Button.TabIndex = 28;
            this.Refresh_Button.Text = "Refresh";
            this.Refresh_Button.UseVisualStyleBackColor = true;
            this.Refresh_Button.Click += new System.EventHandler(this.Refresh_Button_Click);
            // 
            // User_List
            // 
            this.User_List.FormattingEnabled = true;
            this.User_List.Location = new System.Drawing.Point(2, 6);
            this.User_List.Name = "User_List";
            this.User_List.Size = new System.Drawing.Size(230, 95);
            this.User_List.TabIndex = 29;
            // 
            // Are_You_Shure
            // 
            this.Are_You_Shure.AutoSize = true;
            this.Are_You_Shure.Location = new System.Drawing.Point(12, 107);
            this.Are_You_Shure.Name = "Are_You_Shure";
            this.Are_You_Shure.Size = new System.Drawing.Size(174, 17);
            this.Are_You_Shure.TabIndex = 30;
            this.Are_You_Shure.Text = "are you sure you want to delete";
            this.Are_You_Shure.UseVisualStyleBackColor = true;
            this.Are_You_Shure.CheckedChanged += new System.EventHandler(this.Are_You_Shure_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-73, -7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(386, 222);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // Delete_User_B
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 211);
            this.Controls.Add(this.Are_You_Shure);
            this.Controls.Add(this.User_List);
            this.Controls.Add(this.Refresh_Button);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.pictureBox1);
            this.Location = new System.Drawing.Point(1000, 400);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Delete_User_B";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Delete_User_B";
            this.Load += new System.EventHandler(this.Delete_User_B_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Delete_Button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Refresh_Button;
        private System.Windows.Forms.ListBox User_List;
        private System.Windows.Forms.CheckBox Are_You_Shure;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}