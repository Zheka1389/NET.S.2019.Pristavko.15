namespace BLL.Interface.Entities
{
    /// <summary>
    /// Provides a score grading factor Base.
    /// </summary>
    public class Base : BonusCounterType
    {
        #region Const fields

        private const int BaseCoeffCostReplenishment = 2;
        private const int BaseCoeffCostBalanse = 3;

        #endregion Const fields

        #region Constractor

        /// <summary>
        /// Initializes the coefficients.
        /// </summary>
        public Base() : base(BaseCoeffCostReplenishment, BaseCoeffCostBalanse)
        {
        }

        #endregion Constractor
    }
}
