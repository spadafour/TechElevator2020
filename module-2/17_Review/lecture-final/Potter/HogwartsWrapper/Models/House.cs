using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogwartsWrapper.Models
{
    public class House
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string mascot { get; set; }
        public string headOfHouse { get; set; }
        public string houseGhost { get; set; }
        public string founder { get; set; }
        public string school { get; set; }
        public List<string> values { get; set; }
        public List<string> colors { get; set; }
        public List<string> members { get; set; }
    }
}
