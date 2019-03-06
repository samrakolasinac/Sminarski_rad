using Hotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Areas.Administrator.ViewModels
{
    public class SobeTipSobeDodajVM
    {
        public TipSobe TipSobe { get; set; }
        public int sobaID { get; internal set; }
    }
}
