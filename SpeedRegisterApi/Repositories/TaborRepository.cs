using Microsoft.EntityFrameworkCore;
using SpeedRegisterApi.Data;
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
    }
}
