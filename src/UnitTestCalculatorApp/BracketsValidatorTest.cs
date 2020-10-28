using BLL.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCalculatorApp
{
    [TestClass]
    public class BracketsValidatorTest
    {
        [DataRow(")(1+1)+4)")]
        [DataRow("((1+1)+4")]
        [TestMethod]
        [ExpectedException(typeof(System.Exception), " other type exception")]
        public void BracketsValidator_IsValidBrackets_ExpectedException(string mathPhrase)
        {
            BracketsValidator.IsValidBrackets(mathPhrase);
        }

        [DataRow("(9+1)+(-4)")]
        [DataRow("((3+1)+4)")]
        [TestMethod]
        public void BracketsValidator_IsValidBrackets_True(string mathPhrase)
        {
            bool successActual = BracketsValidator.IsValidBrackets(mathPhrase);
            bool successExpected = true;
            Assert.AreEqual(successExpected, successActual);
        }
    }
}
