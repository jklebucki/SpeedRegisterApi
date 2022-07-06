using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeedRegisterApi.Data;

namespace SpeedRegisterApi.Controllers
{
    [Produces("application/json")]
    public class TestController : Controller
    {
        private readonly InterlanDbContext _context;

        public TestController(InterlanDbContext context)
        {
            _context = context;
            var count = _context.Terminarz.Count().ToString();
            Console.WriteLine("Liczba zapisów w DB: " + count);

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

        [Route("api/GetFirstTabor")]
        [HttpGet]
        public async Task<IActionResult> GetTabor()
        {

            var terminarz = await _context.Tabor.OrderBy(t => t.IdTaboru).FirstOrDefaultAsync();

            if (terminarz == null)
            {
                return NotFound();
            }

            return Ok(terminarz);
        }
    }
}
