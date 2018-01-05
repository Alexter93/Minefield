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
        //string[] names = new string[10];
        //int[] times = new int[10];
        //ScoreEntry[] timesArray = new ScoreEntry[10];
        List<ScoreEntry> timesList = new List<ScoreEntry>();

        // constructor ================================================================
        public frmHighScores()
        {
            int finTime;
            string finName;


            InitializeComponent();

            if (!File.Exists("times.txt")) // if there's no score file, create one
                File.Create("times.txt");

            using (StreamReader dataReader = File.OpenText("times.txt"))
            {
                while (!dataReader.EndOfStream && place < 10)
                {
                    finName = dataReader.ReadLine().ToString();
                    finTime = Int32.Parse(dataReader.ReadLine().ToString());
                    //timesArray[place] = new ScoreEntry(finTime, finName);
                    timesList.Add(new ScoreEntry(finTime, finName));
                    place++;
                }
            }
            showTimes();

            if (timesList.Count > 0)
                btnEraseScores.Enabled = true;
        }
        
        // checks to see if the time is quick enough ==================================
        public bool isQuickEnough(int t)
        {

            int slowestValidTime = 0;

            // if there's a vacant spot, assign the new score to it
            if (timesList.Count() >= 10)
            {
                for (int i = 0; i < timesList.Count(); i++)
                {
                    if (timesList[i].getTime() > slowestValidTime)
                    {
                        slowestValidTime = timesList[i].getTime();
                    }
                }
                return t < slowestValidTime;
            }
            else
                return true;
        }

        // inserts a new time into the board (insertion sort) =========================
        public void insertTime(int t, string n)
        {
            //int slowestTimeIndex = 0;
            //int slowestValidTime = 0;

            // if there's a vacant spot, assign the new score to it
            if (timesList.Count < 10)
                timesList.Add(new ScoreEntry(t, n));
            /*for (int i = 0; i < 10; i++)
            {
                if (timesArray[i].getTime() == 0)
                {
                    timesArray[i] = new ScoreEntry(t, n);
                    return;
                }
            }*/

            // if not, assign it to the spot with the slowest time
            // copy this for another funti
            else
            {
                timesList.Remove(timesList[getSlowestTimeIndex()]); // for "timesList.Max()", System.ArgumentException - Additional information: At least one object must implement IComparable.
                timesList.Add(new ScoreEntry(t, n));
            }
            

            /*for (int i=0; i < 10; i++)
            {
                if (slowestValidTime < timesArray[i].getTime())
                {
                    slowestValidTime = timesArray[i].getTime();
                    slowestTimeIndex = i;
                }
            }
            timesArray[slowestTimeIndex] = new ScoreEntry(t, n);*/
            
            if (timesList.Count() > 1)
                sortTimes();
            saveTimes();
            showTimes();
        }

        // sorts the elements in the arrays ===========================================
        private void sortTimes()
        {
            ScoreEntry tempEntry = new ScoreEntry(0, "");

            // insertion sort (least to greatest)
            for (int i = 1; i < timesList.Count; i++)
            {
                if (timesList[i - 1] > timesList[i]) // if greatest to least pattern is detected, not counting 0s...
                {
                    tempEntry = timesList[i - 1];
                    timesList[i - 1] = timesList[i];
                    timesList[i] = tempEntry;

                    i = 0; // resets for another round of sorting the array
                }
            }
            if (timesList.Count > 10)
            {
                for (int i = 1; i < timesList.Count - 10; i++)
                {
                    timesList.RemoveAt(i);
                }
            }
        }

        // shows/updates what is shown as the 10 best times ======================================
        private void showTimes()
        {
            if (timesList.Count > 0)
                btnEraseScores.Enabled = true;

            //sortTimes();
            if (timesList.Count() > 1)
                timesList.OrderBy(ScoreEntry => ScoreEntry.getTime()); // this does not seem to work

            lblTimes.Text = String.Empty;
            lblNames.Text = String.Empty;

            if (timesList.Count() > 0)
            {
                for (int i = 0; i < timesList.Count(); i++)
                {
                    lblTimes.Text += timesList[i].getTime() / 60 + ":";
                    if (timesList[i].getTime() % 60 < 10)
                        lblTimes.Text += "0";
                    lblTimes.Text += timesList[i].getTime() % 60 + "\n";

                    lblNames.Text += timesList[i].getName() + "\n";
                }
            }
        }

        // writes 10 bsaveTimes()est times to file ===============================================
        private void saveTimes()
        {
            if (!File.Exists("times.txt"))
                File.Create("times.txt");

            using (StreamWriter dataWriter = File.CreateText("times.txt"))
            {
                for (int i = 0; i < timesList.Count(); i++)
                {
                    dataWriter.WriteLine(timesList[i].getName());
                    dataWriter.WriteLine(timesList[i].getTime().ToString());
                }
            }
        }

        // finds the returns the index with the slowest time =========================
        private int getSlowestTimeIndex()
        {
            int highestIndex = 0;

            if (timesList.Count() > 1)
                for (int i = 0; i < timesList.Count(); i++)
                {
                    if (highestIndex < timesList[i].getTime())
                        highestIndex =i;
                }
            return highestIndex;
        }

        // clears the score data ======================================================
        private void eraseScoreData()
        {

            if (!File.Exists("times.txt"))
            {
                MessageBox.Show("There is no score data to erase.", "Minefield", MessageBoxButtons.OK);
            }
            else
            {
                //File.Delete("times.txt");
                //File.Create("times.txt");
                File.WriteAllText("times.txt", String.Empty);
                lblTimes.Text = String.Empty;
                lblNames.Text = String.Empty;
                btnEraseScores.Enabled = false;
            }
        }
        
        private void btnEraseScores_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to erase the score data?", "Minefield", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                eraseScoreData();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
