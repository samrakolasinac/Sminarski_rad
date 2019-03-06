using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Areas.Administrator.ViewModels
{
    public class LokacijeIndexVM
    {
        public List<Row> drzave { get; set; }
        public class Row
        {
            public string Naziv { get; internal set; }
            public int DrzavaID { get; internal set; }
        }


    }
}
