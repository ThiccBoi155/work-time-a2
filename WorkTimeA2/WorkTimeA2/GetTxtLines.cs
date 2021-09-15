using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Text;

namespace WorkTimeA2
{
    static class GetTxtLines
    {
        static string txtName = "time-points.txt";

        // Returns all lines of the file named txtName that is on the same directory as the .exe file
        // Returns null if the file doesn't exist
        public static string[] ReadTxtLines()
        {
            string txtFilePath = string.Format("{0}/{1}", new DirectoryInfo(".").FullName, txtName);

            try
            {
                return File.ReadAllLines(txtFilePath);
            }
            catch (FileNotFoundException e)
            {
                return null;
            }
        }
    }
}
