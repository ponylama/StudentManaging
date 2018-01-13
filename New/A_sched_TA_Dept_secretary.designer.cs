namespace New
{
    partial class A_sched_TA_Dept_secretary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_sched_TA_Dept_secretary));
            this.label_TITLE = new System.Windows.Forms.Label();
            this.label_instructions = new System.Windows.Forms.Label();
            this.label_TA_ID = new System.Windows.Forms.Label();
            this.label_DeptID = new System.Windows.Forms.Label();
            this.textBox_ForID = new System.Windows.Forms.TextBox();
            this.textBox_DeptID = new System.Windows.Forms.TextBox();
            this.button_SUBMIT = new System.Windows.Forms.Button();
            this.button_BACK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_TITLE
            // 
            this.label_TITLE.AutoSize = true;
            this.label_TITLE.BackColor = System.Drawing.Color.Transparent;
            this.label_TITLE.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TITLE.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_TITLE.Location = new System.Drawing.Point(51, 29);
            this.label_TITLE.Name = "label_TITLE";
            this.label_TITLE.Size = new System.Drawing.Size(614, 33);
            this.label_TITLE.TabIndex = 0;
            this.label_TITLE.Text = "Schedual department for Teaching Assitant";
            // 
            // label_instructions
            // 
            this.label_instructions.AutoSize = true;
            this.label_instructions.BackColor = System.Drawing.Color.Transparent;
            this.label_instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_instructions.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_instructions.Location = new System.Drawing.Point(75, 88);
            this.label_instructions.Name = "label_instructions";
            this.label_instructions.Size = new System.Drawing.Size(371, 25);
            this.label_instructions.TabIndex = 1;
            this.label_instructions.Text = "Please submit the following fields:";
            // 
            // label_TA_ID
            // 
            this.label_TA_ID.AutoSize = true;
            this.label_TA_ID.BackColor = System.Drawing.Color.Transparent;
            this.label_TA_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_TA_ID.Location = new System.Drawing.Point(80, 153);
            this.label_TA_ID.Name = "label_TA_ID";
            this.label_TA_ID.Size = new System.Drawing.Size(189, 20);
            this.label_TA_ID.TabIndex = 2;
            this.label_TA_ID.Text = "Teaching Assitant ID *";
            // 
            // label_DeptID
            // 
            this.label_DeptID.AutoSize = true;
            this.label_DeptID.BackColor = System.Drawing.Color.Transparent;
            this.label_DeptID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_DeptID.Location = new System.Drawing.Point(334, 153);
            this.label_DeptID.Name = "label_DeptID";
            this.label_DeptID.Size = new System.Drawing.Size(140, 20);
            this.label_DeptID.TabIndex = 3;
            this.label_DeptID.Text = "Department ID *";
            // 
            // textBox_ForID
            // 
            this.textBox_ForID.Location = new System.Drawing.Point(84, 194);
            this.textBox_ForID.Multiline = true;
            this.textBox_ForID.Name = "textBox_ForID";
            this.textBox_ForID.Size = new System.Drawing.Size(185, 24);
            this.textBox_ForID.TabIndex = 4;
            // 
            // textBox_DeptID
            // 
            this.textBox_DeptID.Location = new System.Drawing.Point(338, 194);
            this.textBox_DeptID.Multiline = true;
            this.textBox_DeptID.Name = "textBox_DeptID";
            this.textBox_DeptID.Size = new System.Drawing.Size(198, 24);
            this.textBox_DeptID.TabIndex = 5;
            // 
            // button_SUBMIT
            // 
            this.button_SUBMIT.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.button_SUBMIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button_SUBMIT.Location = new System.Drawing.Point(219, 258);
            this.button_SUBMIT.Name = "button_SUBMIT";
            this.button_SUBMIT.Size = new System.Drawing.Size(175, 44);
            this.button_SUBMIT.TabIndex = 6;
            this.button_SUBMIT.Text = "SUBMIT";
            this.button_SUBMIT.UseVisualStyleBackColor = false;
            this.button_SUBMIT.Click += new System.EventHandler(this.button_SUBMIT_Click);
            // 
            // button_BACK
            // 
            this.button_BACK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button_BACK.Location = new System.Drawing.Point(607, 308);
            this.button_BACK.Name = "button_BACK";
            this.button_BACK.Size = new System.Drawing.Size(169, 55);
            this.button_BACK.TabIndex = 7;
            this.button_BACK.Text = "Back to previous page";
            this.button_BACK.UseVisualStyleBackColor = true;
            this.button_BACK.Click += new System.EventHandler(this.button_BACK_Click);
            // 
            // A_sched_TA_Dept_secretary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(810, 385);
            this.Controls.Add(this.button_BACK);
            this.Controls.Add(this.button_SUBMIT);
            this.Controls.Add(this.textBox_DeptID);
            this.Controls.Add(this.textBox_ForID);
            this.Controls.Add(this.label_DeptID);
            this.Controls.Add(this.label_TA_ID);
            this.Controls.Add(this.label_instructions);
            this.Controls.Add(this.label_TITLE);
            this.Name = "A_sched_TA_Dept_secretary";
            this.Text = "A_sched_TA_Dept_secretary";
            this.Load += new System.EventHandler(this.A_sched_TA_Dept_secretary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_TITLE;
        private System.Windows.Forms.Label label_instructions;
        private System.Windows.Forms.Label label_TA_ID;
        private System.Windows.Forms.Label label_DeptID;
        private System.Windows.Forms.TextBox textBox_ForID;
        private System.Windows.Forms.TextBox textBox_DeptID;
        private System.Windows.Forms.Button button_SUBMIT;
        private System.Windows.Forms.Button button_BACK;
    }
}