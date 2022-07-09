using SpeedRegisterApi.DTO;

namespace SpeedRegisterApi.Services
{
    public interface ITaborService
    {
        Task<IEnumerable<TaborDto>> GetTaborListByCarNumberPlateAsync(string carNumber);
    }
}
