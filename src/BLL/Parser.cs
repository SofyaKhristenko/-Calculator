using System;

namespace BLL
{
    public static class Parser
    {
       // private static bool IsNegative { get; set; }
        public static decimal DigitParser(string mathPhrase, int index, bool isNegative, out int i)
        {
           
            decimal result = default;
            for (i = index; i < mathPhrase.Length; i++)
            {
                bool success = Decimal.TryParse(mathPhrase[i].ToString(), out decimal number);
                if (success)
                    result = checked(result * 10 + number);
                else
                {
                    i--;
                    break;
                }
            }
            return (isNegative) ? -result : result;
        }

        public static int CheckSymbolNumber(char symbol, out bool isNegative)
        {
            isNegative = false;

            switch (symbol)
            {
                case '-':
                    isNegative = true;
                    return 1;
                case '+':
                    return 1;
                default:
                    return 0;
            }
        }
    }
}
