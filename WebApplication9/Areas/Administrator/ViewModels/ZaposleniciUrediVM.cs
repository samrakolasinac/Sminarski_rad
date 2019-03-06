using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication9.Areas.Administrator.ViewModels
{
    public class ZaposleniciUrediVM
    {
        public Zaposlenik Zaposlenik { get; set; }
        public List<SelectListItem> gradovi { get; set; }
        
        public List<SelectListItem> tipZaposlenika { get; set; }
       
    }
}
