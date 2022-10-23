using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektApp.Core;
using ProjektApp.Core.Interfaces;
using ProjektApp.ViewModels;

namespace ProjektApp.Controllers
{
    [Authorize]
    public class AuctionController : Controller
    {
        private readonly IAuctionService _auctionService;

        public AuctionController( IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        // GET: AuctionController1
        public ActionResult Index()
        {
            List<Auction> auctions = _auctionService.GetAuctions();
            List<AuctionVM> auctionVMs = new();
            foreach(var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }

        // GET: AuctionController1/GetMyBids
        public ActionResult GetMyBids()
        {

            List<Auction> auctions = _auctionService.GetMyBids(User.Identity.Name);
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }

        // GET: AuctionController1/GetMyWinningBids
        public ActionResult GetMyWinningBids()
        {

            List<Auction> auctions = _auctionService.GetMyWinningBids(User.Identity.Name);
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }


        // GET: AuctionController1/Details/5
        public ActionResult Details(int id)
        {
            Auction auction = _auctionService.GetById(id);
            AuctionDetailsVM detailsVM = AuctionDetailsVM.FromAuction(auction);
            return View(detailsVM);
        }

        
        // GET: AuctionController1/Create
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: AuctionController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAuctionVM vm)
        {
            if (ModelState.IsValid)
            {
                Auction auction = new Auction()
                {
                    Title = vm.Title,
                    Description = vm.Description,
                    LowestPrice = vm.LowestPrice,
                    CloseDate = vm.CloseAuction,
                    UserName = User.Identity.Name,
                    
                };
                _auctionService.Add(auction);
                return RedirectToAction("Index");
            }
            return View(vm);
        }
     
        // GET: AuctionController1/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: AuctionController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditAuctionVM vm)
        {   
            Auction auction1 = _auctionService.GetById(id);
            if (!auction1.UserName.Equals(User.Identity.Name)) return BadRequest();

            if (ModelState.IsValid)
            {
                Auction auction = new Auction()
                {
                    Description = vm.Description,
                };
           
                EditAuctionVM edit = EditAuctionVM.FromAuction(auction);
                auction.Description = edit.Description;
                _auctionService.Edit(auction, id);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: AuctionController1/Create
        public ActionResult Bid()
        {
            return View();
        }

        // POST: AuctionController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Bid(CreateBidVM vm, int id)
        {
            if (ModelState.IsValid)
            {
                Auction auction = _auctionService.GetById(id);
                Bid newBid = new Bid()
                {
                    Name = User.Identity.Name,
                    BidAmount = vm.BidAmount,
                    AuctionId = id
                };
                _auctionService.AddBid(newBid, auction);
                return RedirectToAction("Index");
            }
            return View(vm);
        }
    }
}
