using System;
using System.IO;

namespace CLI.FileTypeSession
{
    static class FileEntrance
    {
        public static string GetPath(string infoUserSetPathFile)
        {
            string path = PathReader.SetPath(infoUserSetPathFile);
            if (CheckValid(path))
                return path;
            return default;
        }

        private static bool CheckValid(string path)
        {
            if (!FileValidator.IsNullOrEmptyPath(path))
            {
                return FileValidator.IsValid(path) ? true : false;
            }
            return false;
        }

        public static string GetSaveFilePath(string infoUser)
        {
            Console.WriteLine(infoUser);
            return Console.ReadLine();
        }

    }
}
