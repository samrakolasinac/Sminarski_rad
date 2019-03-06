using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.EF;
using Hotel.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.Areas.Administrator.ViewModels;
using WebApplication9.Helper;

namespace WebApplication9.Areas.Administrator.Controllers
{
    [Autorizacija(false, TipKorisnika.Administrator)]
    [Area("Administrator")]
    public class DodatneUslugeController : Controller
    {
        private MojContext _db;

        public DodatneUslugeController(MojContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            DodatneUslugeIndexVM model = new DodatneUslugeIndexVM
            {
                rows = _db.DodatneUsluge.Select(x => new DodatneUslugeIndexVM.Row
                {
                    UslugaID = x.Id,
                    Naziv = x.Naziv,
                  
                }).ToList()
            };
            return View(model);
        }
        public IActionResult Cjenovnik()
        {
            Cjenovnik model = new Cjenovnik
            {
                rows = _db.DodatneUsluge.Select(x => new Cjenovnik.Row
                {
                    naziv = x.Naziv,
                    cijena = x.Cijena,
                    ID=x.Id
                }).ToList()
            };
            return View(model);
        }
      
        public IActionResult Dodaj(int uslugaID)
        {
            DodatneUslugeDodajVM model = new DodatneUslugeDodajVM
            {
                DodatneUsluge=new DodatneUsluge()
            };
            
            return View(model);
        }
        public IActionResult Uredi(int uslugaID)
        {
            DodatneUslugeDodajVM model = new DodatneUslugeDodajVM
            {
                DodatneUsluge=_db.DodatneUsluge.Find(uslugaID)
            };

            return View(nameof(Dodaj),model);
        }
        public IActionResult Detalji(int uslugaID)
        {
            DodatneUslugeDetaljiVM model = new DodatneUslugeDetaljiVM
            {
                dodatneUsluge = _db.DodatneUsluge.Find(uslugaID)
            };
            return View(model);
        }
        public IActionResult Obrisi(int uslugaID)
        {
            DodatneUsluge dodatne = _db.DodatneUsluge.Find(uslugaID);
            _db.DodatneUsluge.Remove(dodatne);
            _db.SaveChanges();

            return Redirect("/Administrator/DodatneUsluge/Index");

        }
       
        public  IActionResult Snimi(DodatneUslugeDodajVM model)
        {

            if(!ModelState.IsValid)
            {
                return View("Dodaj", model);
            }
            DodatneUsluge dodatneUsluge = null;
            if (model.DodatneUsluge.Id != 0)
            {
                dodatneUsluge = model.DodatneUsluge;
                _db.DodatneUsluge.Update(dodatneUsluge);
                _db.SaveChanges();
            }
            else {

              dodatneUsluge = new DodatneUsluge
          {
              Naziv = model.DodatneUsluge.Naziv,
              Opis = model.DodatneUsluge.Opis,
              Cijena=model.DodatneUsluge.Cijena

          };
                _db.DodatneUsluge.Add(dodatneUsluge);
                _db.SaveChanges();
            }
            return Redirect("/Administrator/DodatneUsluge/Index");
        }
    }
}