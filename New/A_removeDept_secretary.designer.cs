namespace New
{
    partial class A_removeDept_secretary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_removeDept_secretary));
            this.label_TITLE = new System.Windows.Forms.Label();
            this.label_instructions = new System.Windows.Forms.Label();
            this.textBox_deptID = new System.Windows.Forms.TextBox();
            this.label_deptID = new System.Windows.Forms.Label();
            this.button_SUBMIT = new System.Windows.Forms.Button();
            this.button_BACK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_TITLE
            // 
            this.label_TITLE.AutoSize = true;
            this.label_TITLE.BackColor = System.Drawing.Color.Transparent;
            this.label_TITLE.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TITLE.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_TITLE.Location = new System.Drawing.Point(70, 30);
            this.label_TITLE.Name = "label_TITLE";
            this.label_TITLE.Size = new System.Drawing.Size(492, 31);
            this.label_TITLE.TabIndex = 0;
            this.label_TITLE.Text = "Remove department from the system";
            // 
            // label_instructions
            // 
            this.label_instructions.AutoSize = true;
            this.label_instructions.BackColor = System.Drawing.Color.Transparent;
            this.label_instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_instructions.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_instructions.Location = new System.Drawing.Point(55, 92);
            this.label_instructions.Name = "label_instructions";
            this.label_instructions.Size = new System.Drawing.Size(375, 48);
            this.label_instructions.TabIndex = 1;
            this.label_instructions.Text = "Please submit the ID of the department \r\nyou would like to remove:";
            // 
            // textBox_deptID
            // 
            this.textBox_deptID.Location = new System.Drawing.Point(69, 182);
            this.textBox_deptID.Multiline = true;
            this.textBox_deptID.Name = "textBox_deptID";
            this.textBox_deptID.Size = new System.Drawing.Size(201, 28);
            this.textBox_deptID.TabIndex = 2;
            // 
            // label_deptID
            // 
            this.label_deptID.AutoSize = true;
            this.label_deptID.BackColor = System.Drawing.Color.Transparent;
            this.label_deptID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_deptID.Location = new System.Drawing.Point(65, 159);
            this.label_deptID.Name = "label_deptID";
            this.label_deptID.Size = new System.Drawing.Size(140, 20);
            this.label_deptID.TabIndex = 3;
            this.label_deptID.Text = "Department ID *";
            // 
            // button_SUBMIT
            // 
            this.button_SUBMIT.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.button_SUBMIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button_SUBMIT.Location = new System.Drawing.Point(121, 281);
            this.button_SUBMIT.Name = "button_SUBMIT";
            this.button_SUBMIT.Size = new System.Drawing.Size(190, 48);
            this.button_SUBMIT.TabIndex = 4;
            this.button_SUBMIT.Text = "SUBMIT";
            this.button_SUBMIT.UseVisualStyleBackColor = false;
            this.button_SUBMIT.Click += new System.EventHandler(this.button_SUBMIT_Click);
            // 
            // button_BACK
            // 
            this.button_BACK.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button_BACK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button_BACK.Location = new System.Drawing.Point(450, 298);
            this.button_BACK.Name = "button_BACK";
            this.button_BACK.Size = new System.Drawing.Size(162, 52);
            this.button_BACK.TabIndex = 5;
            this.button_BACK.Text = "Back to previous page";
            this.button_BACK.UseVisualStyleBackColor = false;
            this.button_BACK.Click += new System.EventHandler(this.button_BACK_Click);
            // 
            // A_removeDept_secretary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(662, 375);
            this.Controls.Add(this.button_BACK);
            this.Controls.Add(this.button_SUBMIT);
            this.Controls.Add(this.label_deptID);
            this.Controls.Add(this.textBox_deptID);
            this.Controls.Add(this.label_instructions);
            this.Controls.Add(this.label_TITLE);
            this.Name = "A_removeDept_secretary";
            this.Text = "A_removeDept_secretary";
            this.Load += new System.EventHandler(this.A_removeDept_secretary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_TITLE;
        private System.Windows.Forms.Label label_instructions;
        private System.Windows.Forms.TextBox textBox_deptID;
        private System.Windows.Forms.Label label_deptID;
        private System.Windows.Forms.Button button_SUBMIT;
        private System.Windows.Forms.Button button_BACK;
    }
}