using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        string? line;
        long validSum = 0;
        while ((line = Console.ReadLine()) != null) // Read until EOF
        {
            if (lineIsValid(line))
            {
                long testValue = long.Parse(line.Split(':')[0]);
                validSum += testValue;
            }
        }
        Console.WriteLine(validSum);
    }

    private static bool lineIsValid(string line)
    {
        string[] parts = line.Split(':');
        long testValue = long.Parse(parts[0]);
        string[] numbers = parts[1].Trim().Split(' ');

        // Convert numbers to longs
        long[] nums = new long[numbers.Length];
        for (long i = 0; i < numbers.Length; i++)
        {
            nums[i] = long.Parse(numbers[i]);
        }

        // Start backtracking
        return Backtrack(nums, 0, nums[0], testValue);
    }

    private static bool Backtrack(long[] nums, long index, long currentResult, long target)
    {
        // Base case: if we've processed all numbers
        if (index == nums.Length - 1)
        {
            //at the end, just return whether our current result is equal to target
            return currentResult == target;
        }

        // Try adding the next number
        if (Backtrack(nums, index + 1, currentResult + nums[index + 1], target))
        {
            return true;
        }

        // Try multiplying the next number
        if (Backtrack(nums, index + 1, currentResult * nums[index + 1], target))
        {
            return true;
        }

        // If neither operation works, backtrack
        return false;
    }
}