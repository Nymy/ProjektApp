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
                    CloseDate = vm.CloseAuction
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
/*
        // GET: AuctionController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuctionController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
