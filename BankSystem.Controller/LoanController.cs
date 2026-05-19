using BankSystem.Data;
using BankSystem.Data.Entities;
using BankSystem.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Controller
{
    public class LoanController
    {
        public async Task CreateLoan(Loan loan)
        {
            using (BankDbContext context = new BankDbContext())
            {
                loan.Status = LoanStatus.Pending;
                await context.Loans.AddAsync(loan);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Loan>> GetPendingLoans()
        {
            using (BankDbContext context = new BankDbContext())
            {
                return await context.Loans
                    .Include(l => l.Client)
                    .Where(l => l.Status == LoanStatus.Pending)
                    .ToListAsync();
            }
        }

        public async Task UpdateLoanStatus(int loanId, LoanStatus newStatus)
        {
            using (BankDbContext context = new BankDbContext())
            {
                var loan = await context.Loans.FirstOrDefaultAsync(l => l.LoanID == loanId);
                if (loan != null)
                {
                    loan.Status = newStatus;
                    if (newStatus == LoanStatus.Approved)
                    {
                        loan.RemainingAmount = loan.Amount;
                    }
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<(decimal TotalGranted, decimal TotalRemaining, int ActiveCount)> GetLoanReport()
        {
            using (BankDbContext context = new BankDbContext())
            {
                var activeLoans = await context.Loans
                    .Where(l => l.Status == LoanStatus.Approved)
                    .ToListAsync();

                decimal totalGranted = activeLoans.Sum(l => l.Amount);
                decimal totalRemaining = activeLoans.Sum(l => l.RemainingAmount);
                int count = activeLoans.Count;

                return (totalGranted, totalRemaining, count);
            }
        }
    }
}
