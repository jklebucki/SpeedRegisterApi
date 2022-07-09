using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpeedRegisterApi.Services;

namespace SpeedRegisterApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Tabor")]
    public class TaborController : Controller
    {

        private readonly ITaborService _taborService;
        public readonly IMapper _mapper;

        public TaborController(ITaborService taborService, IMapper mapper)
        {
            _taborService = taborService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTabor([FromRoute] string id)
        {
            try
            {
                var taborDto = await _taborService.GetTaborListByCarNumberPlateAsync(id);
                return Ok(taborDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
