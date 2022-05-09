using BMS.Domain.Entities;
using BMS.Infra.Repository.LoanModule;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class LoanController : ControllerBase
    {
        private readonly ILoanRepository _loanRepository;
        public LoanController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }
        [HttpGet, Route("getloanlist")]
        public IActionResult GetLoanDetails()
        {
            return Ok(_loanRepository.GetAllLoanDetails());
        }
        [HttpPost, Route("applyloan")]
        public IActionResult CreateLoan([FromBody] Loan loan)
        {
            try
            {
                var result = _loanRepository.ApplyLoan(loan);
                return Ok("Successfully Created !!!");
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet, Route("getLoan/{loanId}")]
        public IActionResult GetLoan(int loanId)
        {
            try
            {
                var result = _loanRepository.GetLoan(loanId);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet, Route("getAllLoanByCustomer/{customerId}")]
        public IActionResult GetAllLoanByCustomer(int customerId)
        {
            try
            {
                var result = _loanRepository.GetAllLoanByCustomer(customerId);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
