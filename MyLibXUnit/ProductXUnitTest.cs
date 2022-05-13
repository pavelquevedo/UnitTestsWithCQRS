using Moq;
using MyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyLibNUnit.Test
{
    public class ProductXUnitTest
    {
        [Fact]
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
            Assert.Equal(40, result);
        }

        [Fact]
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
            Assert.Equal(40, result);
        }
    }
}
