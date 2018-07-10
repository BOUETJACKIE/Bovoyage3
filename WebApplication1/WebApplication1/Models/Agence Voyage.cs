using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bovoyage3.Models
{
    [Table("Agences")]
    public class AgenceVoyage
    {
        public string Nom { get; set; }
    }
}