using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         Given an int array length 2, return true if it does not contain a 2 or 3.
         no23([4, 5]) → true
         no23([4, 2]) → false
         no23([3, 5]) → false
         */
        public bool No23(int[] nums)
        {
            bool no23 = !nums.Contains(2) && !nums.Contains(3);
            return no23;
        }
    }
}
