using System;
using System.Collections.Generic;

namespace BLL.Validator
{
    public static class BracketsValidator
    {
        const int invalidSumIndeces = -1;
        const int validSumIndeces = 1;
        const char openBracket = '(';
        const char closeBracket = ')';


        public static bool IsValidBrackets(string mathPhrase)
        {
            int sumIndeces = 0;

            foreach (var symbol in mathPhrase)
            {
                IsInvalidSumIndecesOfBrackets(symbol, ref sumIndeces);
            }
            CheckSumIndecesAfterValidation(sumIndeces);
            return true;
        }

        private static bool IsInvalidSumIndecesOfBrackets(char symbol, ref int sumIndeces)
        {
            sumIndeces += GetIndexDependOnChar(symbol);
            bool resaltValid = IsInvalidSumIndeces(sumIndeces);
            if (resaltValid)
                throw new Exception("Invalid input brackets");
            return false;

        }

        private static int GetIndexDependOnChar(char userChar)
        {
            switch (userChar)
            {
                case openBracket:
                    return validSumIndeces;
                case closeBracket:
                    return invalidSumIndeces;
                default:
                    return default;
            }
        }

        private static bool IsInvalidSumIndeces(int sumIndeces) => sumIndeces.Equals(invalidSumIndeces);
        private static bool CheckSumIndecesAfterValidation(int sumIndeces) => sumIndeces != 0 ? throw new Exception("Invalid input brackets") : true;

     
    }

}

