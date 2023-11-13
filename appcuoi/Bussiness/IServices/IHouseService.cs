using appcuoi.Bussiness.DTOs.Request;
using appcuoi.Bussiness.DTOs.Respond;
using appcuoi.Data.Models;
using Microsoft.AspNetCore.JsonPatch;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace appcuoi.Bussiness.IServices
{
    public interface IHouseService
    {
        Task Addasync(HouseDTOs houseDTOs,int userId);
        Task<List<ListHouseDTOs>> FindAllAsync();
        Task<List<ListHouseDTOs>> FindByNameAsync(string landlordname);
        Task<List<ListHouseDTOs>> FindByStreetAsync(string streetname);
        Task<List<ListHouseDTOs>> FindByWardAsync(string wardname);
        Task<List<ListHouseDTOs>> FindByDistrictAsync(string districtname);
        Task<StatusCodeResult> UpdateAsync(Microsoft.AspNetCore.JsonPatch.JsonPatchDocument houseupdate,int houseId,string username);  
        
    }
}
