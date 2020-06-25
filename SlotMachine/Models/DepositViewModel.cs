using System;
using System.ComponentModel.DataAnnotations;

namespace SlotMachine.Models
{
    public class DepositViewModel
    {
        [Required(ErrorMessage = "Deposit cannot stay blank!")]
        [Range(0, 10000.00, ErrorMessage = "Must be a positive number, less than 10000")]
        [Display(Name = "Deposit")]
        public decimal Amount { get; set; }
    }
}
