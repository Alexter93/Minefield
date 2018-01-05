using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinefieldV2
{
    public partial class frmNameEntry : Form
    {
        string name = "Someone";
        int seconds = 0;
        frmHighScores scoreScreen;

        // Constructor ================================================================
        public frmNameEntry(int s)
        {
            InitializeComponent();
            scoreScreen = new frmHighScores();
            seconds = s;
        }

        // Click OK ===================================================================
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text == String.Empty)
            {
                MessageBox.Show("Please enter a name for the High Score table");
            }
            else
            {
                name = txtName.Text;
                scoreScreen.insertTime(seconds, name);
                this.Hide();
                scoreScreen.ShowDialog();
            }
        }
    }
}
