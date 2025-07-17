using NUnit.Framework;
using Calculator.Calculations; 
namespace Calculator.Calculations.Tests;

    public class Tests
    {
        [Test]
        public void Sum_WhenAdding2And3_Returns5()
        {
            int result = Calculations.Sum(2, 3);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Difference_WhenSubtracting4From10_Returns6()
        {
            int result = Calculations.Difference(10, 4);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Multiply_WhenMultiplying3And4_Returns12()
        {
            int result = Calculations.Multiply(3, 4);
            Assert.AreEqual(12, result);
        }

        [Test]
        public void Division_WhenDividing10By2_Returns5()
        {
            double result = Calculations.Division(10, 2);
            Assert.AreEqual(5.0, result);
        }

    }