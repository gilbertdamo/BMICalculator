using Caribbean.Services.Strategies;

namespace Caribbean.Services.Factories
{
    public class BMICalculationFactory
    {
        public static IBMICalculationStrategy CreateBMICalculationStrategy(bool includeAge)
        {
            return includeAge ? new AgeBasedBMICalculationStrategy() : new StandardBMICalculationStrategy();
        }
    }
}
