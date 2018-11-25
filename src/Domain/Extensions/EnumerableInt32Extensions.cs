namespace Domain.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumerableInt32Extensions
    {
        public static bool IsIncrementingSequence(this IEnumerable<int> input)
        {
            if(input == null)
            {
                throw new ArgumentNullException();
            }

            int[] inputAsArray = input.ToArray();

            if(inputAsArray.Length <= 1)
            {
                return false;
            }

            int thisValue = inputAsArray[0];

            for(int i = 1; i < inputAsArray.Length; i++)
            {
                if(inputAsArray[i] != thisValue + 1)
                {
                    return false;
                }

                thisValue = inputAsArray[i];
            }

            return true;
        }
    }
}