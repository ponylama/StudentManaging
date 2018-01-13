namespace New
{
    partial class sending_Personal_message_B
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sending_Personal_message_B));
            this.Please_Enter_Student_ID_label = new System.Windows.Forms.Label();
            this.ID_BOX = new System.Windows.Forms.TextBox();
            this.Message_Box = new System.Windows.Forms.TextBox();
            this.Please_Enter_Your_message_label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Hide_Button = new System.Windows.Forms.Button();
            this.Send_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Please_Enter_Student_ID_label
            // 
            this.Please_Enter_Student_ID_label.AutoSize = true;
            this.Please_Enter_Student_ID_label.BackColor = System.Drawing.SystemColors.Highlight;
            this.Please_Enter_Student_ID_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Please_Enter_Student_ID_label.Location = new System.Drawing.Point(12, 9);
            this.Please_Enter_Student_ID_label.Name = "Please_Enter_Student_ID_label";
            this.Please_Enter_Student_ID_label.Size = new System.Drawing.Size(164, 18);
            this.Please_Enter_Student_ID_label.TabIndex = 0;
            this.Please_Enter_Student_ID_label.Text = "Please Enter Student ID";
            // 
            // ID_BOX
            // 
            this.ID_BOX.Location = new System.Drawing.Point(182, 9);
            this.ID_BOX.Name = "ID_BOX";
            this.ID_BOX.Size = new System.Drawing.Size(139, 20);
            this.ID_BOX.TabIndex = 1;
            this.ID_BOX.TextChanged += new System.EventHandler(this.ID_BOX_TextChanged);
            // 
            // Message_Box
            // 
            this.Message_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message_Box.Location = new System.Drawing.Point(15, 63);
            this.Message_Box.Multiline = true;
            this.Message_Box.Name = "Message_Box";
            this.Message_Box.Size = new System.Drawing.Size(306, 118);
            this.Message_Box.TabIndex = 2;
            // 
            // Please_Enter_Your_message_label
            // 
            this.Please_Enter_Your_message_label.AutoSize = true;
            this.Please_Enter_Your_message_label.BackColor = System.Drawing.SystemColors.Highlight;
            this.Please_Enter_Your_message_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Please_Enter_Your_message_label.Location = new System.Drawing.Point(12, 42);
            this.Please_Enter_Your_message_label.Name = "Please_Enter_Your_message_label";
            this.Please_Enter_Your_message_label.Size = new System.Drawing.Size(196, 18);
            this.Please_Enter_Your_message_label.TabIndex = 3;
            this.Please_Enter_Your_message_label.Text = "Please enter your message :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-142, -167);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Hide_Button
            // 
            this.Hide_Button.Location = new System.Drawing.Point(15, 243);
            this.Hide_Button.Name = "Hide_Button";
            this.Hide_Button.Size = new System.Drawing.Size(75, 23);
            this.Hide_Button.TabIndex = 5;
            this.Hide_Button.Text = "Hide";
            this.Hide_Button.UseVisualStyleBackColor = true;
            this.Hide_Button.Click += new System.EventHandler(this.Hide_Button_Click);
            // 
            // Send_Button
            // 
            this.Send_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send_Button.Location = new System.Drawing.Point(123, 226);
            this.Send_Button.Name = "Send_Button";
            this.Send_Button.Size = new System.Drawing.Size(104, 40);
            this.Send_Button.TabIndex = 6;
            this.Send_Button.Text = "Send";
            this.Send_Button.UseVisualStyleBackColor = true;
            this.Send_Button.Click += new System.EventHandler(this.Send_Button_Click);
            // 
            // sending_Personal_message_B
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 278);
            this.Controls.Add(this.Send_Button);
            this.Controls.Add(this.Hide_Button);
            this.Controls.Add(this.Please_Enter_Your_message_label);
            this.Controls.Add(this.Message_Box);
            this.Controls.Add(this.ID_BOX);
            this.Controls.Add(this.Please_Enter_Student_ID_label);
            this.Controls.Add(this.pictureBox1);
            this.Name = "sending_Personal_message_B";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sending_Personal_message_B";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Please_Enter_Student_ID_label;
        private System.Windows.Forms.TextBox ID_BOX;
        private System.Windows.Forms.TextBox Message_Box;
        private System.Windows.Forms.Label Please_Enter_Your_message_label;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Hide_Button;
        private System.Windows.Forms.Button Send_Button;
    }
}