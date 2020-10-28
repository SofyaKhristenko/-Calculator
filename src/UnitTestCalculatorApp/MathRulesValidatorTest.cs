using BLL.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCalculatorApp
{
    [TestClass]
    public class MathRulesValidatorTest
    {
        [DataRow("1+pi")]
        [DataRow("3*x+2*y")]
        [TestMethod]
        [ExpectedException(typeof(System.Exception), " other type exception")]
        public void MathRulesValidator_IsNoLetterSymbolsInMathPhrase_ExpectedException(string mathPhrase)
        {
            MathRulesValidator.IsNoLetterSymbolsInMathPhrase(mathPhrase);
        }
    }
}
