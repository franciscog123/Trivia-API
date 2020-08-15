using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class User
    {
        public User()
        {
            Quiz = new HashSet<Quiz>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TotalScore { get; set; }

        public virtual ICollection<Quiz> Quiz { get; set; }
    }
}
