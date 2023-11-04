using NUnit.Framework;
namespace Calculator
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DividingReturnsResult() 
        {
            double result = Calculator.Divide(3.0, 3.0);
            Assert.AreEqual(1.0, result);
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => Calculator.Divide(5.0, 0.0));
        }

        [Test]
        public void ExtractRoot_NegativeNumber_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => Calculator.ExtractRoot(-4.0, 2.0));
        }

        [Test]
        public void RaiseToThePower_ZeroPower_Returns1()
        {
            double result = Calculator.RaiseToThePower(5.0, 0.0);
            Assert.AreEqual(1.0, result);
        }

        [Test]
        public void RaiseToThePower_NegativePower_ReturnsResult()
        {
            double result = Calculator.RaiseToThePower(4.0, -0.5);
            Assert.AreEqual(0.5, result);
        }

        [Test]
        [TestCase(2.0, 3.0, 5.0)]
        [TestCase(0.0, 0.0, 0.0)]
        [TestCase(-2.0, 2.0, 0.0)]
        public void Add_DataProvider_ReturnsSum(double number1, double number2, double expected)
        {
            double result = Calculator.Add(number1, number2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(2.0, 3.0, 6.0)]
        [TestCase(0.0, 5.0, 0.0)]
        [TestCase(-2.0, -3.0, 6.0)]
        public void Multiply_DataProvider_ReturnsProduct(double number1, double number2, double expected)
        {
            double result = Calculator.Multiply(number1, number2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(9.0, 3.0)]
        [TestCase(25.0, 5.0)]
        [TestCase(1.0, 1.0)]
        public void ExtractSquareRoot_DataProvider_ReturnsSquareRoot(double number, double expected)
        {
            double result = Calculator.ExtractSquareRoot(number);
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(2.0, 3.0, 8.0)]
        [TestCase(3.0, 4.0, 81.0)]
        [TestCase(4.0, -0.5, 0.5)]
        public void RaiseToThePower_DataProvider_ReturnsResult(double number, double power, double expected)
        {
            double result = Calculator.RaiseToThePower(number, power);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ExtractRoot_Zero_ReturnsZero()
        {
            double result = Calculator.ExtractRoot(0.0, 10.0);
            Assert.AreEqual(0.0, result);
        }

        [Test]
        public void ExtractRoot_PositiveNumber_ReturnsRoot()
        {
            double result = Calculator.ExtractRoot(16.0, 2.0);
            Assert.AreEqual(4.0, result);
        }

        [Test]
        public void RaiseToThePower_PositiveNumberAndPower_ReturnsResult()
        {
            double result = Calculator.RaiseToThePower(3.0, 2.0);
            Assert.AreEqual(9.0, result);
        }

        [Test]
        public void Substraction_result()
        {
            double result = Calculator.Substract(3.0, 3.0);
            Assert.AreEqual(0.0, result);
        }

    }
}