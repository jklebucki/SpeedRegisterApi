using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SpeedRegisterApi.Data;
using SpeedRegisterApi.DTO;
using SpeedRegisterApi.Models;

namespace SpeedRegisterApi.Repositories
{
    public class TaborRepository : ITaborRepository
    {
        private readonly InterlanDbContext _interlanDbContext;
        private readonly ILogger _logger;

        public TaborRepository(InterlanDbContext interlanDbContext, ILogger<TaborRepository> logger)
        {
            _interlanDbContext = interlanDbContext;
            _logger = logger;
        }

        public async Task<Tabor> GetTaborByCarNumberPlateAsync(string carNumber)
        {
            var vehicle = await _interlanDbContext.Tabor.FirstOrDefaultAsync(v => v.NrRej == carNumber);
            if (vehicle == null)
                throw new Exception($"Vehicle with car plates number {carNumber} does not exist");
            return vehicle;
        }

        public async Task<IEnumerable<Tabor>> GetTaborListByCarNumberPlateAsync(string carNumber)
        {
            carNumber = carNumber.ToUpper().Replace(" ", "");
            var tabor = await _interlanDbContext.Tabor.Where(nr => nr.NrRej.ToUpper().Replace(" ", "").Contains(carNumber) && nr.Aktywny == 1).ToListAsync();
            if (tabor != null && tabor.Count > 0)
                return tabor;
            else
                throw new Exception($"Vehicle {carNumber} not found");
        }
    }
}
