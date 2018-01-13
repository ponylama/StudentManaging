namespace New
{
    partial class A_ScaduilngClassForExam_Secretary
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
            this.label_ClassNumber = new System.Windows.Forms.Label();
            this.label_ExamNumber = new System.Windows.Forms.Label();
            this.button_SUBMIT = new System.Windows.Forms.Button();
            this.button_BACK = new System.Windows.Forms.Button();
            this.label_TITLE = new System.Windows.Forms.Label();
            this.label_instructions = new System.Windows.Forms.Label();
            this.label1__houreText = new System.Windows.Forms.Label();
            this.comboBox1_examName = new System.Windows.Forms.ComboBox();
            this.comboBox2_ClassNum = new System.Windows.Forms.ComboBox();
            this.comboBox3_examHour = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label_ClassNumber
            // 
            this.label_ClassNumber.AutoSize = true;
            this.label_ClassNumber.BackColor = System.Drawing.Color.Transparent;
            this.label_ClassNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_ClassNumber.Location = new System.Drawing.Point(3, 211);
            this.label_ClassNumber.Name = "label_ClassNumber";
            this.label_ClassNumber.Size = new System.Drawing.Size(132, 20);
            this.label_ClassNumber.TabIndex = 3;
            this.label_ClassNumber.Text = "Class Number *";
            // 
            // label_ExamNumber
            // 
            this.label_ExamNumber.AutoSize = true;
            this.label_ExamNumber.BackColor = System.Drawing.Color.Transparent;
            this.label_ExamNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_ExamNumber.Location = new System.Drawing.Point(12, 161);
            this.label_ExamNumber.Name = "label_ExamNumber";
            this.label_ExamNumber.Size = new System.Drawing.Size(116, 20);
            this.label_ExamNumber.TabIndex = 4;
            this.label_ExamNumber.Text = "Exam Name *";
            // 
            // button_SUBMIT
            // 
            this.button_SUBMIT.BackColor = System.Drawing.SystemColors.Control;
            this.button_SUBMIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button_SUBMIT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_SUBMIT.Location = new System.Drawing.Point(147, 326);
            this.button_SUBMIT.Name = "button_SUBMIT";
            this.button_SUBMIT.Size = new System.Drawing.Size(234, 41);
            this.button_SUBMIT.TabIndex = 7;
            this.button_SUBMIT.Text = "SUBMIT";
            this.button_SUBMIT.UseVisualStyleBackColor = false;
            this.button_SUBMIT.Click += new System.EventHandler(this.button_SUBMIT_Click);
            // 
            // button_BACK
            // 
            this.button_BACK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button_BACK.Location = new System.Drawing.Point(477, 346);
            this.button_BACK.Name = "button_BACK";
            this.button_BACK.Size = new System.Drawing.Size(157, 54);
            this.button_BACK.TabIndex = 8;
            this.button_BACK.Text = "Back to previous page";
            this.button_BACK.UseVisualStyleBackColor = true;
            this.button_BACK.Click += new System.EventHandler(this.button_BACK_Click);
            // 
            // label_TITLE
            // 
            this.label_TITLE.AutoSize = true;
            this.label_TITLE.BackColor = System.Drawing.Color.Transparent;
            this.label_TITLE.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TITLE.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_TITLE.Location = new System.Drawing.Point(39, 36);
            this.label_TITLE.Name = "label_TITLE";
            this.label_TITLE.Size = new System.Drawing.Size(538, 37);
            this.label_TITLE.TabIndex = 9;
            this.label_TITLE.Text = "Schedualing Classes For Exams...";
            // 
            // label_instructions
            // 
            this.label_instructions.AutoSize = true;
            this.label_instructions.BackColor = System.Drawing.Color.Transparent;
            this.label_instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_instructions.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_instructions.Location = new System.Drawing.Point(53, 97);
            this.label_instructions.Name = "label_instructions";
            this.label_instructions.Size = new System.Drawing.Size(371, 25);
            this.label_instructions.TabIndex = 10;
            this.label_instructions.Text = "Please submit the following fields:";
            // 
            // label1__houreText
            // 
            this.label1__houreText.AutoSize = true;
            this.label1__houreText.BackColor = System.Drawing.Color.Transparent;
            this.label1__houreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1__houreText.Location = new System.Drawing.Point(12, 262);
            this.label1__houreText.Name = "label1__houreText";
            this.label1__houreText.Size = new System.Drawing.Size(109, 20);
            this.label1__houreText.TabIndex = 12;
            this.label1__houreText.Text = "Exam Hour *";
            // 
            // comboBox1_examName
            // 
            this.comboBox1_examName.FormattingEnabled = true;
            this.comboBox1_examName.Location = new System.Drawing.Point(166, 163);
            this.comboBox1_examName.Name = "comboBox1_examName";
            this.comboBox1_examName.Size = new System.Drawing.Size(149, 21);
            this.comboBox1_examName.TabIndex = 13;
            // 
            // comboBox2_ClassNum
            // 
            this.comboBox2_ClassNum.FormattingEnabled = true;
            this.comboBox2_ClassNum.Location = new System.Drawing.Point(166, 213);
            this.comboBox2_ClassNum.Name = "comboBox2_ClassNum";
            this.comboBox2_ClassNum.Size = new System.Drawing.Size(149, 21);
            this.comboBox2_ClassNum.TabIndex = 14;
            // 
            // comboBox3_examHour
            // 
            this.comboBox3_examHour.FormattingEnabled = true;
            this.comboBox3_examHour.Items.AddRange(new object[] {
            "9",
            "13",
            "18"});
            this.comboBox3_examHour.Location = new System.Drawing.Point(166, 264);
            this.comboBox3_examHour.Name = "comboBox3_examHour";
            this.comboBox3_examHour.Size = new System.Drawing.Size(149, 21);
            this.comboBox3_examHour.TabIndex = 15;
            // 
            // A_ScaduilngClassForExam_Secretary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::New.Properties.Resources.OS_X_Wallpaper;
            this.ClientSize = new System.Drawing.Size(763, 412);
            this.Controls.Add(this.comboBox3_examHour);
            this.Controls.Add(this.comboBox2_ClassNum);
            this.Controls.Add(this.comboBox1_examName);
            this.Controls.Add(this.label1__houreText);
            this.Controls.Add(this.label_instructions);
            this.Controls.Add(this.label_TITLE);
            this.Controls.Add(this.button_BACK);
            this.Controls.Add(this.button_SUBMIT);
            this.Controls.Add(this.label_ExamNumber);
            this.Controls.Add(this.label_ClassNumber);
            this.Name = "A_ScaduilngClassForExam_Secretary";
            this.Text = "A_ScaduilngClassForExam_Secretarycs";
            this.Load += new System.EventHandler(this.A_ScaduilngClassForExam_Secretary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ClassNumber;
        private System.Windows.Forms.Label label_ExamNumber;
        private System.Windows.Forms.Button button_SUBMIT;
        private System.Windows.Forms.Button button_BACK;
        private System.Windows.Forms.Label label_TITLE;
        private System.Windows.Forms.Label label_instructions;
        private System.Windows.Forms.Label label1__houreText;
        private System.Windows.Forms.ComboBox comboBox1_examName;
        private System.Windows.Forms.ComboBox comboBox2_ClassNum;
        private System.Windows.Forms.ComboBox comboBox3_examHour;
    }
}