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
    public partial class frmDifficulty : Form
    {
        Game freshGame;
        frmBoard gameBoard;

        public frmDifficulty()
        {
            InitializeComponent();
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            freshGame = new Game(1);
            openGame();
        }

        private void btnSkilled_Click(object sender, EventArgs e)
        {
            freshGame = new Game(2);
            openGame();
        }

        private void btnMaster_Click(object sender, EventArgs e)
        {
            freshGame = new Game(3);
            openGame();
        }

        private void openGame()
        {
            gameBoard = new frmBoard(freshGame);
            //Close();
            Hide();
            //MessageBox.Show("diff = " + freshGame.getDiff());
            gameBoard.ShowDialog();
            Close();
        }
    }
}
