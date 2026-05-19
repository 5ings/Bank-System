using BankSystem.Data.Entities;
using BankSystem.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Data
{
    public class BankDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<SystemLog> SystemLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=STUDENT19\\SQLEXPRESS;Database=BankSystemDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(c => c.ClientID);
                entity.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(c => c.LastName).IsRequired().HasMaxLength(50);
                entity.Property(c => c.EGN).IsRequired().HasColumnType("char(10)");
                entity.HasIndex(c => c.EGN).IsUnique();
                entity.Property(c => c.Phone).IsRequired().HasMaxLength(20);
                entity.Property(c => c.Email).IsRequired().HasMaxLength(100);
                entity.HasIndex(c => c.Email).IsUnique();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserID);
                entity.Property(u => u.Username).IsRequired().HasMaxLength(30);
                entity.HasIndex(u => u.Username).IsUnique();
                entity.Property(u => u.PasswordHash).IsRequired().HasMaxLength(255);
                entity.Property(u => u.Role).IsRequired();
                entity.Property(u => u.ClientID).IsRequired(false);
              
                entity.HasOne(u => u.Client)
                      .WithOne(c => c.User)
                      .HasForeignKey<User>(u => u.ClientID)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.AccountID);
                entity.Property(a => a.IBAN).IsRequired().HasColumnType("char(22)");
                entity.HasIndex(a => a.IBAN).IsUnique();
                entity.Property(a => a.Balance).IsRequired().HasPrecision(18, 2);
                entity.Property(a => a.Currency).IsRequired().HasColumnType("char(3)");

                entity.HasOne(a => a.Client)
                      .WithMany(c => c.Accounts)
                      .HasForeignKey(a => a.ClientID)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<BankCard>(entity =>
            {
                entity.HasKey(bc => bc.CardID);
                entity.Property(bc => bc.CardNumber).IsRequired().HasColumnType("char(16)");
                entity.HasIndex(bc => bc.CardNumber).IsUnique();
                entity.Property(bc => bc.CardType).IsRequired();
                entity.Property(bc => bc.ExpiryDate).IsRequired().HasColumnType("char(5)");
                entity.Property(bc => bc.CVV).IsRequired().HasColumnType("char(3)");

                entity.HasOne(bc => bc.Account)
                      .WithMany(a => a.BankCards)
                      .HasForeignKey(bc => bc.AccountID)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.TransactionID);
                entity.Property(t => t.Amount).IsRequired().HasPrecision(18, 2);
                entity.Property(t => t.TransactionType).IsRequired().HasMaxLength(20);
                entity.Property(t => t.TransactionDate).IsRequired();

                entity.HasOne(t => t.Account)
                      .WithMany(a => a.Transactions)
                      .HasForeignKey(t => t.AccountID)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(l => l.LoanID);
                entity.Property(l => l.Amount).IsRequired().HasPrecision(18, 2);
                entity.Property(l => l.RemainingAmount).IsRequired().HasPrecision(18, 2);
                entity.Property(l => l.InterestRate).IsRequired().HasPrecision(5, 2);
                entity.Property(l => l.TermMonths).IsRequired();
                entity.Property(l => l.Status).IsRequired();

                entity.HasOne(l => l.Client)
                      .WithMany(c => c.Loans)
                      .HasForeignKey(l => l.ClientID)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<SystemLog>(entity =>
            {
                entity.HasKey(sl => sl.LogID);
                entity.Property(sl => sl.Action).IsRequired().HasMaxLength(500);
                entity.Property(sl => sl.LogDate).IsRequired();

                entity.HasOne(sl => sl.User)
                      .WithMany(u => u.SystemLogs)
                      .HasForeignKey(sl => sl.UserID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                UserID = 1,
                Username = "admin",
                PasswordHash = "Admin123",
                Role = UserRole.Admin,
                ClientID = null 
            });
        }
    }
}
