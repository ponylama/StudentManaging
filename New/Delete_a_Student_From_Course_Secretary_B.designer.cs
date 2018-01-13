namespace New
{
    partial class Delete_a_Student_From_Course_Secretary_B
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Delete_a_Student_From_Course_Secretary_B));
            this.Exit = new System.Windows.Forms.Button();
            this.AllStudents_Box = new System.Windows.Forms.ComboBox();
            this.Chose_Student = new System.Windows.Forms.Label();
            this.AllCourses_Box = new System.Windows.Forms.ComboBox();
            this.Chosing_a_Course = new System.Windows.Forms.Label();
            this.Delete_Pic = new System.Windows.Forms.PictureBox();
            this.Back = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Delete_Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Back)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Exit.Location = new System.Drawing.Point(534, 248);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(71, 23);
            this.Exit.TabIndex = 10;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // AllStudents_Box
            // 
            this.AllStudents_Box.FormattingEnabled = true;
            this.AllStudents_Box.Location = new System.Drawing.Point(102, 50);
            this.AllStudents_Box.Name = "AllStudents_Box";
            this.AllStudents_Box.Size = new System.Drawing.Size(223, 21);
            this.AllStudents_Box.TabIndex = 9;
            this.AllStudents_Box.SelectedIndexChanged += new System.EventHandler(this.AllStudents_Box_SelectedIndexChanged);
            // 
            // Chose_Student
            // 
            this.Chose_Student.AutoSize = true;
            this.Chose_Student.BackColor = System.Drawing.Color.LightGray;
            this.Chose_Student.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Millimeter, ((byte)(177)));
            this.Chose_Student.Location = new System.Drawing.Point(11, 9);
            this.Chose_Student.Name = "Chose_Student";
            this.Chose_Student.Size = new System.Drawing.Size(245, 24);
            this.Chose_Student.TabIndex = 8;
            this.Chose_Student.Text = "Please Chose a Student: ";
            this.Chose_Student.Click += new System.EventHandler(this.Chose_Student_Click);
            // 
            // AllCourses_Box
            // 
            this.AllCourses_Box.FormattingEnabled = true;
            this.AllCourses_Box.Location = new System.Drawing.Point(318, 133);
            this.AllCourses_Box.Name = "AllCourses_Box";
            this.AllCourses_Box.Size = new System.Drawing.Size(212, 21);
            this.AllCourses_Box.TabIndex = 7;
            this.AllCourses_Box.SelectedIndexChanged += new System.EventHandler(this.AllCourses_Box_SelectedIndexChanged);
            // 
            // Chosing_a_Course
            // 
            this.Chosing_a_Course.AutoSize = true;
            this.Chosing_a_Course.BackColor = System.Drawing.Color.Gainsboro;
            this.Chosing_a_Course.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Millimeter, ((byte)(177)));
            this.Chosing_a_Course.ForeColor = System.Drawing.Color.Black;
            this.Chosing_a_Course.Location = new System.Drawing.Point(212, 89);
            this.Chosing_a_Course.Name = "Chosing_a_Course";
            this.Chosing_a_Course.Size = new System.Drawing.Size(241, 24);
            this.Chosing_a_Course.TabIndex = 6;
            this.Chosing_a_Course.Text = "Please Chose a Course: ";
            this.Chosing_a_Course.Click += new System.EventHandler(this.Chosing_a_Course_Click);
            // 
            // Delete_Pic
            // 
            this.Delete_Pic.BackColor = System.Drawing.Color.Transparent;
            this.Delete_Pic.Image = ((System.Drawing.Image)(resources.GetObject("Delete_Pic.Image")));
            this.Delete_Pic.Location = new System.Drawing.Point(534, 170);
            this.Delete_Pic.Name = "Delete_Pic";
            this.Delete_Pic.Size = new System.Drawing.Size(71, 61);
            this.Delete_Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Delete_Pic.TabIndex = 12;
            this.Delete_Pic.TabStop = false;
            this.Delete_Pic.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.Transparent;
            this.Back.Image = ((System.Drawing.Image)(resources.GetObject("Back.Image")));
            this.Back.Location = new System.Drawing.Point(33, 181);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(58, 50);
            this.Back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Back.TabIndex = 13;
            this.Back.TabStop = false;
            this.Back.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // Delete_a_Student_From_Course_Secretary_B
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(649, 283);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Delete_Pic);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.AllStudents_Box);
            this.Controls.Add(this.Chose_Student);
            this.Controls.Add(this.AllCourses_Box);
            this.Controls.Add(this.Chosing_a_Course);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Name = "Delete_a_Student_From_Course_Secretary_B";
            this.Text = "Delete_a_Student_From_Course_Secretary_B";
            ((System.ComponentModel.ISupportInitialize)(this.Delete_Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Back)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.ComboBox AllStudents_Box;
        private System.Windows.Forms.Label Chose_Student;
        private System.Windows.Forms.ComboBox AllCourses_Box;
        private System.Windows.Forms.Label Chosing_a_Course;
        private System.Windows.Forms.PictureBox Delete_Pic;
        private System.Windows.Forms.PictureBox Back;
    }
}