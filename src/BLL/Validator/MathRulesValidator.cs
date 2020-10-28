using System;

namespace BLL.Validator
{
    public static class MathRulesValidator
    {
        public static bool IsNoLetterSymbolsInMathPhrase(string phrase)
        {
            foreach (var item in phrase.ToCharArray())
            {
                IsChar(item);
            }
            return true;
        }
        private static bool IsChar(char charPhrase) => char.IsLetter(charPhrase)? throw new Exception("Invalid input char"):false;

        private static bool IsDividerZero(decimal divider) => divider.Equals(default);
        
        public static bool IsDividerCorrect(decimal divider)
        {
            if(IsDividerZero(divider))
                throw new Exception("Division by zero");
            return true;
        }
    }
}
