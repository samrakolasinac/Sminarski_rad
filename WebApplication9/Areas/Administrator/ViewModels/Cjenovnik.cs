using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Areas.Administrator.ViewModels
{
    public class Cjenovnik
    {
         public List<Row> rows { get; set; }
        public class Row
        {
            public string naziv { get; internal set; }
            public float cijena { get; internal set; }
            public int ID { get; internal set; }
        }
    }
}
