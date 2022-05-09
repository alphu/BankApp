using BMS.Infra.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS.Domain.Entities;

namespace BMS.Infra.Repository.LoanModule
{
    public class LoanRepository:ILoanRepository
    {
        public BankDBContext _dbcontext;
        public ILogger<LoanRepository> _logger;
        public LoanRepository(BankDBContext dbcontext, ILogger<LoanRepository> logger)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }
        public Loan ApplyLoan(Loan loan)
        {
            try
            {
                if (IsCustomerIdExists(loan.CustomerId))
                {
                    _dbcontext.Loan.Add(loan);
                    _dbcontext.SaveChanges();
                    return loan;
                }
                throw new Exception("Customer Id doesn't exists");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                if (_dbcontext != null)
                    _dbcontext.Dispose();
            }
        }
        public bool IsCustomerIdExists(int id)
        {
            try
            {
                bool isExist = _dbcontext.Customer.Where(x => x.Id == id).Any();
                return isExist;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
           
        }
        public List<Loan> GetAllLoanDetails()
        {
            try
            {
                var Loans =_dbcontext.Loan?.ToList();
                return Loans;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                if (_dbcontext != null)
                    _dbcontext.Dispose();
            }
        }
        public Loan GetLoan(int loanId)
        {
            try
            {
                var data = _dbcontext.Loan
                    .Where(b => b.LoanId == loanId)
                    .FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            finally
            {
                if (_dbcontext != null)
                    _dbcontext.Dispose();
            }
        }
        public Loan GetAllLoanByCustomer(int CustomerId)
        {
            try
            {
                var data = _dbcontext.Loan
                    .Where(b => b.CustomerId == CustomerId)
                    .FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            finally
            {
                if (_dbcontext != null)
                    _dbcontext.Dispose();
            }
        }
    }
}
