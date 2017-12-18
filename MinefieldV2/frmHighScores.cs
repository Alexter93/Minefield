using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MinefieldV2
{
    public partial class frmHighScores : Form
    {
            int place = 0;
            string[] names = new string[10];
            int[] times = new int[10];

        // constructor ================================================================
        public frmHighScores()
        {
            InitializeComponent();

            if (!File.Exists("times.txt")) // if there's no score file, create one
                File.Create("times.txt");

            using (StreamReader dataReader = File.OpenText("times.txt"))
            {
                while (!dataReader.EndOfStream && place < 10)
                {
                    names[place] = dataReader.ReadLine().ToString();
                    times[place] = Int32.Parse(dataReader.ReadLine().ToString());
                    place++;
                }
            }
            showTimes();
        }

        // returns bool show if there's at least 1 vacant spot in the array ===========
        private bool isSocreBoardFull()
        {
            // false if there's enough room for another time
            for (int i=0; i<10;i++)
            {
                if (times[i] == 0)
                    return false;
            }
            return true;
        }

        // returns if a time is quick enough fir the top 10 ===========================
        public bool isQuickEnough(int t)
        {
            // loop through the time array for empty scores
            for (int i = 0; i < 10; i++)
            {
                if (times[i] == 0)
                    return true;
            }
            return false;
        }


        // inserts a new time into the board (insertion sort) =========================
        public void insertTime(int t, string n)
        {
            int slowestTimeIndex = 0;

            if (!isSocreBoardFull())
            {
                // adds the new time to the back of the array if there's room
                times[9] = t;
                names[9] = n;
            }
            else
            {
                // finds the index of the slowest time's index
                for (int i = 0; i < 10; i++)
                {
                    if (times[i] == times.Max())
                        slowestTimeIndex = i;
                }
                // and assignes the new time to it
                times[slowestTimeIndex] = t;
                names[slowestTimeIndex] = n;
            }
            sortTimes();
        }

        // sorts the elements in the arrays ===========================================
        private void sortTimes()
        {
            int tempInt = 9;
            int zeros = 0;
            string tempString = "";

            // move the 0s to the back------------------------------------------------------------------------------------------------
            for (int h = 0; h > 10; h++) // get the amount of zeros in times[]
            {
                if (times[h] == 0)
                    zeros++;
            }

            for (int j = 1; j < zeros; j++)
            {
                for (int i = 0; i < 9; i++) // move shift the empty entries up 1
                {
                    if (times[i] == 0)
                    {
                        times[i] = times[tempInt];
                        times[i + 1] = 0;


                        names[i] = names[i + 1];
                        names[i + 1] = "";
                        tempInt--;
                    }
                }
            }

            tempInt = 0;
            // insertion sort (least to greatest)
            for (int i = 1; i < 10; i++)
            {
                if (times[i - 1] > times[i] && times[i] > 0) // if greatest to least pattern is detected, not counting 0s...
                {
                    /*tempInt = times[i]; // holds the lesser value
                    times[i] = times[i - 1]; // assigns the greater value to the further back slot
                    times[i - 1] = tempInt; // assigns the lesser value to the front slot*/
                    tempInt = times[i - 1];
                    times[i - 1] = times[i];
                    times[i] = tempInt;
                    // adjusts names[] accordingly
                    tempString = names[i];
                    names[i] = names[i - 1];
                    names[i - 1] = tempString;

                    i = 1; // resets for another round of sorting the array
                }
            }
            saveTimes();
        }

        // writes 10 best times to file ===============================================
        private void saveTimes()
        {
            if (!File.Exists("times.txt"))
                File.Create("times.txt");

            using (StreamWriter dataWriter = File.CreateText("times.txt"))
            {
                for (int i = 0; i < 10; i++)
                {
                    dataWriter.WriteLine(names[i]);
                    dataWriter.WriteLine(times[i]);
                }
            }
        }

        // shoes the 10 best times ====================================================
        private void showTimes()
        {
            sortTimes();

            lblTimes.Text = "";
            for (int i = 0; i < times.Length; i++)
            {
                lblTimes.Text += times[i] / 60 + ":";
                if (times[i] % 60 < 10)
                    lblTimes.Text += "0";
                lblTimes.Text += times[i] % 60 + "\n";
            }
            lblNames.Text = "";
            for (int i = 0; i < names.Length; i++)
            {
                lblNames.Text += names[i] + "\n";
            }
        }

        // clears the score data ======================================================
        private void eraseScoreData()
        {
            if(MessageBox.Show("Are you sure you want to erase the score data file?", "Minefield", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                File.Delete("times.txt");
                File.Create("times.txt");
                using (StreamReader dataReader = File.OpenText("times.txt"))
                {
                    while (!dataReader.EndOfStream && place < 10)
                    {
                        names[place] = dataReader.ReadLine().ToString();
                        times[place] = Int32.Parse(dataReader.ReadLine().ToString());
                        place++;
                    }
                }
            }
        }

        // addes a tab at the end of a string (for Labels) ============================
        private string tab(string s, int t = 1)
        {
            int spaces = s.Length % 4 + 4 * (t);
            for (int i = 0; i < spaces; i++)
            {
                s += " ";
            }
            return s;
        }

        private void btnEraseScores_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to erase the score data?", "Minefield", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                eraseScoreData();
                showTimes();
            }
        }
    }
}
