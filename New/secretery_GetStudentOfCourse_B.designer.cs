namespace New
{
    partial class secretery_GetStudentOfCourse_B
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
            this.getID = new System.Windows.Forms.TextBox();
            this.get_students = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // getID
            // 
            this.getID.Location = new System.Drawing.Point(282, 57);
            this.getID.Name = "getID";
            this.getID.Size = new System.Drawing.Size(348, 38);
            this.getID.TabIndex = 1;
            this.getID.Text = "Write ID here";
            // 
            // get_students
            // 
            this.get_students.Location = new System.Drawing.Point(666, 44);
            this.get_students.Name = "get_students";
            this.get_students.Size = new System.Drawing.Size(225, 62);
            this.get_students.TabIndex = 2;
            this.get_students.Text = "Get students";
            this.get_students.UseVisualStyleBackColor = true;
            this.get_students.Click += new System.EventHandler(this.get_students_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(59, 193);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.Size = new System.Drawing.Size(888, 514);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Course ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // secretery_GetStudentOfCourse_B
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 795);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.get_students);
            this.Controls.Add(this.getID);
            this.Name = "secretery_GetStudentOfCourse_B";
            this.Text = "secretery_GetStudentOfCourse_B";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox getID;
        private System.Windows.Forms.Button GetStudent;
        private System.Windows.Forms.Button get_students;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
    }
}