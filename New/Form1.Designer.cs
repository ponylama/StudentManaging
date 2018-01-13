namespace New
{
    partial class Form1
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
            this.LoginB = new System.Windows.Forms.Button();
            this.Student_MenuB = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.support = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginB
            // 
            this.LoginB.Location = new System.Drawing.Point(72, 31);
            this.LoginB.Name = "LoginB";
            this.LoginB.Size = new System.Drawing.Size(75, 23);
            this.LoginB.TabIndex = 11;
            this.LoginB.Text = "Login";
            this.LoginB.UseVisualStyleBackColor = true;
            this.LoginB.Click += new System.EventHandler(this.Login_Click);
            // 
            // Student_MenuB
            // 
            this.Student_MenuB.Location = new System.Drawing.Point(72, 60);
            this.Student_MenuB.Name = "Student_MenuB";
            this.Student_MenuB.Size = new System.Drawing.Size(75, 23);
            this.Student_MenuB.TabIndex = 12;
            this.Student_MenuB.Text = "Student Menu";
            this.Student_MenuB.UseVisualStyleBackColor = true;
            this.Student_MenuB.Click += new System.EventHandler(this.Student_Menu_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Secretary Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Secretary_Menu_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(72, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Add new user";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_Blue2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(72, 148);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Delete user";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.delete_button_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(72, 177);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "Exit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Exit_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(72, 206);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(109, 23);
            this.button5.TabIndex = 17;
            this.button5.Text = "Change Password";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Change_pass_Click);
            // 
            // support
            // 
            this.support.Location = new System.Drawing.Point(205, 31);
            this.support.Name = "support";
            this.support.Size = new System.Drawing.Size(75, 23);
            this.support.TabIndex = 18;
            this.support.Text = "support";
            this.support.UseVisualStyleBackColor = true;
            this.support.Click += new System.EventHandler(this.support_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(201, 159);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(109, 23);
            this.button6.TabIndex = 19;
            this.button6.Text = "change name";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 341);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.support);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Student_MenuB);
            this.Controls.Add(this.LoginB);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button LoginB;
        private System.Windows.Forms.Button Student_MenuB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button support;
        private System.Windows.Forms.Button button6;
    }
}