using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinorTribe.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string City { get; set; }

        [Display(Name = "State")]
        [ForeignKey("State")]
        public int StateId { get; set; }

        //foregin key defined
        public virtual State States { get; set; }
        //End: Foreign Key --------------------

    }
}
