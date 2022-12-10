﻿namespace ContactApplication.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }    
        public string Email { get; set; }   
        public long PhoneNumber { get; set; }
        public string Address { get; set; } 
        public DateTime CreatedDate { get; set; }

    }
}
