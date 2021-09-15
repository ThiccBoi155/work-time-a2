using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimeA2
{
    static class GetSegmentData
    {
        public static int GetTotalTime(IList<TimeSpan> segs)
        {
            return GetTotalTimeInInterval(segs[0], segs[segs.Count - 1]);
        }

        // Returns the total time from s1 to s2
        public static int GetTotalTimeInInterval(TimeSpan s1, TimeSpan s2)
        {
            return s2.start - s1.start + s2.timeSpan;
        }

        public static int GetTotalWithTag(IList<TimeSpan> segs, string tag)
        {
            int sum = 0;

            foreach (TimeSpan seg in segs)
            {
                if (seg.tag == tag)
                    sum += seg.timeSpan;
            }

            return sum;
        }

        public static string GetPercentage(int tagTime, int totalTime)
        {
            var v = 100f * tagTime / totalTime;

            return string.Format("{0}%", v);
        }

        public static void PrintTagAndTimeSpan(IList<TimeSpan> segs)
        {
            foreach (TimeSpan segment in segs)
            {
                Console.WriteLine("{0}: {1}", segment.tag, segment.timeSpan);
            }
        }
    }
}
