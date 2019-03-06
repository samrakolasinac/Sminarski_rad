using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hotel.Data.Models
{
   public class Jelo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje za naziv je obavezno!")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Polje za opis je obavezno!")]
        public string Opis { get; set; }
        [Required(ErrorMessage = "Polje za cijenu je obavezno!")]
        public float Cijena { get; set; }
    }
}
