namespace Caribbean.Services.Strategies
{
    public class AgeBasedBMICalculationStrategy : IBMICalculationStrategy
    {
        public double CalculateBMI(double heightInM, double weightInKg, int? age = null)
        {
            if (!age.HasValue)
            {
                throw new ArgumentException("Age must be provided for age-based BMI calculation.");
            }

            // This is not the actual age adjustmentfactor.
            // I can't find any official age factor in the internet
            // The same with gender there is no official formula
            double ageAdjustmentFactor = age.Value <= 19 ? 0.95 : 1.05;

            return (weightInKg / (heightInM * heightInM)) * ageAdjustmentFactor;
        }
    }
}
