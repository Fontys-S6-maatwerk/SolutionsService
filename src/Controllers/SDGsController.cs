using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class SDGsController : ControllerBase
    {
        private readonly SolutionsServiceContext _context;

        public SDGsController(SolutionsServiceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<SDG>> PostSDG(SDGRequestModel sdg)
        {
            SDG dataModel = SDGRequestModelConverter.ConvertReqModelToDataModel(sdg);

            _context.SDGs.Add(dataModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSDG", new { id = dataModel.Id }, dataModel);
        }

        [HttpGet]
        public async Task<IEnumerable<SDG>> GetAllSDGs()
        {
            return await _context.SDGs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SDG>> GetSDG(Guid id)
        {
            var sdg = await _context.SDGs.FindAsync(id);

            if (sdg == null)
            {
                return NotFound();
            }

            return sdg;
        }
    }
}
