using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleMusic.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleMusic.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiecesByIdController : Controller
    {
        private readonly MusicDbContext _context;
        public PiecesByIdController(MusicDbContext context)
        {
            _context = context;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Piece>>> GetPieces(int id)
        {
            List<Piece> pieces = _context.Pieces.Where(a => a.ComposerId == id).ToList();
            return pieces;
        }
    }
}
