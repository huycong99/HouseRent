using appcuoi.Bussiness.DTOs;
using appcuoi.Bussiness.IServices;
using appcuoi.Data.IRepositories;
using appcuoi.Data.Models;
using appcuoi.Data.Repositories;
using AutoMapper;

namespace appcuoi.Bussiness.Services
{
    public class UserService : IUserService
    {
        IMapper _mapper;
        IUserRepository _repository;
        public UserService(IUserRepository userRepository,IMapper mapper) 
        {
            _mapper = mapper;
            _repository = userRepository;
        }
        public async Task<List<UserDTOs>> GetAllAsync()
        {
            var list = await _repository.FindAll();
            var listDTOs= _mapper.Map<List<UserDTOs>>(list);
            return listDTOs;
        }

        public async Task<UserDTOs> GetAsync(string username)
        {
            var user = await _repository.Find(username);
            return _mapper.Map<UserDTOs>(user);
        }
        public async Task AddAsync(UserRegisterDTOs userRegisterDTOs)
        {

            await _repository.Add(_mapper.Map<Users>(userRegisterDTOs));
        }

        public async Task<string> DeleteAsync(string username)
        {
            var user = await _repository.Find(username);
            if(user == null)
            {
                return "User not Found";
            }

            await _repository.Delete(user);
            return "Successfuly";
        }

        public async Task<List<UserDTOs>> GetInactiveAsync()
        {
            var list = await _repository.FindAllInactive();
            return _mapper.Map<List<UserDTOs>>(list);
        }

        public async Task<string> ActiveUserAsync(Microsoft.AspNetCore.JsonPatch.JsonPatchDocument activeuser,string username)
        {
            var user = await _repository.Find(username);
            if (user == null)
            {
                return "User not Found";
            }

            activeuser.ApplyTo(user);
            await _repository.Update();
            return "Successfuly";

        }
    }
}
