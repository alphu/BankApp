using BMS.Domain.Entities;
using BMS.Infra.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS.Application;
namespace BMS.Infra.Repository.Register
{
    public class RegisterRepositroy : IRegisterRepositroy
    {
        private readonly ILogger _logger;
        private readonly BankDBContext _dbcontext;
        public RegisterRepositroy(BankDBContext dbcontext, ILogger<RegisterRepositroy> logger)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }
        public Customer CreateAccount(Customer customer)
        {
            try
            {
                if (!Validator.IsValidEmail(customer.EmailAddress))
                    throw new Exception("Email Address is not valid.");
                if (!Validator.IsValidPan(customer.Pan))
                    throw new Exception("Pan Number is not valid.");
                if (!Validator.IsValidMobileNumber(customer.ContactNo))
                    throw new Exception("Phone Number is not valid.");

                customer.CreatedDate = DateTime.UtcNow;
                _dbcontext.Customer.Add(customer);
                _dbcontext.SaveChanges();
                _logger.LogInformation("Data saved in the DB");
                return customer;
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

        public List<Customer> GetListofAccounts()
        {
            try
            {
                var data = _dbcontext.Customer.ToList();
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
        public Customer GetAccount(int accountNo)
        {
            try
            {
                var data = _dbcontext.Customer
                    .Where(b => b.Id == accountNo)
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
