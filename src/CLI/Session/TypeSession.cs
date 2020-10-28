using System;

namespace CLI.Session
{
    public enum SessionType
    {
        FileLoad = 1,
        ConsolePrint
    }
    static class TypeSession
    {
        public static SessionType SetTypeSession(string setTypeSession)
        {
            Console.WriteLine(setTypeSession);
            string answer = Console.ReadLine();
            if ("1" == answer)
                return SessionType.FileLoad;
            if ("2" == answer)
                return SessionType.ConsolePrint;
            return default;
        }
       
        public static bool RepeatInput(string repeatInput)
        {
            Console.WriteLine(repeatInput);
            if (Console.ReadLine() == "Y")
                return true;
            return false;
        }
    }
}
