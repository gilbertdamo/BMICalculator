using Caribbean.API.Model;
using Caribbean.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Caribbean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BMIController : ControllerBase
    {
        private readonly IBMICalculatorService _bmiCalculatorService;

        // Constructor injection of the BMI service
        public BMIController(IBMICalculatorService bmiCalculatorService)
        {
            _bmiCalculatorService = bmiCalculatorService;
        }

        // POST api/bmi
        [HttpPost]
        public IActionResult CalculateBMI([FromBody] BMICalculationRequest request)
        {
            try
            {
                // Call the BMI service to get the BMI result
                var result = _bmiCalculatorService.GetBMIDetails(request.HeightInCm, request.WeightInKg);

                // Return the result as a JSON response
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                // Handle validation errors and return a BadRequest response
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Handle other exceptions and return an InternalServerError response
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
