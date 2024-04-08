/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/


using System.Text;


namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length == 0)
                    return 0; // If the array is null or empty, there are no unique elements, so return 0.

                int uniqueCount = 1; // Start the unique count at 1 because the first element is always considered unique.

                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] != nums[i - 1]) // If the current element is different from the previous one...
                        nums[uniqueCount++] = nums[i]; // Store the current element in the next unique position in the array.
                }

                return uniqueCount; // Return the count of unique elements.

            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // Check if the input array is null or has only one element
                if (nums == null || nums.Length <= 1)
                    return nums.ToList(); // Return the array as a List if it meets the condition

                // Sort the array in ascending order
                Array.Sort(nums);

                // Create a new array to store the sorted elements with zeros moved to the end
                int[] result = new int[nums.Length];

                // Variable to count the number of zeros encountered
                int c = 0;

                // Variable to keep track of the index in the result array
                int j = 0;

                // Loop through each element in the sorted array
                for (int i = 0; i < nums.Length; i++)
                {
                    // If the current element is zero, increment the count of zeros
                    if (nums[i] == 0)
                        c++;
                    else
                    {
                        // If the current element is not zero, place it in the result array
                        result[j] = nums[i];
                        j++;
                    }
                }

                // After moving all non-zero elements to the beginning of the result array,
                // fill the remaining positions with zeros based on the count of zeros encountered
                while (c != 0)
                {
                    result[j] = 0;
                    c--;
                    j++;
                }

                // Convert the result array to a List and return it
                return result.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Create a list to store lists of integer triplets that sum up to zero
                IList<IList<int>> result = new List<IList<int>>();

                // Sort the input array in ascending order
                Array.Sort(nums);

                // Iterate through the array elements, leaving space for at least two more elements
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // If the current element is not the first occurrence of its value and is equal to the previous element, skip it
                    if (i > 0 && nums[i] == nums[i - 1])
                        continue;

                    // Iterate through the array elements, leaving space for at least one more element
                    for (int j = i + 1; j < nums.Length - 1; j++)
                    {
                        // If the current element is not the first occurrence of its value after i and is equal to the previous element, skip it
                        if (j > i + 1 && nums[j] == nums[j - 1])
                            continue;

                        // Iterate through the array elements
                        for (int k = j + 1; k < nums.Length; k++)
                        {
                            // If the current element is not the first occurrence of its value after j and is equal to the previous element, skip it
                            if (k > j + 1 && nums[k] == nums[k - 1])
                                continue;

                            // If the sum of the current triplet equals zero, add it to the result list
                            if (nums[i] + nums[j] + nums[k] == 0)
                            {
                                result.Add(new List<int> { nums[i], nums[j], nums[k] });
                            }
                        }
                    }
                }

                // Return the list of integer triplets
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                // Initialize variables to keep track of the maximum consecutive count of 1s and a counter variable
                int maxCount = 0;
                int c = 0;

                // Iterate through each element in the array nums
                foreach (int value in nums)
                {
                    // If the current element is 1, increment the counter
                    if (value == 1)
                        c += 1;
                    else
                    {
                        // If the current element is not 1, update the maxCount with the current count (if greater) and reset the counter
                        maxCount = Math.Max(maxCount, c);
                        c = 0;
                    }
                }

                // After looping through all elements, update the maxCount with the final count (if greater)
                maxCount = Math.Max(maxCount, c);

                // Return the maximum consecutive count of 1s
                return maxCount;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                // Initialize variables to store the decimal equivalent and the length of the binary number
                int dec = 0;
                int length = binary.ToString().Length;

                // Iterate through each digit of the binary number
                for (int i = 0; i < length; i++)
                {
                    // Extract the rightmost digit of the binary number
                    int rem = binary % 10;

                    // If the extracted digit is 1, add the corresponding decimal value to the result
                    if (rem == 1)
                        dec += (int)Math.Pow(2, i);

                    // Remove the rightmost digit from the binary number
                    binary /= 10;
                }

                // Return the decimal equivalent of the binary number
                return dec;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                // Sort the input array in ascending order
                Array.Sort(nums);

                // Initialize variables to keep track of the maximum gap and the current difference between adjacent elements
                int maxGap = 0;
                int diff = 0;

                // Check if the array has more than one element
                if (nums.Length > 1)
                {
                    // Iterate through the array starting from the second element
                    for (int i = 1; i < nums.Length; i++)
                    {
                        // Calculate the difference between the current element and the previous element
                        diff = nums[i] - nums[i - 1];

                        // Update the maximum gap if the current difference is greater
                        if (maxGap < diff)
                            maxGap = diff;
                    }
                }

                // Return the maximum gap between adjacent elements in the sorted array
                return maxGap;

            }

            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // Sort the input array in ascending order
                Array.Sort(nums);

                // Iterate through the sorted array starting from the end
                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    // Check if the current element can form a triangle with the two preceding elements
                    if (nums[i] < nums[i - 1] + nums[i - 2])
                        // If a valid triangle is found, return the sum of its elements
                        return nums[i] + nums[i - 1] + nums[i - 2];
                }

                // If no valid triangle is found, return 0
                return 0;


            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Continue until there are no more occurrences of 'part' in 's'
                while (s.Contains(part))
                {
                    // Find the index of the leftmost occurrence of 'part' in 's'
                    int index = s.IndexOf(part);

                    // Remove 'part' from 's' starting at the found index
                    s = s.Remove(index, part.Length);
                }

                return s;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}