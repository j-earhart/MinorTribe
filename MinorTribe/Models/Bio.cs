using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinorTribe.Models
{
    public class Bio
    {
        public int Id { get; set; }

        [Display(Name = "Favorite Movie")]
        public string Movie { get; set; }

        [Display(Name = "Favorite Food")]
        public string Food { get; set; }

        [Display(Name = "Favorite Super Hero")]
        public string SuperHero { get; set; }
        
    }
}
