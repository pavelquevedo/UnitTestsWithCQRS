using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibMS.Test
{
    [TestClass]
    public class OperationMSTest
    {
        [TestMethod]
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
    }
}
