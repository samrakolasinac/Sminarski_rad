using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.EF;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.Helper;

namespace WebApplication9.Areas.Klijent.Controllers
{
    [Autorizacija(false, TipKorisnika.Klijent)]
    [Area("Klijent")]
    public class HomeController : Controller
    {
        private MojContext _db;

        public HomeController(MojContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ONama()
        {
            return View();
        }

        public IActionResult Galerija()
        {
            return View();
        }
    }
}