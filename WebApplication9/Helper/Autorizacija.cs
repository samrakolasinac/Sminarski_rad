using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Helper
{
    public class Autorizacija: Attribute, IAuthorizationFilter
    {
        private readonly bool _sviKorisnici;
        private readonly TipKorisnika[] _korisnickeUloge;
        public Autorizacija(bool sviKorisnici, params TipKorisnika[] korisnickeUloge)
        {
            _sviKorisnici = sviKorisnici;
            _korisnickeUloge = korisnickeUloge;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            KorisnickiNalog nalog = Autentifikacija.GetLogiraniKorisnik(context.HttpContext);
            if (nalog == null)
            {
                context.HttpContext.Response.Redirect("/Autentifikacija/Prijava");
                return;
            }
            if (_sviKorisnici)
                return;

            if (!_sviKorisnici && nalog.IsAdministrator && _korisnickeUloge.Contains(TipKorisnika.Administrator))
                return;

            if (!_sviKorisnici && nalog.IsUposlenik && _korisnickeUloge.Contains(TipKorisnika.Uposlenik))
                return;

            if (!_sviKorisnici && nalog.IsKlijent && _korisnickeUloge.Contains(TipKorisnika.Klijent))
                return;

            context.HttpContext.Response.Redirect("/Autentifikacija/Prijava");
        }
    }
}
