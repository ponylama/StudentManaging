namespace New
{
    partial class A_stutent_report_perYear
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
            this.backtpp_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dep_naem = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.Year = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // backtpp_btn
            // 
            this.backtpp_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backtpp_btn.Location = new System.Drawing.Point(227, 363);
            this.backtpp_btn.Name = "backtpp_btn";
            this.backtpp_btn.Size = new System.Drawing.Size(200, 32);
            this.backtpp_btn.TabIndex = 16;
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
            this.dataGridView1.Location = new System.Drawing.Point(11, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(661, 253);
            this.dataGridView1.TabIndex = 15;
            // 
            // dep_naem
            // 
            this.dep_naem.Location = new System.Drawing.Point(537, 71);
            this.dep_naem.Name = "dep_naem";
            this.dep_naem.Size = new System.Drawing.Size(129, 20);
            this.dep_naem.TabIndex = 14;
            this.dep_naem.TextChanged += new System.EventHandler(this.dep_naem_TextChanged);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.BackColor = System.Drawing.Color.Transparent;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(345, 66);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(191, 25);
            this.name.TabIndex = 13;
            this.name.Text = "Department Name:";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.Transparent;
            this.title.Location = new System.Drawing.Point(107, 20);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(446, 37);
            this.title.TabIndex = 12;
            this.title.Text = "View report student per year";
            // 
            // Year
            // 
            this.Year.Location = new System.Drawing.Point(161, 72);
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(129, 20);
            this.Year.TabIndex = 18;
            this.Year.TextChanged += new System.EventHandler(this.Year_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Year(a,b,c,d):";
            // 
            // A_stutent_report_perYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::New.Properties.Resources.OS_X_Wallpaper;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(684, 411);
            this.Controls.Add(this.Year);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backtpp_btn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dep_naem);
            this.Controls.Add(this.name);
            this.Controls.Add(this.title);
            this.Name = "A_stutent_report_perYear";
            this.Text = "A_stutent_report_perYear";
            this.Load += new System.EventHandler(this.A_stutent_report_perYear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backtpp_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox dep_naem;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox Year;
        private System.Windows.Forms.Label label1;
    }
}