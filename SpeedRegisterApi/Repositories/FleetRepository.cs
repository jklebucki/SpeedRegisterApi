using Microsoft.EntityFrameworkCore;
using SpeedRegisterApi.Data;
using SpeedRegisterApi.Models;

namespace SpeedRegisterApi.Repositories
{
    public class FleetRepository : IFleetRepository
    {
        private readonly InterlanDbContext _interlanDbContext;
        private readonly ILogger _logger;

        public FleetRepository(InterlanDbContext interlanDbContext, ILogger<FleetRepository> logger)
        {
            _interlanDbContext = interlanDbContext;
            _logger = logger;
        }

        public async Task<Fleet> GetFleetByCarNumberPlateAsync(string carNumber)
        {
            var vehicle = await _interlanDbContext.Fleet.FirstOrDefaultAsync(v => v.NrRej == carNumber);
            if (vehicle == null)
                throw new Exception($"Vehicle with car plates number {carNumber} does not exist");
            return vehicle;
        }

        public async Task<IEnumerable<Fleet>> GetFleetListByCarNumberPlateAsync(string carNumber)
        {
            carNumber = carNumber.ToUpper().Replace(" ", "");
            var tabor = await _interlanDbContext.Fleet.Where(nr => nr.NrRej.ToUpper().Replace(" ", "").Contains(carNumber) && nr.Aktywny == 1).ToListAsync();
            if (tabor != null && tabor.Count > 0)
                return tabor;
            else
                throw new Exception($"Vehicle {carNumber} not found");
        }
    }
}
