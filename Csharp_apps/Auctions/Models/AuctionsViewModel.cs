using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Auctions.Models
{
    public class ListAuctionsViewModel
    {
        public List<Auction> CurrentAuctions { get; set; }

        public User Current_user { get; set; }

 //       public Bid Current_bid { get; set; }
 //       public User Auction_creator { get; set; }


    }

    public class AuctionItemViewModel
    { 
        [Required]
        public int amount { get; set; }
        public Bid Current_bid { get; set; }
        public User Current_user { get; set; }

        public Auction Current_auction { get; set; }

        public User Current_high_bidder { get; set; }
        public User Current_creator { get; set; }


    }
    public class NewAuctionViewModel
    { 
        [Required]
        [MinLength(4)]
        public string product { get; set; }
         
        [Required]
        [MinLength(11)]
        public string description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ending_at { get; set; }

        [Required]
        public int opening_bid { get; set; }

        public User Current_user { get; set; }

    }
    public class LoginViewModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(19)]
        public string username { get; set; }
        
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(19)]
        public string username { get; set; }
        
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password { get; set; }
        
        [Required]
        [Compare("password", ErrorMessage = "Password and confirmation do not match.")]
        [DataType(DataType.Password)]
        public string pw_confirm { get; set; }

        [Required]
        [MinLength(2)]
        public string first_name { get; set; }
        
        [Required]
        [MinLength(2)]
        public string last_name { get; set; }
    }

}