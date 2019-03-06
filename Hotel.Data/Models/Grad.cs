using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotel.Data.Models
{
    public class Grad
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Polje za naziv je obavezno!")]
        public string Naziv { get; set; }
      
       
        public Drzava Drzava { get; set; }
        [ForeignKey(nameof(Drzava))]
        public int DrzavaID { get; set; }
    }
}
