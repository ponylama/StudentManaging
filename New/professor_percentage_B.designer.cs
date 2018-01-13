namespace New
{
    partial class professor_percentage_B
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
            this.PercentageBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cours_List_Box = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.id_list_Box = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PercentageBox
            // 
            this.PercentageBox.Location = new System.Drawing.Point(41, 228);
            this.PercentageBox.Margin = new System.Windows.Forms.Padding(1);
            this.PercentageBox.Multiline = true;
            this.PercentageBox.Name = "PercentageBox";
            this.PercentageBox.Size = new System.Drawing.Size(207, 51);
            this.PercentageBox.TabIndex = 6;
            this.PercentageBox.Text = "Percentage";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 148);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 52);
            this.button1.TabIndex = 4;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cours_List_Box
            // 
            this.cours_List_Box.FormattingEnabled = true;
            this.cours_List_Box.ItemHeight = 16;
            this.cours_List_Box.Location = new System.Drawing.Point(41, 37);
            this.cours_List_Box.Margin = new System.Windows.Forms.Padding(1);
            this.cours_List_Box.Name = "cours_List_Box";
            this.cours_List_Box.Size = new System.Drawing.Size(133, 52);
            this.cours_List_Box.TabIndex = 32;
            this.cours_List_Box.SelectedIndexChanged += new System.EventHandler(this.cours_List_Box_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 17);
            this.label1.TabIndex = 33;
            this.label1.Text = "Please choose cours from your courses";
            // 
            // id_list_Box
            // 
            this.id_list_Box.FormattingEnabled = true;
            this.id_list_Box.ItemHeight = 16;
            this.id_list_Box.Location = new System.Drawing.Point(41, 133);
            this.id_list_Box.Margin = new System.Windows.Forms.Padding(1);
            this.id_list_Box.Name = "id_list_Box";
            this.id_list_Box.Size = new System.Drawing.Size(133, 52);
            this.id_list_Box.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 17);
            this.label2.TabIndex = 35;
            this.label2.Text = "Please choose student from your course";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 198);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 17);
            this.label3.TabIndex = 36;
            this.label3.Text = "Please enter your Percentage";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(306, 257);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 37;
            this.button2.Text = "Hide";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // professor_percentage_B
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 292);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.id_list_Box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cours_List_Box);
            this.Controls.Add(this.PercentageBox);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "professor_percentage_B";
            this.Text = "professor_percentage_B";
            this.Load += new System.EventHandler(this.professor_percentage_B_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox PercentageBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox cours_List_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox id_list_Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
    }
}