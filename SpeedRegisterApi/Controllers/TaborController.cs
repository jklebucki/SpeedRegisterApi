using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeedRegisterApi.Data;
using SpeedRegisterApi.DTO;
using SpeedRegisterApi.Models;

namespace SpeedRegisterApi.Controllers
{
    public class TaborController : Controller
    {

        private readonly InterlanDbContext _context;
        public readonly IMapper _mapper;

        public TaborController(InterlanDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTabor([FromRoute] string id)
        {
            List<TaborDto> taborList = new List<TaborDto>();
            id = id.ToUpper().Replace(" ", "");
            var tabor = await _context.Tabor.Where(nr => nr.NrRej.ToUpper().Replace(" ", "").Contains(id) && nr.Aktywny == 1).ToListAsync();
            var taborDto = _mapper.Map<List<TaborDto>>(tabor);
            if (taborDto != null)
                return Ok(taborDto);
            else
                return BadRequest("No data found");
        }

    }
}
