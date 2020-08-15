using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class Category
    {
        public Category()
        {
            Question = new HashSet<Question>();
        }

        public int CategoryId { get; set; }
        public string Category1 { get; set; }

        public virtual ICollection<Question> Question { get; set; }
    }
}
