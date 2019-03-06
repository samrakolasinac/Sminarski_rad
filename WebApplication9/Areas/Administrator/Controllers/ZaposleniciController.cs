using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.EF;
using Hotel.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication9.Areas.Administrator.ViewModels;
using WebApplication9.Helper;

namespace WebApplication9.Areas.Administrator
{
    [Autorizacija(false, TipKorisnika.Administrator)]
    [Area("Administrator")]

    public class ZaposleniciController : Controller
    {
        private MojContext _db;

        public ZaposleniciController(MojContext db)
        {
            _db = db;
        }


        public IActionResult Index(string pretragaString = null)

        {

            ZaposleniciIndexVM model = new ZaposleniciIndexVM();


            model.rows = _db.Zaposlenik.Select(x => new ZaposleniciIndexVM.Row
            {
                ZaposlenikID = x.id,
                Ime = x.Ime,
                Prezime = x.Prezime,
                BrojTelefon = x.BrojTelefona,
                JMBG = x.JMBG,
                TipUposlenika=x.TipUposlenika.Naziv,
                nalogID=x.NalogID,
                email=x.Email


            }).ToList();


            return View(model);
        }
        public IActionResult Dodaj()
        {
            ZaposleniciDodajVM model = new ZaposleniciDodajVM
            {

                gradovi = _db.Grad.Select(x => new SelectListItem
                {
                    Value = x.id.ToString(),
                    Text = x.Naziv
                }).ToList(),
                tipZaposlenika = _db.TipZaposlenika.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Naziv
                }).ToList()
            };
            return View(model);
        }
        public IActionResult Obrisi(int zaposlenikID)
        {
           
            Zaposlenik zaposlenik = _db.Zaposlenik.Where(z=>z.id==zaposlenikID).FirstOrDefault();
            int nalogID = zaposlenik.NalogID;
            _db.Zaposlenik.Remove(zaposlenik);
            _db.SaveChanges();
            KorisnickiNalog nalog = _db.KorisnickiNalog.Where(x => x.Id == nalogID).FirstOrDefault();
            _db.Remove(nalog);
            _db.SaveChanges();

            return Redirect("/Administrator/Zaposlenici/Index");
        }

        
        public IActionResult Snimi(ZaposleniciDodajVM dodajVM, ZaposleniciUrediVM urediVM, int zaposlenikID)
        {
            if (!ModelState.IsValid)
            {

                dodajVM.gradovi = _db.Grad.Select(x => new SelectListItem
                {
                    Value = x.id.ToString(),
                    Text = x.Naziv
                }).ToList();
                dodajVM.tipZaposlenika = _db.TipZaposlenika.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Naziv
                }).ToList();
                return View("Dodaj", dodajVM);
            }

            KorisnickiNalog nalog = new KorisnickiNalog();
                nalog.KorisnickoIme = dodajVM.KorisnickoIme;
                nalog.Lozinka = dodajVM.Lozinka;
                if (dodajVM.TipID == 1)
                {
                    nalog.IsAdministrator = true;
                }

                else
                {
                    nalog.IsUposlenik = true;
                }
                _db.KorisnickiNalog.Add(nalog);
                _db.SaveChanges();

                Zaposlenik z= new Zaposlenik();
              
            z.Ime = dodajVM.Ime;
            z.Prezime = dodajVM.Prezime;
            z.DatumZaposelenja = dodajVM.DatumZaposelenja;
            z.DatumRodjenja = dodajVM.DatumRodjenja;
            z.JMBG = dodajVM.JMBG;
            z.BrojTelefona = dodajVM.BrojTelefona;
            z.TipUposlenikaID = dodajVM.TipID;
            z.GradID = dodajVM.GradID;
            z.TekuciRacun = dodajVM.TekuciRacun;
            z.NalogID = nalog.Id;
            z.Email = dodajVM.Email;
                _db.Zaposlenik.Add(z);
                _db.SaveChanges();
           


            return Redirect("/Administrator/Zaposlenici/Index");
        }
        public IActionResult Detalji(int ZaposlenikID)
        {
            ZaposleniciDetaljiVM model = _db.Zaposlenik.Where(x => x.id == ZaposlenikID)
                .Select(h => new ZaposleniciDetaljiVM
                {
                    Zaposlenikid=h.id,
                    ImePrezime=h.Ime+" "+h.Prezime,
                    DatumRodjenja=h.DatumRodjenja.ToShortDateString(),
                    DatumZaposlenja=h.DatumZaposelenja.ToShortDateString(),
                    TipZaposlenika=h.TipUposlenika.Naziv,
                    BrojTekucegRacuna = h.TekuciRacun,
                    Grad =h.Grad.Naziv,
                    KorisnickoIme=h.Nalog.KorisnickoIme,
                    Lozinka=h.Nalog.Lozinka,
                    Email=h.Email
                }).FirstOrDefault();
            return View(model);
        }
        public IActionResult Uredi(int zaposlenikID)
        {
            Zaposlenik zaposlenik1 = _db.Zaposlenik.Where(x => x.id == zaposlenikID).Include(n => n.Nalog).FirstOrDefault();
            ZaposleniciUrediVM model = new ZaposleniciUrediVM
            {
                Zaposlenik = zaposlenik1,
              
                gradovi = _db.Grad.Select(x => new SelectListItem
                {
                    Value = x.id.ToString(),
                    Text = x.Naziv
                }).ToList(),
                tipZaposlenika = _db.TipZaposlenika.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Naziv
                }).ToList()

            };

            return View(model);
        }
        public IActionResult SnimiEdit(ZaposleniciUrediVM model)
        {

            if (!ModelState.IsValid)
            {

                model.gradovi = _db.Grad.Select(x => new SelectListItem
                {
                    Value = x.id.ToString(),
                    Text = x.Naziv
                }).ToList();
                model.tipZaposlenika = _db.TipZaposlenika.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Naziv
                }).ToList();
                SelectListItem n = new SelectListItem
                {
                    Value = null,
                    Text = "Nije odabrano"
                };
                model.gradovi.Add(n);
                model.tipZaposlenika.Add(n);
                return View("Dodaj", model);
            }

            Zaposlenik zaposlenik = null;
            KorisnickiNalog nalog;
            if (model.Zaposlenik.id != 0)
            {
                nalog = _db.KorisnickiNalog.Find(model.Zaposlenik.NalogID);
                nalog.KorisnickoIme = model.Zaposlenik.Nalog.KorisnickoIme;
                nalog.Lozinka = model.Zaposlenik.Nalog.Lozinka;
                if (model.Zaposlenik.TipUposlenikaID == 1)
                {
                    nalog.IsAdministrator = true;
                    nalog.IsUposlenik = false;
                }
                else
                {
                    nalog.IsUposlenik = true;
                    nalog.IsAdministrator = false;
                }
                _db.SaveChanges();

                zaposlenik = model.Zaposlenik;
                _db.Zaposlenik.Update(zaposlenik);
                _db.SaveChanges();

            }

                return Redirect("/Administrator/Zaposlenici/Index");
        }
      
    }
}