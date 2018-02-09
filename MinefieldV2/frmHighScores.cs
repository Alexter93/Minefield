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
        List<ScoreEntry> normTimesList = new List<ScoreEntry>();
        List<ScoreEntry> skilTimesList = new List<ScoreEntry>();
        List<ScoreEntry> mastTimesList = new List<ScoreEntry>();

        // constructor ================================================================
        public frmHighScores()
        {
            int finDiff;
            int finTime;
            string finName;
            

            InitializeComponent();

            if (!File.Exists("times.txt")) // if there's no score file, create one
                File.Create("times.txt");

            using (StreamReader dataReader = File.OpenText("times.txt"))
            {
                while (!dataReader.EndOfStream)
                {
                    finDiff = Int32.Parse(dataReader.ReadLine().ToString());
                    finName = dataReader.ReadLine().ToString();
                    finTime = Int32.Parse(dataReader.ReadLine().ToString());
                    switch (finDiff) // add the entries in the appropreate lists based on difficulty
                    {
                        case 2:
                        {
                            skilTimesList.Add(new ScoreEntry(finTime, finName, finDiff));
                            break;
                        }
                        case 3:
                        {
                            mastTimesList.Add(new ScoreEntry(finTime, finName, finDiff));
                            break;
                        }
                        default:
                        {
                            normTimesList.Add(new ScoreEntry(finTime, finName, finDiff));
                            break;
                        }
                    }
                }
            }
            showTimes();
        }
        
        // checks to see if the time is quick enough ==================================
        public bool isQuickEnough(int t, int d)
        {

            int slowestValidTime = 0;

            // if there's a vacant spot, assign the new score to it
            switch (d) // add the entries in the appropreate lists based on difficulty
            {
                case 2:
                {
                    if (skilTimesList.Count() >= 10)
                    {
                        for (int i = 0; i < skilTimesList.Count(); i++)
                        {
                            if (skilTimesList[i].getTime() > slowestValidTime)
                            {
                                slowestValidTime = skilTimesList[i].getTime();
                            }
                        }
                        return t < slowestValidTime;
                    }
                    else
                        return true;
                }
                case 3:
                {
                    if (mastTimesList.Count() >= 10)
                    {
                        for (int i = 0; i < mastTimesList.Count(); i++)
                        {
                            if (mastTimesList[i].getTime() > slowestValidTime)
                            {
                                slowestValidTime = mastTimesList[i].getTime();
                            }
                        }
                        return t < slowestValidTime;
                    }
                    else
                        return true;
                }
                default:
                {
                    if (normTimesList.Count() >= 10)
                    {
                        for (int i = 0; i < normTimesList.Count(); i++)
                        {
                            if (normTimesList[i].getTime() > slowestValidTime)
                            {
                                slowestValidTime = normTimesList[i].getTime();
                            }
                        }
                        return t < slowestValidTime;
                    }
                    else
                        return true;
                }
            }
        }
        
        // inserts a new time into the board ==========================================
        public void insertTime(int t, string n, int d)
        {
            switch (d) // add the entries in the appropreate lists based on difficulty
            {
                case 2:
                    {
                        // if there's a vacant spot, assign the new score to it
                        if (skilTimesList.Count < 10)
                            skilTimesList.Add(new ScoreEntry(t, n, d));

                        // if not, assign it to the spot with the slowest time
                        else
                        {
                            skilTimesList.Remove(skilTimesList[getSlowestTimeIndex(d)]); // for "timesList.Max()", System.ArgumentException - Additional information: At least one object must implement IComparable.
                            skilTimesList.Add(new ScoreEntry(t, n, d));
                        }

                        if (skilTimesList.Count() > 1)
                            sortTimes();
                        break;
                    }
                case 3:
                    {
                        // if there's a vacant spot, assign the new score to it
                        if (mastTimesList.Count < 10)
                            mastTimesList.Add(new ScoreEntry(t, n, d));

                        // if not, assign it to the spot with the slowest time
                        else
                        {
                            mastTimesList.Remove(mastTimesList[getSlowestTimeIndex(d)]); // for "timesList.Max()", System.ArgumentException - Additional information: At least one object must implement IComparable.
                            mastTimesList.Add(new ScoreEntry(t, n, d));
                        }

                        if (mastTimesList.Count() > 1)
                            sortTimes();
                        break;
                    }
                default:
                    {
                        // if there's a vacant spot, assign the new score to it
                        if (normTimesList.Count < 10)
                            normTimesList.Add(new ScoreEntry(t, n, d));

                        // if not, assign it to the spot with the slowest time
                        else
                        {
                            normTimesList.Remove(normTimesList[getSlowestTimeIndex(d)]); // for "timesList.Max()", System.ArgumentException - Additional information: At least one object must implement IComparable.
                            normTimesList.Add(new ScoreEntry(t, n, d));
                        }

                        if (normTimesList.Count() > 1)
                            sortTimes();
                        break;
                    }
            }
            saveTimes();
            showTimes();

            tabControl1.SelectTab(d-1);
        }

        // sorts the elements in the arrays ===========================================
        private void sortTimes()
        {
            ScoreEntry tempEntry = new ScoreEntry(0, "");

            // sort least to greatest - normTimesList
            for (int i = 1; i < normTimesList.Count; i++)
            {
                if (normTimesList[i - 1] > normTimesList[i]) // if greatest to least pattern is detected, not counting 0s...
                {
                    tempEntry = normTimesList[i - 1];
                    normTimesList[i - 1] = normTimesList[i];
                    normTimesList[i] = tempEntry;

                    i = 0; // resets for another round of sorting the array
                }
            }
            if (normTimesList.Count > 10)
            {
                for (int i = 1; i < normTimesList.Count - 10; i++)
                {
                    normTimesList.RemoveAt(i);
                }
            }
            // skilTimesList
            for (int i = 1; i < skilTimesList.Count; i++)
            {
                if (skilTimesList[i - 1] > skilTimesList[i]) // if greatest to least pattern is detected, not counting 0s...
                {
                    tempEntry = skilTimesList[i - 1];
                    skilTimesList[i - 1] = skilTimesList[i];
                    skilTimesList[i] = tempEntry;

                    i = 0; // resets for another round of sorting the array
                }
            }
            if (skilTimesList.Count > 10)
            {
                for (int i = 1; i < skilTimesList.Count - 10; i++)
                {
                    skilTimesList.RemoveAt(i);
                }
            }
            // mastTimesList
            for (int i = 1; i < mastTimesList.Count; i++)
            {
                if (mastTimesList[i - 1] > mastTimesList[i]) // if greatest to least pattern is detected, not counting 0s...
                {
                    tempEntry = mastTimesList[i - 1];
                    mastTimesList[i - 1] = mastTimesList[i];
                    mastTimesList[i] = tempEntry;

                    i = 0; // resets for another round of sorting the array
                }
            }
            if (mastTimesList.Count > 10)
            {
                for (int i = 1; i < mastTimesList.Count - 10; i++)
                {
                    mastTimesList.RemoveAt(i);
                }
            }
        }

        // shows/updates what is shown as the 10 best times ======================================
        private void showTimes()
        {
            sortTimes(); // prety important

            //sortTimes();
            /*if (timesList.Count() > 1)
                timesList.OrderBy(ScoreEntry => ScoreEntry.getTime());*/ // this does not seem to work

            lblNormTimes.Text = String.Empty;
            lblNormNames.Text = String.Empty;
            lblSkilTimes.Text = String.Empty;
            lblSkilNames.Text = String.Empty;
            lblMastTimes.Text = String.Empty;
            lblMastNames.Text = String.Empty;

            // lblNormTimes
            if (normTimesList.Count() > 0)
            {
                for (int i = 0; i < normTimesList.Count(); i++)
                {
                    lblNormTimes.Text += normTimesList[i].getTime() / 60 + ":";
                    if (normTimesList[i].getTime() % 60 < 10)
                        lblNormTimes.Text += "0";
                    lblNormTimes.Text += normTimesList[i].getTime() % 60 + "\n";

                    lblNormNames.Text += normTimesList[i].getName() + "\n";
                }
            }
            // lblSkilTimes
            if (skilTimesList.Count() > 0)
            {
                for (int i = 0; i < skilTimesList.Count(); i++)
                {
                    lblSkilTimes.Text += skilTimesList[i].getTime() / 60 + ":";
                    if (skilTimesList[i].getTime() % 60 < 10)
                        lblSkilTimes.Text += "0";
                    lblSkilTimes.Text += skilTimesList[i].getTime() % 60 + "\n";

                    lblSkilNames.Text += skilTimesList[i].getName() + "\n";
                }
            }
            // lblMastTimes
            if (mastTimesList.Count() > 0)
            {
                for (int i = 0; i < mastTimesList.Count(); i++)
                {
                    lblMastTimes.Text += mastTimesList[i].getTime() / 60 + ":";
                    if (mastTimesList[i].getTime() % 60 < 10)
                        lblMastTimes.Text += "0";
                    lblMastTimes.Text += mastTimesList[i].getTime() % 60 + "\n";

                    lblMastNames.Text += mastTimesList[i].getName() + "\n";
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
                // lblNormTimes
                for (int i = 0; i < normTimesList.Count(); i++)
                {
                    dataWriter.WriteLine(normTimesList[i].getDifficulty().ToString());
                    dataWriter.WriteLine(normTimesList[i].getName());
                    dataWriter.WriteLine(normTimesList[i].getTime().ToString());
                }
                // lblSkilTimes
                for (int i = 0; i < skilTimesList.Count(); i++)
                {
                    dataWriter.WriteLine(skilTimesList[i].getDifficulty().ToString());
                    dataWriter.WriteLine(skilTimesList[i].getName());
                    dataWriter.WriteLine(skilTimesList[i].getTime().ToString());
                }
                // lblMastTimes
                for (int i = 0; i < mastTimesList.Count(); i++)
                {
                    dataWriter.WriteLine(mastTimesList[i].getDifficulty().ToString());
                    dataWriter.WriteLine(mastTimesList[i].getName());
                    dataWriter.WriteLine(mastTimesList[i].getTime().ToString());
                }
            }
        }

        // finds the returns the index with the slowest time =========================
        private int getSlowestTimeIndex(int d)
        {
            int highestIndex = 0;

            switch (d) // add the entries in the appropreate lists based on difficulty
            {
                case 2:
                {
                    if (skilTimesList.Count() > 1)
                        for (int i = 0; i < skilTimesList.Count(); i++)
                        {
                            if (highestIndex < skilTimesList[i].getTime())
                                highestIndex = i;
                        }
                    return highestIndex;
                }
                case 3:
                {
                    if (mastTimesList.Count() > 1)
                        for (int i = 0; i < mastTimesList.Count(); i++)
                        {
                            if (highestIndex < mastTimesList[i].getTime())
                                highestIndex = i;
                        }
                    return highestIndex;
                }
                default:
                {
                    if (normTimesList.Count() > 1)
                        for (int i = 0; i < normTimesList.Count(); i++)
                        {
                            if (highestIndex < normTimesList[i].getTime())
                                highestIndex = i;
                        }
                    return highestIndex;
                }
            }
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
                File.WriteAllText("times.txt", String.Empty);
                lblNormTimes.Text = String.Empty;
                lblNormNames.Text = String.Empty;
                lblSkilTimes.Text = String.Empty;
                lblSkilNames.Text = String.Empty;
                lblMastTimes.Text = String.Empty;
                lblMastNames.Text = String.Empty;
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
