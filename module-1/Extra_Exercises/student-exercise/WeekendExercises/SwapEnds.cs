using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         Given an array of ints, swap the first and last elements in the array. Return the modified array. The array 
         length will be at least 1.
         swapEnds([1, 2, 3, 4]) → [4, 2, 3, 1]
         swapEnds([1, 2, 3]) → [3, 2, 1]
         swapEnds([8, 6, 7, 9, 5]) → [5, 6, 7, 9, 8]
         */
        public int[] SwapEnds(int[] nums)
        {
            int[] swapEnds = new int[nums.Length];
            nums.CopyTo(swapEnds, 0);
            int firstNum = nums[0];
            swapEnds[0] = nums[nums.Length - 1];
            swapEnds[nums.Length - 1] = firstNum;
            return swapEnds;
        }


    }
}
