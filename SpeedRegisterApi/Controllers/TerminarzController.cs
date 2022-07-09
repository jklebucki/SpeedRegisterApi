using Microsoft.AspNetCore.Mvc;
using SpeedRegisterApi.Models;
using SpeedRegisterApi.Services;

namespace SpeedRegisterApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Terminarz")]
    public class TerminarzController : Controller
    {
        private readonly ITerminarzService _terminarzService;
        private readonly ILogger _logger;

        public TerminarzController(ILogger<TerminarzController> ilogger, ITerminarzService terminarzService)
        {
            _terminarzService = terminarzService;
            _logger = ilogger;
        }

        [HttpGet]
        public async Task<IEnumerable<Terminarz>> GetTerminarz()
        {
            return await _terminarzService.GetFullTerminarzAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTerminarz([FromRoute] int id)
        {
            try
            {
                var terminarz = await _terminarzService.GetTerminarzAsync(id);
                return Ok(terminarz);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTerminarz([FromRoute] int id, [FromBody] Terminarz terminarz)
        {

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid terminarz model");
                return BadRequest(ModelState);
            }

            terminarz.IdTerminarz = id;

            try
            {
                await _terminarzService.UpdateTerminarzAsync(terminarz);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostScheduleAsync([FromBody] MobileAppData mobileAppData)
        {
            try
            {
                var terminarz = await _terminarzService.CreateNewEntryAsync(mobileAppData);
                return Ok(terminarz);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleAsync([FromRoute] int id)
        {
            try
            {
                await _terminarzService.DeleteEntryAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }
        }
    }
}
