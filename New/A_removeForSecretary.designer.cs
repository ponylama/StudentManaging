namespace New
{
    partial class A_removeForSecretary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_removeForSecretary));
            this.label_remove = new System.Windows.Forms.Label();
            this.button_remove_dept = new System.Windows.Forms.Button();
            this.button_remove_course = new System.Windows.Forms.Button();
            this.button_remove_headDept = new System.Windows.Forms.Button();
            this.button_bach = new System.Windows.Forms.Button();
            this.button_EXIT = new System.Windows.Forms.Button();
            this.button_remove_sched_lecturersFromDept = new System.Windows.Forms.Button();
            this.button_rmv_TA_fromDept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_remove
            // 
            this.label_remove.AutoSize = true;
            this.label_remove.BackColor = System.Drawing.Color.Transparent;
            this.label_remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_remove.ForeColor = System.Drawing.Color.Salmon;
            this.label_remove.Location = new System.Drawing.Point(158, 35);
            this.label_remove.Name = "label_remove";
            this.label_remove.Size = new System.Drawing.Size(386, 55);
            this.label_remove.TabIndex = 0;
            this.label_remove.Text = "Remove options";
            // 
            // button_remove_dept
            // 
            this.button_remove_dept.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_remove_dept.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_remove_dept.Location = new System.Drawing.Point(43, 118);
            this.button_remove_dept.Name = "button_remove_dept";
            this.button_remove_dept.Size = new System.Drawing.Size(231, 68);
            this.button_remove_dept.TabIndex = 1;
            this.button_remove_dept.Text = "Remove department from the ststem";
            this.button_remove_dept.UseVisualStyleBackColor = false;
            this.button_remove_dept.Click += new System.EventHandler(this.button_remove_dept_Click);
            // 
            // button_remove_course
            // 
            this.button_remove_course.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_remove_course.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_remove_course.Location = new System.Drawing.Point(43, 202);
            this.button_remove_course.Name = "button_remove_course";
            this.button_remove_course.Size = new System.Drawing.Size(231, 59);
            this.button_remove_course.TabIndex = 2;
            this.button_remove_course.Text = "Remove course from the system";
            this.button_remove_course.UseVisualStyleBackColor = false;
            this.button_remove_course.Click += new System.EventHandler(this.button_remove_course_Click);
            // 
            // button_remove_headDept
            // 
            this.button_remove_headDept.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_remove_headDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_remove_headDept.Location = new System.Drawing.Point(43, 285);
            this.button_remove_headDept.Name = "button_remove_headDept";
            this.button_remove_headDept.Size = new System.Drawing.Size(231, 84);
            this.button_remove_headDept.TabIndex = 3;
            this.button_remove_headDept.Text = "Remove Head Department from the system";
            this.button_remove_headDept.UseVisualStyleBackColor = false;
            this.button_remove_headDept.Click += new System.EventHandler(this.button_remove_headDept_Click);
            // 
            // button_bach
            // 
            this.button_bach.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_bach.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_bach.Location = new System.Drawing.Point(322, 352);
            this.button_bach.Name = "button_bach";
            this.button_bach.Size = new System.Drawing.Size(229, 55);
            this.button_bach.TabIndex = 4;
            this.button_bach.Text = "Back to the previous page";
            this.button_bach.UseVisualStyleBackColor = false;
            this.button_bach.Click += new System.EventHandler(this.button_bach_Click);
            // 
            // button_EXIT
            // 
            this.button_EXIT.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_EXIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_EXIT.Location = new System.Drawing.Point(595, 382);
            this.button_EXIT.Name = "button_EXIT";
            this.button_EXIT.Size = new System.Drawing.Size(174, 42);
            this.button_EXIT.TabIndex = 5;
            this.button_EXIT.Text = "LOGOUT";
            this.button_EXIT.UseVisualStyleBackColor = false;
            this.button_EXIT.Click += new System.EventHandler(this.button_EXIT_Click);
            // 
            // button_remove_sched_lecturersFromDept
            // 
            this.button_remove_sched_lecturersFromDept.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_remove_sched_lecturersFromDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_remove_sched_lecturersFromDept.Location = new System.Drawing.Point(322, 118);
            this.button_remove_sched_lecturersFromDept.Name = "button_remove_sched_lecturersFromDept";
            this.button_remove_sched_lecturersFromDept.Size = new System.Drawing.Size(247, 79);
            this.button_remove_sched_lecturersFromDept.TabIndex = 6;
            this.button_remove_sched_lecturersFromDept.Text = "Remove schedual of lecturers from each department";
            this.button_remove_sched_lecturersFromDept.UseVisualStyleBackColor = false;
            this.button_remove_sched_lecturersFromDept.Click += new System.EventHandler(this.button_remove_sched_lecturersFromDept_Click);
            // 
            // button_rmv_TA_fromDept
            // 
            this.button_rmv_TA_fromDept.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_rmv_TA_fromDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_rmv_TA_fromDept.Location = new System.Drawing.Point(322, 224);
            this.button_rmv_TA_fromDept.Name = "button_rmv_TA_fromDept";
            this.button_rmv_TA_fromDept.Size = new System.Drawing.Size(241, 82);
            this.button_rmv_TA_fromDept.TabIndex = 7;
            this.button_rmv_TA_fromDept.Text = "Remove schedual of TA from each department";
            this.button_rmv_TA_fromDept.UseVisualStyleBackColor = false;
            this.button_rmv_TA_fromDept.Click += new System.EventHandler(this.button_rmv_TA_fromDept_Click);
            // 
            // A_removeForSecretary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(781, 436);
            this.Controls.Add(this.button_rmv_TA_fromDept);
            this.Controls.Add(this.button_remove_sched_lecturersFromDept);
            this.Controls.Add(this.button_EXIT);
            this.Controls.Add(this.button_bach);
            this.Controls.Add(this.button_remove_headDept);
            this.Controls.Add(this.button_remove_course);
            this.Controls.Add(this.button_remove_dept);
            this.Controls.Add(this.label_remove);
            this.Name = "A_removeForSecretary";
            this.Text = "A_removeForSecretary";
            this.Load += new System.EventHandler(this.A_removeForSecretary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_remove;
        private System.Windows.Forms.Button button_remove_dept;
        private System.Windows.Forms.Button button_remove_course;
        private System.Windows.Forms.Button button_remove_headDept;
        private System.Windows.Forms.Button button_bach;
        private System.Windows.Forms.Button button_EXIT;
        private System.Windows.Forms.Button button_remove_sched_lecturersFromDept;
        private System.Windows.Forms.Button button_rmv_TA_fromDept;
    }
}