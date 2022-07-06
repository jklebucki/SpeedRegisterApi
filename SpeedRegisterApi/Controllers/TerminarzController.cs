using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SpeedRegisterApi.Data;
using SpeedRegisterApi.Models;
using System.Data.Common;
using System.Data;

namespace SpeedRegisterApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Terminarz")]
    public class TerminarzController : Controller
    {
        private readonly InterlanDbContext _context;

        public TerminarzController(InterlanDbContext context)
        {
            _context = context;
        }

        // GET: api/Terminarz
        [HttpGet]
        public async Task<IEnumerable<Terminarz>> GetTerminarz()
        {
            return await _context.Terminarz.ToListAsync(); //_context.Terminarz;
        }


        // GET: api/Terminarz/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTerminarz([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var terminarz = await _context.Terminarz.SingleOrDefaultAsync(m => m.IdTerminarz == id);

            if (terminarz == null)
            {
                return NotFound();
            }

            return Ok(terminarz);
        }

        // PUT: api/Terminarz/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTerminarz([FromRoute] int id, [FromBody] Terminarz terminarz)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != terminarz.IdTerminarz)
            {
                return BadRequest();
            }

            _context.Entry(terminarz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerminarzExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Terminarz
        [HttpPost]
        public async Task<IActionResult> PostTerminarz([FromBody] Models.MobileAppData md)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            Tabor? auto = new Tabor();
            var barcode = md.barcode.Replace(" ", "").ToUpper();
            string nrR = "";

            if (barcode.Length > 2)
                nrR = barcode.Substring(0, (barcode.Length - 1));

            //Wyszukuję auto
            try
            {
                auto = await _context.Tabor.FirstOrDefaultAsync(nr => nr.NrRej == nrR);
                if (auto == null)
                {
                    return NotFound("Nie znaleziono pojazdu " + nrR);
                }
            }
            catch
            {
                return NotFound("Nie znaleziono pojazdu " + nrR);
            }

            //Tworzę nowy obiekt terminarz
            Terminarz terminarz = new Terminarz();
            //Na początku ustawiam opis
            if (barcode.Substring(barcode.Length - 1, 1) == "R" && barcode.Length > 2)
            {
                terminarz.Opis = "Rozliczenie kierowcy";
            }
            else if (barcode.Substring(barcode.Length - 1, 1) == "F" && barcode.Length > 2)
            {
                terminarz.Opis = "Fracht";
            }
            else
            {
                //jeśli nie ma F lub R przerywam i zgłaszam błąd
                return BadRequest("Nieznany typ dokumentu");
            }

            //Uzupełniam resztę danych
            terminarz.IdTerminarz = idFromProc();
            terminarz.Data = DateTime.Now;
            terminarz.Rodzaj = "Zwrot dokumentów";
            terminarz.Uwagi = "Dane z aplikacji mobilnej";
            terminarz.Uzytkownik = md.location;
            terminarz.UzytkownikWyk = null;
            terminarz.DataWykonania = null;
            terminarz.Klient = "Citronex Trans Logistic Sp. z o.o.";
            terminarz.KlientId = 2708;
            terminarz.Tabor = barcode.Substring(0, barcode.Length - 1);
            terminarz.TaborId = auto.IdTaboru;
            terminarz.Kierowca = null;
            terminarz.KierowcaId = null;
            terminarz.Lokalizacja = null;
            terminarz.Powtarzalny = null;
            terminarz.Interwal = null;
            terminarz.InterwalTyp = null;
            terminarz.KontrahenciCrmId = 1;
            terminarz.KontrahenciCrm = null;
            terminarz.TaborB = auto.NrInwent;
            terminarz.ObjTyp = null;
            terminarz.ObjId = null;

            _context.Terminarz.Add(terminarz);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TerminarzExists(terminarz.IdTerminarz))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return Json(terminarz);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTerminarz([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var terminarz = await _context.Terminarz.SingleOrDefaultAsync(m => m.IdTerminarz == id);
            if (terminarz == null)
            {
                return NotFound();
            }

            _context.Terminarz.Remove(terminarz);
            await _context.SaveChangesAsync();

            return Ok(terminarz);
        }

        private bool TerminarzExists(int id)
        {
            return _context.Terminarz.Any(e => e.IdTerminarz == id);
        }

        private int idFromProc()
        {
            DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();
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
                _context.Database.OpenConnection();
                cmd.ExecuteNonQuery();
                int newID = Convert.ToInt32(cmd.Parameters["@GenValue"].Value);
                _context.Database.CloseConnection();

                return newID;
            }
            catch
            {
                throw;
            }
        }
    }
}
