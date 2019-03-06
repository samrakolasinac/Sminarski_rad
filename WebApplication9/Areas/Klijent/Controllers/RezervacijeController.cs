using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.EF;
using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.Helper;
using Microsoft.AspNetCore.Http;
using WebApplication9.Areas.Klijent.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication9.Areas.Klijent.Controllers
{
    [Autorizacija(false, TipKorisnika.Klijent)]
    [Area("Klijent")]
    public class RezervacijeController : Controller
    {
    
        public MojContext _db;

        public RezervacijeController(MojContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            int id = korisnik.Id;
            RezervacijeIndexVM model = _db.Rezervacija
                .Include(n => n.Gost)
                .Where(x => x.Gost.NalogID == korisnik.Id)
                .Select(b => new RezervacijeIndexVM
                {
                    GostID = id,
                    rows =_db.Rezervacija
                    .Where(v=>v.Gost.NalogID==korisnik.Id)
                    .Select(g=>new RezervacijeIndexVM.Row
                    {
                        RezervacijaID=g.Id,
                        DatumRezervacije=g.datumRezervacije,
                        Aktivna=g.Aktivna,
                        GostId=id,
                        Gost=g.Gost.Ime+" "+g.Gost.Prezime,
                        ZaposlenikID=g._ZaposlenikId,
                        Zaposlenik=g.Zaposlenik.Ime+" "+g.Zaposlenik.Prezime

                    }).ToList()
                }).FirstOrDefault();


            return View(model);
        }



        public IActionResult Detalji(int RezervacijaID)
        { 

            RezervacijeDetaljiVM model = _db.Rezervacija
                .Where(v => v.Id == RezervacijaID)
                .Select(x =>
                new RezervacijeDetaljiVM
                {
                    RezervacijaID = x.Id,
                    Total1=_db.RezervisanaSoba
                    .Include(q=>q.Soba)
                    .Where(n=>n.RezervacijaID==RezervacijaID).Sum(w=>w.Soba.Cijena),
                    Total2=_db.RezervacijaDogadjaj
                    .Include(a=>a.dogadjaj)
                    .Where(b=>b.rezervacijaID==RezervacijaID).Sum(c=>c.dogadjaj.Cijena),
                    Total3=_db.DodatneUslugeRezervacija
                    .Include(k=>k.DodatneUsluge)
                    .Where(v=>v.RezervacijaID==RezervacijaID).Sum(l=>l.DodatneUsluge.Cijena),
                    Total4=_db.StavkeRezervacijeJela
                    .Include(b=>b.Jelo)
                    .Include(m=>m.RezervacijaJela)
                    .Where(a=>a.RezervacijaJela.RezervacijaID==RezervacijaID&&a.RezervacijaJelaID==a.Id)
                    .Sum(u=>u.Jelo.Cijena), 
                    Total=0,
                    Gost = x.Gost.Ime + " " + x.Gost.Prezime,
                    DatumDolaska = x.DatumDolaska,
                    DatumOdlaska = x.DatumOdlska,
                    usluge = _db.DodatneUslugeRezervacija.
                    Where(a => a.RezervacijaID == RezervacijaID)
                    .Select(b => new RezervacijeDetaljiVM.Row
                    {
                        UslugaID = b.DodatneUslugeID,
                        Usluga = b.DodatneUsluge.Naziv,
                        Cijena = b.DodatneUsluge.Cijena,
                        Datum = b.DatumVrijeme,
                        
                    }).ToList(),
                    sobe = _db.RezervisanaSoba
                    .Where(c => c.RezervacijaID == RezervacijaID)
                    .Select(d => new RezervacijeDetaljiVM.Row
                    {
                        SobaID = d.SobaID,
                        Naziv = d.Soba.Naziv,
                        Sprat = d.Soba.Sprat,
                        CijenaSobe = d.Soba.Cijena
                    }).ToList(),
                    dogadjaji = _db.RezervacijaDogadjaj
                    .Where(e => e.rezervacijaID == RezervacijaID)
                    .Select(f => new RezervacijeDetaljiVM.Row
                    {
                        DogadjajID = f.dogadjajID,
                        NazivDogadjaja =f.dogadjaj.Naziv,
                        TipDogadjaja=f.dogadjaj.TipDogadjaja.Naziv,
                        CijenaDogadjaja=f.dogadjaj.Cijena
                    }).ToList(),
                    jela=_db.StavkeRezervacijeJela
                    .Where(h=>h.RezervacijaJela.RezervacijaID==RezervacijaID)
                    .Select(k=>new RezervacijeDetaljiVM.Row
                    {
                        JeloID=k.JeloID,
                        NazivJela=k.Jelo.Naziv,
                        CijenaJela=k.Jelo.Cijena,
                        KolicinaJela=k.Kolicina,
                        UkupnaCijenaJela=k.Jelo.Cijena*k.Kolicina
                    }).ToList(),
                }).FirstOrDefault();
            
            return View(model);
        }


        public IActionResult Dodaj()
        {
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            RezervacijeDodajVM model = _db.Rezervacija
                .Include(n => n.Gost)
                .Where(x => x.Gost.NalogID == korisnik.Id)
                .Select(y => new RezervacijeDodajVM
                {
                    GostID=y.GostID,
                    Gost=y.Gost.Ime+" "+y.Gost.Prezime,
                    DatumRezervacije=DateTime.Now,
                    sobe=_db.Soba.Where(a=>a.Dostupna==true)
                    .Include(m=>m.TipSobe)
                    .Select(v=>new SelectListItem
                    {
                        Value=v.Id.ToString(),
                        Text=v.Naziv+"/"+v.TipSobe.Naziv

                    }).ToList(),
                    DozvoljenoPusenje=false,
                    Usluge=_db.DodatneUsluge
                    .Select(c=>new SelectListItem
                    {
                        Value=c.Id.ToString(),
                        Text=c.Naziv
                    }).ToList()



                }).FirstOrDefault();

            return View(model);
        }



        public IActionResult Snimi(int Id)
        {
            
                KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
                int indeks = _db.Gost.Where(g => g.NalogID == korisnik.Id).Select(l => l.id).FirstOrDefault();
                Soba x = _db.Soba.Find(Id);
                Rezervacija nova = new Rezervacija
                {
                    GostID = indeks,
                    datumRezervacije = DateTime.Now,
                    _ZaposlenikId = 3,
                    Aktivna = true
                };
                _db.Rezervacija.Add(nova);
                _db.SaveChanges();
                RezervisanaSoba soba = new RezervisanaSoba
                {
                    RezervacijaID = nova.Id,
                    SobaID =x.Id,
                    pusenje = false,
                };
                x.Dostupna = false;
                _db.Update(x);
                _db.SaveChanges();
                _db.RezervisanaSoba.Add(soba);
                _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



    

        public IActionResult Otkazi(int RezervacijaID)
        {
            Rezervacija x = _db.Rezervacija.Find(RezervacijaID);
            x.Aktivna = false;
            int RezervacijaSobaID = _db.RezervisanaSoba.Where(j => j.RezervacijaID == RezervacijaID).Select(n => n.Id).FirstOrDefault();
            RezervisanaSoba k = _db.RezervisanaSoba.Find(RezervacijaSobaID);
            int SobaID = k.SobaID;
            Soba s = _db.Soba.Find(SobaID);
            s.Dostupna = true;
            _db.Update(x);
            _db.Update(s);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult RezervisiUsluge(int RezervacijaID)
        {
            RezervacijaRezervisiUsluge model = new RezervacijaRezervisiUsluge
            {
                RezervacijaID = RezervacijaID,
                usluge = _db.DodatneUsluge.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text=x.Naziv
                }).ToList()
            };
            return View(model);
        }

        public IActionResult Snimi2(int RezervacijaID, int UslugaID)
        {
            DodatneUslugeRezervacija x = new DodatneUslugeRezervacija
            {
                DodatneUslugeID = UslugaID,
                RezervacijaID = RezervacijaID,
                DatumVrijeme = DateTime.Now
            };
            _db.DodatneUslugeRezervacija.Add(x);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult RezervisiDogadjaje(int RezervacijaID)
        {
            RezervacijaRezervisiDogadjajeVM model = new RezervacijaRezervisiDogadjajeVM
            {
                RezervacijaID = RezervacijaID,
                dogadjaj = _db.Dogadjaj.Select(l => new SelectListItem
                {
                    Value=l.Id.ToString(),
                    Text=l.Naziv
                }).ToList()
            };
            return View(model);
        }



        public IActionResult Snimi3(int RezervacijaID, int DogadjajID)
        {
            RezervacijaDogadjaj nova = new RezervacijaDogadjaj
            {
                rezervacijaID=RezervacijaID,
                dogadjajID=DogadjajID

            };
            _db.RezervacijaDogadjaj.Add(nova);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult RezervisiJelo(int RezervacijaID)
        {
            RezervacijaRezervisiJeloVM model = new RezervacijaRezervisiJeloVM
            {
                RezervacijaID = RezervacijaID,
                Kolicina = 1,
                jelo = _db.Jelo.Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Naziv
                }).ToList()
            };
            return View(model);
        }




        public IActionResult Snimi4(int RezervacijaID, int JeloID, int Kolicina)
        {

            RezervacijaJela jelo = new RezervacijaJela
            {
                RezervacijaID = RezervacijaID,
                DatumRezervacije = DateTime.Now
            };
            _db.RezervacijaJela.Add(jelo);
            _db.SaveChanges();
            StavkeRezervacijeJela x = new StavkeRezervacijeJela
            {
                RezervacijaJelaID = jelo.Id,
                JeloID = JeloID,
                Kolicina = Kolicina
            };
            _db.StavkeRezervacijeJela.Add(x);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }









        














    }
}