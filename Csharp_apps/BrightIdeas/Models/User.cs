using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrightIdeas.Models
{
    public class User 
    {
        public int id { get; set; }

        public string name { get; set; }

        public string alias { get; set; }

        public string email { get; set; }

        public string password { get; set; }
        
        public DateTime created_at { get; set; }

    }
}