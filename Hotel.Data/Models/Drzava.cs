using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hotel.Data.Models
{
  public  class Drzava
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Polje za naziv je obavezno!")]
        public string Naziv { get; set; }
    }
}
