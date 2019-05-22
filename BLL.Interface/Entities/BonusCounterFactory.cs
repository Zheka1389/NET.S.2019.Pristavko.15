namespace BLL.Interface.Entities
{
    using System;

    /// <summary>
    /// Provides method for getting a bonus counter.
    /// </summary>
    public class BonusCounterFactory
    {
        /// <summary>
        /// Returns a bonus counter by <paramref name="gradingType"/>.
        /// </summary>
        public static BonusCounterType GetBonusCounter(GradingType gradingType)
        {
            switch (gradingType)
            {
                case GradingType.Base:
                    {
                        return new Base();
                    }

                case GradingType.Gold:
                    {
                        return new Gold();
                    }

                case GradingType.Platinum:
                    {
                        return new Platinum();
                    }

                default:
                    {
                        throw new ArgumentException("This type of gradation does not exist.", nameof(gradingType));
                    }
            }
        }
    }
}
