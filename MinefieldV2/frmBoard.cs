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
    public partial class frmBoard : Form
    {
        private Game currentGame;
        private Button[,] tileGrid;
        private int seconds = 0;

        // constructor =======================================================================
        public frmBoard(Game importedGame)
        {
            InitializeComponent();
            this.Size = new Size(importedGame.getXWindowSize(), importedGame.getYWindowSize());
            tileGrid = new Button[importedGame.getXMines(), importedGame.getYMines()];
            currentGame = importedGame;
            createTiles();
            currentGame.setMineLocations();
        }


        // fills the form with the proper number of tiles ====================================
        private void createTiles()
        {
            // first tile will be at 12,94
            Point currentPoint = new Point(12, 94);
            Button currentButton;
            
            // add row of tiles
            for (int x = 0; x < currentGame.getXMines(); x++)
            {
                // add column of tiles
                for (int y = 0; y < currentGame.getYMines(); y++)
                {
                    currentButton = new Button() // adds a button to the form
                    {
                        Height = 25,
                        Width = 25,
                        Location = currentPoint,
                        
                    };
                    currentPoint.Y += 25;
                    tileGrid[x, y] = currentButton;
                    this.Controls.Add(currentButton);
                    currentButton.MouseUp += tile_MouseUp;
                }
                currentPoint.Y = 94;
                currentPoint.X += 25;
            }
        }

        // called every second ===============================================================
        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;
            if (seconds % 60 < 10)
                lblTimer.Text = (seconds / 60) + ":0" + (seconds % 60);
            else
                lblTimer.Text = (seconds / 60) + ":" + (seconds % 60);
        }

        // starts the game, will transfered to tile_MouseUp ==================================
        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        // when a tile button is pressed and released over a tile ============================
        private void tile_MouseUp(object sender, MouseEventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Start();
            }

            for (int x = 0; x < currentGame.getXMines(); x++)
            {
                for (int y = 0; y < currentGame.getYMines(); y++)
                {
                    if (sender == tileGrid[x, y])
                    {
                        if (e.Button == MouseButtons.Right) // right click
                        {
                            if (tileGrid[x, y].Text == String.Empty && tileGrid[x, y].Enabled == true && currentGame.canMarkTile())
                            {
                                tileGrid[x, y].Text = "X";
                                tileGrid[x, y].ForeColor = Color.Black;
                                currentGame.decMarked();
                            }
                            else if (tileGrid[x, y].Text == "X")
                            {
                                tileGrid[x, y].Text = String.Empty;
                                currentGame.incMarked();
                            }
                            lblFlags.Text = currentGame.getMarked().ToString(); // update how many marks the player has
                        }
                        else if (e.Button == MouseButtons.Left && tileGrid[x, y].Text == String.Empty) // left click
                        {
                            if (currentGame.checkTile(x, y)) // clicked on a mine
                            {
                                timer1.Stop();

                                revealMines();
                                if (MessageBox.Show("Game Over\nPlay again?", "Minefield", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    Game restartedGame = new Game(currentGame.getDiff());
                                    frmBoard gameBoard;
                                    this.Hide();
                                    gameBoard = new frmBoard(restartedGame);
                                    gameBoard.ShowDialog();

                                }
                                else
                                {
                                    Application.Exit();
                                }
                            }
                            else // clicked on a safe tile
                            {
                                updateSafeTile(x, y);

                                // this should be it's own funtion, updateSafeTile
                                /*surroundingMines = currentGame.checkSuroundingTiles(x, y);
                                if (surroundingMines > 0)
                                {
                                    tileGrid[x, y].Text = surroundingMines.ToString();
                                }
                                else
                                {
                                    clickSurroundingButtons(x,y);
                                }
                                tileGrid[x, y].Enabled = false;*/
                            }
                        }
                    }
                }
            }
        }

        // updates the same tile appropreatly ================================================
        private void updateSafeTile(int x, int y)
        {
            int surroundingMines;

            surroundingMines = currentGame.checkSuroundingTiles(x, y);
            if (surroundingMines > 0) // a mine is nearby
            {
                tileGrid[x, y].Text = surroundingMines.ToString();
            }
            else // no mines are nearby
            {
                tileGrid[x, y].Enabled = false;
                clickSurroundingButtons(x, y);
            }
            tileGrid[x, y].Enabled = false;
            currentGame.incCleared();
            lblCleared.Text = currentGame.getCleared().ToString();
            if (currentGame.gameWin()) // you win
            {
                timer1.Stop();
                //currentGame.updateTime(seconds); // for high score perposes
                
                // -=<High Score Stuff>=-   -=========================================================================================================================================
                frmHighScores scoreScreen = new frmHighScores();
                if (scoreScreen.isQuickEnough(seconds))
                {
                    MessageBox.Show("You made it to the top 10 quickest times", "Minefield", MessageBoxButtons.OK);
                    scoreScreen.insertTime(seconds, "someone");
                }
                scoreScreen.ShowDialog();


                if (MessageBox.Show("Congradulations! You Won! \nPlay again?", "Minefield", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Hide();
                    frmDifficulty newGame = new frmDifficulty();
                    newGame.ShowDialog();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        // clicks the suronding buttons
        private void clickSurroundingButtons(int x, int y)
        {
            if (y > 0) // button above
            {
                if (tileGrid[x, y - 1].Enabled == true) // makes sure it wasn't already checked, to prevent infinate loops
                    updateSafeTile(x, y - 1);
            }
            if (x > 0) // button to the left
            {
                if (tileGrid[x - 1, y].Enabled == true)
                    updateSafeTile(x - 1, y);
            }
            if (x < (currentGame.getXMines() - 1))  // button to the right
            {
                if (tileGrid[x + 1, y].Enabled == true)
                    updateSafeTile(x + 1, y);
            }
            if (y < (currentGame.getYMines() - 1)) // button below
            {
                if (tileGrid[x, y + 1].Enabled == true)
                    updateSafeTile(x, y + 1);
            }
            if (x > 0 && y > 0) // button above and to the left
            {
                if (tileGrid[x - 1, y - 1].Enabled == true)
                    updateSafeTile(x - 1, y - 1);
            }
            if (x < (currentGame.getXMines() - 1) && y > 0) // button above and to the right
            {
                if (tileGrid[x + 1, y - 1].Enabled == true)
                    updateSafeTile(x + 1, y - 1);
            }
            if (x > 0 && y < (currentGame.getYMines() - 1)) // button below and to the left
            {
                if (tileGrid[x - 1, y + 1].Enabled == true)
                    updateSafeTile(x - 1, y + 1);
            }
            if (x < (currentGame.getXMines() - 1) && y < (currentGame.getYMines() - 1)) // button below and to the right
            {
                if (tileGrid[x + 1, y + 1].Enabled == true)
                    updateSafeTile(x + 1, y + 1);
            }
        }

        // shows all the mine locations ======================================================
        private void revealMines()
        {
            for (int x = 0; x < currentGame.getXMines(); x++)
            {
                for (int y = 0; y < currentGame.getYMines(); y++)
                {
                    if (currentGame.checkTile(x, y))
                        tileGrid[x, y].Text = "*";
                }
            }
        }

        // click File>New Game ===============================================================
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentGame.getCleared() > 0)
            {
                if (MessageBox.Show("Are you sure you want to start a new game?", "Minefield", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Hide();
                    frmDifficulty newGame = new frmDifficulty();
                    newGame.ShowDialog();
                }
            }
            else
            {
                this.Hide();
                frmDifficulty newGame = new frmDifficulty();
                newGame.ShowDialog();
            }
        }

        // click File>Restart Game ===========================================================
        private void restartGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game restartedGame = new Game(currentGame.getDiff());
            frmBoard gameBoard;
            if (currentGame.getCleared() > 0)
            {
                if (MessageBox.Show("Are you sure you want to restart this game?", "Minefield", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Hide();
                    gameBoard = new frmBoard(restartedGame);
                    gameBoard.ShowDialog();
                }
            }
            else
            {
                this.Hide();
                gameBoard = new frmBoard(restartedGame);
                gameBoard.ShowDialog();
            }
        }

        // click File>Exit Game ==============================================================
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you quit this game?", "Minefield", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
        }

        // click Help>How to Play ============================================================
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String instructions = "How to Play:\n\n"+
                                "Objective:\n" +
                                "Clear the minefield for tiles that don't have mines. If you reveal a tile with a mine," +
                                "mine, it's game over.\n\n" +
                                "Controls:\n" +
                                "Left Click: on a tile to reveal what is underneath it. If there's no mine underneath," +
                                "then a number will show many of the surounding tiles contain mines. Surrounding tiles" +
                                "tiles tiles are the tiles above, below, on both sides and the ones in between, diagonally" +
                                "diagonally from the middle tile.\n" +
                                "Right Click: on a tile to mark it. When a tile is marked, you cannot left click on it." +
                                "This is usful for when you think a tile contains a mine. To unmark a tile, simply right" +
                                "click it again.";
            MessageBox.Show(instructions, "Minefield", MessageBoxButtons.OK);
        }

        // click Help>About ==================================================================
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            String text = "Minefield v1.0\n" +
                        "This is an improvement from my LandMine projects. Multiple difficulty levels and an object-" +
                        "oriented design are some of the improvements.\n\n"+
                        "More updates to come...";
            MessageBox.Show(text, "Minefield", MessageBoxButtons.OK);
        }

        // click File>HighScore ==========================================================================================================================================
        private void highScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHighScores scoreScreen = new frmHighScores();
            scoreScreen.ShowDialog();
        }
    }
}
