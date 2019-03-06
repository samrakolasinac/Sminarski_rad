using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Areas.Klijent.ViewModels
{
    public class RezervacijeDodajVM
    {
        public int GostID { get; internal set; }
        public DateTime DatumRezervacije { get; internal set; }
        public string Gost { get; internal set; }
        public List<SelectListItem> sobe { get; set; }
        public List<SelectListItem> Usluge { get; set; }
        public bool DozvoljenoPusenje { get; internal set; }
    }
}
