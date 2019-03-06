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

    }
}