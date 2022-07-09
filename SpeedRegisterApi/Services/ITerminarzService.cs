using SpeedRegisterApi.Models;

namespace SpeedRegisterApi.Services
{
    public interface ITerminarzService
    {
        Task<Terminarz> GetTerminarzAsync(int id);
        Task<IEnumerable<Terminarz>> GetFullTerminarzAsync();
        Task UpdateTerminarzAsync(Terminarz terminarz);
        Task<Terminarz> CreateNewEntryAsync(MobileAppData mobileAppData);
        Task DeleteEntryAsync(int id);
    }
}
