using SpeedRegisterApi.Models;

namespace SpeedRegisterApi.Repositories
{
    public interface ITaborRepository
    {
        Task<Tabor> GetTaborByCarNumberPlateAsync(string carNumber);
        Task<IEnumerable<Tabor>> GetTaborListByCarNumberPlateAsync(string carNumber);
    }
}
