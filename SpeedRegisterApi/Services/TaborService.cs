using AutoMapper;
using SpeedRegisterApi.DTO;
using SpeedRegisterApi.Repositories;

namespace SpeedRegisterApi.Services
{
    public class TaborService : ITaborService
    {
        private readonly ITaborRepository _taborRepository;
        private readonly IMapper _mapper;

        public TaborService(ITaborRepository taborRepository, IMapper mapper)
        {
            _taborRepository = taborRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaborDto>> GetTaborListByCarNumberPlateAsync(string carNumber)
        {
            var tabor = await _taborRepository.GetTaborListByCarNumberPlateAsync(carNumber);
            return _mapper.Map<List<TaborDto>>(tabor);
        }
    }
}
