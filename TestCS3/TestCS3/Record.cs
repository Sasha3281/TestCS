using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCS3
{
    class Record
    {
        DateTime date;
        string time;
        string level;
        string method;
        string msg;

        public Record()
        {
            date = DateTime.Today;
            time = "";
            level = "";
            method = "";
            msg = "";
        }

        public Record(DateTime d, string t, string lev, string meth, string m)
        {
            date = d;
            time = t;
            level = lev;
            method = meth;
            msg = m;
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        public string Level
        {
            get { return level; }
            set { level = value; }
        }

        public string Method
        {
            get { return method; }
            set { method = value; }
        }

        public string Message
        {
            get { return msg; }
            set { msg = value; }
        }

    }
}
