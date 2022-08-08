using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public string Reviewer { get; set; }

    }
}
