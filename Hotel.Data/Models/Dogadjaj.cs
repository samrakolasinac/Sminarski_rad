using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotel.Data.Models
{
    public class Dogadjaj
    {

        public int Id { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
        [Required(ErrorMessage = "Polje za naziv je obavezno!")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Polje za opis je obavezno!")]
        public string Opis { get; set; }
        [Required(ErrorMessage = "Polje za cijenu je obavezno!")]
        public float  Cijena { get; set; }
        public TipDogadjaja TipDogadjaja { get; set; }
        [ForeignKey(nameof(TipDogadjaja))]
        public int TipDogadjajaID { get; set; }

    }
}
