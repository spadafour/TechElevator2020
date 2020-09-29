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
         Given an int array length 3, if there is a 2 in the array immediately followed by a 3, set the 3 element to 0. 
         Return the changed array.
         fix23([1, 2, 3]) → [1, 2, 0]
         fix23([2, 3, 5]) → [2, 0, 5]
         fix23([1, 2, 1]) → [1, 2, 1]
         */
        public int[] Fix23(int[] nums)
        {
            int[] fix23 = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                fix23[i] = nums[i];
            }

            for (int i = 0; i < fix23.Length - 1; i++)
            {
                if (fix23[i] == 2 && fix23[i + 1] == 3)
                {
                    fix23[i + 1] = 0;
                }
            }

            return fix23;
        }
    }
}
