using SpeedRegisterApi.Models;

namespace SpeedRegisterApi.Repositories
{
    public interface IFleetRepository
    {
        Task<Fleet> GetFleetByCarNumberPlateAsync(string carNumber);
        Task<IEnumerable<Fleet>> GetFleetListByCarNumberPlateAsync(string carNumber);
    }
}
