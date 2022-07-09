using SpeedRegisterApi.Models;
using SpeedRegisterApi.Repositories;

namespace SpeedRegisterApi.Services
{
    public class TerminarzService : ITerminarzService
    {
        private readonly ILogger _logger;
        private readonly ITerminarzRepository _terminarzRepository;
        private readonly ITaborRepository _taborRepository;

        public TerminarzService(ILogger<TerminarzService> logger, ITerminarzRepository terminarzRepository, ITaborRepository taborRepository)
        {
            _logger = logger;
            _terminarzRepository = terminarzRepository;
            _taborRepository = taborRepository;
        }

        public async Task<Terminarz> CreateNewEntryAsync(MobileAppData mobileAppData)
        {
            var description = SetDocumentType(mobileAppData);
            var carPlateNumber = mobileAppData.barcode.Replace(" ", "").ToUpper();
            carPlateNumber = carPlateNumber.Substring(0, (carPlateNumber.Length - 1));
            var vehicle = await _taborRepository.GetTaborByCarNumberPlateAsync(carPlateNumber);
            var terminarz = GenerateTerminarz();
            terminarz.Uzytkownik = mobileAppData.location;
            terminarz.Opis = description;
            terminarz.Tabor = carPlateNumber;
            terminarz.TaborId = vehicle.IdTaboru;
            terminarz.TaborB = vehicle.NrInwent;
            try
            {
                terminarz.IdTerminarz = await _terminarzRepository.AddTerminarz(terminarz);
                return terminarz; //mobile app requirements
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

        private Terminarz GenerateTerminarz()
        {
            Terminarz terminarz = new Terminarz();
            terminarz.IdTerminarz = _terminarzRepository.GetNewTerminarzId();
            terminarz.Data = DateTime.Now;
            terminarz.Rodzaj = "Zwrot dokumentów";
            terminarz.Uwagi = "Dane z aplikacji mobilnej";
            terminarz.UzytkownikWyk = null;
            terminarz.DataWykonania = null;
            terminarz.Klient = "Citronex Trans Logistic Sp. z o.o.";
            terminarz.KlientId = 2708;
            terminarz.Kierowca = null;
            terminarz.KierowcaId = null;
            terminarz.Lokalizacja = null;
            terminarz.Powtarzalny = null;
            terminarz.Interwal = null;
            terminarz.InterwalTyp = null;
            terminarz.KontrahenciCrmId = 1;
            terminarz.KontrahenciCrm = null;
            terminarz.ObjTyp = null;
            terminarz.ObjId = null;
            return terminarz;
        }

        public async Task DeleteEntryAsync(int id)
        {
            await _terminarzRepository.DeleteTerminarz(id);
        }

        public async Task<Terminarz> GetTerminarzAsync(int id)
        {
            return await _terminarzRepository.GetTerminarz(id);
        }

        public Task<IEnumerable<Terminarz>> GetFullTerminarzAsync()
        {
            return _terminarzRepository.GetFullTerminarz();
        }

        public async Task UpdateTerminarzAsync(Terminarz terminarz)
        {
            await _terminarzRepository.UpdateTerminarz(terminarz);
        }
    }
}
