﻿namespace New
{
    partial class A_sched_lecturerDept_secretary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_sched_lecturerDept_secretary));
            this.label_TITLE = new System.Windows.Forms.Label();
            this.label_instructions = new System.Windows.Forms.Label();
            this.label_lecturerID = new System.Windows.Forms.Label();
            this.label_deptID = new System.Windows.Forms.Label();
            this.textBox_ForID = new System.Windows.Forms.TextBox();
            this.textBox_deptID = new System.Windows.Forms.TextBox();
            this.button_SUBMIT = new System.Windows.Forms.Button();
            this.button_BACK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_TITLE
            // 
            this.label_TITLE.AutoSize = true;
            this.label_TITLE.BackColor = System.Drawing.Color.Transparent;
            this.label_TITLE.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TITLE.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_TITLE.Location = new System.Drawing.Point(30, 22);
            this.label_TITLE.Name = "label_TITLE";
            this.label_TITLE.Size = new System.Drawing.Size(588, 37);
            this.label_TITLE.TabIndex = 0;
            this.label_TITLE.Text = "Schedualing department for lecturers ";
            // 
            // label_instructions
            // 
            this.label_instructions.AutoSize = true;
            this.label_instructions.BackColor = System.Drawing.Color.Transparent;
            this.label_instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_instructions.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_instructions.Location = new System.Drawing.Point(51, 80);
            this.label_instructions.Name = "label_instructions";
            this.label_instructions.Size = new System.Drawing.Size(371, 25);
            this.label_instructions.TabIndex = 1;
            this.label_instructions.Text = "Please submit the following fields:";
            // 
            // label_lecturerID
            // 
            this.label_lecturerID.AutoSize = true;
            this.label_lecturerID.BackColor = System.Drawing.Color.Transparent;
            this.label_lecturerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_lecturerID.Location = new System.Drawing.Point(52, 174);
            this.label_lecturerID.Name = "label_lecturerID";
            this.label_lecturerID.Size = new System.Drawing.Size(112, 20);
            this.label_lecturerID.TabIndex = 2;
            this.label_lecturerID.Text = "Lecturer ID *";
            // 
            // label_deptID
            // 
            this.label_deptID.AutoSize = true;
            this.label_deptID.BackColor = System.Drawing.Color.Transparent;
            this.label_deptID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_deptID.Location = new System.Drawing.Point(306, 174);
            this.label_deptID.Name = "label_deptID";
            this.label_deptID.Size = new System.Drawing.Size(209, 20);
            this.label_deptID.TabIndex = 3;
            this.label_deptID.Text = "Lecturer department ID *";
            // 
            // textBox_ForID
            // 
            this.textBox_ForID.Location = new System.Drawing.Point(56, 213);
            this.textBox_ForID.Multiline = true;
            this.textBox_ForID.Name = "textBox_ForID";
            this.textBox_ForID.Size = new System.Drawing.Size(176, 24);
            this.textBox_ForID.TabIndex = 4;
            // 
            // textBox_deptID
            // 
            this.textBox_deptID.Location = new System.Drawing.Point(304, 213);
            this.textBox_deptID.Multiline = true;
            this.textBox_deptID.Name = "textBox_deptID";
            this.textBox_deptID.Size = new System.Drawing.Size(211, 24);
            this.textBox_deptID.TabIndex = 5;
            // 
            // button_SUBMIT
            // 
            this.button_SUBMIT.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.button_SUBMIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button_SUBMIT.Location = new System.Drawing.Point(153, 273);
            this.button_SUBMIT.Name = "button_SUBMIT";
            this.button_SUBMIT.Size = new System.Drawing.Size(234, 41);
            this.button_SUBMIT.TabIndex = 6;
            this.button_SUBMIT.Text = "SUBMIT";
            this.button_SUBMIT.UseVisualStyleBackColor = false;
            this.button_SUBMIT.Click += new System.EventHandler(this.button_SUBMIT_Click);
            // 
            // button_BACK
            // 
            this.button_BACK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button_BACK.Location = new System.Drawing.Point(546, 311);
            this.button_BACK.Name = "button_BACK";
            this.button_BACK.Size = new System.Drawing.Size(157, 54);
            this.button_BACK.TabIndex = 7;
            this.button_BACK.Text = "Back to previous page";
            this.button_BACK.UseVisualStyleBackColor = true;
            this.button_BACK.Click += new System.EventHandler(this.button_BACK_Click);
            // 
            // A_sched_lecturerDept_secretary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(742, 387);
            this.Controls.Add(this.button_BACK);
            this.Controls.Add(this.button_SUBMIT);
            this.Controls.Add(this.textBox_deptID);
            this.Controls.Add(this.textBox_ForID);
            this.Controls.Add(this.label_deptID);
            this.Controls.Add(this.label_lecturerID);
            this.Controls.Add(this.label_instructions);
            this.Controls.Add(this.label_TITLE);
            this.Name = "A_sched_lecturerDept_secretary";
            this.Text = "A_sched_lecturerDept_secretary";
            this.Load += new System.EventHandler(this.A_sched_lecturerDept_secretary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_TITLE;
        private System.Windows.Forms.Label label_instructions;
        private System.Windows.Forms.Label label_lecturerID;
        private System.Windows.Forms.Label label_deptID;
        private System.Windows.Forms.TextBox textBox_ForID;
        private System.Windows.Forms.TextBox textBox_deptID;
        private System.Windows.Forms.Button button_SUBMIT;
        private System.Windows.Forms.Button button_BACK;
    }
}