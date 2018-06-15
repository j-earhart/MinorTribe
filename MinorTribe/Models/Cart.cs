using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinorTribe.Models
{
    public class Cart
    {
        public int Id { get; set; }

        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public virtual Product Products { get; set; }

        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        public virtual Order Orders { get; set; }

    }
}
