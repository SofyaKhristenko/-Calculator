using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCalculatorApp
{
    [TestClass]
    public class MathAlgorithmTest
    {
        private static Calculator Calculator { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext _) => Calculator = new Calculator(new MathAlgorithm());


        [DataRow("((-1)+(-1))*(-3)")]
        [DataRow("(4+(-2))*3")]
        [DataRow("2*4+(-2)")]
        [DataRow("(-1)+7")]
        [DataRow("(5-3)*3")]
        [DataRow("(10+2)/2")]
        [TestMethod]
        public void MathAlgorithm_GetCalculationResult_Result6(string mathPhrase)
        {
            MathAlgorithm mathAlgorithm = new MathAlgorithm();

            mathAlgorithm.GetCalculationResult(mathPhrase);
            decimal successActual = mathAlgorithm.CalculateLastOperation();
            decimal successExpected = 6;
            Assert.AreEqual(successExpected, successActual);
        }

       
        [DataRow("(5-3)/(2-2)")]
        [DataRow("(10+2)/0")]
        [ExpectedException(typeof(System.Exception), " other type exception")]
        public void MathAlgorithm_GetCalculationResult_ExpectedException(string mathPhrase)
        {
            MathAlgorithm mathAlgorithm = new MathAlgorithm();
            mathAlgorithm.GetCalculationResult(mathPhrase);
        }

    }
}
