namespace BLL.Interface.Entities
{
    using System;

    /// <summary>
    /// Provides properties and methods for working with the account.
    /// </summary>
    public class BankAccount
    {
        #region Fields

        private int id;
        private string ownerName;
        private string ownerSurname;
        private double amount;
        private int bonusPoints;
        private GradingType typeGrading;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Inintializes a new instance.
        /// </summary>
        public BankAccount(int id, string ownerName, string ownerSurname, double amount, int bonusPoints, GradingType gradingType)
        {
            this.Id = id;
            this.OwnerName = ownerName;
            this.OwnerSurname = ownerSurname;
            this.Amount = amount;
            this.BonusPoints = bonusPoints;
            this.TypeGrading = gradingType;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// A bank account id.
        /// </summary>
        public int Id
        {
            get => this.id;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                this.id = value;
            }
        }

        /// <summary>
        /// Name of bank account holder.
        /// </summary>
        public string OwnerName
        {
            get => this.ownerName;

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.ownerName = value;
            }
        }

        /// <summary>
        /// Surname of bank account holder.
        /// </summary>
        public string OwnerSurname
        {
            get => this.ownerSurname;

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.ownerSurname = value;
            }
        }

        /// <summary>
        /// The amount on the bank account.
        /// </summary>
        public double Amount
        {
            get => this.amount;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                this.amount = value;
            }
        }

        /// <summary>
        /// Bonus points on the bank account.
        /// </summary>
        public int BonusPoints
        {
            get => this.bonusPoints;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                this.bonusPoints = value;
            }
        }

        /// <summary>
        /// Type of bank account graduation.
        /// </summary>
        public GradingType TypeGrading
        {
            get => this.typeGrading;

            set
            {
                if (value == 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                this.typeGrading = value;
            }
        }

        #endregion Properties

        #region Overridden methods

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is null
                ? false
                : ReferenceEquals(this, obj) ? true : obj.GetType() != this.GetType() ? false : this.Equals((BankAccount)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        public bool Equals(BankAccount other)
        {
            return other is null
                ? false
                : ReferenceEquals(this, other)
                ? true
                : this.Id.Equals(other.id)
                && this.OwnerName.Equals(other.OwnerName)
                && this.OwnerSurname.Equals(other.OwnerSurname)
                && this.Amount.Equals(other.Amount)
                && this.BonusPoints.Equals(other.BonusPoints)
                && this.TypeGrading.Equals(other.TypeGrading);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        public override string ToString() => $"Id: {Id};\nOwnerName: {OwnerName};\nOwnerSurname: {OwnerSurname};\nAmount: {Amount};\nBonusPoints: {BonusPoints};\nTypeGrading: {TypeGrading}.";

        /// <summary>
        /// Serves as the  hash function.
        /// </summary>
        public override int GetHashCode()
        {
            var hashcode = this.Id.GetHashCode();
            hashcode = (11 * hashcode) + this.OwnerName.GetHashCode();
            hashcode = (11 * hashcode) + this.OwnerSurname.GetHashCode();
            hashcode = (11 * hashcode) + this.Amount.GetHashCode();
            hashcode = (11 * hashcode) + this.BonusPoints.GetHashCode();
            hashcode = (11 * hashcode) + this.TypeGrading.GetHashCode();
            return hashcode;
        }

        #endregion Overridden methods  
    }
}
