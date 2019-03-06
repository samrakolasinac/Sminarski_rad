using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Areas.Administrator.ViewModels
{
    public class ZaposleniciDodajVM
    {
       
        [Required(ErrorMessage = "Polje za ime je obavezno!")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Polje za prezime je obavezno!")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Polje za broj telefona je obavezno!")]
        [RegularExpression (@"[0-9]{3}[\/][0-9]{3}[-][0-9]{3}")]
        public string BrojTelefona { get; set; }
        [Required(ErrorMessage = "Polje za JMBG je obavezno!")]
        public string JMBG { get; set; }
        [Required(ErrorMessage = "Polje za datum rodjenja  je obavezno!")]
        public DateTime DatumRodjenja { get; set; }
        [Required(ErrorMessage = "Polje za datum zaposlenja je obavezno!")]
        public DateTime DatumZaposelenja { get; set; }

        [Required(ErrorMessage = "Polje za  korisnicko ime je obavezno!")]
        public string KorisnickoIme { get; set; }

        [Required(ErrorMessage = "Polje za  lozinku je obavezno!")]
        public string Lozinka { get; set; }

        [Required(ErrorMessage = "Polje za  lozinku je obavezno!")]
        [RegularExpression(@"^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+[.])+[a-z]{2,5}$")]
        public string Email { get; set; }

        public double? TekuciRacun { get; set; }
        public List<SelectListItem> gradovi { get; set; }
        public int GradID { get; set; }
        public List<SelectListItem> tipZaposlenika { get; set; }
        public int TipID { get; set; }
        public int Zaposlenikid { get; internal set; }

    }
}
