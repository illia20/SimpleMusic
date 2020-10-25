using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleMusic.Models;

namespace SimpleMusic.Controllers
{
    public class MapsController : Controller
    {
        private readonly MusicDbContext _context;
        public MapsController(MusicDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetData()
        {
            List<Composer> c = new List<Composer>();
            foreach(Composer comp in _context.Composers)
            {
                c.Add(comp);
            }
            return Json(c);
        }
    }
}