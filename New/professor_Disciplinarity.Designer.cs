namespace New
{
    partial class professor_Disciplinarity
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.id_list_Box = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cours_List_Box = new System.Windows.Forms.ListBox();
            this.Disciplinarity_box = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 213);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 17);
            this.label3.TabIndex = 49;
            this.label3.Text = "Please enter your Disciplinarity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 17);
            this.label2.TabIndex = 48;
            this.label2.Text = "Please choose student from your course";
            // 
            // id_list_Box
            // 
            this.id_list_Box.FormattingEnabled = true;
            this.id_list_Box.ItemHeight = 16;
            this.id_list_Box.Location = new System.Drawing.Point(69, 148);
            this.id_list_Box.Margin = new System.Windows.Forms.Padding(1);
            this.id_list_Box.Name = "id_list_Box";
            this.id_list_Box.Size = new System.Drawing.Size(133, 52);
            this.id_list_Box.TabIndex = 47;
            this.id_list_Box.SelectedIndexChanged += new System.EventHandler(this.id_list_Box_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 17);
            this.label1.TabIndex = 46;
            this.label1.Text = "Please choose cours from your courses";
            // 
            // cours_List_Box
            // 
            this.cours_List_Box.FormattingEnabled = true;
            this.cours_List_Box.ItemHeight = 16;
            this.cours_List_Box.Location = new System.Drawing.Point(69, 52);
            this.cours_List_Box.Margin = new System.Windows.Forms.Padding(1);
            this.cours_List_Box.Name = "cours_List_Box";
            this.cours_List_Box.Size = new System.Drawing.Size(133, 52);
            this.cours_List_Box.TabIndex = 45;
            this.cours_List_Box.SelectedIndexChanged += new System.EventHandler(this.cours_List_Box_SelectedIndexChanged);
            // 
            // Disciplinarity_box
            // 
            this.Disciplinarity_box.Location = new System.Drawing.Point(53, 249);
            this.Disciplinarity_box.Margin = new System.Windows.Forms.Padding(1);
            this.Disciplinarity_box.Multiline = true;
            this.Disciplinarity_box.Name = "Disciplinarity_box";
            this.Disciplinarity_box.Size = new System.Drawing.Size(245, 46);
            this.Disciplinarity_box.TabIndex = 44;
            this.Disciplinarity_box.Text = "Disciplinary";
            this.Disciplinarity_box.TextChanged += new System.EventHandler(this.Disciplinarity_box_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 52);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 52);
            this.button1.TabIndex = 43;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 429);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 50;
            this.button2.Text = "Hide";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // professor_Disciplinarity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 464);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.id_list_Box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cours_List_Box);
            this.Controls.Add(this.Disciplinarity_box);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "professor_Disciplinarity";
            this.Text = "professor_Disciplinarity";
            this.Load += new System.EventHandler(this.professor_Disciplinarity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox id_list_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox cours_List_Box;
        private System.Windows.Forms.TextBox Disciplinarity_box;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}