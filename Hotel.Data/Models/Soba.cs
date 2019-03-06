using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotel.Data.Models
{
     public class Soba
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje za naziv je obavezno!")]
        
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Polje za sprat je obavezno!")]
        public int Sprat { get; set; }
        [Required(ErrorMessage = "Polje za cijenu je obavezno!")]
        public float Cijena { get; set; }

        public bool Dostupna { get; set; } 

        public TipSobe TipSobe { get; set; }
        [ForeignKey(nameof(TipSobe))]
        [Required(ErrorMessage = "Odaberite tip sobe!")]
        public int TipSobeID { get; set; }
    }
}
