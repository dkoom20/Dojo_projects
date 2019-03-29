using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Auctions.Models 
{
    public class Auction
    {
        public int id { get; set; }
        public int creatorid { get; set; }
        public string product { get; set; }
        [Required]
        [MinLength(4)]
        public string description { get; set; }
        [Required]
        [MinLength(11)]
        public int opening_bid { get; set; }
        public int sold_for { get; set; }

        public DateTime ending_at { get; set; }
        public DateTime created_at { get; set; }

        public User creator { get; set; }
        public List<Bid> auctionBids { get; set; }
        public Auction()
        {
            auctionBids = new List<Bid>();
        }

        public string RemainTime 
        {
            get
            {
                TimeSpan remaining = ending_at - DateTime.Now;
                return $"{remaining.Days} Days";
            }
        }

    }
}