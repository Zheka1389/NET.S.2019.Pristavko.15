namespace BLL.Interface.Entities
{
    public class Gold : BonusCounterType
    {
        #region Const fields

        private const int GoldCoeffCostReplenishment = 4;
        private const int GoldCoeffCostBalanse = 5;

        #endregion Const fields

        #region Constractor

        /// <summary>
        /// Initializes the coefficients.
        /// </summary>
        public Gold() : base(GoldCoeffCostReplenishment, GoldCoeffCostBalanse)
        {
        }

        #endregion Constractor
    }
}
