using MyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyLibNUnit.Test
{

    public class ClientXUnitTest
    {
        private Client client;

        public ClientXUnitTest()
        {
            client = new();
        }

        [Fact]
        public void CreateCompleteName_InputFirstNameLastName_ReturnsCompleteName()
        {
            //Arrange
            //Client client = new();

            //Act 
            string completeName = client.CreateCompleteName("Pavel", "Quevedo");

            //Assert

            Assert.Equal("Pavel Quevedo", completeName);
            //Assert.AreEqual(completeName, "Pavel Quevedo");
            Assert.Contains("Quevedo", completeName);
            Assert.Contains("quevedo", completeName, StringComparison.OrdinalIgnoreCase);
            Assert.StartsWith("Pavel", completeName);
            Assert.EndsWith("Quevedo", completeName);


        }

        [Fact]
        public void CreateCompleteName_NoValues_ReturnsNull()
        {
            //Arrange
            //Client client = new();

            //Act 


            //Assert
            Assert.Null(client.ClientName);
        }

        [Theory]
        [InlineData("Pavel", "Quevedo")]
        public void CreateCompleteName_InputFirstNameLastName_ReturnsNotNull(string firstName, string lastName)
        {
            //Arrange
            //Client client = new();

            //Act 
            client.CreateCompleteName(firstName, lastName);

            //Assert
            Assert.NotNull(client.ClientName);
        }

        [Fact]
        public void DiscountEval_DefaultClient_ReturnsDiscountInterval()
        {
            int discount = client.Discount;

            Assert.InRange(discount, 5, 24);
        }

        [Fact]
        public void CreateCompleteName_InputName_ReturnsNotNull()
        {
            client.CreateCompleteName("Pavel", "");
            Assert.NotNull(client.ClientName);
            Assert.False(string.IsNullOrEmpty(client.ClientName));
        }

        [Fact]
        public void ClientName_InputBlankName_ThrowsException()
        {
            var exceptionDetail = Assert.Throws<ArgumentException>(() =>
                client.CreateCompleteName("", "Quevedo"));
            Assert.Equal("FirstName is blank", exceptionDetail.Message);


            //Assert.That(() => client.CreateCompleteName("", "Quevedo"),
            //    Throws.ArgumentException.With.Message.EqualTo("FirstName is blank"));


            Assert.Throws<ArgumentException>(() => client.CreateCompleteName("", "Quevedo"));
        
        }

        [Fact]
        public void GetClientDetail_CreateClientWithMoreThan500TotalOrder_ReturnClientPremium()
        {
            //Arrange
            client.OrderTotal = 700;

            //Act
            var result = client.GetClientDetail();

            //Assert
            //Assert.That(result, Is.TypeOf<ClientPremium>());
            Assert.IsType<ClientPremium>(result);
        }
    }
}
