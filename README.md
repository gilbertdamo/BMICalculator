# BMI Calculator Solution

## Running the Solution

To run this solution, please make sure the API project is set as the startup project in your IDE. Follow these steps to get the API up and running:

1. **Open the Solution**: Open the solution file (`.sln`) in your IDE (e.g., Visual Studio).

2. **Set the Startup Project**: Right-click on the API project in the Solution Explorer and select "Set as Startup Project."

3. **Build the Solution**: Build the solution to resolve all dependencies.
   ```bash
   dotnet build
4. Run the Solution: Start the API project.
   ```bash
   dotnet run

The API should now be running and accessible at https://localhost:7184 (or another port if configured differently).

## Project Files

This solution is structured into three main layers:

### **API Layer**
- **Description**: Contains the ASP.NET Core API controllers and endpoint configurations.
- **Location**: `Caribbean.API` directory.

### **Service Layer**
- **Description**: Contains the core business logic and service implementations.
- **Location**: `Caribbean.API` directory.

### **Test Layer**
- **Description**: Contains unit tests for the service layer to ensure correctness and reliability.
- **Location**: `Caribbean.Test` directory.

## Design Patterns Used

### **Dependency Injection**
- **Description**: Utilized for managing object creation and dependency management across the application. This allows for easier testing and better separation of concerns.

### **Interfaces for Abstraction**
- **Description**: Interfaces are used to define contracts for service and strategy implementations, promoting flexibility and ease of maintenance.

### **Builder Pattern**
- **Description**: Employed in the `BMIResultModelBuilder` class to construct `BMIResultModel` instances in a step-by-step manner.

### **Strategy Pattern**
- **Description**: Implemented through `AgeBasedBMICalculationStrategy` and `StandardBMICalculationStrategy` to provide different BMI calculation methods based on age inclusion.

### **Factory Pattern**
- **Description**: Utilized in `BMICalculationFactory` to create appropriate BMI calculation strategies based on whether age is considered.

## Example Usage

### **API Endpoint**

- **POST /api/bmi**
  - **Description**: Calculates BMI and provides health status.
  - **Request Body**:
    ```json
    {
      "heightInCm": 175,
      "weightInKg": 70
    }
    ```
  - **Response**:
    ```json
    {
      "bmi": 22.86,
      "healthStatus": "Normal weight"
    }
    ```

## Testing

This project includes unit tests to ensure the correctness and reliability of the service layer. The tests are located in the `YourTestProject` directory and are implemented using [xUnit/NUnit/MSTest] (choose the relevant framework).

### Running Tests

To run the tests, follow these steps:

1. **Open the Solution**: Open the solution file (`.sln`) in your IDE (e.g., Visual Studio).

2. **Set Up Test Project**: Make sure the test project (`Caribbean.Test`) is correctly referenced in the solution.

3. **Run Tests**:
   - **Using Command Line**:
     ```bash
     dotnet test Caribbean.Test.csproj
     ```
   - **Using IDE**: Use the test explorer or runner in your IDE to execute the tests.

### Test Coverage

The tests cover:
- **Validation Logic**: Ensures that height and weight validation works correctly.
- **BMI Calculation**: Verifies the accuracy of BMI calculations with and without age consideration.
- **Health Message**: Checks that the correct health status is returned based on BMI.

### Example Tests

Here are a few examples of the unit tests implemented:

- **Validation Tests**:
  - Test for invalid height values (e.g., zero, negative, unusually large values).
  - Test for invalid weight values (e.g., zero, negative, unusually large values).

- **Calculation Tests**:
  - Test for BMI calculations with standard and age-based strategies.
  - Test for expected BMI results given specific height and weight inputs.

- **Health Message Tests**:
  - Test for correct health status based on various BMI ranges (e.g., underweight, normal weight, overweight, obesity).

For detailed information on the individual tests and their results, refer to the `Caribbean.Test` directory.
