using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Authenticator;
using Hotel.Data.EF;
using Hotel.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication9.Helper;
using WebApplication9.ViewModels;
using Microsoft.AspNetCore.Http.Authentication;

namespace WebApplication9.Controllers
{
    public class AutentifikacijaController : Controller
    {
        private MojContext _db;
        private IHttpContextAccessor httpContext;
        private const string key = "qaz123!@@)(*";
        private const string SessionKeyName = "_Name";
        public AutentifikacijaController(MojContext db, IHttpContextAccessor httpContext)
        {
            _db = db;
            this.httpContext = httpContext;
        }

        public IActionResult Prijava()
        {

            return View(new LoginVM());
        }
        [HttpPost]
        public IActionResult Prijava(LoginVM login)
        {
          
            KorisnickiNalog korisnik = _db.KorisnickiNalog.Where(x => x.KorisnickoIme == login.Username && x.Lozinka == login.Password)
                .FirstOrDefault();
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            if (korisnik == null)
            {
                ModelState.AddModelError("", "Korisnicko ime ili lozinka nisu ispravni");
            }
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            HttpContext.SetLogiraniKorisnik(korisnik);

            if (korisnik.IsUposlenik)
            {
                HttpContext.Session.SetString(SessionKeyName, korisnik.KorisnickoIme);
                return RedirectToAction("VerifyAuth");



            }
            else if (korisnik.IsKlijent)
            {
                //HttpContext.Session.SetString(SessionKeyName, korisnik.KorisnickoIme);
                //return RedirectToAction("VerifyAuth");
                return Redirect("/Klijent/Home/Index");

            }
            else
            {


                HttpContext.Session.SetString(SessionKeyName, korisnik.KorisnickoIme);
                return RedirectToAction("VerifyAuth");

             

            }


            
            return View();
        }

        public IActionResult Profil()
        {
           
            KorisnickiNalog nalog = HttpContext.GetLogiraniKorisnik();
            if (nalog.IsKlijent)
            {
                return Redirect("/Klijent/Home/Index");
            }
            else if (nalog.IsUposlenik)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect("/Administrator/Home/Index");
            }

        }
        public IActionResult VerifyAuth()
        {
            if (HttpContext.Session.GetString(SessionKeyName) != null)
            {
                 TwoFactorAuthenticator twoFactorAuthenticator = new TwoFactorAuthenticator();

                string UserUniqueKey = (Convert.ToString(HttpContext.Session.GetString(SessionKeyName)) + key);

                ViewData["UserUniqueKey"] = UserUniqueKey;
                var setupInfo = twoFactorAuthenticator.GenerateSetupCode("Dotnet Awesome",UserUniqueKey, 300, 300);
                ViewBag.BarcodeImageUrl = setupInfo.QrCodeSetupImageUrl;
                ViewBag.SetupCode = setupInfo.ManualEntryKey;

                return View();

            }
            else
            {
                return RedirectToAction("Prijava");
            }
        }
        [HttpPost]

        public IActionResult VerifyAuth(string passcode)
        {
           
            var token=passcode;

            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();

            string UserUniqueKey = (Convert.ToString(HttpContext.Session.GetString(SessionKeyName)) + key);

            bool isValid = tfa.ValidateTwoFactorPIN(UserUniqueKey, token);

            if (isValid)
            {

                ViewData["id"] = Convert.ToString(HttpContext.Session.GetString(SessionKeyName));



                return RedirectToAction("Profil");

            }



            return RedirectToAction("Prijava");
        }
        public IActionResult Registracija()
        {
            AutentifikacijaRegistracijaVM model = new AutentifikacijaRegistracijaVM();
            model.Gradovi = _db.Grad.Select(x => new SelectListItem
            {
                Value = x.id.ToString(),
                Text = x.Naziv
            }).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Registracija(AutentifikacijaRegistracijaVM login)
        {
            KorisnickiNalog nalog = new KorisnickiNalog
            {
                KorisnickoIme = login.KorisnickoIme,
                Lozinka = login.Password,
                IsAdministrator = false,
                IsKlijent = true,
                IsUposlenik = false
            };

            _db.KorisnickiNalog.Add(nalog);
            _db.SaveChanges();

            Gost gost = new Gost
            {
                Ime = login.Ime,
                Prezime = login.Prezime,
                GradID = login.GradID,
                NalogID = nalog.Id,
                BrojTelefona = login.BrojTelefona,
                Spol = login.Spol
            };
            _db.Gost.Add(gost);
            _db.SaveChanges();
            if (!ModelState.IsValid)
            {
                return View(gost);
            }
            return RedirectToAction("Prijava", "Autentifikacija");
        }
        public IActionResult Odjava()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Prijava");
        }


    }
}