namespace New
{
    partial class Secretery_Student_Placement
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
            this.Lecture_Placement = new System.Windows.Forms.Button();
            this.Practice_Placement = new System.Windows.Forms.Button();
            this.Lab_Placement = new System.Windows.Forms.Button();
            this.Add_To_Course = new System.Windows.Forms.Button();
            this.Delete_From_Course = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lecture_Placement
            // 
            this.Lecture_Placement.Location = new System.Drawing.Point(61, 28);
            this.Lecture_Placement.Name = "Lecture_Placement";
            this.Lecture_Placement.Size = new System.Drawing.Size(127, 23);
            this.Lecture_Placement.TabIndex = 0;
            this.Lecture_Placement.Text = "Lecture Placement";
            this.Lecture_Placement.UseVisualStyleBackColor = true;
            // 
            // Practice_Placement
            // 
            this.Practice_Placement.Location = new System.Drawing.Point(61, 68);
            this.Practice_Placement.Name = "Practice_Placement";
            this.Practice_Placement.Size = new System.Drawing.Size(127, 23);
            this.Practice_Placement.TabIndex = 1;
            this.Practice_Placement.Text = "Practice Placement";
            this.Practice_Placement.UseVisualStyleBackColor = true;
            // 
            // Lab_Placement
            // 
            this.Lab_Placement.Location = new System.Drawing.Point(61, 115);
            this.Lab_Placement.Name = "Lab_Placement";
            this.Lab_Placement.Size = new System.Drawing.Size(127, 23);
            this.Lab_Placement.TabIndex = 2;
            this.Lab_Placement.Text = "Lab Placement";
            this.Lab_Placement.UseVisualStyleBackColor = true;
            // 
            // Add_To_Course
            // 
            this.Add_To_Course.Location = new System.Drawing.Point(61, 163);
            this.Add_To_Course.Name = "Add_To_Course";
            this.Add_To_Course.Size = new System.Drawing.Size(127, 23);
            this.Add_To_Course.TabIndex = 3;
            this.Add_To_Course.Text = "Add To Course";
            this.Add_To_Course.UseVisualStyleBackColor = true;
            // 
            // Delete_From_Course
            // 
            this.Delete_From_Course.Location = new System.Drawing.Point(61, 206);
            this.Delete_From_Course.Name = "Delete_From_Course";
            this.Delete_From_Course.Size = new System.Drawing.Size(127, 23);
            this.Delete_From_Course.TabIndex = 4;
            this.Delete_From_Course.Text = "Delete From Course";
            this.Delete_From_Course.UseVisualStyleBackColor = true;
            // 
            // Secretery_Student_Placement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.Delete_From_Course);
            this.Controls.Add(this.Add_To_Course);
            this.Controls.Add(this.Lab_Placement);
            this.Controls.Add(this.Practice_Placement);
            this.Controls.Add(this.Lecture_Placement);
            this.Name = "Secretery_Student_Placement";
            this.Text = "Secretery_Student_Placement";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Lecture_Placement;
        private System.Windows.Forms.Button Practice_Placement;
        private System.Windows.Forms.Button Lab_Placement;
        private System.Windows.Forms.Button Add_To_Course;
        private System.Windows.Forms.Button Delete_From_Course;
    }
}