namespace New
{
    partial class A_queryTeachingAssistantSecretary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_queryTeachingAssistantSecretary));
            this.label1_tachingAssistant = new System.Windows.Forms.Label();
            this.label1_taID = new System.Windows.Forms.Label();
            this.button1_search = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1_backtpp = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1_tachingAssistant
            // 
            this.label1_tachingAssistant.AutoSize = true;
            this.label1_tachingAssistant.BackColor = System.Drawing.Color.Transparent;
            this.label1_tachingAssistant.Font = new System.Drawing.Font("AR JULIAN", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_tachingAssistant.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1_tachingAssistant.Location = new System.Drawing.Point(-4, 19);
            this.label1_tachingAssistant.Name = "label1_tachingAssistant";
            this.label1_tachingAssistant.Size = new System.Drawing.Size(590, 56);
            this.label1_tachingAssistant.TabIndex = 0;
            this.label1_tachingAssistant.Text = "Query Teaching Assistant";
            // 
            // label1_taID
            // 
            this.label1_taID.AutoSize = true;
            this.label1_taID.BackColor = System.Drawing.Color.Transparent;
            this.label1_taID.Font = new System.Drawing.Font("AR JULIAN", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_taID.Location = new System.Drawing.Point(42, 111);
            this.label1_taID.Name = "label1_taID";
            this.label1_taID.Size = new System.Drawing.Size(246, 25);
            this.label1_taID.TabIndex = 2;
            this.label1_taID.Text = "teaching assistant id : *";
            // 
            // button1_search
            // 
            this.button1_search.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1_search.BackgroundImage")));
            this.button1_search.Font = new System.Drawing.Font("AR JULIAN", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1_search.Location = new System.Drawing.Point(472, 109);
            this.button1_search.Name = "button1_search";
            this.button1_search.Size = new System.Drawing.Size(75, 34);
            this.button1_search.TabIndex = 4;
            this.button1_search.Text = "O.K";
            this.button1_search.UseVisualStyleBackColor = true;
            this.button1_search.Click += new System.EventHandler(this.button1_search_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(59, 179);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(466, 145);
            this.dataGridView1.TabIndex = 5;
            // 
            // button1_backtpp
            // 
            this.button1_backtpp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1_backtpp.BackgroundImage")));
            this.button1_backtpp.Font = new System.Drawing.Font("AR JULIAN", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1_backtpp.Location = new System.Drawing.Point(199, 358);
            this.button1_backtpp.Name = "button1_backtpp";
            this.button1_backtpp.Size = new System.Drawing.Size(188, 31);
            this.button1_backtpp.TabIndex = 6;
            this.button1_backtpp.Text = "back to previous page";
            this.button1_backtpp.UseVisualStyleBackColor = true;
            this.button1_backtpp.Click += new System.EventHandler(this.button1_backtpp_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(320, 117);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // A_queryTeachingAssistantSecretary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(589, 420);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1_backtpp);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1_search);
            this.Controls.Add(this.label1_taID);
            this.Controls.Add(this.label1_tachingAssistant);
            this.Name = "A_queryTeachingAssistantSecretary";
            this.Text = "A_queryTeachingAssistantSecretary";
            this.Load += new System.EventHandler(this.A_queryTeachingAssistantSecretary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1_tachingAssistant;
        private System.Windows.Forms.Label label1_taID;
        private System.Windows.Forms.Button button1_search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1_backtpp;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}