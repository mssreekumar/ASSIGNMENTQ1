using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1_Summer2021
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Q1 : Enter the Moves of Robot:");
            string moves = Console.ReadLine();
            bool pos = JudgeCircle(moves);
            if (pos)
            {
                Console.WriteLine("The Robot return’s to initial Position (0,0)");
            }
            else
            {
                Console.WriteLine("The Robot doesn’t return to the Initial Postion (0,0)");
            }

            Console.WriteLine();

            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s = Console.ReadLine();
            bool flag = CheckIfPangram(s);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:

            int[] arr = { 1, 2, 3, 1, 1, 3 };
            int gp = NumIdenticalPairs(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("The number of IdenticalPairs in the array are {0}:", gp);


            //Question 4:
            int[] arr1 = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4:");
            int pivot = PivotIndex(arr1);
            if (pivot > 0)
            {
                Console.WriteLine("The Pivot index for the given array is {0}", pivot);
            }
            else
            {
                Console.WriteLine("The given array has no Pivot index");
            }
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            Console.WriteLine("Enter the First Word:");
            String word1 = Console.ReadLine();
            Console.WriteLine("Enter the Second Word:");
            String word2 = Console.ReadLine();
            String merged = MergeAlternately(word1, word2);
            Console.WriteLine("The Merged Sentence fromed by both words is {0}", merged);


            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            string sentence = Console.ReadLine();
            string goatLatin = ToGoatLatin(sentence);
            Console.WriteLine("Goat Latin for the Given Sentence is {0}", goatLatin);
            Console.WriteLine();

        }

        /* 
<summary>
/// Input: moves = "UD"
/// Output: true
/// Explanation: The robot moves up once, and then down once. All moves have the same ///magnitude, so it ended up at the origin where it started. Therefore, we return true.
</summary>
<retunrs>true/False</returns>
*/
        private static bool JudgeCircle(string moves)
        {
            try
            {
                int[] freq = new int[4];
                foreach (char ch in moves)
                    freq[ch == 'L' ? 0 : ch == 'R' ? 1 : ch == 'U' ? 2 : ch == 'D' ? 3 : 0]++;
                return ((freq[0] == freq[1]) && (freq[2] == freq[3]));
                return false;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /* 
 <summary>
A pangram is a sentence where every letter of the English alphabet appears at least once.
Given a string sentence containing only lowercase English letters, return true if sentence is a pangram, or false otherwise.
Example 1:
Input: sentence = "thequickbrownfoxjumpsoverthelazydog"
Output: true
Explanation: sentence contains at least one of every letter of the English alphabet.
</summary>
</returns> true/false </returns>
Note: Use of String function (Contains) and hasmap is not allowed, think of other ways how you could the numbers be represented
        */


        private static bool CheckIfPangram(string s)
        {
            try
            {
                bool CheckIfPangram(string sentence)
                {
                    HashSet<char> h = new HashSet<char>();

                    foreach (char c in sentence)
                    {
                        if (!h.Contains(c))
                        {
                            h.Add(c);
                        }
                    }


                    return h.Count() == 26;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }

        }


        /*

 <summary> 
 Given an array of integers nums 
 A pair (i,j) is called good if nums[i] == nums[j] and i < j.
 Return the number of good pairs.
 Example:
 Input: nums = [1,2,3,1,1,3]
 Output: 4
 Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
   return type  : int
 </summary>
 <returns>int </returns>
     */

        private static int NumIdenticalPairs(int[] arr)
        {
            try
            {
                //Using nested loops to identify the good pairs. Each number is compared to numbers with higher index,
                //if they are matching counter will be incremented.
                int count = 0;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[i] == arr[j])
                        {
                            count++;
                        }
                    }
                }
                return count;

            }
            catch (Exception)
            {

                throw;
            }
        }






        /*

          <summary>


          <summary>
   Given an array of integers nums, calculate the pivot index of this array.The pivot index is the index where the sum of all the numbers strictly to the left of  the index is equal to the sum of all the numbers strictly to the index's right.
  If the index is on the left edge of the array, then the left sum is 0 because there are no elements to the left. This also applies to the right edge of the array.
  Return the leftmost pivot index. If no such index exists, return -1.
  Example 1:
  Input: nums = [1,7,3,6,5,6]
         Output : 3


      Explanation:
  The pivot index is 3.
  Left sum = nums[0] + nums[1] + nums[2] = 1 + 7 + 3 = 11
  Right sum = nums[4] + nums[5] = 5 + 6 = 11
          /// </summary>
          /// <param name="nums"></param>
          /// <returns>Number the index in the array</returns>
      */
        private static int PivotIndex(int[] nums)
        {
            try
            {
                 static int PivotIndex(int[] nums)
                {
                    //if the array length is 1, then the sum of left and right subarrays is already equal (to 0)
                    if (nums.Length == 1)
                        return 0;

                    //array length
                    int numsLength = nums.Length;
                    //left pointer
                    int leftIndex = 0;
                    //sum of numbers of left subarray
                    int leftSum = 0;
                    //total sum of numbers in the array
                    int totalSum = 0;

                    //find the total sum
                    foreach (int i in nums)
                    {
                        totalSum += i;
                    }

                    //iterate over the array
                    while (leftIndex < numsLength)
                    {
                        //before adding a number to the leftSum, check if subtracting from totalSum would make leftSum==totalSum (meaning this is the index to return)
                        if ((totalSum - nums[leftIndex]) == leftSum)
                            return leftIndex;
                        //otherwise, add it to leftSum and subtract it from totalSum
                        leftSum += nums[leftIndex];
                        totalSum -= nums[leftIndex++];
                    }

                    return -1;

                }
                return 0;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

        /*
            /// <summary>
    /// You are given two strings word1 and word2. Merge the strings by adding letters /// in alternating order, starting with word1. If a string is longer than the other,
    /// append the additional letters onto the end of the merged string.
    /// Example 1
    /// Input: word1 = "abc", word2 = "pqr"
    /// Output: "apbqcr"
    /// Explanation: The merged string will be merged as so:
    /// word1:  a   b   c
    /// word2:    p   q   r
    /// merged: a p b q c r
    /// </summary>
           /// <param name="word1"></param>
    ///<param name="word2"></param>
           /// <returns>return the merged string </returns>

    */


        private static string MergeAlternately(string word1, string word2)
        {
            try
            {
                //both words are split into char arrays then, each character is appended into StringBuilder one after the other.
                int temp = 0;
                if (word1.Length > word2.Length)
                {
                    temp = word1.Length;
                }
                else
                {
                    temp = word2.Length;
                }
                char[] w1 = word1.ToCharArray();
                char[] w2 = word2.ToCharArray();
                StringBuilder output = new StringBuilder();

                for (int i = 0; i < temp; i++)
                {
                    if (i < w1.Length)
                    {
                        output.Append(w1[i]);
                    }
                    if (i < w2.Length)
                    {
                        output.Append(w2[i]);
                    }
                }

                return output.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        /*


        /*
        <summary>
    /// A sentence sentence is given, composed of words separated by spaces. Each word consists of lowercase and uppercase letters only.
    We would like to convert the sentence to "Goat Latin" (a made-up language similar to Pig Latin.)
    The rules of Goat Latin are as follows:
    1)	If a word begins with a vowel (a, e, i, o, or u), append "ma" to the end of the word.
    For example, the word 'apple' becomes 'applema'.

    2)	If a word begins with a consonant (i.e. not a vowel), remove the first letter and append it to the end, then add "ma".
    For example, the word "goat" becomes "oatgma".

    3)	Add one letter 'a' to the end of each word per its word index in the sentence, starting with 1.
    For example, the first word gets "a" added to the end, the second word gets "aa" added to the end and so on.
    Hint : think of a string function to divide the sentence on white spaces
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns> string</returns>
       */
        private static string ToGoatLatin(string sentence)
        {
            try
            {
                // write your code here.
                return "null";

            }
            catch (Exception)
            {

                throw;
            }


        }


    }
}



