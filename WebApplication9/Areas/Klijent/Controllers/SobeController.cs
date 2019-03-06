using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.EF;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.Areas.Klijent.ViewModels;
using WebApplication9.Helper;

namespace WebApplication9.Areas.Klijent.Controllers
{
    [Autorizacija(false, TipKorisnika.Klijent)]
    [Area("Klijent")]
    public class SobeController : Controller
    {
        private MojContext _db;

        public SobeController(MojContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            SobeIndexVM model = new SobeIndexVM
            {
                sobe = _db.Soba.Where(v=>v.Dostupna==true)
                .Select(x => new SobeIndexVM.Row
                {
                    sobaID = x.Id,
                    Naziv = x.Naziv,
                    tipSObe = x.TipSobe.Naziv,
                    BrojSprata = x.Sprat,
                    cijena = x.Cijena,
                    dostupna = x.Dostupna

                }).ToList()
            };
            return View(model);
        }


        public IActionResult Cjenovnik()
        {
            SobeCjenovnikVM model = new SobeCjenovnikVM
            {
                rows = _db.Soba.Where(v=>v.Dostupna==true)
                .Select(x => new SobeCjenovnikVM.Row
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