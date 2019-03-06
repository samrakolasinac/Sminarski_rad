using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Areas.Klijent.ViewModels
{
    public class DogadjajiIndexVM
    {
        public List<Row> rows { get; set; }

        public class Row
        {
            public int dogadjajID { get; internal set; }
            public string naziv { get; internal set; }
            public DateTime pocetak { get; internal set; }
            public DateTime kraj { get; internal set; }
            public string tipDogadjaj { get; internal set; }
        }
    }
}
