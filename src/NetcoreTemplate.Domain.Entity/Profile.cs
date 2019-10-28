using System;

namespace NetcoreTemplate.Domain.Entity
{
    public class Profile
    {
        public Guid Id { get; set; }
        public ProfileAddress Address { get; set; }
        
        public string UserId { get; set; }
        public User User { get; set; }
        
        public class ProfileAddress
        {
            public Guid Id { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
        }
    }
}