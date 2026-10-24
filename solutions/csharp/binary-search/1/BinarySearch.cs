public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        int i = 0;
        int j = input.Length - 1;
        
        while (i <= j)
        {
            int midpoint = (i + j) / 2;
            
            if(input[midpoint] == value)
                return midpoint;
            else if (input[midpoint] < value)
                i = midpoint + 1;
            else
                j = midpoint - 1;
        }

        return -1;
    }
}