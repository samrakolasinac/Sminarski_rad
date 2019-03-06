using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Areas.Klijent.ViewModels
{
    public class RezervacijaRezervisiDogadjajeVM
    {
        public int RezervacijaID { get; internal set; }
        public List<SelectListItem> dogadjaj { get; set; }
    }
}
