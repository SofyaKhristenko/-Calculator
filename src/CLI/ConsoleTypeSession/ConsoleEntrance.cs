using System;

namespace CLI.ConsoleTypeSession
{
    static class ConsoleEntrance
    {
        public static string StrartConsoleSession(string SetMathExpression)
        {
            Console.WriteLine(SetMathExpression);
            string mathPhrase = Console.ReadLine();
            if (ConsoleValidator.IsEmpty(mathPhrase))
                return mathPhrase;
            return default;
        }
    }
}
