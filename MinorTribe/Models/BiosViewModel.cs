using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MinorTribe.Models
{
    public class BiosViewModel
    {
        public Bio bio { get; set; }

        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "jpg,jpeg,png")]
        public IFormFile file { get; set; }
    }
}
