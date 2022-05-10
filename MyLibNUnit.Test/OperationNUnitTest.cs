using MyLib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibNUnit.Test
{
    [TestFixture]
    public class OperationNUnitTest
    {
        [Test]
        public void Sum_InputTwoNumbers_GetCorrectValue()
        {
            //Arrange
            Operation operation = new();
            int num1 = 4;
            int num2 = 5;

            //Act
            var result = operation.Sum(num1, num2);

            //Assert
            Assert.AreEqual(9, result);
        }

        [Test]
        public void IsPairValue_InputPair_ReturnFalse()
        {
            //Arrange
            Operation operation = new();
            int value = 5;

            //Act
            bool isPair = operation.IsPairValue(value);

            //Assert
            Assert.IsFalse(isPair);
            //or
            Assert.That(isPair, Is.EqualTo(false));
        }

        [Test]
        public void IsPairValue_InputPair_ReturnTrue()
        {
            //Arrange
            Operation operation = new();
            int value = 4;

            //Act
            bool isPair = operation.IsPairValue(value);

            //Assert
            Assert.IsTrue(isPair);
            //or
            Assert.That(isPair, Is.EqualTo(true));
        }

        [Test]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(20)]
        public void IsPairValue_InputPair_ReturnTrue(int value)
        {
            //Arrange
            Operation operation = new();

            //Act
            bool isPair = operation.IsPairValue(value);

            //Assert
            Assert.IsTrue(isPair);
            //or
            Assert.That(isPair, Is.EqualTo(true));
        }

        [Test]
        [TestCase(7, ExpectedResult = false)]
        [TestCase(6, ExpectedResult = true)]
        [TestCase(20, ExpectedResult = true)]
        public bool IsPairValue_InputPair_ReturnTrueWithExpectedResults(int value)
        {
            //Arrange
            Operation operation = new();

            //Act
            bool isPair = operation.IsPairValue(value);

            //Assert
            return isPair;
        }


        [Test]
        [TestCase(2.2, 1.2)]
        [TestCase(5.8, 3.2)]
        public void SumDecimal_InputTwoNumbers_GetCorrectValue(double decimal1, double decimal2)
        {
            //Arrange
            Operation operation = new();

            //Act
            var result = operation.SumDecimal(decimal1, decimal2);

            //Assert
            Assert.AreEqual(9, result);
        }

    }
}
