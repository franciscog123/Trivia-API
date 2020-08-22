using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string CategoryString { get; set; }
    }
}
