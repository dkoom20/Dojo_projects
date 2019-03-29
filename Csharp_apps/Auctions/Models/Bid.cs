using System;
using System.ComponentModel.DataAnnotations;


namespace Auctions.Models 
{
    public class Bid
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int auctionid { get; set; }
        public int amount { get; set; }
        public DateTime created_at { get; set; }

    }
}