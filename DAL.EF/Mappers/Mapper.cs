namespace DAL.EF.Mappers
{
    using System;
    using DAL.Interface.DTO;
    using ORM.Entities;
    
    /// <summary>
    /// Implements an adapter for the account.
    /// </summary>
    public static class Mapper
    {
        /// <summary>
        /// Represent as an object of Account type.
        /// </summary>
        public static Account ToAccount(this BankAccount bankAccount)
        {
            return bankAccount is null
                ? null
                : new Account()
                {
                    Id = bankAccount.Id,
                    OwnerName = bankAccount.OwnerName,
                    OwnerSurname = bankAccount.OwnerSurname,
                    Amount = Convert.ToDouble(bankAccount.Amount),
                    BonusPoints = bankAccount.BonusPoints,
                    TypeGrading = bankAccount.TypeGrading
                };
        }

        /// <summary>
        /// Represent as an object of BankAccount type.
        /// </summary>
        public static BankAccount ToBankAccount(this Account account)
        {
            return account is null
                ? null
                : new BankAccount()
                {
                    Id = account.Id,
                    OwnerName = account.OwnerName,
                    OwnerSurname = account.OwnerSurname,
                    Amount = Convert.ToDecimal(account.Amount),
                    BonusPoints = account.BonusPoints,
                    TypeGrading = account.TypeGrading
                };
        }
    }
}
