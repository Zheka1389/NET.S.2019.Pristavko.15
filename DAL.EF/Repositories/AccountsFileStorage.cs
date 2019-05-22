namespace DAL.EF.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using DAL.Interface.DTO;
    using DAL.Interface.Interfaces;
    
    /// <summary>
    /// Provides methods for working with the data store as a file.
    /// </summary>
    public class AccountsFileStorage : IRepository
    {
        #region Static constructor

        /// <summary>
        /// The static cinstructor to initialize the Path.
        /// </summary>
        static AccountsFileStorage() => Path = AppDomain.CurrentDomain.BaseDirectory + "AccountListStorage.txt";

        #endregion Static constructor

        #region Constructors

        /// <summary>
        /// Initializes a new state.
        /// </summary>
        public AccountsFileStorage(IEnumerable<Account> listAccounts) => this.WriteDataToFile(listAccounts);

        /// <summary>
        /// Initializes a new state.
        /// </summary>
        public AccountsFileStorage()
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The path to the file with the collection of accounts.
        /// </summary>
        public static string Path { get; private set; }

        #endregion Properties

        #region IRepository<Account> implementation

        /// <summary>
        /// Gets a list of all objects.
        /// </summary>
        public IEnumerable<Account> GetAll() => this.ReadDataFromFile();

        /// <summary>
        /// Gets one object by id.
        /// </summary>
        public Account Get(int id)
        {
            var account = this.ReadDataFromFile()
                .ToList()
                .Find(element => element.Id == id);

            if (account is null)
            {
                throw new KeyNotFoundException("Id is not found.");
            }

            return account;
        }

        /// <summary>
        /// Adds new object to file.
        /// </summary>
        public void Add(Account account)
        {
            var listAccounts = this.ReadDataFromFile().ToList();

            if (listAccounts.Exists(element => element.Id == account.Id))
            {
                throw new DuplicateWaitObjectException("This account already exists.");
            }

            listAccounts.Add(account);
            this.AppendDataToFile(account);
        }

        /// <summary>
        /// Updates the data about the object.
        /// </summary>
        public void Update(Account account)
        {
            var listAccounts = this.ReadDataFromFile().ToList();

            var findingAccount = listAccounts.Find(element => element.Id == account.Id);

            if (findingAccount is null)
            {
                throw new KeyNotFoundException("This account is not found.");
            }

            var index = listAccounts.IndexOf(findingAccount);

            listAccounts.Remove(findingAccount);
            listAccounts.Insert(index, account);

            this.WriteDataToFile(listAccounts);
        }

        /// <summary>
        /// Deletes the data about the object.
        /// </summary>
        public void Delete(Account account)
        {
            var listAccounts = this.ReadDataFromFile().ToList();

            var findingAccount = listAccounts.Find(element => element.Id == account.Id);

            if (findingAccount is null)
            {
                throw new KeyNotFoundException("This account is not found.");
            }

            listAccounts.Remove(findingAccount);

            this.WriteDataToFile(listAccounts);
        }

        #endregion IRepository<Account> implementation

        #region Private method for working with file

        private IEnumerable<Account> ReadDataFromFile()
        {
            var listAccounts = new List<Account>();

            var file = new FileStream(Path, FileMode.Open, FileAccess.Read);
            var reader = new BinaryReader(file);

            while (reader.PeekChar() != -1)
            {
                var account = new Account
                {
                    Id = reader.ReadInt32(),
                    OwnerName = reader.ReadString(),
                    OwnerSurname = reader.ReadString(),
                    Amount = reader.ReadDouble(),
                    BonusPoints = reader.ReadInt32(),
                    TypeGrading = reader.ReadInt32()
                };
                listAccounts.Add(account);
            }

            reader.Close();
            file.Close();

            return listAccounts;
        }

        private void WriteDataToFile(IEnumerable<Account> listAccounts)
        {
            if (listAccounts is null)
            {
                throw new ArgumentNullException(nameof(listAccounts));
            }

            var file = new FileStream(Path, FileMode.Create, FileAccess.Write);
            var writer = new BinaryWriter(file);

            foreach (var account in listAccounts)
            {
                writer.Write(account.Id);
                writer.Write(account.OwnerName);
                writer.Write(account.OwnerSurname);
                writer.Write(account.Amount);
                writer.Write(account.BonusPoints);
                writer.Write(account.TypeGrading);
            }

            writer.Close();
            file.Close();
        }

        private void AppendDataToFile(Account account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            var file = new FileStream(Path, FileMode.Append, FileAccess.Write);
            var writer = new BinaryWriter(file);

            writer.Write(account.Id);
            writer.Write(account.OwnerName);
            writer.Write(account.OwnerSurname);
            writer.Write(account.Amount);
            writer.Write(account.BonusPoints);
            writer.Write(account.TypeGrading);

            writer.Close();
            file.Close();
        }

        #endregion Private method for working with file
    }
}
