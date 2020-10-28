using BLL.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCalculatorApp
{
    [TestClass]
    public class MathSymbolsValidatorTest
    {
        [DataRow("2++5+1")]
        [DataRow("4/*2")]
        [TestMethod]
        [ExpectedException(typeof(System.Exception), " other type exception")]
        public void MathSymbolsValidator_IsValidMathSymbols_ExpectedException(string mathPhrase)
        {
            MathSymbolsValidator.IsValidMathSymbols(mathPhrase);
        }
    }
}
