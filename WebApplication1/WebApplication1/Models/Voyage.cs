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
        public int Id { get; set; }

        [ForeignKey("IdAgence")]
        public AgenceVoyage Agence { get; set; }

        public int IdAgence { get; set; }

        [ForeignKey("IdDestination")]
        public Destination Destination { get; set; }

        public int IdDestination { get; set; }

        public DateTime DateAller { get; set; }

        public DateTime DateRetour { get; set; }

        public int PlacesDispo { get; set; }

        public Decimal TarifToutCompris { get; set; }


        public void Reserver(int places)
        {

        }


    }
}