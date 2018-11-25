namespace Domain.Extensions
{
    public static class ArrayBuilder
    {
        public static int[,] BuildSquareArray(
            int dimension,
            int initialValue)
        {
            int[,] result = new int[dimension, dimension];
            for(int r = 0; r < dimension; r++)
            {
                for(int c = 0; c < dimension; c++)
                {
                    result[r, c] = initialValue;
                }
            }

            return result;
        }
    }
}