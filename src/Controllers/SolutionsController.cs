using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SolutionsService.Converters;
using SolutionsService.Data;
using SolutionsService.Helpers;
using SolutionsService.Models;
using SolutionsService.Parameters;
using SolutionsService.Models.RequestModel;
using SolutionsService.Models.ResponseModels;

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
        public ActionResult<IEnumerable<Solution>> GetSolution([FromQuery] SolutionParameters solutionParameters)
        {
            var solutions = _context.Solutions.OfType<Solution>().Include(s => s.SDGs).ThenInclude(sdgs => sdgs.SDG).AsQueryable();

            if (solutionParameters.SolutionTypes != null && solutionParameters.SolutionTypes.Any())
            {
                var solutionsFiltered = new List<Solution>();
                if (solutionParameters.SolutionTypes.Contains("Article"))
                {
                    solutionsFiltered.AddRange(solutions.OfType<Article>());
                }
                if (solutionParameters.SolutionTypes.Contains("HowTo"))
                {
                    solutionsFiltered.AddRange(solutions.OfType<HowTo>());
                }
                solutions = solutionsFiltered.AsQueryable();
            } 

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

            if (solutionParameters.SDGs != null && solutionParameters.SDGs.Any())
            {
                var solutionsFiltered = new List<Solution>();
                foreach(var sdg in solutionParameters.SDGs)
                {
                    solutionsFiltered.AddRange(solutions.Where(solution => solution.SDGs.Any(sdgsolution => sdgsolution.SDG.Name.Equals(sdg))));
                }
                solutions = solutionsFiltered.AsQueryable();
            }

            if (!solutionParameters.AuthorId.Equals(Guid.Empty))
            {
                solutions = solutions.Where(s => s.AuthorId.Equals(solutionParameters.AuthorId)).AsQueryable();
            }

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
        public async Task<ActionResult<SolutionResponse>> GetSolution(Guid id)
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

            return solution.ConvertToResponseModel();
        }

        // GET: api/Solutions/SDG
        [HttpGet("sdg")]
        public async Task<ActionResult<IEnumerable<SolutionResponse>>> GetSDGSolutions(Guid id)
        {
            if (!SDGExists(id))
            {
                return NotFound();
            }

            var solutionsPerSDG = await _context.Solutions
                .Include(solutions => solutions.SDGs)
                .ThenInclude(sdg => sdg.SDG)
                .Where(sol => sol.SDGs.Any(sdg => sdg.SDGId == id))
                .ToListAsync();

            List<SolutionResponse> response = new List<SolutionResponse>();

            foreach(var item in solutionsPerSDG)
            {
                response.Add(item.ConvertToResponseModel());
            }

            return response;
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
        public async Task<ActionResult<SolutionResponse>> PostArticle(ArticleRequestModel article)
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

            SolutionResponse response = dataModel.ConvertToResponseModel();

            //return http response
            return CreatedAtAction("GetSolution", new { id = response.Id }, response);
        }

        // POST: api/Solutions/howto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("howto")]
        public async Task<ActionResult<SolutionResponse>> PostHowTo(HowToRequestModel howTo)
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

            SolutionResponse response = dataModel.ConvertToResponseModel();

            //return http response
            return CreatedAtAction("GetSolution", new { id = response.Id }, response);
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
        public async Task<ActionResult<IEnumerable<SolutionResponse>>> GetSolutionsFromAuthor(Guid id)
        {
            var solutionsPerSDG = await _context.Solutions
                .Include(solutions => solutions.SDGs)
                .ThenInclude(sdg => sdg.SDG)
                .Where(sol => sol.AuthorId == id)
                .ToListAsync();

            List<SolutionResponse> response = new List<SolutionResponse>();

            foreach (var item in solutionsPerSDG)
            {
                response.Add(item.ConvertToResponseModel());
            }

            return response;
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
