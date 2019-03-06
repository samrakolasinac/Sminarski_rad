using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.EF;
using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication9.Areas.Administrator.ViewModels;
using WebApplication9.Helper;

namespace WebApplication9.Areas.Administrator.Controllers
{
    [Autorizacija(false, TipKorisnika.Administrator)]
    [Area("Administrator")]
    public class DogadjajiController : Controller
    {
       

        private MojContext _db;

        public DogadjajiController(MojContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            DogadjajiIndexVM model = new DogadjajiIndexVM
            {
 rows=_db.Dogadjaj.Select(x=>new DogadjajiIndexVM.Row
 {
        dogadjajID=x.Id,
        naziv=x.Naziv,
        pocetak=x.Pocetak,
        kraj=x.Kraj,
        tipDogadjaj=x.TipDogadjaja.Naziv

    
 }).ToList()

            };
            return View(model);
        }
        public IActionResult Dodaj()
        {
            DogadjajiDodajVM model = new DogadjajiDodajVM
            {
                dogadjaji=new Dogadjaj(),
                tip = _db.TipDogadjaja.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text=x.Naziv
                }).ToList()
            };
            return View(model);
        }
        public IActionResult DodajTipDogadjaj(int ID)
        {
            DogadjajiDodajTipVM model = new DogadjajiDodajTipVM
            {
                TipDogadjaja = new TipDogadjaja(),
                DogadjajID=ID
            };
            return PartialView(model);
        }
        public IActionResult SnimiTip(DogadjajiDodajTipVM model, int ID)
        {

            if (!ModelState.IsValid)
            {

                return View("DodajTipDogadjaj", model);
            }
            if (ID == null)
            {
                TipDogadjaja tipDogadjaja = new TipDogadjaja
                {
                    Naziv = model.TipDogadjaja.Naziv
                };
                _db.TipDogadjaja.Add(tipDogadjaja);
                _db.SaveChanges();
                return RedirectToAction(nameof(Dodaj));
            }
            else
            {
                TipDogadjaja tipDogadjaja = new TipDogadjaja
                {
                    Naziv = model.TipDogadjaja.Naziv
                };
                _db.TipDogadjaja.Add(tipDogadjaja);
                _db.SaveChanges();
                return RedirectToAction(nameof(Uredi),ID);
            }
        }
        public IActionResult Uredi(int ID)
        {
            DogadjajiDodajVM model = new DogadjajiDodajVM
            {
                dogadjaji = _db.Dogadjaj.Find(ID),
                tip = _db.TipDogadjaja.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv
                }).ToList()
            };
            return View(nameof(Dodaj), model);
        }
        public IActionResult Snimi(DogadjajiDodajVM model)
        {

            if (!ModelState.IsValid)
            {
                model.tip = _db.TipDogadjaja.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv
                }).ToList();
                return View("Dodaj", model);
            }
            Dogadjaj dogadjaj;
            if (model.dogadjaji.Id != 0)
            {
                dogadjaj = model.dogadjaji;
                _db.Dogadjaj.Update(dogadjaj);
                _db.SaveChanges();
            }
            else
            {
                dogadjaj = new Dogadjaj();
                dogadjaj = model.dogadjaji;
            _db.Dogadjaj.Add(dogadjaj);
                _db.SaveChanges();
            }


            return RedirectToAction("Index");
        }
        public IActionResult Obrisi(int ID)
        {

            Dogadjaj dogadjaj = _db.Dogadjaj.Find(ID);
            _db.Dogadjaj.Remove(dogadjaj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Detalji(int ID)
        {
            DogadjajiDetaljiVM model = new DogadjajiDetaljiVM
            {
                dogadjaj = _db.Dogadjaj.Find(ID)
            };
            return View(model);
        }
        public IActionResult Cjenovnik()
        {
            Cjenovnik model = new Cjenovnik
            {
                rows = _db.Dogadjaj.Select(x => new Cjenovnik.Row
                {
                    naziv = x.Naziv,
                    cijena = x.Cijena,
                    ID = x.Id
                }).ToList()
            };
            return View(model);
        }
    }
    
}