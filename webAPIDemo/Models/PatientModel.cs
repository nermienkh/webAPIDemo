using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webAPIDemo.Models
{
    public class PatientModel
    {
        
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}