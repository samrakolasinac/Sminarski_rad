using Hotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Areas.Administrator.ViewModels
{
    public class LokacijeDodajGradVM
    {
        public Grad grad { get; set; }
        public Drzava drazav { get; internal set; }
        public int drzaavaID { get; internal set; }
        public string nazivDrzava { get; internal set; }
    }
}
