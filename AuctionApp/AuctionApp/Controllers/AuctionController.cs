using System;
using AuctionApp.Core;
using AuctionApp.Core.Interfaces;
using AuctionApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace AuctionApp.Controllers
{
    [Authorize]
    public class AuctionController : Controller
    {
        private readonly IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        // GET: AuctionController
        public ActionResult MyAuctions()
        {
           List<Auction> auction = _auctionService.getMyAuctions(User.Identity.Name);
           List<AuctionVM> auctionsVMs = new();

            foreach(var a in auction)
            {
                auctionsVMs.Add(AuctionVM.FromAuction(a));
            }
           return View(auctionsVMs);
        }

        public ActionResult AllAuctions()
        {
            List<Auction> auction = _auctionService.getAllAuctions(User.Identity.Name);
            List<AuctionVM> auctionsVMs = new();

            foreach (var a in auction)
            {
                auctionsVMs.Add(AuctionVM.FromAuction(a));
            }

            return View(auctionsVMs);
        }

        public ActionResult CreateAuction()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAuction(CreateAuctionVM vm)
        {
            if (ModelState.IsValid)
            {
                Auction auction = new Auction()
                {
                    Name = vm.Name,
                    Description = vm.Description,
                    InitialPrice = vm.InitialPrice,
                    Owner = User.Identity.Name
                };
                _auctionService.createAuction(auction);
                return RedirectToAction("MyAuctions");
            }
            return View(vm);
        }

        public ActionResult BidDetails(int id)
        {
            Auction auction = _auctionService.getAuctionBidsById(id);
            if (auction == null) return NotFound();

            AuctionDetailsVM auctionDetailsVM = AuctionDetailsVM.FromAuction(auction);


            return View(auctionDetailsVM);
        }

        public ActionResult EditDescription(AuctionDetailsVM advm)
        {
            ViewData["Id"] = advm.Id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDescription(AuctionVM vm)
        {

            Auction auction = _auctionService.getById(vm.Id);
            if (!auction.Owner.Equals(User.Identity.Name)) return BadRequest("Wrong id");

            _auctionService.editDescription(vm.Description, vm.Id);

             return RedirectToAction("MyAuctions");
        }

        public ActionResult AddBid(AuctionVM vm)
        {
            ViewData["Id"] = vm.Id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBid(BidVM vm)
        {
            Auction auction = _auctionService.getById(vm.Id);
            if (auction.Owner.Equals(User.Identity.Name)) return BadRequest("Wrong id");
           
            else if (vm.BidPrice < auction.HighestBid)
            {
                return BadRequest("Your bid must be higher than the present highest bid");
            }

            Bid bid = new Bid()
            {
                BidPrice = vm.BidPrice,
                UserName = User.Identity.Name
            };

            _auctionService.addBid(bid,vm.Id);

             return RedirectToAction("AllAuctions");
        }

        public ActionResult WonAuctions()
        {

            List<Auction> auction = _auctionService.GetAuctionsWon(User.Identity.Name);
            List<AuctionVM> auctionsVMs = new();

            foreach (var a in auction)
            {
                auctionsVMs.Add(AuctionVM.FromAuction(a));
            }
            return View(auctionsVMs);
        }

        public ActionResult AuctionsBidOn()
        {
            string userName = User.Identity.Name;
            List<Auction> auction = _auctionService.getAuctionsUserBidOn(userName);
            List<AuctionVM> auctionVM = new List<AuctionVM>();
            foreach (Auction a in auction)
            {
                auctionVM.Add(AuctionVM.FromAuction(a));
            }

            return View(auctionVM);
        }
    }
}

