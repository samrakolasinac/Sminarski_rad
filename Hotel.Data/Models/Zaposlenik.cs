using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotel.Data.Models
{
    public class Zaposlenik
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Polje za ime je obavezno!")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Polje za prezime je obavezno!")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Polje za broj telefona je obavezno!")]
        public string BrojTelefona { get; set; }
        [Required(ErrorMessage = "Polje za JMBG je obavezno!")]
        public string JMBG { get; set; }
        [Required(ErrorMessage = "Polje za datum rodjenja  je obavezno!")]
        public DateTime DatumRodjenja { get; set; }
        [Required(ErrorMessage = "Polje za datum zaposlenja je obavezno!")]
        public DateTime DatumZaposelenja { get; set; }


        public string Email { get; set; }
        public double? TekuciRacun { get; set; }



        public virtual KorisnickiNalog Nalog { get; set; }
        public int NalogID { get; set; }


        public TipZaposlenika TipUposlenika { get; set; }
        [ForeignKey(nameof(TipUposlenika))]
        public int TipUposlenikaID { get; set; }

        public Grad Grad { get; set; }
        [ForeignKey(nameof(Grad))]
        public int GradID { get; set; }





    }
}
