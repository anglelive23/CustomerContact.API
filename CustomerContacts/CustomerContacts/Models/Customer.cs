using System.ComponentModel.DataAnnotations;

namespace CustomerContacts.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public Contact Contact { get; set; }

        public int ContactId { get; set; }
    }
}
