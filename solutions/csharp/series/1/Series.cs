public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (sliceLength > numbers.Length || sliceLength <= 0)
            throw new ArgumentException();

        char[] nums = numbers.ToCharArray();
        string[] slices = new string[nums.Length - sliceLength + 1];
        for (int i = 0; i <= nums.Length - sliceLength; i++)
        {
            for (int j = i; j < i + sliceLength; j++)
            {
                slices[i] += nums[j].ToString(); 
            }
        }

        return slices;
    }
}