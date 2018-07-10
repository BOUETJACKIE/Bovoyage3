using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bovoyage3.Models
{
    public enum CivilitePersonne : byte { Madame = 1, Monsieur, Mademoiselle }

    public abstract class Personne
    {
        public int Id { get; set; }
        public CivilitePersonne Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public DateTime DateNaissance { get; set; }
        public int Age { get; set; }
    }
}