using System;

namespace BLL.Validator
{
    static class MathLexemeValidator
    {
        public static bool IsValid(string phrase)
        {
            BracketsValidator.IsValidBrackets(phrase);
            MathSymbolsValidator.IsValidMathSymbols(phrase);
            MathRulesValidator.IsNoLetterSymbolsInMathPhrase(phrase);
            return true;
        }

    }
}
