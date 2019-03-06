using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotel.Data.Models
{
   public  class Gost
    {
        public int id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Spol { get; set; }



        public virtual KorisnickiNalog Nalog { get; set; }
        [ForeignKey(nameof(Nalog))]
        public int NalogID { get; set; }

        public Firma Firma { get; set; }
        [ForeignKey(nameof(Firma))]
        public int? FirmaID { get; set; }


        public Grad Grad { get; set; }
        [ForeignKey(nameof(Grad))]
        public int GradID { get; set; }

    }
}
