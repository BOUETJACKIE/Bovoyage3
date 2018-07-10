using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bovoyage3.Models
{
    [Table("Agences")]
    public class AgenceVoyage:BaseModel
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Adresse { get; set; }

        public string Telephone { get; set; }


        public override string ToString()
        {
            return $"{this.Nom}";
        }
    }
}