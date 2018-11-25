namespace Domain.Extensions
{
    public static class Int32Extensions
    {
        /// <summary>
        /// Returns the index of the given integer in the Fibonacci sequence.
        /// </summary>
        /// <remarks>
        /// Ignores the initial 0 and duplicate 1 in the strict interpretation
        /// of the Fibonacci sequence because the grid will compare square
        /// values by value, rather than by sequence position.
        /// </remarks>
        /// <param name="i">The input.</param>
        /// <returns>
        /// The index of the given integer in the Fibonacci sequence, or -1
        /// if i == 0, or not in the Fibonacci sequence.
        /// </returns>
        public static int GetFibonacciIndex(this int i)
        {
            if(i <= 0)
            {
                return -1;
            }

            if(i <= 3)
            {
                return i - 1;
            }

            int lastValue = 0;
            int thisValue = 1;
            int nextValue = 1;
            int result = -1;

            while (nextValue < i)
            {
                nextValue = lastValue + thisValue;

                result++;
                lastValue = thisValue;
                thisValue = nextValue;
            }

            if(nextValue != i)
            {
                return -1;
            }

            return result;
        }
    }
}