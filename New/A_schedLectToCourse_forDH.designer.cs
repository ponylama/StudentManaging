namespace New
{
    partial class A_schedLectToCourse_forDH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_schedLectToCourse_forDH));
            this.label_TITLE = new System.Windows.Forms.Label();
            this.label_instructions = new System.Windows.Forms.Label();
            this.label_courseID = new System.Windows.Forms.Label();
            this.label_lectID = new System.Windows.Forms.Label();
            this.textBox_courseID = new System.Windows.Forms.TextBox();
            this.textBox_lectID = new System.Windows.Forms.TextBox();
            this.button_SUBMIT = new System.Windows.Forms.Button();
            this.button_BACK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_TITLE
            // 
            this.label_TITLE.AutoSize = true;
            this.label_TITLE.BackColor = System.Drawing.Color.Transparent;
            this.label_TITLE.Font = new System.Drawing.Font("AR JULIAN", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TITLE.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_TITLE.Location = new System.Drawing.Point(68, 40);
            this.label_TITLE.Name = "label_TITLE";
            this.label_TITLE.Size = new System.Drawing.Size(563, 41);
            this.label_TITLE.TabIndex = 0;
            this.label_TITLE.Text = "Schedualing lecturer to course";
            // 
            // label_instructions
            // 
            this.label_instructions.AutoSize = true;
            this.label_instructions.BackColor = System.Drawing.Color.Transparent;
            this.label_instructions.Font = new System.Drawing.Font("AR JULIAN", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_instructions.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_instructions.Location = new System.Drawing.Point(91, 100);
            this.label_instructions.Name = "label_instructions";
            this.label_instructions.Size = new System.Drawing.Size(525, 23);
            this.label_instructions.TabIndex = 1;
            this.label_instructions.Text = "Please submit the course and lecturer who teaches";
            // 
            // label_courseID
            // 
            this.label_courseID.AutoSize = true;
            this.label_courseID.BackColor = System.Drawing.Color.Transparent;
            this.label_courseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_courseID.Location = new System.Drawing.Point(92, 172);
            this.label_courseID.Name = "label_courseID";
            this.label_courseID.Size = new System.Drawing.Size(99, 20);
            this.label_courseID.TabIndex = 2;
            this.label_courseID.Text = "course ID *";
            // 
            // label_lectID
            // 
            this.label_lectID.AutoSize = true;
            this.label_lectID.BackColor = System.Drawing.Color.Transparent;
            this.label_lectID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_lectID.Location = new System.Drawing.Point(318, 172);
            this.label_lectID.Name = "label_lectID";
            this.label_lectID.Size = new System.Drawing.Size(106, 20);
            this.label_lectID.TabIndex = 3;
            this.label_lectID.Text = "lecturer ID *";
            // 
            // textBox_courseID
            // 
            this.textBox_courseID.Location = new System.Drawing.Point(96, 204);
            this.textBox_courseID.Multiline = true;
            this.textBox_courseID.Name = "textBox_courseID";
            this.textBox_courseID.Size = new System.Drawing.Size(135, 26);
            this.textBox_courseID.TabIndex = 4;
            // 
            // textBox_lectID
            // 
            this.textBox_lectID.Location = new System.Drawing.Point(322, 204);
            this.textBox_lectID.Multiline = true;
            this.textBox_lectID.Name = "textBox_lectID";
            this.textBox_lectID.Size = new System.Drawing.Size(159, 26);
            this.textBox_lectID.TabIndex = 5;
            // 
            // button_SUBMIT
            // 
            this.button_SUBMIT.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.button_SUBMIT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_SUBMIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_SUBMIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button_SUBMIT.Location = new System.Drawing.Point(220, 272);
            this.button_SUBMIT.Name = "button_SUBMIT";
            this.button_SUBMIT.Size = new System.Drawing.Size(146, 34);
            this.button_SUBMIT.TabIndex = 6;
            this.button_SUBMIT.Text = "SUBMIT";
            this.button_SUBMIT.UseVisualStyleBackColor = false;
            this.button_SUBMIT.Click += new System.EventHandler(this.button_SUBMIT_Click);
            // 
            // button_BACK
            // 
            this.button_BACK.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_BACK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_BACK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_BACK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button_BACK.Location = new System.Drawing.Point(573, 326);
            this.button_BACK.Name = "button_BACK";
            this.button_BACK.Size = new System.Drawing.Size(136, 45);
            this.button_BACK.TabIndex = 7;
            this.button_BACK.Text = "Back to previous page";
            this.button_BACK.UseVisualStyleBackColor = false;
            this.button_BACK.Click += new System.EventHandler(this.button_BACK_Click);
            // 
            // A_schedLectToCourse_forDH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(753, 402);
            this.Controls.Add(this.button_BACK);
            this.Controls.Add(this.button_SUBMIT);
            this.Controls.Add(this.textBox_lectID);
            this.Controls.Add(this.textBox_courseID);
            this.Controls.Add(this.label_lectID);
            this.Controls.Add(this.label_courseID);
            this.Controls.Add(this.label_instructions);
            this.Controls.Add(this.label_TITLE);
            this.Name = "A_schedLectToCourse_forDH";
            this.Text = "A_schedLectToCourse_forDH";
            this.Load += new System.EventHandler(this.A_schedLectToCourse_forDH_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_TITLE;
        private System.Windows.Forms.Label label_instructions;
        private System.Windows.Forms.Label label_courseID;
        private System.Windows.Forms.Label label_lectID;
        private System.Windows.Forms.TextBox textBox_courseID;
        private System.Windows.Forms.TextBox textBox_lectID;
        private System.Windows.Forms.Button button_SUBMIT;
        private System.Windows.Forms.Button button_BACK;
    }
}