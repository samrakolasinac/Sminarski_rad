using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Areas.Administrator.ViewModels
{
    public class LokacijePrikaziGradoveVM
    {
        public List<Row> gradovi { get; set; }
        public int DrzavaID { get; internal set; }
        public class Row
        {
            public string Naziv { get; internal set; }
            public int Id { get; internal set; }
           
        }
    }
}
