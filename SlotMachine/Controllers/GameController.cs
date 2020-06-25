using Microsoft.AspNetCore.Mvc;
using SlotMachine.Data.Repository;
using SlotMachine.Infrastructure;
using SlotMachine.Models;
using SlotMachine.Services;

namespace SlotMachine.Controllers
{
    public class GameController : Controller
    {
        IBalanceRepository balanceRepository;
        IGameProcessor gameProcessor;

        public GameController(IBalanceRepository balanceRepository, IGameProcessor gameProcessor)
        {
            Validated.NotNull(balanceRepository, nameof(balanceRepository));
            Validated.NotNull(gameProcessor, nameof(gameProcessor));

            this.balanceRepository = balanceRepository;
            this.gameProcessor = gameProcessor;
        }

        [HttpGet]
        public IActionResult Deposit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Deposit(DepositViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            this.balanceRepository.Credit(model.Amount);

            return RedirectToAction(nameof(Bid));
        }

        [HttpGet]
        public IActionResult Bid(BidViewModel model)
        {
            return View();
        }

        [HttpPost]
        [ActionName(nameof(Bid))]
        public IActionResult BidPost(BidViewModel model)
        {
            decimal balance = this.balanceRepository.Balance;

            if (model.Stake > balance)
            {
                ModelState.AddModelError(nameof(model.Stake), "Stake cannot exceed balance.");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            model = this.SetBidViewModel(model.Stake);

            return View(model);
        }

        [HttpGet]
        public IActionResult NewGame()
        {
            this.balanceRepository.Reset();

            return RedirectToAction(nameof(Deposit));
        }

        private BidViewModel SetBidViewModel(decimal stake)
        {
            var model = new BidViewModel();
            model.Stake = stake;

            this.balanceRepository.Debit(model.Stake);

            model.Table = this.gameProcessor.GetTable();
            model.Win = this.gameProcessor.CalculateWin(stake, model.Table);

            this.balanceRepository.Credit(model.Win);

            model.Balance = this.balanceRepository.Balance;
            model.GameOver = this.balanceRepository.GameOver();

            return model;
        }
    }
}
