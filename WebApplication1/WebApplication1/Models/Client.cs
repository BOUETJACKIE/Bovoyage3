using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bovoyage3.Models
{
    [Table("Clients")]
    public class Client : Personne
    {
        public string Email { get; set; }

      //  [ForeignKey("PersonneId")]
        //public Personne Personne { get; set; }
    }
}