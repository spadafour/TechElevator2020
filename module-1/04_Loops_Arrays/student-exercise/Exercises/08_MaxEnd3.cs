using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         Given an array of ints length 3, figure out which is larger between the first and last elements
         in the array, and set all the other elements to be that value. Return the changed array.
         MaxEnd3([1, 2, 3]) → [3, 3, 3]
         MaxEnd3([11, 5, 9]) → [11, 11, 11]
         MaxEnd3([2, 11, 3]) → [3, 3, 3]
         */
        public int[] MaxEnd3(int[] nums)
        {
            int last = nums.Length - 1;
            
            //determine which value (first or last) is larger
            int larger = nums[0] >= nums[last] ? nums[0] : nums[last];
            //iterate through to change to larger value
            for (int i=0; i<nums.Length; i++)
            {
                nums[i] = larger;
            }
            return nums;
        }

    }
}
