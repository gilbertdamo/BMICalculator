using Caribbean.Services;
using Caribbean.Services.Services.Validations;
using System.ComponentModel.DataAnnotations;

namespace Caribbean.Test
{
    public class BMICalculatorServiceTests
    {
        private readonly BMICalculatorService _service;

        public BMICalculatorServiceTests()
        {
            _service = new BMICalculatorService(new BMICalculatorValidationService());
        }

        // Test for invalid height
        [Theory]
        [InlineData(-1, 70, "Height must be greater than zero.")]
        [InlineData(0, 70, "Height must be greater than zero.")]
        [InlineData(300, 70, "Height is unusually large. Please enter a valid value.")]
        public void GetBMIDetails_InvalidHeight_ShouldReturnValidationError(double heightInCm, double weightInKg, string expectedMessage)
        {
            // Act & Assert
            var exception = Assert.Throws<ValidationException>(() => _service.GetBMIDetails(heightInCm, weightInKg));
            Assert.Equal(expectedMessage, exception.Message);
        }

        // Test for invalid weight
        [Theory]
        [InlineData(160, -1, "Weight must be greater than zero.")]
        [InlineData(160, 0, "Weight must be greater than zero.")]
        [InlineData(160, 400, "Weight is unusually large. Please enter a valid value.")]
        public void GetBMIDetails_InvalidWeight_ShouldReturnValidationError(double heightInCm, double weightInKg, string expectedMessage)
        {
            // Act & Assert
            var exception = Assert.Throws<ValidationException>(() => _service.GetBMIDetails(heightInCm, weightInKg));
            Assert.Equal(expectedMessage, exception.Message);
        }

        // Test for valid BMI and health message
        [Theory]
        [InlineData(160, 60, 23.4, "Normal weight")] // Example data
        [InlineData(175, 70, 22.9, "Normal weight")]
        [InlineData(150, 50, 22.2, "Normal weight")]
        [InlineData(160, 45, 17.6, "Underweight")]
        [InlineData(160, 80, 31.2, "Obesity")]
        public void GetBMIDetails_ValidInputs_ShouldReturnExpectedResult(double heightInCm, double weightInKg, double expectedBmi, string expectedHealthStatus)
        {
            // Act
            var result = _service.GetBMIDetails(heightInCm, weightInKg);

            // Assert
            Assert.Equal(expectedBmi, result.Bmi, 1); // Compare with precision of 1 decimal place
            Assert.Equal(expectedHealthStatus, result.HealthStatus);
        }
    }
}
