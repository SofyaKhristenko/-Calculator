using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CLI.FileTypeSession
{
   static class FileRecorder
    {
       
        public static void Recording(List<string> resultCalculate, string path)
        {
            File.AppendAllLines(path, resultCalculate);
        }
    }
}
