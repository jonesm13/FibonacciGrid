namespace Domain.Extensions
{
    public static class Int32Extensions
    {
        public static int FibonacciIndex(this int i)
        {
            if (i <= 1)
            {
                return i;
            }

            int a = 0, b = 1, c = 1;
            int res = 1;

            while (c < i)
            {
                c = a + b;

                res++;
                a = b;
                b = c;
            }

            return res;
        }
    }
}
