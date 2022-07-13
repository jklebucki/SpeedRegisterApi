using SpeedRegisterApi.Models;
using SpeedRegisterApi.Repositories;

namespace SpeedRegisterApi.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly ILogger _logger;
        private readonly IScheduleRepository _sheduleRepository;
        private readonly IFleetRepository _fleetRepository;

        public ScheduleService(ILogger<ScheduleService> logger, IScheduleRepository sheduleRepository, IFleetRepository fleetRepository)
        {
            _logger = logger;
            _sheduleRepository = sheduleRepository;
            _fleetRepository = fleetRepository;
        }

        public async Task<Schedule> CreateNewEntryAsync(MobileAppData mobileAppData)
        {
            var description = SetDocumentType(mobileAppData);
            var carPlateNumber = mobileAppData.barcode.Replace(" ", "").ToUpper();
            carPlateNumber = carPlateNumber.Substring(0, (carPlateNumber.Length - 1));
            var vehicle = await _fleetRepository.GetFleetByCarNumberPlateAsync(carPlateNumber);
            var shedule = GenerateShedule();
            shedule.Uzytkownik = mobileAppData.location;
            shedule.Opis = description;
            shedule.Tabor = carPlateNumber;
            shedule.TaborId = vehicle.IdTaboru;
            shedule.TaborB = vehicle.NrInwent;
            try
            {
                shedule.IdTerminarz = await _sheduleRepository.AddSchedule(shedule);
                return shedule; //mobile app requirements
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                throw new Exception("I cant't add a new entry to the schedule.");
            }
        }

        private string SetDocumentType(MobileAppData mobileAppData)
        {
            var barcode = mobileAppData.barcode;
            if (barcode.Substring(barcode.Length - 1, 1) == "R" && barcode.Length > 2)
            {
                return "Rozliczenie kierowcy";
            }
            else if (barcode.Substring(barcode.Length - 1, 1) == "F" && barcode.Length > 2)
            {
                return "Fracht";
            }
            else
            {
                throw new Exception("Wrong barcode data - R or F not found.");
            }
        }

        private Schedule GenerateShedule()
        {
            Schedule shedule = new Schedule();
            shedule.IdTerminarz = _sheduleRepository.GetNewScheduleId();
            shedule.Data = DateTime.Now;
            shedule.Rodzaj = "Zwrot dokumentów";
            shedule.Uwagi = "Dane z aplikacji mobilnej";
            shedule.UzytkownikWyk = null;
            shedule.DataWykonania = null;
            shedule.Klient = "Citronex Trans Logistic Sp. z o.o.";
            shedule.KlientId = 2708;
            shedule.Kierowca = null;
            shedule.KierowcaId = null;
            shedule.Lokalizacja = null;
            shedule.Powtarzalny = null;
            shedule.Interwal = null;
            shedule.InterwalTyp = null;
            shedule.KontrahenciCrmId = 1;
            shedule.KontrahenciCrm = null;
            shedule.ObjTyp = null;
            shedule.ObjId = null;
            return shedule;
        }

        public async Task DeleteEntryAsync(int id)
        {
            await _sheduleRepository.DeleteSchedule(id);
        }

        public async Task<Schedule> GetScheduleAsync(int id)
        {
            return await _sheduleRepository.GetSchedule(id);
        }

        public Task<IEnumerable<Schedule>> GetFullScheduleAsync()
        {
            return _sheduleRepository.GetFullSchedule();
        }

        public async Task UpdateScheduleAsync(Schedule shedule)
        {
            await _sheduleRepository.UpdateSchedule(shedule);
        }
    }
}
