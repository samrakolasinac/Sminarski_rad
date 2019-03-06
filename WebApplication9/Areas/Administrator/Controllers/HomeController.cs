using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.EF;
using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.Helper;

namespace WebApplication9.Areas.Administrator.Controllers
{
    [Autorizacija(false, TipKorisnika.Administrator)]
    [Area("Administrator")]
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
    }
}