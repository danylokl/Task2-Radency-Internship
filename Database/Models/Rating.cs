using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Rating
    {
        public int Id { get; set; }
       
        public virtual Book BookId { get; set; }
        public double Score { get; set; }

    }
}
