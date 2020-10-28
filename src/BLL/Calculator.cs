using BLL.Validator;
using System;

namespace BLL
{
    public class Calculator
    {
        public MathAlgorithm MathAlgorithm { get; set; }

        public Calculator(MathAlgorithm algorithm)
        {
            this.MathAlgorithm = algorithm;
        }

        public string Count(string mathPhrase)
        {
            bool success;
            try
            {
                success = MathLexemeValidator.IsValid(mathPhrase);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

           
            string result;
            try
            {
                if (success)
                {
                    MathAlgorithm.GetCalculationResult(mathPhrase);
                }

                result = MathAlgorithm.CalculateLastOperation().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return result;
        }
    }

}
