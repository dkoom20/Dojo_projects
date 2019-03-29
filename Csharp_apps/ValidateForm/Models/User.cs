using System.ComponentModel.DataAnnotations;
 
namespace ValidateForm.Models
{
    public class User
    {
        [Required]
        [MinLength(4)]
        public string FirstName { get; set; }
        
        [Required]
        [MinLength(4)]
        public string LastName { get; set; }
 
        [Required]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required]
        [Range(0,111)]
        public int Age { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}