namespace BLL.Interface.Interfaces
{
    using BLL.Interface.Entities;

    /// <summary>
    /// Contains methods for calculating bonuses.
    /// </summary>
    public interface IBonusCounter
    {
        /// <summary>
        /// State the bonus counter.
        /// </summary>
        void InstallTypeBonusCounter(GradingType gradingType);

        /// <summary>
        /// Increases bonus points.
        /// </summary>
        int Increase(int bonusPoints);

        /// <summary>
        /// Reductions bonus points.
        /// </summary>
        int Reduction(int bonusPoints);
    }
}
