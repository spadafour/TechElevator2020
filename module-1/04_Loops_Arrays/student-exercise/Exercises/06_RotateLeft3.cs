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
         Given an array of ints length 3, return an array with the elements "rotated left" so {1, 2, 3}
         yields {2, 3, 1}.
         RotateLeft3([1, 2, 3]) → [2, 3, 1]
         RotateLeft3([5, 11, 9]) → [11, 9, 5]
         RotateLeft3([7, 0, 0]) → [0, 0, 7]
         */
        public int[] RotateLeft3(int[] nums)
        {
            //new array to hold new order
            int[] rotate = new int[nums.Length];
            //set last int in new array to the first in old array
            rotate[rotate.Length-1] = nums[0];
            //for loop to set the rest
            for (int i=0; i<nums.Length-1; i++)
            {
                rotate[i] = nums[i + 1];
            }
            return rotate;
        }

    }
}
