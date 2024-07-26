using Caribbean.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caribbean.Services.Services.Validations
{
    public interface IBMICalculatorValidationService
    {
        ValidationResult ValidateHeight(double height);
        ValidationResult ValidateWeight(double weight);
    }

    public class BMICalculatorValidationService : IBMICalculatorValidationService
    {
        public ValidationResult ValidateHeight(double height)
        {
            if (height <= 0)
            {
                return new ValidationResult(false, "Height must be greater than zero.");
            }
            if (height > 2.5)
            {
                return new ValidationResult(false, "Height is unusually large. Please enter a valid value.");
            }
            return new ValidationResult(true);
        }

        public ValidationResult ValidateWeight(double weight)
        {
            if (weight <= 0)
            {
                return new ValidationResult(false, "Weight must be greater than zero.");
            }
            if (weight > 300)
            {
                return new ValidationResult(false, "Weight is unusually large. Please enter a valid value.");
            }
            return new ValidationResult(true);
        }
    }
}
