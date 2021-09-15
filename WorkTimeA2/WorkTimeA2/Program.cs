using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimeA2
{
    class Program
    {
        //*/
        static void Main(string[] args)
        {
            RunProgram();

            Console.ReadKey();
        }
        //*/

        static void RunProgram()
        {
            IEnumerable<string> txtLines = GetTxtLines.ReadTxtLines();

            GetSegmentData.Segments = GetTxtLines.GetSegments(txtLines);

            Console.WriteLine();

            int totalTime = GetSegmentData.GetTotalTime();
            Console.WriteLine("Total time: {0} - {1}", totalTime, TimePoint.GetIntInFormat(totalTime));

            foreach (string tag in GetTxtLines.totalTags)
                PrintTagStat(totalTime, tag);

            Console.WriteLine();

            GetSegmentData.PrintTagAndTimeSpan();
        }

        static void PrintTagStat(int totalTime, string tag)
        {
            int tagTime = GetSegmentData.GetTotalWithTag(tag);
            Console.WriteLine("Total {0} time: {1} - {2}, {3}", tag, tagTime, TimePoint.GetIntInFormat(tagTime), GetSegmentData.GetPercentage(tagTime, totalTime));

        }

        /*/
        static void Main(string[] args)
        {
            char inputKey = 'y';

            while (inputKey == 'y')
            {
                RunProgram();

                do
                {
                    Console.Write("Run again (y/n)");
                    inputKey = Console.ReadKey().KeyChar;
                }
                while (inputKey != 'y' && inputKey != 'n');

                Console.Clear();
            }
        }
        //*/
    }
}
