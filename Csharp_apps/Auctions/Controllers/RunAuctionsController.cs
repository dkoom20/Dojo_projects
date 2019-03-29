using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Auctions.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Auctions.Controllers
{
    public class RunAuctionsController : Controller
    {
        private AuctionsContext _context;

        public RunAuctionsController(AuctionsContext context)
        {
            _context = context;
        }

         public User Logged_user
        {
            get {return _context.users.SingleOrDefault(u => u.id == (int)HttpContext.Session.GetInt32("UserId"));}
        }


        [HttpGet]
        [Route("GetAuctions")]
        public IActionResult GetAuctions()
        {
            if(Logged_user == null)
            {
                int? CurrUser = HttpContext.Session.GetInt32("UserId");
                
                ModelState.AddModelError("User", "User not logged in");
                return RedirectToAction("Login", "User");
            }

//*************************************************************************
//
//  Update values when an auction ends and is sold
//
//*************************************************************************
            List <Auction> allAuctions = _context.auctions.OrderBy(a => a.ending_at)
                            .Include(auction => auction.creator)
                            .Include(auction => auction.auctionBids)
                            .ToList();

            DateTime currDate = DateTime.Now;
            foreach (Auction a in allAuctions)
            {
                if (currDate < a.ending_at)
                {
                    break;
                }
                else
                {
                    if (a.sold_for == 0)
                    {
                        List <Bid> allBids = _context.bids.Where(b => b.auctionid == a.id).OrderByDescending(b => b.amount).ToList();
                        Bid highBid = new Bid();
                        User highBidder = new User();
                        if(allBids.Count() > 0)    
                        {   
                            highBid = allBids.First();
                            highBidder = _context.users.SingleOrDefault(u => u.id == highBid.userid);

                            highBidder.available_funds = highBidder.available_funds - highBid.amount;
                            _context.users.Update(highBidder);
                            
                            a.creator.available_funds = a.creator.available_funds + highBid.amount;
                            _context.users.Update(a.creator);

                            a.sold_for = highBid.amount;
                            _context.auctions.Update(a);

                            _context.SaveChanges();
                        }
                    }
                } 
            }

//*************************************************************************
//
//  display auctions page
//
//*************************************************************************
            ListAuctionsViewModel viewModel = new ListAuctionsViewModel()
            {
                CurrentAuctions = allAuctions,
                Current_user = Logged_user
            };


            return View("ListAuctions", viewModel);
        }


        [HttpGet]
        [Route("NewAuction")]
        public IActionResult NewAuction()
        {
            if(Logged_user == null)
                return RedirectToAction("Index");
            
            NewAuctionViewModel Viewmodel = new NewAuctionViewModel()
            {
                Current_user = Logged_user,
            };

            return View("NewAuction", Viewmodel);
        }


        [HttpPost]
        [Route("CreateAuction")]
        public IActionResult CreateAuction(NewAuctionViewModel viewModel)
        {
            if(Logged_user == null)
                return RedirectToAction("Index");

            if(viewModel.description == null || viewModel.product == null ||
               viewModel.description == "" || viewModel.product == "" )
            {
                TempData["Error"] = "Product and Description must be entered";
                return RedirectToAction("NewAuction");
            }

            if(viewModel.description.Length < 11)
                TempData["Error"] = " Description must be entered at least 11 characters";

            if(viewModel.product.Length < 4)
                TempData["Error"] = "Product must be at least 4 characters";

            if(viewModel.opening_bid < 1 )
                TempData["Error"] = "An opening bid of 1 or greater is required";

            if(viewModel.opening_bid < 1 ||
               viewModel.product.Length < 4 ||
               viewModel.description.Length < 11)
                return RedirectToAction("NewAuction");


            TimeSpan auctionTime = viewModel.ending_at - DateTime.Now;
            if(auctionTime.TotalDays < 1)
                return RedirectToAction("NewAuction");


            Auction newAuction = new Auction();

            newAuction.creatorid = Logged_user.id;
            newAuction.product = viewModel.product;
            newAuction.description = viewModel.description;
            newAuction.opening_bid = viewModel.opening_bid;
            newAuction.sold_for = 0;

            newAuction.ending_at = viewModel.ending_at;


            newAuction.created_at = DateTime.Now;
            _context.auctions.Add(newAuction);
            _context.SaveChanges();

            return RedirectToAction("GetAuctions");
        }


//==================== Auction Item Detail page =====================
        [HttpGet]
        [Route("GetItem/{auctionid}")]
        public IActionResult GetItem(int auctionid)
        {
            if(Logged_user == null)
                 return RedirectToAction("");

            try
            {
                Auction tryAuction = _context.auctions.Where(a => a.id == auctionid).SingleOrDefault();
            }
            catch (System.Exception)
            {
                 return RedirectToAction("");
            }

            Auction theAuction = _context.auctions.Where(a => a.id == auctionid).SingleOrDefault();
            HttpContext.Session.SetInt32("AuctionId", auctionid);

            List <Bid> allBids = _context.bids.Where(b => b.auctionid == auctionid).OrderByDescending(b => b.amount).ToList();
 
            Bid highBid = new Bid();
            User highBidder = new User();

            if(allBids.Count() == 0)
            {
                highBid.id = 0;
                highBid.userid = 0;
                highBid.auctionid = auctionid;
                highBid.amount = 0;
                highBid.created_at = DateTime.Now;
                highBidder.id = 0;
                highBidder.first_name = "... Nobody has bid yet";
                highBidder.created_at = DateTime.Now;

                Console.WriteLine("=================== BID is NULL ===============================================");
            }
            else
            {
                highBid = allBids.First();
                highBidder = _context.users.SingleOrDefault(u => u.id == highBid.userid);
            }

            AuctionItemViewModel ViewModel = new AuctionItemViewModel()
            {
                Current_user = Logged_user,
                Current_auction = theAuction,
                Current_bid = highBid,
                Current_high_bidder = highBidder,
                Current_creator = _context.users.SingleOrDefault(u => u.id == theAuction.creatorid),
            };

            return View("AuctionItem", ViewModel);
        }


        [HttpGet]
        [Route("DeleteAuction/{auctionId}")]

        public IActionResult DeleteAuction(int auctionId)
        {
            if(Logged_user == null)
                 return RedirectToAction("");

            Auction currAuction = _context.auctions.Where(a => a.id == auctionId).SingleOrDefault();

            _context.auctions.Remove(currAuction);
            _context.SaveChanges();

            return RedirectToAction("GetAuctions");
        }


        [HttpPost]
        [Route("BidItem")]
        public IActionResult BidItem(AuctionItemViewModel ViewModel)
        {
            if(Logged_user == null)
                return RedirectToAction("");    

            Auction theAuction = _context.auctions.Where(a => a.id == (int)HttpContext.Session.GetInt32("AuctionId")).SingleOrDefault();

            int CurrentBid = 0;

            List <Bid> allBids = _context.bids.Where(b => b.auctionid == theAuction.id).OrderByDescending(b => b.amount).ToList();
            Bid highBid = new Bid();

            if(allBids.Count() == 0)
            {
                CurrentBid = 0;
            }
            else
            {
                highBid = allBids.First();
                CurrentBid = highBid.amount;
            }


            if (ModelState.IsValid)
            {
                if (Logged_user.id == theAuction.creatorid)
                {
                    TempData["Error"] = "You cannot bid on your own auction";
                }
                else
                {
                    DateTime currDate = DateTime.Now;
                    if (currDate < theAuction.ending_at &&
                        theAuction.sold_for == 0)
                    {
                        Bid newBid = new Bid();
                        if(ViewModel.amount <= Logged_user.available_funds)
                        {
                            if(ViewModel.amount > 0 && 
                                ViewModel.amount > CurrentBid &&
                                ViewModel.amount >= theAuction.opening_bid)
                            {
                                newBid.userid = Logged_user.id;
                                newBid.auctionid = theAuction.id;
                                newBid.amount = ViewModel.amount;
                                newBid.created_at = DateTime.Now;

                                _context.bids.Add(newBid);
                                _context.SaveChanges();

                                return RedirectToAction("GetAuctions");
                            }
                            else
                            {  
                                TempData["Error"] = "Bid is too low, must be greater than opening bid and current high bid";
                            }
                        }
                        else
                        {  
                            TempData["Error"] = "Bid exceeds your available funds";
                        }
                    }    
                    else
                    {  
                        TempData["Error"] = "Bidding for this Auction has ended";
                    }
                }
            }


            User highBidder = new User();

            if(allBids.Count() == 0)
            {
                highBid.id = 0;
                highBid.userid = 0;
                highBid.auctionid = theAuction.id;
                highBid.amount = 0;
                highBid.created_at = DateTime.Now;
                highBidder.id = 0;
                highBidder.first_name = "... Nobody has bid yet";
                highBidder.created_at = DateTime.Now;

                Console.WriteLine("=================== BID is NULL ===============================================");
            }
            else
            {
                highBid = allBids.First();
                highBidder = _context.users.SingleOrDefault(u => u.id == highBid.userid);
            }

            AuctionItemViewModel reViewModel = new AuctionItemViewModel()
            {
                Current_user = Logged_user,
                Current_auction = theAuction,
                Current_bid = highBid,
                Current_high_bidder = highBidder,
                Current_creator = _context.users.SingleOrDefault(u => u.id == theAuction.creatorid),
            };

            return View("AuctionItem", reViewModel);
        }
    }
}