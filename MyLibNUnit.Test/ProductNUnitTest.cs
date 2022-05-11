using Moq;
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
    public class ProductNUnitTest
    {
        [Test]
        public void GetPrice_PremiumClient_ReturnsPrice80()
        {
            //Arrange
            Product product = new()
            {
                Price = 50
            };

            //Act
            var result = product.GetPrice(new Client { IsPremium = true });

            //Assert
            Assert.That(result, Is.EqualTo(40));
        }

        [Test]
        public void GetPrice_PremiumClientMock_ReturnsPrice80()
        {
            //Arrange
            Product product = new()
            {
                Price = 50
            };
            var client = new Mock<IClient>();
            client.Setup(c => c.IsPremium).Returns(true);

            //Act
            var result = product.GetPrice(client.Object);

            //Assert
            Assert.That(result, Is.EqualTo(40));
        }
    }
}
