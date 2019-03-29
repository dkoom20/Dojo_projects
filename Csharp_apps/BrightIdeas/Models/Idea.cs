using System;

namespace BrightIdeas.Models
{
    public class Idea 
    {
        public int id { get; set; }
        public int userid { get; set; }
        public string text { get; set; }
        public DateTime created_at { get; set; }
        public User IdeaGuy { get; set; }
    }
}