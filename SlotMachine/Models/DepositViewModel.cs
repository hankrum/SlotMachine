using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SlotMachine.Models
{
    public class DepositViewModel
    {
        [Required]
        [Range(0, 10000.00, ErrorMessage = "Must be a positive number, less than 10000")]
        [Display(Name = "Deposit")]
        public decimal Amount { get; set; }
    }
}
