using BLL.Validator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    enum MathPriority
    {
        Less,
        More
    }

    enum TypeOfMathSymbols
    {
        Digit,
        Opertation,
        Bracket
    }

    enum Operation
    {
        Sum,
        Substraction,
        Multiplication,
        Division
    }

    public class MathAlgorithm
    {
        const char _openBracket = '(';
        const char _closeBracket = ')';
        public static Dictionary<char, int> MathOperation { get; set; } = new Dictionary<char, int>  {
            {'+', 1},
            {'-', 1 },
            {'*', 2 },
            {'/', 2 }
        };

        public Stack<decimal> NumbersStack = new Stack<decimal>();
        public Stack<char> MathOperationStack = new Stack<char>();
        public Stack<string> TypeOfSymbolsStack = new Stack<string>();
        public void GetCalculationResult(string mathPhrase)
        {
            ClearPreviousInfoInSteck();
            bool existNumberInBrackets = false;
            bool openBracket = false;
            bool negative = false;

            for (int i = 0; i < mathPhrase.Length; i++)
            {
                TypeOfMathSymbols typeOfChar = GetTypeAboutChar(mathPhrase[i]);

                switch (typeOfChar)
                {
                    case TypeOfMathSymbols.Bracket:
                        openBracket = IsOpenBracket(mathPhrase[i]);
                        if (existNumberInBrackets)
                        {
                            existNumberInBrackets = false;
                        }
                        else
                            IsCloseBracket(mathPhrase[i]);

                        break;

                    case TypeOfMathSymbols.Digit:
                        decimal number = Parser.DigitParser(mathPhrase, i, negative, out int index);
                        negative = false;
                        i = index;
                        SetNumberToSteck(number);
                        break;

                    case TypeOfMathSymbols.Opertation:
                        existNumberInBrackets = IsExistNumberInBrackets(mathPhrase[i], openBracket, out negative);
                        if (!existNumberInBrackets)
                            PushMathOperation(mathPhrase[i]);
                        break;
                }
                TypeOfSymbolsStack.Push(typeOfChar.ToString());
            }
        }

        private void ClearPreviousInfoInSteck()
        {
            TypeOfSymbolsStack.Clear();
            NumbersStack.Clear();
            MathOperationStack.Clear();
        }

        private bool IsExistNumberInBrackets(char symbol, bool openBracket, out bool negative)
        {
            if (openBracket && IsPreviousSymbolOpenBracket())
            {
                Parser.CheckSymbolNumber(symbol, out negative);
                MathOperationStack.Pop();
                return true;
            }
            negative = false;
            return false;
        }
        private bool IsPreviousSymbolOpenBracket()
        {
            string previousTypeOfSymbols = TypeOfSymbolsStack.Peek();
            if (previousTypeOfSymbols.Any() && previousTypeOfSymbols.Equals(TypeOfMathSymbols.Bracket.ToString()))
            {
                return true;
            }
            return false;
        }

        private TypeOfMathSymbols GetTypeAboutChar(char symbol)
        {
            if (IsBrackets(symbol))
                return TypeOfMathSymbols.Bracket;
            if (char.IsDigit(symbol))
                return TypeOfMathSymbols.Digit;
            else
                return TypeOfMathSymbols.Opertation;
        }

        private void SetNextOperationOrCalculate(MathPriority priority)
        {
            switch (priority)
            {
                case MathPriority.Less:
                    break;
                case MathPriority.More:
                    CalculateOperation(MathOperationStack.Pop());
                    break;
            }
        }

        private MathPriority CheckPriorityOperation(char itemPhrase)
        {
            if (MathOperationStack.Peek().Equals(_openBracket)
                || MathOperation[MathOperationStack.Peek()] < MathOperation[itemPhrase])
                return MathPriority.Less;

            return MathPriority.More;
        }

        private void CalculateOperation(char operetion)
        {
            switch (operetion)
            {
                case '+':
                    NumbersStack.Push(NumbersStack.Pop() + NumbersStack.Pop());
                    break;
                case '-':
                    decimal subtractor = NumbersStack.Pop();
                    decimal subtracted = NumbersStack.Pop();
                    NumbersStack.Push(subtracted - subtractor);
                    break;
                case '*':
                    NumbersStack.Push(NumbersStack.Pop() * NumbersStack.Pop());
                    break;
                case '/':
                    decimal divider = NumbersStack.Pop();
                    MathRulesValidator.IsDividerCorrect(divider);
                    decimal dividend = NumbersStack.Pop();
                    NumbersStack.Push(dividend / divider);
                    break;
            }
        }

        public void SetNumberToSteck(decimal number)
        {
            NumbersStack.Push(number);
        }

        private void PushMathOperation(char itemPhrase)
        {
            if (MathOperationStack.Count != 0)
            {
                MathPriority priority = CheckPriorityOperation(itemPhrase);
                SetNextOperationOrCalculate(priority);
            }
            MathOperationStack.Push(itemPhrase);
        }

        private bool IsOpenBracket(char itemPhrase)
        {
            if (itemPhrase.Equals(_openBracket))
            {
                MathOperationStack.Push(itemPhrase);
                return true;
            }
            return false;
        }

        private bool IsCloseBracket(char itemPhrase)
        {
            if (itemPhrase.Equals(_closeBracket))
            {
                do
                {
                    CalculateOperation(MathOperationStack.Pop());
                } while (MathOperationStack.Peek() != '(');
                MathOperationStack.Pop();
                return true;
            }
            return false;
        }

        private bool IsBrackets(char symbol) => (symbol.Equals(_openBracket) || symbol.Equals(_closeBracket)) ?
                  true : false;

        public decimal CalculateLastOperation()
        {
            for (int i = 0; i < MathOperationStack.Count;)
            {
                CalculateOperation(MathOperationStack.Pop());
            }
            decimal result = NumbersStack.Pop();
            return result;
        }
    }
}
