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

        [HttpGet("{vehiclePlateNumber}")]
        public async Task<IActionResult> GetTabor([FromRoute] string vehiclePlateNumber)
        {
            try
            {
                var taborDto = await _taborService.GetTaborListByCarNumberPlateAsync(vehiclePlateNumber);
                return Ok(taborDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
