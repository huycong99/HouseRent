using appcuoi.Bussiness.DTOs;
using appcuoi.Data.Models;

namespace appcuoi.Data.IRepositories
{
    public interface IUserRepository
    {
        Task<Users> Find(string username); 
        Task<Users> Find(string username, string password);
        Task<List<Users>> FindAll();
        Task<List<Users>> FindAllInactive();

        Task Add(Users users);
        Task Delete(Users Users);
        Task Update();
    }
}
