namespace New
{
    partial class A_TeachingAssistant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_TeachingAssistant));
            this.label1 = new System.Windows.Forms.Label();
            this.viewArrangment = new System.Windows.Forms.Button();
            this.insertionWork = new System.Windows.Forms.Button();
            this.BACKtpp = new System.Windows.Forms.Button();
            this.LOGOUT = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(166, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 42);
            this.label1.TabIndex = 6;
            this.label1.Text = "Welcome";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // viewArrangment
            // 
            this.viewArrangment.BackColor = System.Drawing.Color.Transparent;
            this.viewArrangment.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("viewArrangment.BackgroundImage")));
            this.viewArrangment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewArrangment.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.viewArrangment.Location = new System.Drawing.Point(87, 113);
            this.viewArrangment.Name = "viewArrangment";
            this.viewArrangment.Size = new System.Drawing.Size(331, 44);
            this.viewArrangment.TabIndex = 7;
            this.viewArrangment.Text = "View arrangment of my lessons";
            this.viewArrangment.UseVisualStyleBackColor = false;
            this.viewArrangment.Click += new System.EventHandler(this.viewArrangment_Click);
            // 
            // insertionWork
            // 
            this.insertionWork.BackColor = System.Drawing.Color.Transparent;
            this.insertionWork.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("insertionWork.BackgroundImage")));
            this.insertionWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertionWork.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.insertionWork.Location = new System.Drawing.Point(87, 186);
            this.insertionWork.Name = "insertionWork";
            this.insertionWork.Size = new System.Drawing.Size(331, 44);
            this.insertionWork.TabIndex = 8;
            this.insertionWork.Text = "Insetrion work hours";
            this.insertionWork.UseVisualStyleBackColor = false;
            this.insertionWork.Click += new System.EventHandler(this.insertionWork_Click);
            // 
            // BACKtpp
            // 
            this.BACKtpp.BackColor = System.Drawing.Color.Transparent;
            this.BACKtpp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BACKtpp.BackgroundImage")));
            this.BACKtpp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BACKtpp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BACKtpp.Location = new System.Drawing.Point(87, 262);
            this.BACKtpp.Name = "BACKtpp";
            this.BACKtpp.Size = new System.Drawing.Size(331, 45);
            this.BACKtpp.TabIndex = 9;
            this.BACKtpp.Text = "Back to previous page";
            this.BACKtpp.UseVisualStyleBackColor = false;
            this.BACKtpp.Click += new System.EventHandler(this.BACKtpp_Click);
            // 
            // LOGOUT
            // 
            this.LOGOUT.BackColor = System.Drawing.Color.Transparent;
            this.LOGOUT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LOGOUT.BackgroundImage")));
            this.LOGOUT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LOGOUT.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LOGOUT.Location = new System.Drawing.Point(87, 340);
            this.LOGOUT.Name = "LOGOUT";
            this.LOGOUT.Size = new System.Drawing.Size(331, 44);
            this.LOGOUT.TabIndex = 10;
            this.LOGOUT.Text = "Log out";
            this.LOGOUT.UseVisualStyleBackColor = false;
            this.LOGOUT.Click += new System.EventHandler(this.LOGOUT_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(708, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Teaching Assistant Menu";
            // 
            // A_TeachingAssistant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(957, 459);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LOGOUT);
            this.Controls.Add(this.BACKtpp);
            this.Controls.Add(this.insertionWork);
            this.Controls.Add(this.viewArrangment);
            this.Controls.Add(this.label1);
            this.Name = "A_TeachingAssistant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teaching Assistant menu";
            this.Load += new System.EventHandler(this.A_TeachingAssistant_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button viewArrangment;
        private System.Windows.Forms.Button insertionWork;
        private System.Windows.Forms.Button BACKtpp;
        private System.Windows.Forms.Button LOGOUT;
        private System.Windows.Forms.Label label2;
    }
}