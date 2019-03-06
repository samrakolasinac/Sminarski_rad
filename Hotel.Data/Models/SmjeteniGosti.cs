using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotel.Data.Models
{
   public class SmjeteniGosti
    {
        public int Id { get; set; }
        public string BrojPasosa { get; set; }


        public RezervisanaSoba RezervisanaSoba { get; set; }
        [ForeignKey(nameof(RezervisanaSoba))]
        public int RezervisanaSobaID { get; set; }

        public Gost Gost { get; set; }
        [ForeignKey(nameof(Gost))]
        public int GostID { get; set; }
    }
}
