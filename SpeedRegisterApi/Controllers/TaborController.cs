using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpeedRegisterApi.Services;

namespace SpeedRegisterApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Tabor")]
    public class TaborController : Controller
    {

        private readonly IFleetService _fleetService;
        public readonly IMapper _mapper;

        public TaborController(IFleetService fleetService, IMapper mapper)
        {
            _fleetService = fleetService;
            _mapper = mapper;
        }

        [HttpGet("{vehiclePlateNumber}")]
        public async Task<IActionResult> GetTabor([FromRoute] string vehiclePlateNumber)
        {
            try
            {
                var taborDto = await _fleetService.GetFleetListByCarNumberPlateAsync(vehiclePlateNumber);
                return Ok(taborDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
