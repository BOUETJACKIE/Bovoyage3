using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bovoyage3.Models
{
    [Table("Voyages")]
    public class Voyage
    {
        public DateTime dateAller { get; set; }
        public DateTime dateRetour { get; set; }
        public int placesDisponibles { get; set; }
        public decimal tarifToutCompris { get; set; }

        public void Reserver() { }
            
    }
}