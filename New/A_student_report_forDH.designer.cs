namespace New
{
    partial class A_student_report_forDH
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
            this.title = new System.Windows.Forms.Label();
            this.backtpp_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.Label();
            this.code_text = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.Transparent;
            this.title.Location = new System.Drawing.Point(81, 26);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(545, 37);
            this.title.TabIndex = 1;
            this.title.Text = "View report student for department";
            // 
            // backtpp_btn
            // 
            this.backtpp_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backtpp_btn.Location = new System.Drawing.Point(237, 363);
            this.backtpp_btn.Name = "backtpp_btn";
            this.backtpp_btn.Size = new System.Drawing.Size(200, 32);
            this.backtpp_btn.TabIndex = 11;
            this.backtpp_btn.Text = "back to previous page";
            this.backtpp_btn.UseVisualStyleBackColor = true;
            this.backtpp_btn.Click += new System.EventHandler(this.backtpp_btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(661, 253);
            this.dataGridView1.TabIndex = 10;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.BackColor = System.Drawing.Color.Transparent;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(17, 70);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(191, 25);
            this.name.TabIndex = 7;
            this.name.Text = "Department Name:";
            // 
            // code_text
            // 
            this.code_text.Location = new System.Drawing.Point(209, 75);
            this.code_text.Name = "code_text";
            this.code_text.Size = new System.Drawing.Size(129, 20);
            this.code_text.TabIndex = 8;
            this.code_text.TextChanged += new System.EventHandler(this.code_text_TextChanged);
            // 
            // A_student_report_forDH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::New.Properties.Resources.OS_X_Wallpaper;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(705, 407);
            this.Controls.Add(this.backtpp_btn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.code_text);
            this.Controls.Add(this.name);
            this.Controls.Add(this.title);
            this.Name = "A_student_report_forDH";
            this.Text = "A_student_report_forDH";
            this.Load += new System.EventHandler(this.A_student_report_forDH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button backtpp_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.TextBox code_text;
    }
}