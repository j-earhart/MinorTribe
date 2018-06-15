using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinorTribe.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }

        [Display(Name = "State")]
        [ForeignKey("States")]
        public int StateId { get; set; }
        public virtual State States { get; set; }

        [Display(Name = "City")]
        public string City{ get; set; }
        
       
        

    }
}
