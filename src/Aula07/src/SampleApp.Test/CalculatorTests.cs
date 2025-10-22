using Xunit;
using SampleApp;

namespace SampleApp.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_ShouldReturnCorrectSum()
        {
            Assert.Equal(5, Calculator.Add(2, 3));
        }

        [Fact]
        public void Divide_ByZero_ShouldThrowException()
        {
            Assert.Throws<System.DivideByZeroException>(() => Calculator.Divide(5, 0));
        }
    }
}
