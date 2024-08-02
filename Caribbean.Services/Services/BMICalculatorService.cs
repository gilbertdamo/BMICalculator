using Caribbean.Services.Builder;
using Caribbean.Services.Factories;
using Caribbean.Services.Model;
using Caribbean.Services.Services.Validations;
using Caribbean.Services.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Caribbean.Services
{
    public interface IBMICalculatorService
    {
        /// <summary>
        /// Calculates the Body Mass Index (BMI) and provides a detailed result based on the given height and weight.
        /// Optionally includes age in the BMI calculation if provided.
        /// </summary>
        /// <param name="heightInCm">The height of the individual in centimeters.</param>
        /// <param name="age">The age of the individual. If provided, determines whether age-based BMI calculation is used.</param>
        /// <returns>A <see cref="BMIResultModel"/> containing the calculated BMI and corresponding health status.</returns>
        /// <exception cref="ValidationException">Thrown if height or weight validation fails.</exception>
        BMIResultModel GetBMIDetails(double heightInCm, double weightInKg);
    }

    public class BMICalculatorService : IBMICalculatorService
    {
        private readonly IBMICalculatorValidationService _bMICalculatorValidationService;
        public BMICalculatorService(IBMICalculatorValidationService bMICalculatorValidationService)
        {
                _bMICalculatorValidationService = bMICalculatorValidationService;
        }

        /// <summary>
        /// Calculates the Body Mass Index (BMI) and provides a detailed result based on the given height and weight.
        /// Optionally includes age in the BMI calculation if provided.
        /// </summary>
        /// <param name="heightInCm">The height of the individual in centimeters.</param>
        /// <param name="weightInKg">The weight of the individual in kilograms.</param>
        /// <returns>A <see cref="BMIResultModel"/> containing the calculated BMI and corresponding health status.</returns>
        /// <exception cref="ValidationException">Thrown if height or weight validation fails.</exception>
        public BMIResultModel GetBMIDetails(double heightInCm, double weightInKg)
        {
            var heightInM = UnitConverter.CentimetersToMeters(heightInCm);

            // validations
            ValidateHeight(heightInM);
            ValidateWeight(weightInKg);

            // For demonstration purpose a factory is created if age or gender is a factor for formula
            var strategy = BMICalculationFactory.CreateBMICalculationStrategy(false);

            var bmi = strategy.CalculateBMI(heightInM, weightInKg);

            return new BMIResultModelBuilder()
                .SetBmi(bmi)
                .SetHealthStatus(GetHealthMessage(bmi))
                .Build();
        }

        /// <summary>
        /// Determines the health status based on the given BMI value.
        /// </summary>
        /// <param name="bmi">The Body Mass Index value to evaluate.</param>
        /// <returns>A string representing the health status based on the BMI value.
        /// Possible values are:
        /// - "Underweight" if BMI is less than 18.5
        /// - "Normal weight" if BMI is between 18.5 and 24.9
        /// - "Overweight" if BMI is between 25.0 and 29.9
        /// - "Obesity" if BMI is 30.0 or higher</returns>
        public string GetHealthMessage(double bmi)
        {
            if (bmi < 18.5)
                return "Underweight";
            if (bmi < 24.9)
                return "Normal weight";
            if (bmi < 29.9)
                return "Overweight";
            return "Obesity";
        }

        private void ValidateHeight(double height)
        {
            var result = _bMICalculatorValidationService.ValidateHeight(height);
            if (!result.IsValid)
            {
                throw new ValidationException(result.ErrorMessage);
            }
        }

        private void ValidateWeight(double weight)
        {
            var result =_bMICalculatorValidationService.ValidateWeight(weight);
            if (!result.IsValid)
            {
                throw new ValidationException(result.ErrorMessage);
            }
        }

    }
}
