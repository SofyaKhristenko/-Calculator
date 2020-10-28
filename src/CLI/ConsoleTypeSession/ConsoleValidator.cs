using System;
using System.Collections.Generic;
using System.Text;

namespace CLI.ConsoleTypeSession
{
    static class ConsoleValidator
    {
        public static bool IsEmpty(string phrase)
        {
            if (phrase == "" || phrase == default)
            {
                return false;
            }

            return true;
        }
    }
}
