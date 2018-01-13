namespace New
{
    partial class A_queryStudentSecretary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_queryStudentSecretary));
            this.label1_query_Student = new System.Windows.Forms.Label();
            this.label1_IDstudent = new System.Windows.Forms.Label();
            this.lable1_insttructions_title = new System.Windows.Forms.Label();
            this.studentID_text = new System.Windows.Forms.TextBox();
            this.button1_search = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.backtpp_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1_query_Student
            // 
            this.label1_query_Student.AutoSize = true;
            this.label1_query_Student.BackColor = System.Drawing.Color.Transparent;
            this.label1_query_Student.Font = new System.Drawing.Font("AR JULIAN", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_query_Student.ForeColor = System.Drawing.Color.Transparent;
            this.label1_query_Student.Location = new System.Drawing.Point(30, 31);
            this.label1_query_Student.Name = "label1_query_Student";
            this.label1_query_Student.Size = new System.Drawing.Size(349, 56);
            this.label1_query_Student.TabIndex = 0;
            this.label1_query_Student.Text = "Query Student";
            // 
            // label1_IDstudent
            // 
            this.label1_IDstudent.AutoSize = true;
            this.label1_IDstudent.BackColor = System.Drawing.Color.Transparent;
            this.label1_IDstudent.Font = new System.Drawing.Font("AR JULIAN", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_IDstudent.Location = new System.Drawing.Point(45, 159);
            this.label1_IDstudent.Name = "label1_IDstudent";
            this.label1_IDstudent.Size = new System.Drawing.Size(150, 25);
            this.label1_IDstudent.TabIndex = 1;
            this.label1_IDstudent.Text = "Student ID : *";
            // 
            // lable1_insttructions_title
            // 
            this.lable1_insttructions_title.AutoSize = true;
            this.lable1_insttructions_title.BackColor = System.Drawing.Color.Transparent;
            this.lable1_insttructions_title.Font = new System.Drawing.Font("AR JULIAN", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable1_insttructions_title.ForeColor = System.Drawing.Color.Transparent;
            this.lable1_insttructions_title.Location = new System.Drawing.Point(45, 111);
            this.lable1_insttructions_title.Name = "lable1_insttructions_title";
            this.lable1_insttructions_title.Size = new System.Drawing.Size(405, 25);
            this.lable1_insttructions_title.TabIndex = 2;
            this.lable1_insttructions_title.Text = "Please enter the following information:";
            // 
            // studentID_text
            // 
            this.studentID_text.Location = new System.Drawing.Point(50, 202);
            this.studentID_text.Name = "studentID_text";
            this.studentID_text.Size = new System.Drawing.Size(129, 20);
            this.studentID_text.TabIndex = 3;
            // 
            // button1_search
            // 
            this.button1_search.Font = new System.Drawing.Font("AR JULIAN", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1_search.Location = new System.Drawing.Point(212, 202);
            this.button1_search.Name = "button1_search";
            this.button1_search.Size = new System.Drawing.Size(75, 23);
            this.button1_search.TabIndex = 4;
            this.button1_search.Text = "search";
            this.button1_search.UseVisualStyleBackColor = true;
            this.button1_search.Click += new System.EventHandler(this.button1_search_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 252);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(484, 101);
            this.dataGridView1.TabIndex = 5;
            // 
            // backtpp_btn
            // 
            this.backtpp_btn.Font = new System.Drawing.Font("AR JULIAN", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backtpp_btn.Location = new System.Drawing.Point(143, 390);
            this.backtpp_btn.Name = "backtpp_btn";
            this.backtpp_btn.Size = new System.Drawing.Size(200, 23);
            this.backtpp_btn.TabIndex = 6;
            this.backtpp_btn.Text = "back to previous page";
            this.backtpp_btn.UseVisualStyleBackColor = true;
            this.backtpp_btn.Click += new System.EventHandler(this.backtpp_btn_Click);
            // 
            // A_queryStudentSecretary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(541, 452);
            this.Controls.Add(this.backtpp_btn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1_search);
            this.Controls.Add(this.studentID_text);
            this.Controls.Add(this.lable1_insttructions_title);
            this.Controls.Add(this.label1_IDstudent);
            this.Controls.Add(this.label1_query_Student);
            this.Name = "A_queryStudentSecretary";
            this.Text = "A_queryStudentSecretary";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1_query_Student;
        private System.Windows.Forms.Label label1_IDstudent;
        private System.Windows.Forms.Label lable1_insttructions_title;
        private System.Windows.Forms.TextBox studentID_text;
        private System.Windows.Forms.Button button1_search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button backtpp_btn;
    }
}