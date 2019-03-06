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
            DodatneUslugeCjenovnikVM model = new DodatneUslugeCjenovnikVM
            {
                rows = _db.DodatneUsluge.Select(x => new DodatneUslugeCjenovnikVM.Row
                {
                    naziv = x.Naziv,
                    cijena = x.Cijena,
                    ID = x.Id
                }).ToList()
            };
            return View(model);
        }




        public IActionResult Detalji(int uslugaID)
        {
            DodatneUslugeDetaljiVM model = new DodatneUslugeDetaljiVM
            {
                dodatneUsluge = _db.DodatneUsluge.Find(uslugaID)
            };
            return View(model);
        }
    }
}