namespace BLL.Interface.Entities
{
    /// <summary>
    /// Represents an abstract class for working with the bonus counter.
    /// </summary>
    public abstract class BonusCounterType
    {
        #region Constructor

        /// <summary>
        /// Full constructor to initialize the coefficients.
        /// </summary>
        public BonusCounterType(int coeffCostReplenishment, int coeffCostBalanse)
        {
            this.CoeffCostReplenishment = coeffCostReplenishment;
            this.CoeffCostBalanse = coeffCostBalanse;
        }

        #endregion Constructor

        #region  Properties

        /// <summary>
        /// The coefficient of replenishment used in the replenishment of the account.
        /// </summary>
        public int CoeffCostReplenishment { get; private set; }

        /// <summary>
        /// The balance cost factor used when debiting an account.
        /// </summary>
        public int CoeffCostBalanse { get; private set; }

        #endregion  Properties
    }
}
