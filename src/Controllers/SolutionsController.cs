using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsService.Data;
using SolutionsService.Models;

namespace SolutionsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionsController : ControllerBase
    {
        private readonly SolutionsServiceContext _context;

        public SolutionsController(SolutionsServiceContext context)
        {
            _context = context;
        }

        // GET: api/Solutions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Solution>>> GetSolution()
        {
            return await _context.Solution.ToListAsync();
        }

        // GET: api/Solutions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solution>> GetSolution(long id)
        {
            var solution = await _context.Solution.FindAsync(id);

            if (solution == null)
            {
                return NotFound();
            }

            return solution;
        }

        // PUT: api/Solutions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolution(long id, Solution solution)
        {
            if (id != solution.Id)
            {
                return BadRequest();
            }

            _context.Entry(solution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolutionExists(id))
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

        // POST: api/Solutions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Solution>> PostSolution(Solution solution)
        {
            _context.Solution.Add(solution);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolution", new { id = solution.Id }, solution);
        }

        // DELETE: api/Solutions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolution(long id)
        {
            var solution = await _context.Solution.FindAsync(id);
            if (solution == null)
            {
                return NotFound();
            }

            _context.Solution.Remove(solution);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SolutionExists(long id)
        {
            return _context.Solution.Any(e => e.Id == id);
        }
    }
}
