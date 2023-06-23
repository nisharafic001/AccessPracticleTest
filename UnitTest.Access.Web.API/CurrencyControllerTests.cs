using Microsoft.AspNetCore.Mvc;
using Access.Web.API.Controllers;
using NUnit.Framework;

namespace UnitTest.Access.Web.API
{
    [TestFixture]
    public class CurrencyControllerTests
    {
        [Test]
        public void ConvertToWords_Zero_ReturnsZero()
        {
            // Arrange
            decimal value = 0m;
            string expected = "Zero";

            // Act
            var controller = new CurrencyController();

            var result = controller.ConvertToWords(value) as OkObjectResult;
            var actual = result.Value as string;
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConvertToWords_PositiveValue_ReturnsOkResultWithCorrectWords()
        {
            // Arrange
            var controller = new CurrencyController();
            decimal value = 1.15m;
            string expected = "One Dollar and Fifteen Cents";

            // Act
            var result = controller.ConvertToWords(value) as OkObjectResult;
            var actual = result.Value as string;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConvertToWords_NegativeValue_ReturnsCorrectWordsWithMinus()
        {
            // Arrange
            var controller = new CurrencyController();
            decimal value = -70.62m;
            string expected = "Minus Seventy Dollars and Sixty Two Cents";

            // Act
            var result = controller.ConvertToWords(value) as OkObjectResult;
            var actual = result.Value as string;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}