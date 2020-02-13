using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BrodenSchmeiderAPITest
{
     public class HelperMethods
    {
        public static void CreateDirectory(string directoryPath)
        {
            Directory.CreateDirectory(directoryPath);
        }

        public static void CreateFile(string path)
        {
            File.Create(path).Close();
        }
    }
}
