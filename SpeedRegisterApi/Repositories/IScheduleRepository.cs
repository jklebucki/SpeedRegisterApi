using SpeedRegisterApi.Models;

namespace SpeedRegisterApi.Repositories
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Schedule>> GetFullSchedule();
        Task<Schedule> GetSchedule(int sheduleId);
        Task<int> AddSchedule(Schedule shedule);
        Task UpdateSchedule(Schedule shedule);
        Task DeleteSchedule(int sheduleId);
        int GetNewScheduleId();
    }
}
