public static class Sieve
{
    public static int[] Primes(int limit)
    {
        int[] nums = new int[limit - 1];

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                for (int j = 2; j <= limit / (i + 2); j++)
                {
                    int multiple = (i + 2) * j;
                    nums[multiple - 2] = 1;
                }   
            }
        }
        
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
                nums[i] = i + 2;
        }

        return Array.FindAll(nums, num => num != 1);
    }
}