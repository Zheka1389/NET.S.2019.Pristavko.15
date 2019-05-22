namespace BLL.Interface.Interfaces
{
    using System.Collections.Generic;
    using BLL.Interface.Entities;
    
    public interface IBankAccountService
    {
        /// <summary>
        /// Gets a list of all objects.
        /// </summary>
        IEnumerable<BankAccount> GetAll();

        /// <summary>
        /// Opens a new bank account.
        /// </summary>
        void Open(string ownerName, string ownerSurname, double amount, GradingType gradingType);

        /// <summary>
        /// Closes a bank account.
        /// </summary>
        void Close(int id);

        /// <summary>
        /// Refills a bank account with the account.
        /// </summary>
        void Refill(int id, double amount);

        /// <summary>
        /// Withdrawals from the bank account.
        /// </summary>
        void Withdrawal(int id, double amount);
    }
}
