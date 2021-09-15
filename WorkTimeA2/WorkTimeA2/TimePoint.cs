using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimeA2
{
    class TimePoint
    {
        // 0 - 1439
        private int Min;

        public TimePoint() : this(0, 0) { }

        public TimePoint(int hour, int min)
        {
            setMin(hour, min);
        }

        public TimePoint(string s)
        {
            // Seperator index
            int sepIndex = s.IndexOf(':');

            int hour = int.Parse(s.Substring(0, sepIndex));
            int min = int.Parse(s.Substring(sepIndex + 1));

            setMin(hour, min);
        }

        private void setMin(int hour, int min)
        {
            if (!(0 <= min && min < 60))
                throw new ArgumentOutOfRangeException("min has to be a value between 0 and 59.");
            if (!(0 <= hour && hour < 24))
                throw new ArgumentOutOfRangeException("hour has to be a value between 0 and 23.");

            Min = hour * 60 + min;
        }

        static string addZeroPlace(int i)
        {
            return i > 9 ? i.ToString() : string.Format("0{0}", i);
        }

        public static string GetIntInFormat(int totalMin)
        {
            int min = totalMin % 60;
            int hour = (totalMin - min) / 60;

            return string.Format("{0}:{1}", addZeroPlace(hour), addZeroPlace(min));
        }

        public override string ToString()
        {
            return GetIntInFormat(Min);
        }

        public static int operator -(TimePoint t1, TimePoint t2)
        {
            return t1.Min - t2.Min;
        }
    }
}
