using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Auctions.Models
{
    public class User 
    {

        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }

        public int available_funds { get; set; }
        
  //      public List<Withdrawal> Withdrawals { get; set; }
        public DateTime created_at { get; set; }

    }
}