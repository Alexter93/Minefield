namespace MinefieldV2
{
    partial class frmHighScores
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
            this.btnEraseScores = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblPlaces1 = new System.Windows.Forms.Label();
            this.lblNormTimes = new System.Windows.Forms.Label();
            this.lblNormNames = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblSkilTimes = new System.Windows.Forms.Label();
            this.lblSkilNames = new System.Windows.Forms.Label();
            this.lblPlaces2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblMastTimes = new System.Windows.Forms.Label();
            this.lblMastNames = new System.Windows.Forms.Label();
            this.lblPlaces3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEraseScores
            // 
            this.btnEraseScores.Location = new System.Drawing.Point(12, 247);
            this.btnEraseScores.Name = "btnEraseScores";
            this.btnEraseScores.Size = new System.Drawing.Size(128, 23);
            this.btnEraseScores.TabIndex = 15;
            this.btnEraseScores.Text = "Erase Score Data";
            this.btnEraseScores.UseVisualStyleBackColor = true;
            this.btnEraseScores.Click += new System.EventHandler(this.btnEraseScores_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(142, 247);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(128, 23);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(258, 229);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblPlaces1);
            this.tabPage1.Controls.Add(this.lblNormTimes);
            this.tabPage1.Controls.Add(this.lblNormNames);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(250, 200);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Normal";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblPlaces1
            // 
            this.lblPlaces1.AutoSize = true;
            this.lblPlaces1.Location = new System.Drawing.Point(6, 12);
            this.lblPlaces1.Name = "lblPlaces1";
            this.lblPlaces1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPlaces1.Size = new System.Drawing.Size(29, 170);
            this.lblPlaces1.TabIndex = 5;
            this.lblPlaces1.Text = "1)\r\n2)\r\n3)\r\n4)\r\n5)\r\n6)\r\n7)\r\n8)\r\n9)\r\n10)\r\n";
            // 
            // lblNormTimes
            // 
            this.lblNormTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNormTimes.AutoSize = true;
            this.lblNormTimes.Location = new System.Drawing.Point(206, 12);
            this.lblNormTimes.Name = "lblNormTimes";
            this.lblNormTimes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNormTimes.Size = new System.Drawing.Size(19, 85);
            this.lblNormTimes.TabIndex = 4;
            this.lblNormTimes.Text = "T\r\nI\r\nM\r\nE\r\nS";
            this.lblNormTimes.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblNormNames
            // 
            this.lblNormNames.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNormNames.AutoSize = true;
            this.lblNormNames.Location = new System.Drawing.Point(84, 12);
            this.lblNormNames.Name = "lblNormNames";
            this.lblNormNames.Size = new System.Drawing.Size(19, 85);
            this.lblNormNames.TabIndex = 6;
            this.lblNormNames.Text = "N\r\nA\r\nM\r\nE\r\nS";
            this.lblNormNames.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblSkilTimes);
            this.tabPage2.Controls.Add(this.lblSkilNames);
            this.tabPage2.Controls.Add(this.lblPlaces2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(250, 200);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Skilled";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblSkilTimes
            // 
            this.lblSkilTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSkilTimes.AutoSize = true;
            this.lblSkilTimes.Location = new System.Drawing.Point(206, 12);
            this.lblSkilTimes.Name = "lblSkilTimes";
            this.lblSkilTimes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSkilTimes.Size = new System.Drawing.Size(19, 85);
            this.lblSkilTimes.TabIndex = 7;
            this.lblSkilTimes.Text = "T\r\nI\r\nM\r\nE\r\nS";
            this.lblSkilTimes.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSkilNames
            // 
            this.lblSkilNames.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSkilNames.AutoSize = true;
            this.lblSkilNames.Location = new System.Drawing.Point(84, 12);
            this.lblSkilNames.Name = "lblSkilNames";
            this.lblSkilNames.Size = new System.Drawing.Size(19, 85);
            this.lblSkilNames.TabIndex = 8;
            this.lblSkilNames.Text = "N\r\nA\r\nM\r\nE\r\nS";
            this.lblSkilNames.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPlaces2
            // 
            this.lblPlaces2.AutoSize = true;
            this.lblPlaces2.Location = new System.Drawing.Point(6, 12);
            this.lblPlaces2.Name = "lblPlaces2";
            this.lblPlaces2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPlaces2.Size = new System.Drawing.Size(29, 170);
            this.lblPlaces2.TabIndex = 6;
            this.lblPlaces2.Text = "1)\r\n2)\r\n3)\r\n4)\r\n5)\r\n6)\r\n7)\r\n8)\r\n9)\r\n10)\r\n";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblMastTimes);
            this.tabPage3.Controls.Add(this.lblMastNames);
            this.tabPage3.Controls.Add(this.lblPlaces3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(250, 200);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Master";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblMastTimes
            // 
            this.lblMastTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMastTimes.AutoSize = true;
            this.lblMastTimes.Location = new System.Drawing.Point(206, 12);
            this.lblMastTimes.Name = "lblMastTimes";
            this.lblMastTimes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMastTimes.Size = new System.Drawing.Size(19, 85);
            this.lblMastTimes.TabIndex = 9;
            this.lblMastTimes.Text = "T\r\nI\r\nM\r\nE\r\nS";
            this.lblMastTimes.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMastNames
            // 
            this.lblMastNames.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMastNames.AutoSize = true;
            this.lblMastNames.Location = new System.Drawing.Point(84, 12);
            this.lblMastNames.Name = "lblMastNames";
            this.lblMastNames.Size = new System.Drawing.Size(19, 85);
            this.lblMastNames.TabIndex = 10;
            this.lblMastNames.Text = "N\r\nA\r\nM\r\nE\r\nS";
            this.lblMastNames.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPlaces3
            // 
            this.lblPlaces3.AutoSize = true;
            this.lblPlaces3.Location = new System.Drawing.Point(6, 12);
            this.lblPlaces3.Name = "lblPlaces3";
            this.lblPlaces3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPlaces3.Size = new System.Drawing.Size(29, 170);
            this.lblPlaces3.TabIndex = 7;
            this.lblPlaces3.Text = "1)\r\n2)\r\n3)\r\n4)\r\n5)\r\n6)\r\n7)\r\n8)\r\n9)\r\n10)\r\n";
            // 
            // frmHighScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 282);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnEraseScores);
            this.Name = "frmHighScores";
            this.Text = "Minefield";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnEraseScores;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblPlaces1;
        private System.Windows.Forms.Label lblNormTimes;
        private System.Windows.Forms.Label lblNormNames;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblPlaces2;
        private System.Windows.Forms.Label lblPlaces3;
        private System.Windows.Forms.Label lblSkilTimes;
        private System.Windows.Forms.Label lblSkilNames;
        private System.Windows.Forms.Label lblMastTimes;
        private System.Windows.Forms.Label lblMastNames;
    }
}