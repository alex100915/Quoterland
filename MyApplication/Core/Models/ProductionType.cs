using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyApplication.Core.Models
{
    public class ProductionType
    {
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }
    }
}