﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Bovoyage3.Models;

namespace Bovoyage3.Models
{
    [Table("DossierReservation")]
    public class DossierReservation: BaseModel
    {
        public int Id { get; set; }

        [ForeignKey("IdVoyage")]
        public  Voyage Voyage { get; set; }

        public int IdVoyage { get; set; }

       

        [ForeignKey("IdClient")]
        public  Client Client { get; set; }

        public int IdClient { get; set; }

        public string NumeroCarteBancaire { get; set; }
   
       

        public decimal PrixTotal { get { return 0; } }

       

        public void ValiderSolvabilite()
        {

        }

        public void Accepter()
        {

        }

        public override string ToString()
        {
            return $"{this.NumeroCarteBancaire} ({this.Id})";
        }
    }
}