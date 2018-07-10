using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bovoyage3.Models
{
    public class Voyage
    {
        public DateTime dateAller { get; set; }
        public DateTime dateRetour { get; set; }
        public int placesDisponibles { get; set; }
        public decimal tarifToutCompris { get; set; }

        public void Reserver() { }
            
    }
}