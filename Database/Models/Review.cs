using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public virtual Book Bookid { get; set; }
        public string Reviewer { get; set; }

    }
}
