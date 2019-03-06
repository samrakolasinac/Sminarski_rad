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
                rows = _db.Dogadjaj.Select(x => new DogadjajiIndexVM.Row
                {
                    dogadjajID = x.Id,
                    naziv = x.Naziv,
                    pocetak = x.Pocetak,
                    kraj = x.Kraj,
                    tipDogadjaj = x.TipDogadjaja.Naziv


                }).ToList()

            };
            return View(model);
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
            DogadjajiCjenovnikVM model = new DogadjajiCjenovnikVM
            {
                rows = _db.Dogadjaj.Select(x => new DogadjajiCjenovnikVM.Row
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