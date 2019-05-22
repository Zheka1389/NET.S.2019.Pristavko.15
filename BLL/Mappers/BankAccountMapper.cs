namespace BLL.Mappers
{
    using BLL.Interface.Entities;
    using DAL.Interface.DTO;

    /// <summary>
    /// Implements an adapter for the account.
    /// </summary>
    public static class BankAccountMapper
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
                    Amount = bankAccount.Amount,
                    BonusPoints = bankAccount.BonusPoints,
                    TypeGrading = (int)bankAccount.TypeGrading
                };
        }

        /// <summary>
        /// Represent as an object of BankAccount type.
        /// </summary>
        public static BankAccount ToBankAccount(this Account account)
        {
            return account is null
                ? null
                : new BankAccount(
                account.Id,
                account.OwnerName,
                account.OwnerSurname,
                account.Amount,
                account.BonusPoints,
                (GradingType)account.TypeGrading);
        }
    }
}
