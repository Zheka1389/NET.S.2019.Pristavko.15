namespace BLL.ServiceImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BLL.Interface.Entities;
    using BLL.Interface.Interfaces;
    using BLL.Mappers;
    using DAL.Interface.Interfaces;
    
    /// <summary>
    /// Provides methods for working with a bank accounts list.
    /// </summary>
    public class BankAccountService : IBankAccountService
    {
        #region Fields

        private IGenerator generator;
        private IRepository repository;
        private IBonusCounter bonusCounter;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new state of the object.
        /// </summary>
        public BankAccountService(IRepository repository, IGenerator generator, IBonusCounter bonusCounter)
        {
            this.Repository = repository;
            this.Generator = generator;
            this.BonusCounter = bonusCounter;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets and sets id geterator. 
        /// </summary>
        private IGenerator Generator
        {
            get => this.generator;

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.generator = value;
            }
        }

        /// <summary>
        /// Gets and sets objects of BankAccount type.
        /// </summary>
        private IRepository Repository
        {
            get => this.repository;

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.repository = value;
            }
        }

        /// <summary>
        /// The bonus counter.
        /// </summary>
        private IBonusCounter BonusCounter
        {
            get => this.bonusCounter;

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.bonusCounter = value;
            }
        }

        #endregion Properties

        #region IBankAccountService implementation

        /// <summary>
        /// Gets a list of all objects.
        /// </summary>
        public IEnumerable<BankAccount> GetAll() => this.Repository.GetAll().Select(item => item.ToBankAccount());

        /// <summary>
        /// Opens a new bank account.
        /// </summary>
        public void Open(string ownerName, string ownerSurname, double amount, GradingType gradingType)
        {
            var id = this.Generator.GenerateId();

            var bankAccount = new BankAccount(id, ownerName, ownerSurname, 0, 0, gradingType);

            this.BonusCounter.InstallTypeBonusCounter(bankAccount.TypeGrading);

            bankAccount.Amount += amount;
            bankAccount.BonusPoints = this.BonusCounter.Increase(bankAccount.BonusPoints);

            this.Repository.Add(bankAccount.ToAccount());
        }

        /// <summary>
        /// Closes a bank account.
        /// </summary>
        public void Close(int id)
        {
            BankAccount bankAccount = this.GetAll().FirstOrDefault(element => element.Id == id);

            if (bankAccount is null)
            {
                throw new KeyNotFoundException("Id is not found.");
            }

            this.Repository.Delete(bankAccount.ToAccount());
        }

        /// <summary>
        /// Refills a bank account with the account.
        /// </summary>
        public void Refill(int id, double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount is not be negative.", nameof(amount));
            }

            var bankAccount = this.GetAll().FirstOrDefault(element => element.Id == id);

            if (bankAccount is null)
            {
                throw new KeyNotFoundException("Id is not found.");
            }

            this.BonusCounter.InstallTypeBonusCounter(bankAccount.TypeGrading);

            bankAccount.Amount += amount;
            bankAccount.BonusPoints = this.BonusCounter.Increase(bankAccount.BonusPoints);

            this.Repository.Update(bankAccount.ToAccount());
        }

        /// <summary>
        /// Withdrawals from the bank account.
        /// </summary>
        public void Withdrawal(int id, double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount is not be negative.", nameof(amount));
            }

            var bankAccount = this.GetAll().FirstOrDefault(element => element.Id == id);

            if (bankAccount is null)
            {
                throw new KeyNotFoundException("Id is not found.");
            }

            this.BonusCounter.InstallTypeBonusCounter(bankAccount.TypeGrading);

            bankAccount.Amount -= amount;
            bankAccount.BonusPoints = this.BonusCounter.Reduction(bankAccount.BonusPoints);

            this.Repository.Update(bankAccount.ToAccount());
        }

        #endregion IBankAccountService implementation
    }
}
