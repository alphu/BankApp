using BMS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using BMS.Api.Controllers;
using BMS.Infra.Repository.Register;
using BMS.Infra.Repository.LoanModule;
using System;
using BMS.Application;

namespace BMS.Test
{
    public class RegisterTest
    {
        private RegisterController _registerController;
        private Mock<IRegisterRepositroy> _registerRepository;
        private Mock<ILoanRepository> _loanRepository;
        public Customer _customer;
        public Loan _loan;

        [SetUp]
        public void Setup()
        {
            _registerRepository = new Mock<IRegisterRepositroy>();
            _loanRepository = new Mock<ILoanRepository>();
            _customer = new Customer() { Name = "Alphonsa", Username = "alphu", Password = "123", ContactNo = "9747944567", EmailAddress = "alphonsa@gmail.com", Address = "Kochi", Country = "India", State = "Kerala", AccountType = "Savings", DOB = Convert.ToDateTime("10-06-1991"), CreatedDate = DateTime.UtcNow, Pan = "BMPG6085T" };
        }

        [Test]
        public void CreateAccount_OkResult()
        {
            // Arrange
            _registerRepository.Setup(x => x.CreateAccount(_customer));
            var controller = new RegisterController(_registerRepository.Object);

            // Act
            var actionResult = controller.CreateAccount(_customer);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            Assert.IsNotNull(actionResult);
        }

        [TestCase("alp#gmail.com")]
        [TestCase("alp@gmail")]
        [TestCase("alp@gmailcom")]
        public void IsNotValidEmail(string value)
        {
            bool isValid = Validator.IsValidEmail(value);
            Assert.IsFalse(isValid);
        }

        [TestCase("alp@gmail.com")]
        [TestCase("alp@outlook.com")]
        [TestCase("alp@cts.com")]
        public void IsValidEmail(string value)
        {
            bool isValid = Validator.IsValidEmail(value);
            Assert.IsTrue(isValid);
        }

        [TestCase("@3rsgdf")]
        [TestCase("awsdsf")]
        [TestCase("aqswzxcdef")]
        public void IsNotValidPan(string value)
        {
            bool isValid = Validator.IsValidPan(value);
            Assert.IsFalse(isValid);
        }

        [TestCase("BEMPG6085T")]
        public void IsValidPan(string value)
        {
            bool isValid = Validator.IsValidPan(value);
            Assert.IsTrue(isValid);
        }

        [TestCase("Abvcf43ed")]
        [TestCase("1234567890")]
        [TestCase("5647389201")]
        public void IsNotValidPhoneNumber(string value)
        {
            bool isValid = Validator.IsValidMobileNumber(value);
            Assert.IsFalse(isValid);
        }

        [TestCase("9737933456")]
        [TestCase("9747944568")]
        [TestCase("9539644860")]
        public void IsValidPhoneNumber(string value)
        {
            bool isValid = Validator.IsValidMobileNumber(value);
            Assert.IsTrue(isValid);
        }

       
        [Test]
        public void GetAccountDetails_OkResult()
        {
            // Arrange
            _registerRepository.Setup(x => x.GetListofAccounts());
            var controller = new RegisterController(_registerRepository.Object);

            // Act
            var actionResult = controller.GetAccountDetails();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            Assert.IsNotNull(actionResult);
        }

        [Test]
        public void GetAccountDetailsById_OkResult()
        {
            // Arrange
            _registerRepository.Setup(x => x.GetAccount(1));
            var controller = new RegisterController(_registerRepository.Object);

            // Act
            var actionResult = controller.GetAccount(1);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            Assert.IsNotNull(actionResult);
        }
        [Test]
        public void CreateAccount_Throwexception()
        {
            // Arrange
            _customer.EmailAddress = "test#gmail.com";
            _registerRepository.Setup(x => x.CreateAccount(_customer)).Throws(new Exception());
            var controller = new RegisterController(_registerRepository.Object);

            // Assert
            Assert.Throws<Exception>(() => controller.CreateAccount(_customer));
        }
    }
}
