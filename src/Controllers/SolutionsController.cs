using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsService.Converters;
using SolutionsService.Data;
using SolutionsService.Models;
using SolutionsService.Models.RequestModel;

namespace SolutionsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ggcPolicy")]
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
            List<Solution> solutions = await _context.Solutions.Include(solution => solution.SDGs).ToListAsync();

            //entity framework is a bit TOO lazy with lazy loading so you have to explicitly load the SDGs in order for them to appear in the response
            foreach (var solution in solutions)
            {
                foreach (SDGSolution sdg in solution.SDGs)
                {
                    await _context.SDGs.FirstOrDefaultAsync(x => x.Id == sdg.SDGId);
                }
            }

            return solutions;
        }

        // GET: api/Solutions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solution>> GetSolution(Guid id)
        {
            var solution = await _context.Solutions.Include(solution => solution.SDGs).FirstOrDefaultAsync(x => x.Id == id);

            //entity framework is a bit TOO lazy with lazy loading so you have to explicitly load the SDGs in order for them to appear in the response
            foreach (SDGSolution sdg in solution.SDGs)
            {
                await _context.SDGs.FirstOrDefaultAsync(x => x.Id == sdg.SDGId);
            }

            if (solution == null)
            {
                return NotFound();
            }

            return solution;
        }

        // GET: api/Solutions/SDG
        [HttpGet("sdg")]
        public async Task<ActionResult<IEnumerable<Solution>>> GetSDGSolutions(Guid id)
        {

            var solutions = await _context.Solutions.Include(solutions => solutions.SDGs).ToListAsync();
            //entity framework is a bit TOO lazy with lazy loading so you have to explicitly load the SDGs in order for them to appear in the response
            foreach (var solution in solutions)
            {
                foreach (SDGSolution sdg in solution.SDGs)
                {
                    await _context.SDGs.FirstOrDefaultAsync(x => x.Id == sdg.SDGId);
 
                }
            }

            var SDGSolution = solutions.Where(SDGSolution => SDGSolution.SDGs.Any(sdg => sdg.SDGId == id)).ToList();
            
            if (SDGSolution == null)
            {
                return NotFound();
            }

            return SDGSolution;
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
        public async Task<ActionResult<Solution>> PostArticle(ArticleRequestModel article)
        {
            //convert to datamodel
            Article dataModel = ArticleRequestModelConverter.ConvertReqModelToDataModel(article);

            //check existence of SDGs
            foreach (var item in dataModel.SDGs)
            {
                if (!SDGExists(item.SDGId))
                {
                    return NotFound();
                }
            }

            //ensure many to many relationship is properly defined
            await PopulateManyToManySDGs(dataModel);

            //save entity
            _context.Solutions.Add(dataModel);
            await _context.SaveChangesAsync();

            //return http response
            return CreatedAtAction("GetSolution", new { id = dataModel.Id }, dataModel);
        }

        // POST: api/Solutions/howto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("howto")]
        public async Task<ActionResult<Solution>> PostHowTo(HowToRequestModel howTo)
        {
            //convert to datamodel
            HowTo dataModel = HowToRequestModelConverter.ConvertReqModelToDataModel(howTo);

            //check existence of SDGs
            foreach (var item in dataModel.SDGs)
            {
                if (!SDGExists(item.SDGId))
                {
                    return NotFound();
                }
            }

            //ensure many to many relationships are properly defined
            await PopulateManyToManySDGs(dataModel);

            //save entity
            _context.Solutions.Add(dataModel);
            await _context.SaveChangesAsync();

            //return http response
            return CreatedAtAction("GetSolution", new { id = dataModel.Id }, dataModel);
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

        private bool SDGExists(Guid id)
        {
            return _context.SDGs.Any(e => e.Id == id);
        }

        private async Task<Solution> PopulateManyToManySDGs(Solution solution)
        {
            List<SDG> sdgEntities = new List<SDG>();

            foreach (var item in solution.SDGs)
            {
                SDG sdg = await _context.SDGs.FindAsync(item.SDGId);
                item.SDG = sdg;
            }

            return solution;
        }
    }
}
