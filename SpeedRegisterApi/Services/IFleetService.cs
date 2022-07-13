using SpeedRegisterApi.DTO;

namespace SpeedRegisterApi.Services
{
    public interface IFleetService
    {
        Task<IEnumerable<FleetDto>> GetFleetListByCarNumberPlateAsync(string carNumber);
    }
}
