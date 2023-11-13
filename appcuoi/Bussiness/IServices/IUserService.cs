using appcuoi.Bussiness.DTOs;
using appcuoi.Data.Models;
using Azure;

namespace appcuoi.Bussiness.IServices
{
    public interface IUserService
    {
        Task<List<UserDTOs>> GetAllAsync();
        Task<UserDTOs> GetAsync(string username);
        Task AddAsync(UserRegisterDTOs userRegisterDTOs);
        Task<string> DeleteAsync(string username);
        Task<List<UserDTOs>> GetInactiveAsync();
        Task<string> ActiveUserAsync(Microsoft.AspNetCore.JsonPatch.JsonPatchDocument activeuser, string username);
    }
}
