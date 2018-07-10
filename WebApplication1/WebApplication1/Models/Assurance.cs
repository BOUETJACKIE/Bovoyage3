using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bovoyage3.Models
{
    [Table("Assurances")]
    public class Assurance
    {
        public int Id { get; set; }

        public string Designation { get; set; }

    }
}