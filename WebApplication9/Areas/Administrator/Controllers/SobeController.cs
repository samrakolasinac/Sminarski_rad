using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.EF;
using Microsoft.AspNetCore.Mvc;
using Hotel.Data.Models;
using WebApplication9.Areas.Administrator.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication9.Helper;

namespace WebApplication9.Areas.Administrator.Controllers
{
    [Autorizacija(false, TipKorisnika.Administrator)]
    [Area("Administrator")]
    public class SobeController : Controller
    {
        private MojContext _db;

        public SobeController(MojContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            SobaIndexVM model = new SobaIndexVM
            {
                sobe=_db.Soba.Select(x=>new SobaIndexVM.Row
                {
                    sobaID=x.Id,
                    Naziv=x.Naziv,
                    tipSObe=x.TipSobe.Naziv,
                    BrojSprata=x.Sprat,
                    cijena=x.Cijena,
                    dostupna=x.Dostupna
                    
                }).ToList()
            };
            return View(model);
        }
        public IActionResult Cjenovnik()
        {
            Cjenovnik model = new Cjenovnik
            {
                rows = _db.Soba.Select(x => new Cjenovnik.Row
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
            SobeDodajVM model = new SobeDodajVM
            {
                soba=new Soba(),
                tipSoba=_db.TipSobe.Select(x=>new SelectListItem {
                    Value=x.Id.ToString(),
                    Text=x.Naziv
                }).ToList()
            };
            return View(model);
        }
        public IActionResult Uredi(int sobaID)
        {
            SobeDodajVM model = new SobeDodajVM
            {
                soba = _db.Soba.Find(sobaID),
                tipSoba = _db.TipSobe.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv
                }).ToList()
            };
            return View(nameof(Dodaj),model);
        }

        public IActionResult DodajTipSobe(int sobaID)
        {
            SobeTipSobeDodajVM model = new SobeTipSobeDodajVM
            {

                TipSobe = new TipSobe(),
                sobaID=sobaID
            };
            return PartialView(model);
        }
     
        public IActionResult SnimiTip(SobeTipSobeDodajVM model, int sobaID)
        { 

            if (!ModelState.IsValid)
            {
               
                return View("DodajTipSobe", model);
            }
            if (sobaID == 0)
            {
                TipSobe tipSobe = new TipSobe();
                tipSobe = model.TipSobe;
                _db.TipSobe.Add(tipSobe);
                _db.SaveChanges();
                return RedirectToAction(nameof(Dodaj));
            }
            else
            {
                TipSobe tipSobe = new TipSobe();
                tipSobe = model.TipSobe;
                _db.TipSobe.Add(tipSobe);
                _db.SaveChanges();
                return RedirectToAction(nameof(Uredi),sobaID);
            }
           
        }
        public IActionResult Snimi(SobeDodajVM model)
        {


            if(!ModelState.IsValid)
            {
                model.tipSoba = _db.TipSobe.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv
                }).ToList();

                return View("Dodaj", model);
            }
            Soba novaSoba = null;
            if (model.soba.Id != 0)
            {
                novaSoba = model.soba;
                _db.Soba.Update(novaSoba);
                _db.SaveChanges();
               
            }
            else 
            {
                novaSoba = new Soba
                {
                    TipSobeID = model.soba.TipSobeID,
                    Naziv = model.soba.Naziv,
                    Sprat = model.soba.Sprat,
                    Cijena=model.soba.Cijena,
                    Dostupna=model.soba.Dostupna
                  

                };
                _db.Soba.Add(novaSoba);
                _db.SaveChanges();
            };
            
            return Redirect("/Administrator/Sobe/Index");
        }
        public IActionResult Obrisi(int sobaID)
        {
            Soba soba = _db.Soba.Find(sobaID);
            _db.Soba.Remove(soba);
            _db.SaveChanges();

            return Redirect("/Administrator/Sobe/Index");
        }
    }
}