using appcuoi.Bussiness.DTOs.Request;
using appcuoi.Bussiness.DTOs.Respond;
using appcuoi.Bussiness.IServices;
using appcuoi.Data.IRepositories;
using appcuoi.Data.Models;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace appcuoi.Bussiness.Services
{
    public class HouseService:IHouseService
    {
        IHouseRepository _houseRepository;
        IMapper _mapper;

        public HouseService(IHouseRepository houseRepository,IMapper mapper)
        {
            _houseRepository = houseRepository;
            _mapper = mapper;
           
        }

        public async Task Addasync(HouseDTOs houseDTOs, int userId)
        {
            var house = _mapper.Map<Houses>(houseDTOs);
            house.UserId= userId;
            await _houseRepository.Add(house);
            
        }

        public async Task<List<ListHouseDTOs>> FindAllAsync()
        {
            var list = await _houseRepository.FindAll();
            return _mapper.Map<List<ListHouseDTOs>>(list);
        }

        public async Task<List<ListHouseDTOs>> FindByDistrictAsync(string districtname)
        {
            var list = await _houseRepository.FindByDistrict(districtname);
            return _mapper.Map<List<ListHouseDTOs>>(list);
        }

        public async Task<List<ListHouseDTOs>> FindByNameAsync(string landlordname)
        {
            var list = await _houseRepository.FindByName(landlordname);
            return _mapper.Map<List<ListHouseDTOs>>(list);
        }

        public async Task<List<ListHouseDTOs>> FindByStreetAsync(string streetname)
        {
            var list = await _houseRepository.FindByStreet(streetname);
            return _mapper.Map<List<ListHouseDTOs>>(list);
        }

        public async Task<List<ListHouseDTOs>> FindByWardAsync(string wardname)
        {
            var list = await _houseRepository.FindByWard(wardname);
            return  _mapper.Map<List<ListHouseDTOs>>(list);
        }

        public async Task<StatusCodeResult> UpdateAsync(Microsoft.AspNetCore.JsonPatch.JsonPatchDocument houseupdate,int houseId, string username)
        {
            var house = await _houseRepository.FindById(houseId);
            if(house == null)
            {
                return new NotFoundResult();
            }
            if(house.User.Username!= username)
            {
                return new UnauthorizedResult();
            }
           houseupdate.ApplyTo(house);
            await _houseRepository.Update();

            return new OkResult();
        }
    }
}
