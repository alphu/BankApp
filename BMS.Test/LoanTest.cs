using BMS.Api.Controllers;
using BMS.Domain.Entities;
using BMS.Infra.Repository.LoanModule;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Test
{
    public class LoanTest
    {
        private LoanController _loanController;
        private Mock<ILoanRepository> _loanRepository;
        public Customer _customer;
        public Loan _loan;

        [SetUp]
        public void Setup()
        {
            
            _loanRepository = new Mock<ILoanRepository>();
            _loan = new Loan() { CustomerId = 1, LoanType = "Personal", LoanAmount = 200000, LoanDate = DateTime.UtcNow, LoanDuration = 24, ROI = 7 };
        }
        [Test]
        public void ApplyLoan_OkResult()
        {
            // Arrange
            _loanRepository.Setup(x => x.ApplyLoan(_loan));
            var controller = new LoanController(_loanRepository.Object);

            // Act
            var actionResult = controller.CreateLoan(_loan);


            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
        }

        [Test]
        public void GetAllLoanDetails_OkResult()
        {
            // Arrange
            _loanRepository.Setup(x => x.GetAllLoanDetails());
            var controller = new LoanController(_loanRepository.Object);

            // Act
            var actionResult = controller.GetLoanDetails();

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
        }
        [Test]
        public void GetAllLoanById_OkResult()
        {
            // Arrange
            _loanRepository.Setup(x => x.GetLoan(1));
            var controller = new LoanController(_loanRepository.Object);

            // Act
            var actionResult = controller.GetLoan(1);

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
        }
        [Test]
        public void GetAllLoanByCustomer_OkResult()
        {
            // Arrange
            _loanRepository.Setup(x => x.GetAllLoanByCustomer(1));
            var controller = new LoanController(_loanRepository.Object);

            // Act
            var actionResult = controller.GetAllLoanByCustomer(1);

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
        }
    }
}
