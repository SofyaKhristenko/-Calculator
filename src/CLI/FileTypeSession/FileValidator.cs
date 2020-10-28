using System;
using System.Collections.Generic;
using System.Text;

namespace CLI.FileTypeSession
{
   static class FileValidator
    {
        public static bool IsNullOrEmptyPath(string path) => String.IsNullOrEmpty(path) ? true : false;
       
        public static bool IsValid(string path) => System.IO.File.Exists(path) ? true : false;

    }
}
