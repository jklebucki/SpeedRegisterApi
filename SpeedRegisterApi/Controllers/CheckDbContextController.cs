using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeedRegisterApi.Data;

namespace SpeedRegisterApi.Controllers
{
    [Produces("application/json")]
    public class CheckDbContextController : Controller
    {
        private readonly InterlanDbContext _context;

        public CheckDbContextController(InterlanDbContext context)
        {
            _context = context;
        }

        [Route("api/GetFirstTerminarz")]
        [HttpGet]
        public async Task<IActionResult> GetTerminarz()
        {

            var terminarz = await _context.Terminarz.OrderBy(t => t.IdTerminarz).FirstOrDefaultAsync();

            if (terminarz == null)
            {
                return NotFound();
            }

            return Ok(terminarz);
        }

        [Route("api/GetLastTerminarz")]
        [HttpGet]
        public async Task<IActionResult> GetLastTerminarz()
        {

            var terminarz = await _context.Terminarz.OrderBy(t => t.IdTerminarz).LastOrDefaultAsync();

            if (terminarz == null)
            {
                return NotFound();
            }

            return Ok(terminarz);
        }

        [Route("api/GetFirstTabor")]
        [HttpGet]
        public async Task<IActionResult> GetTabor()
        {

            var tabor = await _context.Tabor.OrderBy(t => t.IdTaboru).FirstOrDefaultAsync();

            if (tabor == null)
            {
                return NotFound();
            }

            return Ok(tabor);
        }

        [Route("api/GetLastTabor")]
        [HttpGet]
        public async Task<IActionResult> GetLastTabor()
        {

            var tabor = await _context.Tabor.OrderBy(t => t.IdTaboru).LastOrDefaultAsync();

            if (tabor == null)
            {
                return NotFound();
            }

            return Ok(tabor);
        }
    }
}
