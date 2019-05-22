namespace BLL.ServiceImplementation
{
    using System;
    using BLL.Interface.Entities;
    using BLL.Interface.Interfaces;

    public class BonusCounter : IBonusCounter
    {
        #region Fields

        private BonusCounterType bonusCounter;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Inintializes a new instance.
        /// </summary>
        public BonusCounter() => this.bonusCounter = null;

        #endregion Constructor

        #region Public method for getting bonusCounter

        /// <summary>
        /// Install the bonus counter.
        /// </summary>
        public void InstallTypeBonusCounter(GradingType gradingType) => this.bonusCounter = BonusCounterFactory.GetBonusCounter(gradingType);

        #endregion Public method for getting bonusCounter

        #region Public methods to decrease/increase bonus points

        /// <summary>
        /// Increases bonus points depending on the coefficient of replenishment.
        /// </summary>
        public virtual int Increase(int bonusPoints)
        {
            if (this.bonusCounter is null)
            {
                throw new InvalidOperationException("The type of bonus counter is not install.");
            }

            return bonusPoints + this.bonusCounter.CoeffCostReplenishment;
        }

        /// <summary>
        /// Reduces bonus points depending on the value of the balance.
        /// </summary>
        public virtual int Reduction(int bonusPoints)
        {
            if (this.bonusCounter is null)
            {
                throw new InvalidOperationException("The type of bonus counter is not install.");
            }

            return (bonusPoints <= this.bonusCounter.CoeffCostReplenishment)
                ? 0
                : bonusPoints - this.bonusCounter.CoeffCostReplenishment;
        }

        #endregion Public methods to decrease/increase bonus points
    }
}
