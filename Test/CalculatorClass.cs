

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace SmartClac.Test
{
    [TestClass] 
    public class CalculatorClass:BaseTest
    {
        public CalculatorClass():base(new Class.ClsClaculation()) {       }

       //[TestMethod("TestAllexpretion")]
       // [Theory]
        [InlineData("5+3",8)]
        [InlineData("5-3",2)]
        [InlineData("5*3",15)]
        [InlineData("15/3",5)]
        [InlineData("5%3",2)]
        //[Fact]
      public  void TestCalc(string expretion,double result)
        {

            Assert.Equals(_Icalculation.Claculate(expretion), result);
        }
    }
}
