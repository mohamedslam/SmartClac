

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartClac.Class;
using Xunit;

namespace SmartClac.Test
{
    [TestClass] 
    public class CalculatorTest:BaseTest
    {
        public CalculatorTest():base(new ClsClaculation()) {       }

        [TestMethod("TestAllexpretion")]
        [Theory]
        [InlineData("5+3", 8)]
        [InlineData("5-3", 2)]
        [InlineData("5*3", 15)]
        [InlineData("15/3", 5)]
        [InlineData("5%3", 2)]
        [InlineData("5+3-2*4/5%3", 3)]
        [InlineData("(5+3)-2*(4/5%3)", 2)]
        public void TestCalc(string expretion, double result) => Assert.AreEqual(_Icalculation.Claculate(expretion), result);
    }
}
