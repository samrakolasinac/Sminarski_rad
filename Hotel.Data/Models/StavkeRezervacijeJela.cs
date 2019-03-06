using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotel.Data.Models
{
    public class StavkeRezervacijeJela
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje za opis je obavezno!")]
        public int Kolicina { get; set; }


        public RezervacijaJela RezervacijaJela { get; set; }
        [ForeignKey(nameof(RezervacijaJela))]
        public int RezervacijaJelaID { get; set; }


        public Jelo Jelo { get; set; }
        [ForeignKey(nameof(Jelo))]
        public int JeloID { get; set; }
    }

}
