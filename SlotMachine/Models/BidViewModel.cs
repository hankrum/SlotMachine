using SlotMachine.Data.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace SlotMachine.Models
{
    public class BidViewModel
    {
        public decimal Balance { get; set; }

        public Row[] Table { get; set; }

        [Required(ErrorMessage ="Stake cannot stay blank!")]
        [Range(0, 10000.00, ErrorMessage = "Must be a positive number, less than 10000")]
        public decimal Stake { get; set; }

        public decimal Win { get; set; }

        public bool GameOver { get; set; }
    }
}
