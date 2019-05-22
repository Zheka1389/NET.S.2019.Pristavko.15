namespace ORM.Context
{
    using System.Data.Entity;
    using ORM.Entities;   

    /// <summary>
    /// The class context for interacting with the database.
    /// </summary>
    public class BankContext : DbContext
    {
        /// <summary>
        /// Initialize new context.
        /// </summary>
        public BankContext()
            : base("Bank")
        {
        }

        /// <summary>
        /// Get and set bank accounts from the database.
        /// </summary>
        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}
