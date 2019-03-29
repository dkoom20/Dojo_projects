using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace BrightIdeas.Models
{
 //   public class BigListofIdeas
 //   {
 //       public int LikesCount { get; set; }
//        public Idea CurrIdea { get; set; }

//    }

    public class IdeasDashboardViewModel
    {
//        public List <BigListofIdeas> BigDashboardList { get; set; }
 
        public List<Idea> CurrentIdeas { get; set; }
        public List<int> LikesList { get; set; }

        public User Current_user { get; set; }

        public string text { get; set; }
    }

    public class UserProfileViewModel
    { 
        public User Profiled_user { get; set; }
        public User Current_user { get; set; }
        public int UserPosts { get; set; }
        public int UserLikes { get; set; }
    }
    public class LikeStatusViewModel
    { 
        public List<Likenit> allLikers { get; set; }

        public Idea Selected_idea { get; set; }
        public User Selected_user { get; set; }

    }

//    public class LoginRegViewModel
//    {
//        public LoginUser LogViewModel { get; set; }
//        public RegisterUser RegViewModel { get; set; }

//    }

    public class LoginUser
    {
        [Required]
        [MinLength(7)]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }

    public class RegisterUser
    {
        [Required]
        [MinLength(3)]
        public string name { get; set; }

        [Required]
        [MinLength(1)]
        public string alias { get; set; }

        [Required]
        [MinLength(7)]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "Password and confirmation do not match.")]
        [DataType(DataType.Password)]
        public string pw_confirm { get; set; }
    }
}