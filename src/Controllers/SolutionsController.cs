using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SolutionsService.Data;
using SolutionsService.Helpers;
using SolutionsService.Models;
using SolutionsService.Parameters;

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
        public ActionResult<IEnumerable<Solution>> GetSolution([FromQuery] SolutionParameters solutionParameters)
        {
            var solutions = _context.Solutions.OfType<Solution>().Include("SDGs");

            Console.WriteLine(solutionParameters.SolutionTypes.Count());

            if (solutionParameters.SolutionTypes != null && solutionParameters.SolutionTypes.Any())
            {
                Console.WriteLine("Start filtering Type");
                foreach(var solutionType in solutionParameters.SolutionTypes)
                {
                    Console.WriteLine(solutionType);
                }
                var solutionsFiltered = new List<Solution>();
                if (solutionParameters.SolutionTypes.Contains("Article"))
                {
                    Console.WriteLine("Filter Articles");
                    solutionsFiltered.AddRange(solutions.OfType<Article>());
                }
                if (solutionParameters.SolutionTypes.Contains("HowTo"))
                {
                    Console.WriteLine("Filter HowTo's");
                    solutionsFiltered.AddRange(solutions.OfType<HowTo>());
                }
                solutions = solutionsFiltered.AsQueryable();
            }
            Console.WriteLine(solutions.Count()); 

            if (solutionParameters.WeatherExtremes != null && solutionParameters.WeatherExtremes.Any())
            {
                Console.WriteLine("Start filtering WeatherExtreme");
                var solutionsFiltered = new List<Solution>();
                foreach (var weatherExtreme in solutionParameters.WeatherExtremes)
                {
                    solutionsFiltered.AddRange(solutions.Where(s => s.WeatherExtreme == weatherExtreme));
                }
                solutions = solutionsFiltered.AsQueryable();
            }

            Console.WriteLine("Start filtering SDGs");

            if (solutionParameters.SDGs != null && solutionParameters.SDGs.Any())
            {
                var solutionsFiltered = new List<Solution>();
                foreach(var sdg in solutionParameters.SDGs)
                {
                    solutionsFiltered.AddRange(solutions.Where(s => s.SDGs.Contains(_context.SDGs.FirstOrDefault(sdg => sdg.Name.Equals(sdg)))));
                }
                solutions = solutionsFiltered.AsQueryable();
            }

            //if (!solutionParameters.AuthorId.Equals(Guid.Empty))
            //{
            //    solutions = solutions.Where(s => s.AuthorId.Equals(solutionParameters.AuthorId)).AsQueryable();
            //}

            SearchByName(ref solutions, solutionParameters.Name);

            var pagedSolutions = PagedList<Solution>.ToPagedList(solutions, solutionParameters.PageNumber, solutionParameters.PageSize);

            var metadata = new
            {
                pagedSolutions.TotalCount,
                pagedSolutions.PageSize,
                pagedSolutions.CurrentPage,
                pagedSolutions.TotalPages,
                pagedSolutions.HasNext,
                pagedSolutions.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(pagedSolutions);
        }

        // GET: api/Solutions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solution>> GetSolution(Guid id)
        {
            var solution = await _context.Solutions.FindAsync(id);

            if (solution == null)
            {
                return NotFound();
            }

            return solution;
        }

        // PUT: api/Solutions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolution(Guid id, Solution solution)
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

        // POST: api/Solutions/article
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("article")]
        public async Task<ActionResult<Solution>> PostArticle(Article solution)
        {
            solution.UploadDate = DateTime.Now;
            solution.LastUpdatedTime = DateTime.Now;
            _context.AttachRange(solution.SDGs);
            _context.Solutions.Add(solution);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolution", new { id = solution.Id }, solution);
        }

        // POST: api/Solutions/howto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("howto")]
        public async Task<ActionResult<Solution>> PostHowTo(HowTo solution)
        {
            solution.UploadDate = DateTime.Now;
            solution.LastUpdatedTime = DateTime.Now;
            _context.AttachRange(solution.SDGs);
            _context.Solutions.Add(solution);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolution", new { id = solution.Id }, solution);
        }

        // DELETE: api/Solutions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolution(Guid id)
        {
            var solution = await _context.Solutions.FindAsync(id);
            if (solution == null)
            {
                return NotFound();
            }

            _context.Solutions.Remove(solution);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}/likes/{userId}")]
        public async Task<IActionResult> LikeSolution(Guid id, Guid userId)
        {
            //TODO: implement
            return NoContent();
        }

        [HttpDelete("{id}/likes/{userId}")]
        public async Task<IActionResult> UnlikeSolution(Guid id, Guid userId)
        {
            //TODO: implement
            return NoContent();
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetSolutionsFromAuthor(Guid id)
        {
            //TODO: implement
            return new OkResult();
        }

        [HttpGet("liked/{id}")]
        public async Task<IActionResult> GetSolutionsLikedByUser(Guid id)
        {
            //TODO: implement
            return new OkResult();
        }

        [HttpGet("followed/{id}")]
        public async Task<IActionResult> GetSolutionsFollowedByUser(Guid id)
        {
            //TODO: implement
            return new OkResult();
        }

        private bool SolutionExists(Guid id)
        {
            return _context.Solutions.Any(e => e.Id == id);
        }

        private void SearchByName(ref IQueryable<Solution> solutions, string name)
        {
            if (!solutions.Any() || string.IsNullOrWhiteSpace(name))
            {
                return;
            }
            solutions = solutions.Where(s => s.Name.ToLower().Contains(name.Trim().ToLower()));
        }
    }
}
