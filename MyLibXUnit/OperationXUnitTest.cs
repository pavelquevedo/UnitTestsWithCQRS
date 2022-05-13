using MyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyLibNUnit.Test
{
    public class OperationXUnitTest
    {
        [Fact]
        public void Sum_InputTwoNumbers_GetCorrectValue()
        {
            //Arrange
            Operation operation = new();
            int num1 = 4;
            int num2 = 5;

            //Act
            var result = operation.Sum(num1, num2);

            //Assert
            Assert.Equal(9, result);
        }

        [Fact]
        public void IsPairValue_InputPair_ReturnFalse()
        {
            //Arrange
            Operation operation = new();
            int value = 5;

            //Act
            bool isPair = operation.IsPairValue(value);

            //Assert
            Assert.False(isPair);
            //or
            //Assert.That(isPair, Is.EqualTo(false));
        }

        [Fact]
        public void IsPairValue_InputPair_ReturnTrue()
        {
            //Arrange
            Operation operation = new();
            int value = 4;

            //Act
            bool isPair = operation.IsPairValue(value);

            //Assert
            Assert.True(isPair);
            //or
            //Assert.That(isPair, Is.EqualTo(true));
        }

        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(20)]
        public void IsPairValue_InputPairInlineData_ReturnTrue(int value)
        {
            //Arrange
            Operation operation = new();

            //Act
            bool isPair = operation.IsPairValue(value);

            //Assert
            Assert.True(isPair);
            //or
            //Assert.That(isPair, Is.EqualTo(true));
        }

        [Theory]
        [InlineData(7, false)]
        [InlineData(6, true)]
        [InlineData(20, true)]
        public void IsPairValue_InputPair_ReturnTrueWithExpectedResults(int value, bool expectedResult)
        {
            //Arrange
            Operation operation = new();

            //Act
            bool isPair = operation.IsPairValue(value);

            //Assert
            //return isPair == expectedResult;
            Assert.Equal(expectedResult, isPair);
        }


        [Theory]
        [InlineData(2.2, 1.2)] //result 3.4
        [InlineData(1.23, 2.24)] //result 4.47
        public void SumDecimal_InputTwoNumbers_GetCorrectValue(double decimal1, double decimal2)
        {
            //Arrange
            Operation operation = new();

            //Act
            var result = operation.SumDecimal(decimal1, decimal2);

            //Assert
            //Last parameter is to round the decimals
            Assert.Equal(3.4, result, 0);
        }

        [Fact]
        public void GetOddNumbersList_InputMinMaxInterval_ReturnsOddNumbersList()
        {
            //Arrange
            Operation operation = new();
            List<int> oddNumbersExpected = new() { 5, 7, 9 };

            //Act
            List<int> oddNumbersResult = operation.GetOddNumbersList(4, 10);

            //Assert
            Assert.Equal(oddNumbersResult, oddNumbersExpected);
            //Assert.AreEqual(oddNumbersExpected, oddNumbersResult);
            Assert.Contains(5, oddNumbersResult);
            //Assert.Contains(5, oddNumbersResult);
            Assert.NotEmpty(oddNumbersResult);
            Assert.Equal(3, oddNumbersResult.Count);
            Assert.DoesNotContain(100, oddNumbersResult);
            Assert.Equal(oddNumbersResult.OrderBy(u => u), oddNumbersResult);
            //To check if all the items in the collection are unique
            //Assert.That(oddNumbersResult, Is.Unique);
        }

    }
}
