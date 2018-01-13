namespace New
{
    partial class Student_Placement_to_Lec_Secretary_B
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Student_Placement_to_Lec_Secretary_B));
            this.Save = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.AllStudents_Box = new System.Windows.Forms.ComboBox();
            this.Chose_Student = new System.Windows.Forms.Label();
            this.AllCourses_Box = new System.Windows.Forms.ComboBox();
            this.Chosing_a_Course = new System.Windows.Forms.Label();
            this.Go_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(23, 176);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(120, 23);
            this.Save.TabIndex = 17;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(188, 176);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 16;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // AllStudents_Box
            // 
            this.AllStudents_Box.FormattingEnabled = true;
            this.AllStudents_Box.Location = new System.Drawing.Point(23, 51);
            this.AllStudents_Box.Name = "AllStudents_Box";
            this.AllStudents_Box.Size = new System.Drawing.Size(121, 21);
            this.AllStudents_Box.TabIndex = 15;
            this.AllStudents_Box.SelectedIndexChanged += new System.EventHandler(this.AllStudents_Box_SelectedIndexChanged);
            // 
            // Chose_Student
            // 
            this.Chose_Student.AutoSize = true;
            this.Chose_Student.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Millimeter, ((byte)(177)));
            this.Chose_Student.Location = new System.Drawing.Point(19, 9);
            this.Chose_Student.Name = "Chose_Student";
            this.Chose_Student.Size = new System.Drawing.Size(245, 24);
            this.Chose_Student.TabIndex = 14;
            this.Chose_Student.Text = "Please Chose a Student: ";
            this.Chose_Student.Click += new System.EventHandler(this.Chose_Student_Click);
            // 
            // AllCourses_Box
            // 
            this.AllCourses_Box.FormattingEnabled = true;
            this.AllCourses_Box.Location = new System.Drawing.Point(23, 130);
            this.AllCourses_Box.Name = "AllCourses_Box";
            this.AllCourses_Box.Size = new System.Drawing.Size(377, 21);
            this.AllCourses_Box.TabIndex = 13;
            this.AllCourses_Box.SelectedIndexChanged += new System.EventHandler(this.AllCourses_Box_SelectedIndexChanged);
            // 
            // Chosing_a_Course
            // 
            this.Chosing_a_Course.AutoSize = true;
            this.Chosing_a_Course.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Millimeter, ((byte)(177)));
            this.Chosing_a_Course.Location = new System.Drawing.Point(19, 92);
            this.Chosing_a_Course.Name = "Chosing_a_Course";
            this.Chosing_a_Course.Size = new System.Drawing.Size(244, 24);
            this.Chosing_a_Course.TabIndex = 12;
            this.Chosing_a_Course.Text = "Please Chose a Lecture: ";
            this.Chosing_a_Course.Click += new System.EventHandler(this.Chosing_a_Course_Click);
            // 
            // Go_Back
            // 
            this.Go_Back.Location = new System.Drawing.Point(304, 176);
            this.Go_Back.Name = "Go_Back";
            this.Go_Back.Size = new System.Drawing.Size(112, 23);
            this.Go_Back.TabIndex = 18;
            this.Go_Back.Text = "Go Back To Main Menu";
            this.Go_Back.UseVisualStyleBackColor = true;
            this.Go_Back.Click += new System.EventHandler(this.Go_Back_Click);
            // 
            // Student_Placement_to_Lec_Secretary_B
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(431, 235);
            this.Controls.Add(this.Go_Back);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.AllStudents_Box);
            this.Controls.Add(this.Chose_Student);
            this.Controls.Add(this.AllCourses_Box);
            this.Controls.Add(this.Chosing_a_Course);
            this.Name = "Student_Placement_to_Lec_Secretary_B";
            this.Text = "Student_Placement_to_Lec_Secretary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.ComboBox AllStudents_Box;
        private System.Windows.Forms.Label Chose_Student;
        private System.Windows.Forms.ComboBox AllCourses_Box;
        private System.Windows.Forms.Label Chosing_a_Course;
        private System.Windows.Forms.Button Go_Back;
    }
}