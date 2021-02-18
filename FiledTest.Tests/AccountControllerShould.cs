using FiledTest.Controllers;
using FiledTest.Dtos;
using FiledTest.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace FiledTest.Tests
{
    public class AccountControllerShould
    {
        private readonly Mock<ICheapPaymentGateway> _cheapPaymentRepoMock = new Mock<ICheapPaymentGateway>();
        private readonly Mock<IExpensivePaymentGateway> _expensivePaymentRepoMock = new Mock<IExpensivePaymentGateway>();
        private readonly AccountController _sut;

        public AccountControllerShould()
        {
            _sut = new AccountController(_cheapPaymentRepoMock.Object, _expensivePaymentRepoMock.Object);
        }
        [Test]
        public async Task ProcessCheapValidPayment()
        {
            //Arrange
            var paymentModel = new PaymentDto
            {
                CreditCardNumber = "1234 5678 1234 5670",
                CardHolder = "Jennifer Lawrence",
                ExpirationDate = DateTime.Now,
                SecurityCode = "451",
                Amount = 11.50M
            };
            _cheapPaymentRepoMock.Setup(x => x.ProcessCheapPaymentAsync(paymentModel)).ReturnsAsync(true);
            //Act
            var result = await _sut.ProcessPayment(paymentModel) as OkResult;
            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task ProcessExpensiveValidPayment()
        {
            //Arrange
            var paymentModel = new PaymentDto
            {
                CreditCardNumber = "1234567812345670",
                CardHolder = "Vin Diesel",
                ExpirationDate = DateTime.Now.AddYears(5),
                SecurityCode = "222",
                Amount = 250M
            };
            _cheapPaymentRepoMock.Setup(x => x.ProcessCheapPaymentAsync(paymentModel)).ReturnsAsync(true);
            //Act
            var result = await _sut.ProcessPayment(paymentModel) as OkResult;
            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}