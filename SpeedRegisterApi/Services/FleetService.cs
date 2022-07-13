using AutoMapper;
using SpeedRegisterApi.DTO;
using SpeedRegisterApi.Repositories;

namespace SpeedRegisterApi.Services
{
    public class FleetService : IFleetService
    {
        private readonly IFleetRepository _taborRepository;
        private readonly IMapper _mapper;

        public FleetService(IFleetRepository taborRepository, IMapper mapper)
        {
            _taborRepository = taborRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FleetDto>> GetFleetListByCarNumberPlateAsync(string carNumber)
        {
            var tabor = await _taborRepository.GetFleetListByCarNumberPlateAsync(carNumber);
            return _mapper.Map<List<FleetDto>>(tabor);
        }
    }
}
