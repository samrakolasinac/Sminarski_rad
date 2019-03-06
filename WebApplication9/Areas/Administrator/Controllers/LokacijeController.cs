using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.EF;
using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication9.Areas.Administrator.ViewModels;
using WebApplication9.Helper;

namespace WebApplication9.Controllers
{
    [Autorizacija(false, TipKorisnika.Administrator)]
    [Area("Administrator")]
    public class LokacijeController : Controller
    {
        private MojContext _db;

        public LokacijeController(MojContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            LokacijeIndexVM model = new LokacijeIndexVM
            {
                drzave = _db.Drzava.Select(x => new LokacijeIndexVM.Row
                {
                    Naziv = x.Naziv,
                    DrzavaID = x.id
                }).ToList()
            };

            return View(model);
        }
        public IActionResult PrikaziGradove(int drzavaID)
        {

            LokacijePrikaziGradoveVM model = new LokacijePrikaziGradoveVM
            {
                DrzavaID = drzavaID,
                gradovi = _db.Grad.Where(g => g.DrzavaID == drzavaID)
                .Select(x => new LokacijePrikaziGradoveVM.Row
                {
                    Naziv = x.Naziv,
                    Id = x.id,
                   
                }).ToList()
            };

            return View(model);
        }
        public IActionResult Dodaj()
        {
            LokacijeDodajVM model = new LokacijeDodajVM
            {
                Drzava = new Drzava()

            };

            return View(model);
        }
        public IActionResult Uredi(int drzavaID)
        {
            LokacijeDodajVM model = new LokacijeDodajVM
            {
                Drzava = _db.Drzava.Find(drzavaID)

            };

            return View(nameof(Dodaj), model);
        }

        public IActionResult Snimi(LokacijeDodajVM model)
        {

            if (!ModelState.IsValid)
            {
                return View("Dodaj", model);
            }
            Drzava novaDrzava = null;
            if (model.Drzava.id != null)
            {
                novaDrzava = model.Drzava;
                _db.Drzava.Update(novaDrzava);
                _db.SaveChanges();
            }
            else
            {
                novaDrzava = new Drzava();
                novaDrzava = model.Drzava;
                _db.Drzava.Add(novaDrzava);
                _db.SaveChanges();

            }

            return Redirect("/Administrator/Lokacije/Index");

        }
        public IActionResult Obrisi(int drzavaID)
        {
            Drzava drzava = _db.Drzava.Find(drzavaID);
            _db.Drzava.Remove(drzava);
            _db.SaveChanges();
            return Redirect("/Administrator/Lokacije/Index");
        }
        public IActionResult ObrisiGrad(int gradID)
        {
            Grad grad = _db.Grad.Find(gradID);
            int drzavaID = grad.DrzavaID;
            _db.Grad.Remove(grad);
            _db.SaveChanges();
            return Redirect("/Administrator/Lokacije/PrikaziGradove?drzavaID=" + drzavaID);
        }
        public IActionResult DodajGrad(int drzavaID)
        {
            LokacijeDodajGradVM model = new LokacijeDodajGradVM
            {
                grad = new Grad(),
                drzaavaID=drzavaID,
                nazivDrzava=_db.Drzava.Where(d=>d.id==drzavaID).Select(x=>x.Naziv).FirstOrDefault()

            };

            return View(model);
        }
        public IActionResult UrediGrad(int gradID)
        {
            Grad grad1 = _db.Grad.Where(g => g.id == gradID).Include(x => x.Drzava).FirstOrDefault();
            LokacijeDodajGradVM model = new LokacijeDodajGradVM
            {
                grad = grad1,
                drzaavaID = grad1.DrzavaID,
                nazivDrzava = grad1.Drzava.Naziv

            };
            return View(nameof(DodajGrad), model);
        }
        public IActionResult SnimiGrad(LokacijeDodajGradVM model, int drzaavaID)
        {

            if (!ModelState.IsValid)
            {
                return View("DodajGrad", model);
            }
            Grad noviGrad = null;
            if (model.grad.id != 0)
            {
                noviGrad = model.grad;
                noviGrad.DrzavaID = drzaavaID;
                _db.Grad.Update(noviGrad);
                _db.SaveChanges();
            }
            else
            {
                noviGrad = new Grad();
                noviGrad.Naziv = model.grad.Naziv;
                noviGrad.DrzavaID = drzaavaID;


                _db.Grad.Add(noviGrad);
                _db.SaveChanges();
            }
            return Redirect("/Administrator/Lokacije/PrikaziGradove?drzavaID=" +drzaavaID);
        }
    
    }
}