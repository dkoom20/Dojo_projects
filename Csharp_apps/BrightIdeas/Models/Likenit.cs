using System;
using System.Collections.Generic;

namespace BrightIdeas.Models
{
    public class Likenit
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int ideaid { get; set; }
        public DateTime created_at { get; set; }
        public User Liker { get; set; }
 
    }
}