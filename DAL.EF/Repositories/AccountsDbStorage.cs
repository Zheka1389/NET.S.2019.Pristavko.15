namespace DAL.EF.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DAL.EF.Mappers;
    using DAL.Interface.DTO;
    using DAL.Interface.Interfaces;
    using ORM.Context;
    
    /// <summary>
    /// Provides methods for working with the database.
    /// </summary>
    public class AccountsDbStorage : IRepository
    {
        /// <summary>
        /// The data context.
        /// </summary>
        private readonly BankContext context;

        /// <summary>
        /// Initialize new instance.
        /// </summary>
        public AccountsDbStorage() => this.context = new BankContext();

        /// <summary>
        /// Gets a list of all objects.
        /// </summary>
        public IEnumerable<Account> GetAll() => context.BankAccounts.ToArray().Select(item => item.ToAccount());

        /// <summary>
        /// Gets one object by id.
        /// </summary>
        public Account Get(int id) => context.BankAccounts.FirstOrDefault(item => item.Id == id).ToAccount();

        /// <summary>
        /// Adds new object to storage.
        /// </summary>
        public void Add(Account account)
        {
            context.BankAccounts.Add(account.ToBankAccount());
            context.SaveChanges();
        }

        /// <summary>
        /// Updates the data about the object.
        /// </summary>
        public void Update(Account account)
        {
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).OwnerName = account.OwnerName;
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).OwnerSurname = account.OwnerSurname;
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).Amount = Convert.ToDecimal(account.Amount);
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).BonusPoints = account.BonusPoints;
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).TypeGrading = account.TypeGrading;
            context.SaveChanges();
        }

        /// <summary>
        /// Deletes the data about the object.
        /// </summary>
        public void Delete(Account account)
        {
            context.BankAccounts.Remove(account.ToBankAccount());
            context.SaveChanges();
        }
    }
}
