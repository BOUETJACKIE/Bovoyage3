using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bovoyage3.Models
{
    public class Client : Personne
    {
        public string Email { get; set; }
    }
}