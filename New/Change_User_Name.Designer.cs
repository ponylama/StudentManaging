namespace New
{
    partial class Change_User_Name
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Change_User_Name));
            this.User_List = new System.Windows.Forms.ListBox();
            this.Refresh_Button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Change_Name = new System.Windows.Forms.Button();
            this.Change_last_name = new System.Windows.Forms.Button();
            this.name_Label = new System.Windows.Forms.Label();
            this.Write_Box = new System.Windows.Forms.TextBox();
            this.Change_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // User_List
            // 
            this.User_List.FormattingEnabled = true;
            this.User_List.Location = new System.Drawing.Point(12, 12);
            this.User_List.Name = "User_List";
            this.User_List.Size = new System.Drawing.Size(250, 95);
            this.User_List.TabIndex = 34;
            // 
            // Refresh_Button
            // 
            this.Refresh_Button.Location = new System.Drawing.Point(271, 12);
            this.Refresh_Button.Name = "Refresh_Button";
            this.Refresh_Button.Size = new System.Drawing.Size(75, 23);
            this.Refresh_Button.TabIndex = 33;
            this.Refresh_Button.Text = "Refresh";
            this.Refresh_Button.UseVisualStyleBackColor = true;
            this.Refresh_Button.Click += new System.EventHandler(this.Refresh_Button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(187, 204);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 32;
            this.button2.Text = "Hide";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Change_Name
            // 
            this.Change_Name.Location = new System.Drawing.Point(12, 123);
            this.Change_Name.Name = "Change_Name";
            this.Change_Name.Size = new System.Drawing.Size(110, 23);
            this.Change_Name.TabIndex = 31;
            this.Change_Name.Text = "Change first name";
            this.Change_Name.UseVisualStyleBackColor = true;
            this.Change_Name.Click += new System.EventHandler(this.Change_Name_Click);
            // 
            // Change_last_name
            // 
            this.Change_last_name.Location = new System.Drawing.Point(128, 123);
            this.Change_last_name.Name = "Change_last_name";
            this.Change_last_name.Size = new System.Drawing.Size(121, 23);
            this.Change_last_name.TabIndex = 35;
            this.Change_last_name.Text = "Change last Name";
            this.Change_last_name.UseVisualStyleBackColor = true;
            this.Change_last_name.Click += new System.EventHandler(this.Change_LastName_Click);
            // 
            // name_Label
            // 
            this.name_Label.AutoSize = true;
            this.name_Label.Location = new System.Drawing.Point(12, 169);
            this.name_Label.Name = "name_Label";
            this.name_Label.Size = new System.Drawing.Size(35, 13);
            this.name_Label.TabIndex = 36;
            this.name_Label.Text = "label1";
            this.name_Label.Visible = false;
            // 
            // Write_Box
            // 
            this.Write_Box.Location = new System.Drawing.Point(151, 166);
            this.Write_Box.Name = "Write_Box";
            this.Write_Box.Size = new System.Drawing.Size(156, 20);
            this.Write_Box.TabIndex = 37;
            this.Write_Box.Visible = false;
            // 
            // Change_button
            // 
            this.Change_button.Location = new System.Drawing.Point(51, 204);
            this.Change_button.Name = "Change_button";
            this.Change_button.Size = new System.Drawing.Size(110, 23);
            this.Change_button.TabIndex = 38;
            this.Change_button.Text = "Change";
            this.Change_button.UseVisualStyleBackColor = true;
            this.Change_button.Visible = false;
            this.Change_button.Click += new System.EventHandler(this.Change_button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-47, -33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(444, 320);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // Change_User_Name
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 260);
            this.Controls.Add(this.Change_button);
            this.Controls.Add(this.Write_Box);
            this.Controls.Add(this.name_Label);
            this.Controls.Add(this.Change_last_name);
            this.Controls.Add(this.User_List);
            this.Controls.Add(this.Refresh_Button);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Change_Name);
            this.Controls.Add(this.pictureBox1);
            this.Location = new System.Drawing.Point(1000, 400);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Change_User_Name";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Change_User_Name";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox User_List;
        private System.Windows.Forms.Button Refresh_Button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Change_Name;
        private System.Windows.Forms.Button Change_last_name;
        private System.Windows.Forms.Label name_Label;
        private System.Windows.Forms.TextBox Write_Box;
        private System.Windows.Forms.Button Change_button;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}