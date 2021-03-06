﻿using Bovoyage3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Bovoyage3.Data
{
    public class Bovoyage3DbContext: DbContext
    {
        public Bovoyage3DbContext() : base("bovoyage3Azure") { }
            
        public DbSet<Participant> Participants { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<AgenceVoyage> AgenceVoyages { get; set; }

        public DbSet<Destination> Destinations { get; set; }

        public DbSet<DossierReservation> DossierReservations { get; set; }

        public DbSet<Voyage> Voyages { get; set; }

        public DbSet<AssuranceAnulation> AssuranceAnulations { get; set; }
    }
}