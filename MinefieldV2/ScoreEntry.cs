using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldV2
{
    public class ScoreEntry
    {
        private int time = 0;
        private string name = "";

        // constructor =============================================================
        public ScoreEntry(int t, string n)
        {
            time = t;
            name = n;
        }

        // getters ================================================================
        public int getTime()
        { return time; }

        public string getName()
        { return name; }

        // setters ================================================================
        public void setTime(int t)
        { time = t; }

        public void setName(string n)
        { name = n; }

        // overloading of relational operators ====================================
        public static bool operator < (ScoreEntry se1, ScoreEntry se2)
        {
            if (se1.time == 0) // 0 > #, becase sorting
                return false;
            else if (se2.time == 0)
                return true;
            return se1.time < se2.time;
        }

        public static bool operator > (ScoreEntry se1, ScoreEntry se2)
        {
            if (se1.time == 0) // 0 > #, becase sorting
                return true;
            else if (se2.time == 0)
                return false;
            return se1.time > se2.time;
        }

        public static bool operator <= (ScoreEntry se1, ScoreEntry se2)
        {
            return se1.time <= se2.time;
        }

        public static bool operator >= (ScoreEntry se1, ScoreEntry se2)
        {
            return se1.time >= se2.time;
        }

        public static bool operator == (ScoreEntry se1, ScoreEntry se2)
        {
            return se1.time == se2.time && se1.name == se2.name;
        }

        public static bool operator != (ScoreEntry se1, ScoreEntry se2)
        {
            return se1.time != se2.time && se1.name != se2.name;
        }
    }
}
