using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleMusic.Models;

namespace SimpleMusic.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiecesController : ControllerBase
    {
        private readonly MusicDbContext _context;

        public PiecesController(MusicDbContext context)
        {
            _context = context;
        }

        // GET: api/Pieces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Piece>>> GetPieces()
        {
            return await _context.Pieces.ToListAsync();
        }

        // GET: api/Pieces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Piece>> GetPiece(int id)
        {
            var piece = await _context.Pieces.FindAsync(id);

            if (piece == null)
            {
                return NotFound();
            }

            return piece;
        }

        // PUT: api/Pieces/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiece(int id, Piece piece)
        {
            if (id != piece.Id)
            {
                return BadRequest();
            }

            _context.Entry(piece).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PieceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pieces
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Piece>> PostPiece(Piece piece)
        {
            if (PieceExists(piece))
                return BadRequest("Error");
            _context.Pieces.Add(piece);
            await _context.SaveChangesAsync();

            return Ok(piece);
        }

        // DELETE: api/Pieces/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Piece>> DeletePiece(int id)
        {
            var piece = await _context.Pieces.FindAsync(id);
            if (piece == null)
            {
                return NotFound();
            }

            _context.Pieces.Remove(piece);
            await _context.SaveChangesAsync();

            return piece;
        }

        private bool PieceExists(int id)
        {
            return _context.Pieces.Any(e => e.Id == id);
        }
        private bool PieceExists(Piece piece)
        {
            return _context.Pieces.Any(e => e.Name == piece.Name && e.Composer == piece.Composer);
        }
    }
}
