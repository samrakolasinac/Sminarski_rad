using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
   public class KorisnickiNalog
    {
        public int Id { get; set; }

        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public bool IsAdministrator { get; set; }

        public bool IsUposlenik { get; set; }

        public bool IsKlijent { get; set; }
    }
}
