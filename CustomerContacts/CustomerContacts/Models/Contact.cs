using System.ComponentModel.DataAnnotations;

namespace CustomerContacts.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string FirstName { get; set; }
        [Required, MaxLength (255)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string MobileNumber { get; set; }
    }
}
