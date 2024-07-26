namespace Caribbean.Services.Strategies
{
    public class StandardBMICalculationStrategy : IBMICalculationStrategy
    {
        public double CalculateBMI(double heightInM, double weightInKg, int? age = null)
        {
            // Standard BMI calculation
            return weightInKg / (heightInM * heightInM);
        }
    }
}
