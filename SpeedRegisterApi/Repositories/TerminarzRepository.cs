using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SpeedRegisterApi.Data;
using SpeedRegisterApi.Models;
using System.Data;
using System.Data.Common;

namespace SpeedRegisterApi.Repositories
{
    public class TerminarzRepository : ITerminarzRepository
    {
        private readonly InterlanDbContext _interlanDbContext;
        private readonly ILogger _logger;

        public TerminarzRepository(InterlanDbContext interlanDbContext, ILogger<TerminarzRepository> logger)
        {
            _interlanDbContext = interlanDbContext;
            _logger = logger;
        }

        public async Task<int> AddTerminarz(Terminarz terminarz)
        {
            try
            {
                await _interlanDbContext.AddAsync(terminarz);
                await _interlanDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                throw new Exception("Error - I can't add a new entry");
            }
            return terminarz.IdTerminarz;
        }

        public async Task DeleteTerminarz(int terminarzId)
        {
            var terminarz = await _interlanDbContext.Terminarz.FirstOrDefaultAsync(t => t.IdTerminarz == terminarzId);
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

        public async Task<IEnumerable<Terminarz>> GetFullTerminarz()
        {
            return await _interlanDbContext.Terminarz.ToListAsync();
        }

        public async Task<Terminarz> GetTerminarz(int terminarzId)
        {
            var terminarz = await _interlanDbContext.Terminarz.FirstOrDefaultAsync(t => t.IdTerminarz == terminarzId);
            if (terminarz == null)
                throw new Exception($"The schedule with id {terminarzId} does not exist.");
            return terminarz;
        }

        public async Task UpdateTerminarz(Terminarz terminarz)
        {
            try
            {
                _interlanDbContext.Entry(terminarz).State = EntityState.Modified;
                _interlanDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                throw new Exception("I can't update schedule");
            }
        }
        public int GetNewTerminarzId()
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
