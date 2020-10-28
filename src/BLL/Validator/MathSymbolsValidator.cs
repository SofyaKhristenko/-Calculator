using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validator
{
    public static class MathSymbolsValidator
    {
        const int subBetweenNearbyOperation = 1;
        private static readonly char[] MathOperation = new char[] { '+', '-', '*', '/' };
        private static List<int> MathSymbolsInUserPhrase = new List<int>();

        public static bool IsValidMathSymbols(string phrase)
        {
            MathSymbolsInUserPhrase.Clear();
            GetIndecesOfMathSymbols(phrase);
            IsCorrectMathSymbols();
            return true;
        }

        private static void GetIndecesOfMathSymbols(string mathPhrase)
        {
            for (int index = 0; index < mathPhrase.Length; index++)
            {
                bool mathOperationSymbol = IsSymbolMathOperation(mathPhrase[index]);
                if (mathOperationSymbol)
                    MathSymbolsInUserPhrase.Add(index);
            }
        }

        public static bool IsSymbolMathOperation(char mathSymbol)
        {
            foreach (var operation in MathOperation)
            {
                if (mathSymbol.Equals(operation))
                    return true;
            }
            return false;
        }

        private static bool IsCorrectMathSymbols()
        {
            for (int i = 0; i < MathSymbolsInUserPhrase.Count - 1; i++)
            {
                int subIndices = MathSymbolsInUserPhrase[i+1] - MathSymbolsInUserPhrase[i];
                CheckInputUserMathSymbols(subIndices);
            }
            return true;
        }

        private static bool CheckInputUserMathSymbols(int subIndices) => subIndices.Equals(subBetweenNearbyOperation) ?
            throw new Exception("Invalid input math operation.") : false;



    }
}
