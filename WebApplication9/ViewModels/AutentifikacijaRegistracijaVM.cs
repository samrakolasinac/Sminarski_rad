using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.ViewModels
{
    public class AutentifikacijaRegistracijaVM
    {
        [Required(ErrorMessage = "Ime je obavezno.")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno.")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "BrojTelelfona je obavezan.")]
        public string BrojTelefona { get; set; }

      
        public string Spol { get; set; }

        [Required(ErrorMessage = "Email je obavezan.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Korisnicko ime je obavezno.")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Lozinka je obavezna")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public List<SelectListItem> Gradovi { get; set; }
        public int GradID { get; set; }
    }
}
