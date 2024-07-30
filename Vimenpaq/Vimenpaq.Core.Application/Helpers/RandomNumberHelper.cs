namespace Domex.Core.Application.Helpers
{
    public class RandomNumberHelper
    {
        private static readonly Random _random = new Random();

        public static double GetRandomNumber(int numOrder)
        {
            double minValue = 100;
            double maxValue = numOrder * 1000;

            double randomValue = _random.NextDouble() * (maxValue - minValue) + minValue;

            return Math.Round(randomValue, 2);
        }
    }
}
