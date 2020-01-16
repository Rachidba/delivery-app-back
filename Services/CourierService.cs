using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using delivery_app_back.DbContext;
using delivery_app_back.Entities;
using delivery_app_back.Models;

namespace delivery_app_back.Services
{
    public interface ICourierService
    {
        Task<ICollection<CourierItemDto>> Get();
        Task<CourierDetailsDto> Get(int userId);
        Task<CourierDetailsDto> Create(CourierForCreationDto courierData);
    }
    
    public class CourierService : ICourierService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public CourierService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ICollection<CourierItemDto>> Get()
        {
            var couriers = await _dbContext.GetCouriers();

            return _mapper.Map<ICollection<CourierItemDto>>(couriers);
        }

        public async Task<CourierDetailsDto> Get(int userId)
        {
            var foundCourier = await _dbContext.GetCourier(userId);

            return foundCourier == null ? null : _mapper.Map<CourierDetailsDto>(foundCourier);
        }

        public async Task<CourierDetailsDto> Create(CourierForCreationDto courierData)
        {
            var courierToSave = _mapper.Map<Courier>(courierData);
            await _dbContext.CreateCourier(courierToSave);

            return courierToSave == null ? null : _mapper.Map<CourierDetailsDto>(courierToSave);
        }
    }
}