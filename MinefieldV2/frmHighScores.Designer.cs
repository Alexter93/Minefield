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
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnSkilled = new System.Windows.Forms.Button();
            this.btnMaster = new System.Windows.Forms.Button();
            this.lblTimes = new System.Windows.Forms.Label();
            this.grpScores = new System.Windows.Forms.GroupBox();
            this.lblNames = new System.Windows.Forms.Label();
            this.lblPlaces = new System.Windows.Forms.Label();
            this.btnEraseScores = new System.Windows.Forms.Button();
            this.grpScores.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNormal
            // 
            this.btnNormal.Enabled = false;
            this.btnNormal.Location = new System.Drawing.Point(12, 12);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(75, 23);
            this.btnNormal.TabIndex = 0;
            this.btnNormal.Text = "Normal";
            this.btnNormal.UseVisualStyleBackColor = true;
            // 
            // btnSkilled
            // 
            this.btnSkilled.Enabled = false;
            this.btnSkilled.Location = new System.Drawing.Point(102, 12);
            this.btnSkilled.Name = "btnSkilled";
            this.btnSkilled.Size = new System.Drawing.Size(75, 23);
            this.btnSkilled.TabIndex = 1;
            this.btnSkilled.Text = "Skilled";
            this.btnSkilled.UseVisualStyleBackColor = true;
            // 
            // btnMaster
            // 
            this.btnMaster.Enabled = false;
            this.btnMaster.Location = new System.Drawing.Point(195, 12);
            this.btnMaster.Name = "btnMaster";
            this.btnMaster.Size = new System.Drawing.Size(75, 23);
            this.btnMaster.TabIndex = 2;
            this.btnMaster.Text = "Master";
            this.btnMaster.UseVisualStyleBackColor = true;
            // 
            // lblTimes
            // 
            this.lblTimes.AutoSize = true;
            this.lblTimes.Location = new System.Drawing.Point(203, 18);
            this.lblTimes.Name = "lblTimes";
            this.lblTimes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTimes.Size = new System.Drawing.Size(49, 17);
            this.lblTimes.TabIndex = 4;
            this.lblTimes.Text = "TIMES";
            // 
            // grpScores
            // 
            this.grpScores.Controls.Add(this.lblNames);
            this.grpScores.Controls.Add(this.lblPlaces);
            this.grpScores.Controls.Add(this.lblTimes);
            this.grpScores.Location = new System.Drawing.Point(12, 41);
            this.grpScores.Name = "grpScores";
            this.grpScores.Size = new System.Drawing.Size(258, 200);
            this.grpScores.TabIndex = 14;
            this.grpScores.TabStop = false;
            this.grpScores.Text = "High Scores:";
            // 
            // lblNames
            // 
            this.lblNames.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNames.AutoSize = true;
            this.lblNames.Location = new System.Drawing.Point(97, 18);
            this.lblNames.Name = "lblNames";
            this.lblNames.Size = new System.Drawing.Size(56, 17);
            this.lblNames.TabIndex = 6;
            this.lblNames.Text = "NAMES";
            // 
            // lblPlaces
            // 
            this.lblPlaces.AutoSize = true;
            this.lblPlaces.Location = new System.Drawing.Point(6, 18);
            this.lblPlaces.Name = "lblPlaces";
            this.lblPlaces.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPlaces.Size = new System.Drawing.Size(29, 170);
            this.lblPlaces.TabIndex = 5;
            this.lblPlaces.Text = "1)\r\n2)\r\n3)\r\n4)\r\n5)\r\n6)\r\n7)\r\n8)\r\n9)\r\n10)\r\n";
            // 
            // btnEraseScores
            // 
            this.btnEraseScores.Location = new System.Drawing.Point(76, 247);
            this.btnEraseScores.Name = "btnEraseScores";
            this.btnEraseScores.Size = new System.Drawing.Size(128, 23);
            this.btnEraseScores.TabIndex = 15;
            this.btnEraseScores.Text = "Erase Score Data";
            this.btnEraseScores.UseVisualStyleBackColor = true;
            this.btnEraseScores.Click += new System.EventHandler(this.btnEraseScores_Click);
            // 
            // frmHighScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 282);
            this.Controls.Add(this.btnEraseScores);
            this.Controls.Add(this.grpScores);
            this.Controls.Add(this.btnMaster);
            this.Controls.Add(this.btnSkilled);
            this.Controls.Add(this.btnNormal);
            this.Name = "frmHighScores";
            this.Text = "Minefield";
            this.grpScores.ResumeLayout(false);
            this.grpScores.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Button btnSkilled;
        private System.Windows.Forms.Button btnMaster;
        private System.Windows.Forms.Label lblTimes;
        private System.Windows.Forms.GroupBox grpScores;
        private System.Windows.Forms.Label lblPlaces;
        private System.Windows.Forms.Label lblNames;
        private System.Windows.Forms.Button btnEraseScores;
    }
}