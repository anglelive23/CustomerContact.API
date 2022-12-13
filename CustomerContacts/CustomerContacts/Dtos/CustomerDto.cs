namespace CustomerContacts.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public ContactDto Contact { get; set; }
        public int ContactId { get; set; }
    }
}
