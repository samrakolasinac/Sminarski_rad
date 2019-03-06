
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.EF;
using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.Areas.Administrator.ViewModels;
using WebApplication9.Helper;

namespace WebApplication9.Areas.Administrator.Controllers
{
    [Autorizacija(false, TipKorisnika.Administrator)]
    [Area("Administrator")]
    public class JeloController : Controller
    {
        private MojContext _db;

        public JeloController(MojContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            JeloIndexVM model = new JeloIndexVM
            {
                rows = _db.Jelo.Select(x => new JeloIndexVM.Row
                {
                    jeloID=x.Id,
                    Naziv=x.Naziv,
                    Opis=x.Opis
                }).ToList()
            };
            return View(model);
        }
        public IActionResult Cjenovnik()
        {
            Cjenovnik model = new Cjenovnik
            {
                rows = _db.Jelo.Select(x => new Cjenovnik.Row
                {
                    naziv = x.Naziv,
                    cijena = x.Cijena,
                    ID = x.Id
                }).ToList()
            };
            return View(model);
        }
        public IActionResult Dodaj()
        {

            JeloDodajVM model = new JeloDodajVM
            {
                Jelo = new Jelo()
            };
            return View(model);
        }
        public IActionResult Uredi(int jeloID)
        {

            JeloDodajVM model = new JeloDodajVM
            {
                Jelo = _db.Jelo.Find(jeloID)
            };
            return View(nameof(Dodaj),model);
        }
        public IActionResult Snimi(JeloDodajVM model)
        {


            if(!ModelState.IsValid)
            {
                return View("Dodaj", model);
            }
            Jelo jelo = null;
            if (model.Jelo.Id!=0)
            {
                jelo = model.Jelo;
                _db.Jelo.Update(jelo);
                _db.SaveChanges();
            }
            else
            { 
            jelo = new Jelo();
            jelo = model.Jelo;
            _db.Jelo.Add(jelo);
            _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult Obrisi(int jeloID)
        {
            Jelo jelo = _db.Jelo.Find(jeloID);
            _db.Jelo.Remove(jelo);
            _db.SaveChanges();
            

            return RedirectToAction("Index");
        }

    }
}