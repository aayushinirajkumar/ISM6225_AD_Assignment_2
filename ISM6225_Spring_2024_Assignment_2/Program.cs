using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // List for storing missing numbers
                List<int> result = new List<int>();

                // First pass: Mark the presence of each number by negating the value at the corresponding index
                for (int i = 0; i < nums.Length; i++)
                {
                    int val = Math.Abs(nums[i]); // Take absolute value in case it's already been negated

                    // Guard condition to avoid Index Out Of Range Exception
                    // Only process values that are in range
                    if (val >= 1 && val <= nums.Length)
                    {
                        int index = val - 1;

                        // Negate the value at that index if it's still positive
                        if (nums[index] > 0)
                        {
                            nums[index] = -nums[index];
                        }
                    }
                }

                // Second pass: Find indices with positive values 
                // Hence, those numbers (index + 1) are missing from the array
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > 0)
                    {
                        result.Add(i + 1); // i + 1 gives the actual number that was missing
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Create separate lists to store even and odd numbers
                List<int> evens = new List<int>();
                List<int> odds = new List<int>();

                // Loop through each element in the array
                foreach (int num in nums)
                {
                    // If the number is even, add it to the evens list
                    if (num % 2 == 0)
                        evens.Add(num);
                    // Otherwise, add it to the odds list
                    else
                        odds.Add(num);
                }

                // Append the odd numbers after the even numbers
                evens.AddRange(odds);

                // Convert the final combined list to an array and return it
                return evens.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Dictionary to store number/index
                Dictionary<int, int> map = new Dictionary<int, int>();

                // Loop through each element in array
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];

                    // If the complement exists, return indices
                    if (map.ContainsKey(complement))
                    {
                        return new int[] { map[complement], i };
                    }

                    // Store current number with its index
                    if (!map.ContainsKey(nums[i]))
                    {
                        map[nums[i]] = i;
                    }
                }

                // If no solution found, return empty array
                return new int[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Sorting array from largest to smallest
                Array.Sort(nums);

                int n = nums.Length;

                // Case 1: Product of largest three numbers
                int product1 = nums[n - 1] * nums[n - 2] * nums[n - 3];

                // Case 2: Product of two smallest and largest number
                int product2 = nums[0] * nums[1] * nums[n - 1];

                // Return the maximum of the two
                return Math.Max(product1, product2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Convert decimal number to binary using base 2
                string binary = Convert.ToString(decimalNumber, 2);

                return binary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0;
                int right = nums.Length - 1;

                // Binary search loop
                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    // If mid is greater than right, min is in the right half
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        // Min is at mid or to the left of mid
                        right = mid;
                    }
                }

                // At the end, left == right and points to the smallest value
                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Negative numbers are not palindromes
                if (x < 0)
                {
                    return false;
                }

                int original = x;
                int reversed = 0;

                // Reverse the number
                while (x != 0)
                {
                    int digit = x % 10;
                    reversed = reversed * 10 + digit;
                    x /= 10;
                }

                // A number is a palindrome if it equals its reversed version
                return original == reversed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Base cases
                if (n == 0) return 0;
                if (n == 1) return 1;

                int a = 0;
                int b = 1;
                int fib = 0;

                // Looping from 2 to n to build Fibonacci value
                for (int i = 2; i <= n; i++)
                {
                    fib = a + b;
                    a = b;
                    b = fib;
                }

                return fib;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
