using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Areas.Klijent.ViewModels
{
    public class SobeIndexVM
    {
        public List<Row> sobe { get; set; }

        public class Row
        {
            public int sobaID { get; internal set; }
            public string Naziv { get; internal set; }
            public string tipSObe { get; internal set; }
            public int BrojSprata { get; internal set; }
            public float cijena { get; internal set; }
            public bool dostupna { get; internal set; }
        }
    }
}
