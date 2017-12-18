namespace MinefieldV2
{
    partial class frmDifficulty
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
            this.btnMaster = new System.Windows.Forms.Button();
            this.btnSkilled = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMaster
            // 
            this.btnMaster.Location = new System.Drawing.Point(231, 68);
            this.btnMaster.Margin = new System.Windows.Forms.Padding(4);
            this.btnMaster.Name = "btnMaster";
            this.btnMaster.Size = new System.Drawing.Size(100, 47);
            this.btnMaster.TabIndex = 7;
            this.btnMaster.Text = "Master (32X24)";
            this.btnMaster.UseVisualStyleBackColor = true;
            this.btnMaster.Click += new System.EventHandler(this.btnMaster_Click);
            // 
            // btnSkilled
            // 
            this.btnSkilled.Location = new System.Drawing.Point(123, 68);
            this.btnSkilled.Margin = new System.Windows.Forms.Padding(4);
            this.btnSkilled.Name = "btnSkilled";
            this.btnSkilled.Size = new System.Drawing.Size(100, 47);
            this.btnSkilled.TabIndex = 6;
            this.btnSkilled.Text = "Skilled (16X16)";
            this.btnSkilled.UseVisualStyleBackColor = true;
            this.btnSkilled.Click += new System.EventHandler(this.btnSkilled_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.Location = new System.Drawing.Point(15, 68);
            this.btnNormal.Margin = new System.Windows.Forms.Padding(4);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(100, 47);
            this.btnNormal.TabIndex = 5;
            this.btnNormal.Text = "Normal (8X8)";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select a Difficulty:";
            // 
            // frmDifficulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 137);
            this.Controls.Add(this.btnMaster);
            this.Controls.Add(this.btnSkilled);
            this.Controls.Add(this.btnNormal);
            this.Controls.Add(this.label1);
            this.Name = "frmDifficulty";
            this.Text = "Minefield";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMaster;
        private System.Windows.Forms.Button btnSkilled;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Label label1;
    }
}

