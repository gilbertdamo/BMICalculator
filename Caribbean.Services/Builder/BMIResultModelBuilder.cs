using Caribbean.Services.Model;

namespace Caribbean.Services.Builder
{
    public class BMIResultModelBuilder
    {
        private readonly BMIResultModel _bMIResultModel = new BMIResultModel();

        public BMIResultModelBuilder SetBmi(double bmi)
        {
            _bMIResultModel.Bmi = Math.Round(bmi, 1);
            return this;
        }

        public BMIResultModelBuilder SetHealthStatus(string status)
        {
            _bMIResultModel.HealthStatus = status;
            return this;
        }

        public BMIResultModel Build()
        {
            return _bMIResultModel;
        }
    }
}
