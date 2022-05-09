using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS.Domain.Entities;
namespace BMS.Infra.Repository.LoanModule
{
   public interface ILoanRepository
    {
        Loan ApplyLoan(Loan loan);

        List<Loan> GetAllLoanDetails();
        Loan GetLoan(int loanId);
        Loan GetAllLoanByCustomer(int CustomerId);
    }
}
