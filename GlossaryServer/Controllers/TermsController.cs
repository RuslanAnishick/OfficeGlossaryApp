using GlossaryServer.Data;
using GlossaryServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlossaryServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TermsController : ControllerBase
    {
        private readonly GlossaryDbContext _context;

        public TermsController(GlossaryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Term>>> GetTerms()
        {
            return await _context.Terms
                .OrderBy(t => t.Title)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Term>> GetTerm(int id)
        {
            var term = await _context.Terms.FindAsync(id);

            if (term == null)
                return NotFound();

            return term;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Term>>> SearchTerms([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return await _context.Terms.ToListAsync();

            query = query.ToLower();

            return await _context.Terms
                .Where(t =>
                    t.Title.ToLower().Contains(query) ||
                    t.Category.ToLower().Contains(query) ||
                    t.Description.ToLower().Contains(query))
                .OrderBy(t => t.Title)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Term>> CreateTerm(Term term)
        {
            _context.Terms.Add(term);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTerm), new { id = term.Id }, term);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTerm(int id, Term term)
        {
            if (id != term.Id)
                return BadRequest();

            _context.Entry(term).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTerm(int id)
        {
            var term = await _context.Terms.FindAsync(id);

            if (term == null)
                return NotFound();

            _context.Terms.Remove(term);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}