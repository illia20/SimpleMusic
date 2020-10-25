using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleMusic.Models;

namespace SimpleMusic.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InputController : ControllerBase
    {
        private readonly MusicDbContext _context;
        public InputController(MusicDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public JsonResult AutocompleteCountryId(string term)
        {
            var m = _context.Countries.Where(q => q.Name.StartsWith(term)).Select(q => new { label = q.Name, value = q.Id }).Distinct();
            return new JsonResult(m);
        }
    }
}