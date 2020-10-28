using System.IO;

namespace CLI
{
    public static class Rows
    {
        public static string[] GetLines(string path) => File.ReadAllLines(path);
    }
}
