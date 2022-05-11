using Moq;
using MyLib;
using MyLib.Interface;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibNUnit.Test
{
    [TestFixture]
    public class BankAccountNUnitTest
    {
        private BankAccount _bankAccount;

        [SetUp]
        public void SetUp()
        {
            _bankAccount = new BankAccount(new LoggerGeneral());
        }

        [Test]
        public void Deposit_InputAmount100LoggerFake_ReturnsTrue()
        {
            var result = _bankAccount.Deposit(100);

            Assert.IsTrue(result);
            Assert.That(_bankAccount.GetBalance, Is.EqualTo(100));
        }

        [Test]
        public void Deposit_InputAmount100Mocking_ReturnsTrue()
        {
            //Arrange
            var clientMocking = new Mock<ILoggerGeneral>();
            BankAccount bankAccount = new BankAccount(clientMocking.Object);

            //Act
            var result = bankAccount.Deposit(100);

            //Assert
            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }

        [Test]
        [TestCase(200, 100)]
        [TestCase(200, 150)]
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
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(200, 300)]
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
            Assert.IsFalse(result);
        }

        [Test]
        public void BankAccountLoggerGeneral_LogMocking_ReturnsTrue()
        {
            //Arrange
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string strTest = "hello world";

            loggerGeneralMock.Setup(m => m.MessageReturnsString(It.IsAny<string>())).Returns<string>(str => str.ToLower());

            //Act
            var result = loggerGeneralMock.Object.MessageReturnsString("heLLO World");

            //Assert
            Assert.That(result, Is.EqualTo(strTest));
        }

        [Test]
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
            Assert.IsTrue(result);
        }

        [Test]
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
            Assert.IsTrue(result);
            Assert.IsFalse(result2);
        }
    }
}
