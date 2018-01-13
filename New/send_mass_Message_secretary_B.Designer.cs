namespace New
{
    partial class send_mass_Message_secretary_B
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
            this.cours_List_Box = new System.Windows.Forms.ListBox();
            this.load_Courses = new System.Windows.Forms.Button();
            this.Please_Select_Cours_from_List = new System.Windows.Forms.Label();
            this.write_message_Label = new System.Windows.Forms.Label();
            this.send_Buttom = new System.Windows.Forms.Button();
            this.message_Box = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cours_List_Box
            // 
            this.cours_List_Box.FormattingEnabled = true;
            this.cours_List_Box.Location = new System.Drawing.Point(177, 10);
            this.cours_List_Box.Margin = new System.Windows.Forms.Padding(1);
            this.cours_List_Box.Name = "cours_List_Box";
            this.cours_List_Box.Size = new System.Drawing.Size(375, 82);
            this.cours_List_Box.TabIndex = 31;
            this.cours_List_Box.SelectedIndexChanged += new System.EventHandler(this.cours_List_Box_SelectedIndexChanged);
            // 
            // load_Courses
            // 
            this.load_Courses.Location = new System.Drawing.Point(177, 96);
            this.load_Courses.Name = "load_Courses";
            this.load_Courses.Size = new System.Drawing.Size(75, 23);
            this.load_Courses.TabIndex = 32;
            this.load_Courses.Text = "load List";
            this.load_Courses.UseVisualStyleBackColor = true;
            this.load_Courses.Click += new System.EventHandler(this.load_Courses_Click);
            // 
            // Please_Select_Cours_from_List
            // 
            this.Please_Select_Cours_from_List.AutoSize = true;
            this.Please_Select_Cours_from_List.Location = new System.Drawing.Point(4, 10);
            this.Please_Select_Cours_from_List.Name = "Please_Select_Cours_from_List";
            this.Please_Select_Cours_from_List.Size = new System.Drawing.Size(169, 13);
            this.Please_Select_Cours_from_List.TabIndex = 33;
            this.Please_Select_Cours_from_List.Text = "Please Select Cours From The List";
            // 
            // write_message_Label
            // 
            this.write_message_Label.AutoSize = true;
            this.write_message_Label.Location = new System.Drawing.Point(13, 139);
            this.write_message_Label.Name = "write_message_Label";
            this.write_message_Label.Size = new System.Drawing.Size(132, 13);
            this.write_message_Label.TabIndex = 34;
            this.write_message_Label.Text = "Please write your message";
            // 
            // send_Buttom
            // 
            this.send_Buttom.Location = new System.Drawing.Point(16, 261);
            this.send_Buttom.Name = "send_Buttom";
            this.send_Buttom.Size = new System.Drawing.Size(75, 23);
            this.send_Buttom.TabIndex = 36;
            this.send_Buttom.Text = "Send";
            this.send_Buttom.UseVisualStyleBackColor = true;
            this.send_Buttom.Click += new System.EventHandler(this.send_Buttom_Click);
            // 
            // message_Box
            // 
            this.message_Box.Location = new System.Drawing.Point(16, 156);
            this.message_Box.Multiline = true;
            this.message_Box.Name = "message_Box";
            this.message_Box.Size = new System.Drawing.Size(536, 99);
            this.message_Box.TabIndex = 37;
            // 
            // send_mass_Message_secretary_B
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 372);
            this.Controls.Add(this.message_Box);
            this.Controls.Add(this.send_Buttom);
            this.Controls.Add(this.write_message_Label);
            this.Controls.Add(this.Please_Select_Cours_from_List);
            this.Controls.Add(this.load_Courses);
            this.Controls.Add(this.cours_List_Box);
            this.Name = "send_mass_Message_secretary_B";
            this.Text = "send_mass_Message_secretary_B";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox cours_List_Box;
        private System.Windows.Forms.Button load_Courses;
        private System.Windows.Forms.Label Please_Select_Cours_from_List;
        private System.Windows.Forms.Label write_message_Label;
        private System.Windows.Forms.Button send_Buttom;
        private System.Windows.Forms.TextBox message_Box;
    }
}