namespace New
{
    partial class Student_Placement_to_Course_Secretary_B
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Student_Placement_to_Course_Secretary_B));
            this.Chosing_a_Course = new System.Windows.Forms.Label();
            this.AllCourses_Box = new System.Windows.Forms.ComboBox();
            this.Chose_Student = new System.Windows.Forms.Label();
            this.AllStudents_Box = new System.Windows.Forms.ComboBox();
            this.Exit = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Go_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Chosing_a_Course
            // 
            resources.ApplyResources(this.Chosing_a_Course, "Chosing_a_Course");
            this.Chosing_a_Course.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Chosing_a_Course.Name = "Chosing_a_Course";
            this.Chosing_a_Course.Click += new System.EventHandler(this.Chosing_a_Course_Click);
            // 
            // AllCourses_Box
            // 
            this.AllCourses_Box.FormattingEnabled = true;
            resources.ApplyResources(this.AllCourses_Box, "AllCourses_Box");
            this.AllCourses_Box.Name = "AllCourses_Box";
            this.AllCourses_Box.SelectedIndexChanged += new System.EventHandler(this.AllCourses_Box_SelectedIndexChanged);
            // 
            // Chose_Student
            // 
            resources.ApplyResources(this.Chose_Student, "Chose_Student");
            this.Chose_Student.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Chose_Student.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Chose_Student.Name = "Chose_Student";
            // 
            // AllStudents_Box
            // 
            this.AllStudents_Box.FormattingEnabled = true;
            resources.ApplyResources(this.AllStudents_Box, "AllStudents_Box");
            this.AllStudents_Box.Name = "AllStudents_Box";
            this.AllStudents_Box.SelectedIndexChanged += new System.EventHandler(this.AllStudents_Box_SelectedIndexChanged);
            // 
            // Exit
            // 
            resources.ApplyResources(this.Exit, "Exit");
            this.Exit.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Exit.Name = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Save
            // 
            resources.ApplyResources(this.Save, "Save");
            this.Save.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Save.Name = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Go_Back
            // 
            this.Go_Back.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.Go_Back, "Go_Back");
            this.Go_Back.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Go_Back.Name = "Go_Back";
            this.Go_Back.UseVisualStyleBackColor = false;
            this.Go_Back.Click += new System.EventHandler(this.Go_Back_Click);
            // 
            // Student_Placement_to_Course_Secretary_B
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Go_Back);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.AllStudents_Box);
            this.Controls.Add(this.Chose_Student);
            this.Controls.Add(this.AllCourses_Box);
            this.Controls.Add(this.Chosing_a_Course);
            this.Name = "Student_Placement_to_Course_Secretary_B";
            this.Load += new System.EventHandler(this.Student_Placement_to_Course_Secretary_B_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Chosing_a_Course;
        private System.Windows.Forms.ComboBox AllCourses_Box;
        private System.Windows.Forms.Label Chose_Student;
        private System.Windows.Forms.ComboBox AllStudents_Box;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Go_Back;
    }
}