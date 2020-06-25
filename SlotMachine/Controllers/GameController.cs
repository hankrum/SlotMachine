using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SlotMachine.Data.Repository;
using SlotMachine.Models;

namespace SlotMachine.Controllers
{
    public class GameController : Controller
    {
        IBalanceRepository balanceRepository;

        public GameController(IBalanceRepository balanceRepository)
        {
            this.balanceRepository = balanceRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Deposit(DepositViewModel model)
        {
            this.balanceRepository.Credit(model.Amount);

            return RedirectToAction(nameof(Bid));
        }

        [HttpGet]
        public IActionResult Bid()
        {
            return View();
        }
    }
}
