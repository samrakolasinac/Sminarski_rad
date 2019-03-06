using Hotel.Data.EF;
using Hotel.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Helper
{
    public enum TipKorisnika
    {
        Administrator = 1,
        Uposlenik,
        Klijent
    }
    public static class Autentifikacija
    {
       

        private const string _logiraniNalog = "logirani_nalog";

        public static void SetLogiraniKorisnik(this HttpContext context, KorisnickiNalog korisnik)
        {
            context.Session.Set(_logiraniNalog, korisnik);
        }

       
        public static KorisnickiNalog GetLogiraniKorisnik(this HttpContext context)
        {
            KorisnickiNalog korisnik = context.Session.Get<KorisnickiNalog>(_logiraniNalog);

            return korisnik;
        }
      
    }
}
