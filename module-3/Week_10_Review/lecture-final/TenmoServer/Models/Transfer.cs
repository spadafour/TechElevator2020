using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TenmoServer.Models
{
    public class Transfer
    {
        public int TransferId { get; set; }
        [Required]
        public int AccountTo { get; set; }
        [Required]
        public int AccountFrom { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
