namespace New
{
    partial class A_remove_Lecturer_DH
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
            this.button_BACK = new System.Windows.Forms.Button();
            this.button_SUBMIT = new System.Windows.Forms.Button();
            this.label_lecturerID = new System.Windows.Forms.Label();
            this.textBox_lecturerID = new System.Windows.Forms.TextBox();
            this.label_instructions = new System.Windows.Forms.Label();
            this.label_TITLE = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_BACK
            // 
            this.button_BACK.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button_BACK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button_BACK.Location = new System.Drawing.Point(427, 276);
            this.button_BACK.Name = "button_BACK";
            this.button_BACK.Size = new System.Drawing.Size(162, 52);
            this.button_BACK.TabIndex = 11;
            this.button_BACK.Text = "Back to previous page";
            this.button_BACK.UseVisualStyleBackColor = false;
            this.button_BACK.Click += new System.EventHandler(this.button_BACK_Click);
            // 
            // button_SUBMIT
            // 
            this.button_SUBMIT.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.button_SUBMIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button_SUBMIT.Location = new System.Drawing.Point(140, 277);
            this.button_SUBMIT.Name = "button_SUBMIT";
            this.button_SUBMIT.Size = new System.Drawing.Size(190, 48);
            this.button_SUBMIT.TabIndex = 10;
            this.button_SUBMIT.Text = "SUBMIT";
            this.button_SUBMIT.UseVisualStyleBackColor = false;
            this.button_SUBMIT.Click += new System.EventHandler(this.button_SUBMIT_Click);
            // 
            // label_lecturerID
            // 
            this.label_lecturerID.AutoSize = true;
            this.label_lecturerID.BackColor = System.Drawing.Color.Transparent;
            this.label_lecturerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_lecturerID.Location = new System.Drawing.Point(74, 164);
            this.label_lecturerID.Name = "label_lecturerID";
            this.label_lecturerID.Size = new System.Drawing.Size(112, 20);
            this.label_lecturerID.TabIndex = 9;
            this.label_lecturerID.Text = "Lecturer ID *";
            // 
            // textBox_lecturerID
            // 
            this.textBox_lecturerID.Location = new System.Drawing.Point(78, 187);
            this.textBox_lecturerID.Multiline = true;
            this.textBox_lecturerID.Name = "textBox_lecturerID";
            this.textBox_lecturerID.Size = new System.Drawing.Size(201, 28);
            this.textBox_lecturerID.TabIndex = 8;
            // 
            // label_instructions
            // 
            this.label_instructions.AutoSize = true;
            this.label_instructions.BackColor = System.Drawing.Color.Transparent;
            this.label_instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_instructions.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_instructions.Location = new System.Drawing.Point(74, 88);
            this.label_instructions.Name = "label_instructions";
            this.label_instructions.Size = new System.Drawing.Size(341, 48);
            this.label_instructions.TabIndex = 7;
            this.label_instructions.Text = "Please submit the ID of the Lecturer\r\nyou would like to remove:";
            // 
            // label_TITLE
            // 
            this.label_TITLE.AutoSize = true;
            this.label_TITLE.BackColor = System.Drawing.Color.Transparent;
            this.label_TITLE.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TITLE.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_TITLE.Location = new System.Drawing.Point(72, 34);
            this.label_TITLE.Name = "label_TITLE";
            this.label_TITLE.Size = new System.Drawing.Size(453, 31);
            this.label_TITLE.TabIndex = 6;
            this.label_TITLE.Text = "Remove Lecturer from the system";
            // 
            // A_remove_Lecturer_DH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::New.Properties.Resources.OS_X_Wallpaper;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(705, 372);
            this.Controls.Add(this.button_BACK);
            this.Controls.Add(this.button_SUBMIT);
            this.Controls.Add(this.label_lecturerID);
            this.Controls.Add(this.textBox_lecturerID);
            this.Controls.Add(this.label_instructions);
            this.Controls.Add(this.label_TITLE);
            this.Name = "A_remove_Lecturer_DH";
            this.Text = "A_remove_Lecturer_DH";
            this.Load += new System.EventHandler(this.A_remove_Lecturer_DH_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_BACK;
        private System.Windows.Forms.Button button_SUBMIT;
        private System.Windows.Forms.Label label_lecturerID;
        private System.Windows.Forms.TextBox textBox_lecturerID;
        private System.Windows.Forms.Label label_instructions;
        private System.Windows.Forms.Label label_TITLE;
    }
}