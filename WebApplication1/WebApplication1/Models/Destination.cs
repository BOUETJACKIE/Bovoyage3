﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bovoyage3.Models
{
    public enum EtatDossierReservation : byte { EnAttente, EnCours, Refusee, Acceptee }

    public enum RaisonAnnulationDossier : byte { Client = 1, PlacesInsuffisantes }

    [Table("Destinations")]

    public class Destination
    {
        public int Id { get; set; }
        public string Continent { get; set; }
        public string Pays { get; set; }
        public string Region { get; set; }
        public string description { get; set; }
    }
}