using System;

namespace CLI.FileTypeSession
{
    static class PathReader
    {
        public static string SetPath(string infoUser)
        {
            Console.WriteLine(infoUser);
            return Console.ReadLine();
        }
    }
}
