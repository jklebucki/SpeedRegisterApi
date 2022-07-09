using SpeedRegisterApi.Models;

namespace SpeedRegisterApi.Repositories
{
    public interface ITerminarzRepository
    {
        Task<IEnumerable<Terminarz>> GetFullTerminarz();
        Task<Terminarz> GetTerminarz(int terminarzId);
        Task<int> AddTerminarz(Terminarz terminarz);
        Task UpdateTerminarz(Terminarz terminarz);
        Task DeleteTerminarz(int terminarzId);
        int GetNewTerminarzId();
    }
}
