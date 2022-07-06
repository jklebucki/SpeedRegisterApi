using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeedRegisterApi.Data;
using SpeedRegisterApi.DTO;

namespace SpeedRegisterApi.Controllers
{
    public class TaborController : Controller
    {

        private readonly InterlanDbContext _context;

        public TaborController(InterlanDbContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public async Task<IEnumerable<TaborDto>> GetTabor([FromRoute] string id)
        {
            List<TaborDto> taborList = new List<TaborDto>();
            id = id.ToUpper().Replace(" ", "");
            var tabor = await _context.Tabor.Where(nr => nr.NrRej.ToUpper().Replace(" ", "").Contains(id) && nr.Aktywny == 1).ToListAsync();
            foreach (var el in tabor)
            {
                taborList.Add(new TaborDto()
                {
                    IdTaboru = el.IdTaboru,
                    NrRej = el.NrRej,
                    Marka = el.Marka,
                    Model = el.Model,
                    Wlasciciel = el.Wlasciciel,
                    Dzial = el.Dzial,
                    Podwykonawca = el.Podwykonawca
                });
            }
            Console.WriteLine($"{taborList.Count}");
            return taborList;
        }

    }
}
