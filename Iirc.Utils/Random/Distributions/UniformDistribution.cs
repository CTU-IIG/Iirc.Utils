namespace Iirc.Utils.Random.Distributions
{
    public class UniformDistribution
    {
        private double minValueInclusive;
        private double maxValueExclusive;
        private System.Random random;

        public UniformDistribution(double minValueInclusive, double maxValueExclusive, System.Random random)
        {
            this.minValueInclusive = minValueInclusive;
            this.maxValueExclusive = maxValueExclusive;
            this.random = random != null ? random : new System.Random();
        }

        public double Sample()
        {
            var randValue = this.random.NextDouble();
            return randValue * (maxValueExclusive - minValueInclusive) + minValueInclusive;
        }
    }
}