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
using SolutionsService.Models.ResponseModels;
using SolutionsService.Logic;

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
        public async Task<ActionResult<SDGResponse>> PostSDG(SDGRequestModel sdg)
        {
            SDG dataModel = SDGRequestModelConverter.ConvertReqModelToDataModel(sdg);

            _context.SDGs.Add(dataModel);
            await _context.SaveChangesAsync();

            SDGResponse response = ResponseModelBuilder.BuildSDGResponse(dataModel);

            return CreatedAtAction("GetSDG", new { id = response.Id }, response);
        }

        [HttpGet]
        public async Task<IEnumerable<SDGResponse>> GetAllSDGs()
        {
            List<SDG> data = await _context.SDGs.ToListAsync();

            List<SDGResponse> response = new List<SDGResponse>();

            foreach(var item in data)
            {
                response.Add(ResponseModelBuilder.BuildSDGResponse(item));
            }

            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SDGResponse>> GetSDG(Guid id)
        {
            var sdg = await _context.SDGs.FindAsync(id);

            if (sdg == null)
            {
                return NotFound();
            }

            return ResponseModelBuilder.BuildSDGResponse(sdg);
        }
    }
}
