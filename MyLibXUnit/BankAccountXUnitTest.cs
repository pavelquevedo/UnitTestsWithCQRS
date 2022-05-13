using Moq;
using MyLib;
using MyLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyLibNUnit.Test
{
    public class BankAccountXUnitTest
    {
        private BankAccount _bankAccount;

        public BankAccountXUnitTest()
        {
            _bankAccount = new BankAccount(new LoggerGeneral());
        }

        [Fact]
        public void Deposit_InputAmount100LoggerFake_ReturnsTrue()
        {
            var result = _bankAccount.Deposit(100);

            Assert.True(result);
            Assert.Equal(100, _bankAccount.GetBalance());
        }

        [Fact]
        public void Deposit_InputAmount100Mocking_ReturnsTrue()
        {
            //Arrange
            var clientMocking = new Mock<ILoggerGeneral>();
            BankAccount bankAccount = new BankAccount(clientMocking.Object);

            //Act
            var result = bankAccount.Deposit(100);

            //Assert
            Assert.True(result);
            Assert.Equal(100, bankAccount.GetBalance());
        }

        [Theory]
        [InlineData(200, 100)]
        [InlineData(200, 150)]
        public void Withdrawal_InputAmount100WithBalance200Mocking_ReturnsTrue(int balance, int withdrawal)
        {
            //Arrange
            var loggerMock = new Mock<ILoggerGeneral>();
            loggerMock.Setup(m => m.LogDatabase(It.IsAny<string>())).Returns(true);
            loggerMock.Setup(m => m.LogBalanceAfterWithdrawal(It.IsAny<int>())).Returns(true);
            //Or
            //loggerMock.Setup(m => m.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);

            //Act
            BankAccount bankAccount = new BankAccount(loggerMock.Object);
            bankAccount.Deposit(balance);

            var result = bankAccount.Withdrawal(withdrawal);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(200, 300)]
        public void Withdrawal_InputAmount300WithBalance200Mocking_ReturnsFalse(int balance, int withdrawal)
        {
            //Arrange
            var loggerMock = new Mock<ILoggerGeneral>();
            //loggerMock.Setup(m => m.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);
            //Or
            loggerMock.Setup(m => m.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            //Act
            BankAccount bankAccount = new BankAccount(loggerMock.Object);
            bankAccount.Deposit(balance);

            var result = bankAccount.Withdrawal(withdrawal);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void BankAccountLoggerGeneral_LogMocking_ReturnsTrue()
        {
            //Arrange
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string strTest = "hello world";

            loggerGeneralMock.Setup(m => m.MessageReturnsString(It.IsAny<string>())).Returns<string>(str => str.ToLower());

            //Act
            var result = loggerGeneralMock.Object.MessageReturnsString("heLLO World");

            //Assert
            Assert.Equal(result, strTest);
        }

        [Fact]
        public void BankAccountLoggerGeneral_LogMockingOutput_ReturnsTrue()
        {
            //Arrange
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string strTest = "hello";
            string parameterOut = "";

            loggerGeneralMock.Setup(m => m.MessageReturnsStringReturnBool(It.IsAny<string>(), out strTest)).Returns(true);

            //Act
            var result = loggerGeneralMock.Object.MessageReturnsStringReturnBool("Pavel", out parameterOut);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void BankAccountLoggerGeneral_LogMockingRefParam_ReturnsTrue()
        {
            //Arrange
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            Client client = new();
            Client unusedClient = new();

            loggerGeneralMock.Setup(m => m.MessageWithReferenceObjectReturnBool(ref client)).Returns(true);

            //Act
            var result = loggerGeneralMock.Object.MessageWithReferenceObjectReturnBool(ref client);
            //In this case we're passing a different client object which is not configured in the mock setup,
            //so the result should be false
            var result2 = loggerGeneralMock.Object.MessageWithReferenceObjectReturnBool(ref unusedClient);

            //Assert
            Assert.True(result);
            Assert.False(result2);
        }

        [Fact]
        public void BankAccountLoggerGeneral_LogMockingAndTypeProperties_ReturnsTrue()
        {
            //Arrange
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            //It is recommended to put this line after the declaration of the mock
            loggerGeneralMock.SetupAllProperties();

            loggerGeneralMock.Setup(u => u.Type).Returns("Warning");
            //loggerGeneralMock.Setup(u => u.Priority).Returns(10);

            //Act            
            //If you want to change the properties this way, it's necessary to add the line after the mock declaration:
            loggerGeneralMock.Object.Priority = 100;

            //Assert
            Assert.Equal("Warning", loggerGeneralMock.Object.Type);
            Assert.Equal(100, loggerGeneralMock.Object.Priority);

            //Callbacks
            string tempText = "Pavel";
            loggerGeneralMock.Setup(m => m.LogDatabase(It.IsAny<string>()))
                .Returns(true)
                .Callback((string param) =>
                {
                    if (tempText != null)
                    {
                        tempText += param;
                    }
                    else
                    {
                        tempText = string.Empty;
                    }
                });

            var result = loggerGeneralMock.Object.LogDatabase("Quevedo");

            Assert.Equal("PavelQuevedo", tempText);
        }

        [Fact]
        public void BankAccountLogger_VerifyExample()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();

            BankAccount bankAccount = new(loggerGeneralMock.Object);
            bankAccount.Deposit(100);

            Assert.Equal(100, bankAccount.GetBalance());

            //Verify how many times the mock is calling the method Message
            loggerGeneralMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(3));

            //Verify if the text "Test 1" was sent to the method Message at least once
            loggerGeneralMock.Verify(u => u.Message("Test 1"), Times.AtLeastOnce);

            //Verify if a property was set to 100 correctly once
            loggerGeneralMock.VerifySet(u => u.Priority = 100, Times.Once);

            //Verify if the getter of property "Priority" was used during the execution
            loggerGeneralMock.VerifyGet(u => u.Priority, Times.Once);

        }
    }
}
