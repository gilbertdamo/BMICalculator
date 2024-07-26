namespace Caribbean.Services.Utilities
{
    public static class UnitConverter
    {
        /// <summary>
        /// Converts a length from centimeters to meters.
        /// </summary>
        /// <param name="centimeters">The length in centimeters.</param>
        /// <returns>The length in meters.</returns>
        public static double CentimetersToMeters(double centimeters)
        {
            return centimeters / 100.0;
        }
    }
}
