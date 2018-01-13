namespace New
{
    partial class A_viewReportHoursOf_TA_forDH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_viewReportHoursOf_TA_forDH));
            this.label_TITLE = new System.Windows.Forms.Label();
            this.label_deptID = new System.Windows.Forms.Label();
            this.label_month = new System.Windows.Forms.Label();
            this.label_year = new System.Windows.Forms.Label();
            this.textBox_deptID = new System.Windows.Forms.TextBox();
            this.numericUpDown_month = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_year = new System.Windows.Forms.NumericUpDown();
            this.button_view = new System.Windows.Forms.Button();
            this.dataGridView_staffHoursTable = new System.Windows.Forms.DataGridView();
            this.button_BACK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_month)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_staffHoursTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label_TITLE
            // 
            this.label_TITLE.AutoSize = true;
            this.label_TITLE.BackColor = System.Drawing.Color.Transparent;
            this.label_TITLE.Font = new System.Drawing.Font("AR JULIAN", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TITLE.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_TITLE.Location = new System.Drawing.Point(176, 37);
            this.label_TITLE.Name = "label_TITLE";
            this.label_TITLE.Size = new System.Drawing.Size(335, 38);
            this.label_TITLE.TabIndex = 0;
            this.label_TITLE.Text = "Hours report of TA";
            // 
            // label_deptID
            // 
            this.label_deptID.AutoSize = true;
            this.label_deptID.BackColor = System.Drawing.Color.Transparent;
            this.label_deptID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_deptID.Location = new System.Drawing.Point(60, 114);
            this.label_deptID.Name = "label_deptID";
            this.label_deptID.Size = new System.Drawing.Size(137, 20);
            this.label_deptID.TabIndex = 1;
            this.label_deptID.Text = "department ID *";
            // 
            // label_month
            // 
            this.label_month.AutoSize = true;
            this.label_month.BackColor = System.Drawing.Color.Transparent;
            this.label_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_month.Location = new System.Drawing.Point(238, 114);
            this.label_month.Name = "label_month";
            this.label_month.Size = new System.Drawing.Size(76, 20);
            this.label_month.TabIndex = 2;
            this.label_month.Text = "month  *";
            // 
            // label_year
            // 
            this.label_year.AutoSize = true;
            this.label_year.BackColor = System.Drawing.Color.Transparent;
            this.label_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_year.Location = new System.Drawing.Point(358, 114);
            this.label_year.Name = "label_year";
            this.label_year.Size = new System.Drawing.Size(55, 20);
            this.label_year.TabIndex = 3;
            this.label_year.Text = "year *";
            // 
            // textBox_deptID
            // 
            this.textBox_deptID.Location = new System.Drawing.Point(54, 142);
            this.textBox_deptID.Multiline = true;
            this.textBox_deptID.Name = "textBox_deptID";
            this.textBox_deptID.Size = new System.Drawing.Size(143, 25);
            this.textBox_deptID.TabIndex = 4;
            // 
            // numericUpDown_month
            // 
            this.numericUpDown_month.Location = new System.Drawing.Point(229, 143);
            this.numericUpDown_month.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown_month.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_month.Name = "numericUpDown_month";
            this.numericUpDown_month.Size = new System.Drawing.Size(85, 20);
            this.numericUpDown_month.TabIndex = 5;
            this.numericUpDown_month.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_year
            // 
            this.numericUpDown_year.Location = new System.Drawing.Point(351, 143);
            this.numericUpDown_year.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numericUpDown_year.Minimum = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.numericUpDown_year.Name = "numericUpDown_year";
            this.numericUpDown_year.Size = new System.Drawing.Size(109, 20);
            this.numericUpDown_year.TabIndex = 6;
            this.numericUpDown_year.Value = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            // 
            // button_view
            // 
            this.button_view.BackColor = System.Drawing.Color.Wheat;
            this.button_view.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_view.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_view.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button_view.Location = new System.Drawing.Point(501, 134);
            this.button_view.Name = "button_view";
            this.button_view.Size = new System.Drawing.Size(109, 34);
            this.button_view.TabIndex = 7;
            this.button_view.Text = "view report";
            this.button_view.UseVisualStyleBackColor = false;
            this.button_view.Click += new System.EventHandler(this.button_view_Click);
            // 
            // dataGridView_staffHoursTable
            // 
            this.dataGridView_staffHoursTable.AllowUserToAddRows = false;
            this.dataGridView_staffHoursTable.AllowUserToDeleteRows = false;
            this.dataGridView_staffHoursTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_staffHoursTable.Location = new System.Drawing.Point(45, 216);
            this.dataGridView_staffHoursTable.Name = "dataGridView_staffHoursTable";
            this.dataGridView_staffHoursTable.ReadOnly = true;
            this.dataGridView_staffHoursTable.Size = new System.Drawing.Size(545, 174);
            this.dataGridView_staffHoursTable.TabIndex = 8;
            // 
            // button_BACK
            // 
            this.button_BACK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button_BACK.Location = new System.Drawing.Point(630, 312);
            this.button_BACK.Name = "button_BACK";
            this.button_BACK.Size = new System.Drawing.Size(129, 43);
            this.button_BACK.TabIndex = 9;
            this.button_BACK.Text = "Back to previous page";
            this.button_BACK.UseVisualStyleBackColor = true;
            this.button_BACK.Click += new System.EventHandler(this.button_BACK_Click);
            // 
            // A_viewReportHoursOf_TA_forDH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(797, 412);
            this.Controls.Add(this.button_BACK);
            this.Controls.Add(this.dataGridView_staffHoursTable);
            this.Controls.Add(this.button_view);
            this.Controls.Add(this.numericUpDown_year);
            this.Controls.Add(this.numericUpDown_month);
            this.Controls.Add(this.textBox_deptID);
            this.Controls.Add(this.label_year);
            this.Controls.Add(this.label_month);
            this.Controls.Add(this.label_deptID);
            this.Controls.Add(this.label_TITLE);
            this.Name = "A_viewReportHoursOf_TA_forDH";
            this.Text = "A_viewReportHoursOf_TA_forDH";
            this.Load += new System.EventHandler(this.A_viewReportHoursOf_TA_forDH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_month)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_staffHoursTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_TITLE;
        private System.Windows.Forms.Label label_deptID;
        private System.Windows.Forms.Label label_month;
        private System.Windows.Forms.Label label_year;
        private System.Windows.Forms.TextBox textBox_deptID;
        private System.Windows.Forms.NumericUpDown numericUpDown_month;
        private System.Windows.Forms.NumericUpDown numericUpDown_year;
        private System.Windows.Forms.Button button_view;
        private System.Windows.Forms.DataGridView dataGridView_staffHoursTable;
        private System.Windows.Forms.Button button_BACK;
    }
}