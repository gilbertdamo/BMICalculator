namespace Caribbean.Services.Strategies
{
    public interface IBMICalculationStrategy
    {
        double CalculateBMI(double heightInM, double weightInKg, int? age = null);
    }
}
