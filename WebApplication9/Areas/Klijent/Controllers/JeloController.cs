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
                    jeloID = x.Id,
                    Naziv = x.Naziv,
                    Opis = x.Opis
                }).ToList()
            };
            return View(model);
        }


        public IActionResult Cjenovnik()
        {
            JeloCjenovnikVM model = new JeloCjenovnikVM
            {
                rows = _db.Jelo.Select(x => new JeloCjenovnikVM.Row
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