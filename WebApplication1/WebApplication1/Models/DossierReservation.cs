using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bovoyage3.Models
{
    public class DossierReservation
    {
        public int NumeroUnique { get; set; }
        public string NumeroCarteBancaire { get; set; }
        public decimal PrixTotal { get; set; }

    }
}