using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Areas.Administrator.ViewModels
{
    public class DogadjajiDodajVM
    {
        public List<SelectListItem> tip { get; set; }
        public Dogadjaj dogadjaji { get;  set; }
    }
}
