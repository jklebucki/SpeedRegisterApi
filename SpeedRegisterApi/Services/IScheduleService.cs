using SpeedRegisterApi.Models;

namespace SpeedRegisterApi.Services
{
    public interface IScheduleService
    {
        Task<Schedule> GetScheduleAsync(int id);
        Task<IEnumerable<Schedule>> GetFullScheduleAsync();
        Task UpdateScheduleAsync(Schedule shedule);
        Task<Schedule> CreateNewEntryAsync(MobileAppData mobileAppData);
        Task DeleteEntryAsync(int id);
    }
}
