namespace Fedex.Core.Application.Helpers
{
    public class RandomNumberHelper
    {
        private static readonly Random _random = new Random();

        public static double GetRandomNumber(double minValue = 100, double maxValue = 2000)
        {
            double randomValue = _random.NextDouble() * (maxValue - minValue) + minValue;

            return Math.Round(randomValue, 2);
        }
    }
}
