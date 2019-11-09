using System;

namespace NetcoreTemplate.Domain.Entity
{
    public class Profile
    {
        public Guid Id { get; set; }
        
        public string UserId { get; set; }
        public User User { get; set; }
    }
}