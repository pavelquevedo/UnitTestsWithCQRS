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
    public class ClientNUnitTest
    {
        private Client client; 

        [SetUp]
        public void Setup()
        {
            client = new();
        }

        [Test]
        public void CreateCompleteName_InputFirstNameLastName_ReturnsCompleteName()
        {
            //Arrange
            //Client client = new();

            //Act 
            string completeName = client.CreateCompleteName("Pavel", "Quevedo");

            //Assert
            Assert.That(completeName, Is.EqualTo("Pavel Quevedo"));
            Assert.AreEqual(completeName, "Pavel Quevedo");
            Assert.That(completeName, Does.Contain("Quevedo"));
            Assert.That(completeName, Does.Contain("quevedo").IgnoreCase);
            Assert.That(completeName, Does.StartWith("Pavel"));
            Assert.That(completeName, Does.EndWith("Quevedo"));
        }

        [Test]
        public void CreateCompleteName_NoValues_ReturnsNull()
        {
            //Arrange
            //Client client = new();

            //Act 


            //Assert
            Assert.IsNull(client.ClientName);
        }

        [Test]
        [TestCase("Pavel","Quevedo")]
        public void CreateCompleteName_InputFirstNameLastName_ReturnsNotNull(string firstName, string lastName)
        {
            //Arrange
            //Client client = new();

            //Act 
            client.CreateCompleteName(firstName, lastName);

            //Assert
            Assert.IsNotNull(client.ClientName);
        }
    }
}
