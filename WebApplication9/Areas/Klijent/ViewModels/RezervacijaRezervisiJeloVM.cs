using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Areas.Klijent.ViewModels
{
    public class RezervacijaRezervisiJeloVM
    {
   
        public int RezervacijaID { get; internal set; }
        public List<SelectListItem> jelo { get; set; }
        [Required]
        [Range(1,15)]
        public int Kolicina { get; internal set; }
    }
}
