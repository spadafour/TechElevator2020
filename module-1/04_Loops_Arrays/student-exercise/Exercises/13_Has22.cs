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
         Given an array of ints, return true if the array contains a 2 next to a 2 somewhere.
         Has22([1, 2, 2]) → true
         Has22([1, 2, 1, 2]) → false
         Has22([2, 1, 2]) → false
         */
        public bool Has22(int[] nums)
        {
            bool twoNextTo = false;
            int holder = nums[0];
            for (int i=1; i<nums.Length; i++)
            {
                if (nums[i]==2 && nums[i]==holder)
                {
                    twoNextTo = true;
                }
                holder = nums[i];
            }
            return false;
        }

    }
}
