using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
