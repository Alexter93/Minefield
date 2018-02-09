using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldV2
{
    public class Game
    {
        private Random rand = new Random();
        private bool[,] mines;
        private int cleared;
        private int diff;
        private int marked;
        private int time;
        private int xMines;
        private int yMines;
        private int xWindowSize;
        private int yWindowSize;

        // constructor =======================================================================
        public Game(int importedDiff)
        {
            cleared = 0;
            diff = importedDiff;

            switch (diff)
            {
            case 2: // Skilled Game
                {
                    // Rez 442, 576
                    xWindowSize = 442;
                    yWindowSize = 576;
                    xMines = 16;
                    yMines = 16;
                    marked = 40;
                    break;
                }
            case 3: // Master Game
                {
                    // Rez 842, 776
                    xWindowSize = 842;
                    yWindowSize = 776;
                    xMines = 32;
                    yMines = 24;
                    marked = 99;
                    break;
                }
            default: // Normal (Default) Game
                {
                    // Rez 242 (or 270), 376
                    xWindowSize = 242;
                    yWindowSize = 376;
                    xMines = 8;
                    yMines = 8;
                    marked = 10;
                    break;
                }
            }

            mines = new bool[xMines, yMines];
        }

        // sets the mine locations ===========================================================
        public void setMineLocations()
        {
            int tempX; 
            int tempY;

            for (int i = 0; i < marked; i++)
            {
                do // so there's no more than one mine per button
                {
                    tempX = rand.Next(xMines - 1);
                    tempY = rand.Next(yMines - 1);
                }
                while (mines[tempX, tempY] == true);
                mines[tempX, tempY] = true;

                // debug to list mine locations
                //lblDebug.Text += '\n' + "[" + tempX + " , " + tempY + "]";
                //Buttons[tempX, tempY].Text = "*";
            }
        }

        // returns a bool showing if there's a mine at a location or not =====================
        public bool checkTile(int x, int y)
        {
            if (mines[x, y] == true)
                return true;
            return false;
        }

        // returns the number of mines in a curounding buttons ===============================
        public int checkSuroundingTiles(int x, int y)
        {
            int surounding = 0;

            if (y > 0) // button above
            {
                if (checkTile(x, y - 1))
                    surounding++;
            }
            if (x > 0) // button to the left
            {
                if (checkTile(x - 1, y))
                    surounding++;
            }
            if (x < (xMines - 1))  // button to the right
            {
                if (checkTile(x + 1, y))
                    surounding++;
            }
            if (y < (yMines - 1)) // button below
            {
                if (checkTile(x, y + 1))
                    surounding++;
            }
            if (x > 0 && y > 0) // button above and to the left
            {
                if (checkTile(x - 1, y - 1))
                surounding++;
            }
            if (x < (xMines - 1) && y > 0) // button above and to the right
            {
                if (checkTile(x + 1, y - 1))
                    surounding++;
            }
            if (x > 0 && y < (yMines - 1)) // button below and to the left
            {
                if (checkTile(x - 1, y + 1))
                    surounding++;
            }
            if (x < (xMines - 1) && y < (yMines - 1)) // button below and to the right
            {
                if (checkTile(x + 1, y + 1))
                    surounding++;
            }
            return surounding;
        }

        // returns a bool on if there's any marks left or not ================================
        public bool canMarkTile()
        {
            if (marked > 0)
                return true;
            else
                return false;
        }

        // returns a bool on if the game is won or not =======================================
        public bool gameWin()
        {
            switch (diff)
            {
            case 2: // Skilled Game
                {
                    if (cleared < (xMines * yMines - 20))
                        return false;
                    else
                        return true;
                }
            case 3: // Master Game
                {
                    if (cleared < (xMines * yMines - 35))
                        return false;
                    else
                        return true;
                }
            default: // Normal Game
                {
                    if (cleared < (xMines * yMines - 10))
                        return false;
                    else
                        return true;
                }
            }
        }

        // setter for int time ===============================================================
        public void updateTime(int newTime)
        {
            time = newTime;
        }

        // decrament marked ==================================================================
        public void decMarked()
        {
            if (marked > 0)
            {
                marked--;
            }
            return;
        }

        // incrament marked ==================================================================
        public void incMarked()
        {
            if (diff == 3 && marked < 35 || diff == 2 && marked < 20 || diff == 1 && marked < 10)
            {
                marked++;
            }
            return;
        }

        // incrament cleared =================================================================
        public void incCleared()
        {
            cleared++;
            return;
        }

        // returns marked ====================================================================
        public int getMarked()
        {
            return marked;
        }
        
        // returns diff ======================================================================
        public int getDiff()
        {
            return diff;
        }

        // returns cleared ==================================================================
        public int getCleared()
        {
            return cleared;
        }

        // returns xWindowSize ===============================================================
        public int getXWindowSize()
        {
            return xWindowSize;
        }

        // returns yWindowSize ===============================================================
        public int getYWindowSize()
        {
            return yWindowSize;
        }

        // returns xMines ===============================================================
        public int getXMines()
        {
            return xMines;
        }

        // returns yMines ===============================================================
        public int getYMines()
        {
            return yMines;
        }
    }
}
