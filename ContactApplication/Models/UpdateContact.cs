namespace ContactApplication.Models
{
    public class UpdateContact
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
