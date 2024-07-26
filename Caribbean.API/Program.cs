using Caribbean.Services;
using Caribbean.Services.Services.Validations;
using Caribbean.Services.Strategies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application Services
builder.Services.AddScoped<IBMICalculatorService, BMICalculatorService>();
builder.Services.AddScoped<IBMICalculatorValidationService, BMICalculatorValidationService>();
builder.Services.AddScoped<IBMICalculationStrategy, StandardBMICalculationStrategy>();
builder.Services.AddScoped<IBMICalculationStrategy, AgeBasedBMICalculationStrategy>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
