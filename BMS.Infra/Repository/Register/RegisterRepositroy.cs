using BMS.Domain.Entities;
using BMS.Infra.Data;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                //if (!Utility.IsValidEmail(customer.EmailAddress))
                //    throw new AppException("Email Address is not valid.");
                //if (!Utility.IsValidPan(customer.Pan))
                //    throw new AppException("Pan Number is not valid.");
                //if (!Utility.IsValidMobileNumber(customer.ContactNo))
                //    throw new AppException("Phone Number is not valid.");

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
    }
}
