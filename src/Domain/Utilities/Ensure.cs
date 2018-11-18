namespace Domain.Utilities
{
    using System;

    public static class Ensure
    {
        public static void IsInRange<T>(
            T value,
            T min,
            T max,
            string argumentName)
            where T : IComparable
        {
            if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        public static void IsNotNull(object @object, string argumentName)
        {
            if (@object == null)
            {
                throw new ArgumentException(argumentName);
            }
        }
    }
}