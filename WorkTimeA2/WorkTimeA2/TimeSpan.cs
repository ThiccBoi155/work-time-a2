using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimeA2
{
    class TimeSpan
    {
        public TimePoint start;
        public int timeSpan;
        public string tag;

        public TimeSpan()
        {
            start = new TimePoint();
            timeSpan = 0;
            tag = "no tag";
        }

        // Working past midnight isn't implemented yet
        public TimeSpan(TimePoint t1, TimePoint t2, string _tag)
        {
            start = t1;
            timeSpan = t2 - t1;
            tag = _tag;

            if (timeSpan < 0)
                throw new ArgumentException("Working past midnight isn't implemented yet.");
        }

        /*
        public static int GetSum(IEnumerable<TimeSpan> timeSpans)
        {
            int sum = 0;
            return sum;
        }
        //*/
    }
}
