namespace DAL.Interface.Interfaces
{
    using System.Collections.Generic;
    using DAL.Interface.DTO;
    
    /// <summary>
    /// Contains methods for working with data from account.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Gets a list of all objects.
        /// </summary>
        IEnumerable<Account> GetAll();

        /// <summary>
        /// Gets one object by id.
        /// </summary>
        Account Get(int id);

        /// <summary>
        /// Adds new object to storage.
        /// </summary>
        void Add(Account account);

        /// <summary>
        /// Updates the data about the object.
        /// </summary>
        void Update(Account account);

        /// <summary>
        /// Deletes the data about the object.
        /// </summary>
        void Delete(Account account);
    }
}
