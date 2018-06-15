using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinorTribe.Models
{
    public class Order
    {
        public int Id { get; set; }

        
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public virtual Customer Customers { get; set; }

    }
}
