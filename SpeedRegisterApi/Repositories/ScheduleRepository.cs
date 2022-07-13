using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SpeedRegisterApi.Data;
using SpeedRegisterApi.Models;
using System.Data;
using System.Data.Common;

namespace SpeedRegisterApi.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly InterlanDbContext _interlanDbContext;
        private readonly ILogger _logger;

        public ScheduleRepository(InterlanDbContext interlanDbContext, ILogger<ScheduleRepository> logger)
        {
            _interlanDbContext = interlanDbContext;
            _logger = logger;
        }

        public async Task<int> AddSchedule(Schedule schedule)
        {
            try
            {
                await _interlanDbContext.AddAsync(schedule);
                await _interlanDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                throw new Exception("Error - I can't add a new entry");
            }
            return schedule.IdTerminarz;
        }

        public async Task DeleteSchedule(int terminarzId)
        {
            var terminarz = await _interlanDbContext.Schedule.FirstOrDefaultAsync(t => t.IdTerminarz == terminarzId);
            if (terminarz == null)
                throw new Exception($"The schedule with id {terminarzId} does not exist.");
            try
            {
                _interlanDbContext.Remove(terminarz);
                await _interlanDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Schedule>> GetFullSchedule()
        {
            return await _interlanDbContext.Schedule.ToListAsync();
        }

        public async Task<Schedule> GetSchedule(int terminarzId)
        {
            var terminarz = await _interlanDbContext.Schedule.FirstOrDefaultAsync(t => t.IdTerminarz == terminarzId);
            if (terminarz == null)
                throw new Exception($"The schedule with id {terminarzId} does not exist.");
            return terminarz;
        }

        public async Task UpdateSchedule(Schedule schedule)
        {
            try
            {
                _interlanDbContext.Entry(schedule).State = EntityState.Modified;
                await _interlanDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                throw new Exception("I can't update schedule");
            }
        }
        public int GetNewScheduleId()
        {
            DbCommand cmd = _interlanDbContext.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "[dbo].[GENER_ID]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@GENER_NAME";
            p1.DbType = DbType.String;
            p1.Value = "GID_TERMINARZ";
            p1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(p1);


            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@GenValue";
            p2.DbType = DbType.Int32;
            p2.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(p2);

            try
            {
                _interlanDbContext.Database.OpenConnection();
                cmd.ExecuteNonQuery();
                int newID = Convert.ToInt32(cmd.Parameters["@GenValue"].Value);
                _interlanDbContext.Database.CloseConnection();

                return newID;
            }
            catch
            {
                throw;
            }
        }
    }
}
