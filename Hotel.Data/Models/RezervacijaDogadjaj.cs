using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotel.Data.Models
{
   public class RezervacijaDogadjaj
    {
        public int Id { get; set; }

        public Dogadjaj dogadjaj { get; set; }
        [ForeignKey(nameof(dogadjaj))]
        public int dogadjajID { get; set; }

        public Rezervacija rezervacija { get; set; }
        [ForeignKey(nameof(rezervacija))]
        public int rezervacijaID { get; set; }

    }
}
