using appcuoi.Bussiness.DTOs;
using appcuoi.Bussiness.DTOs.Respond;
using appcuoi.Bussiness.IServices;
using appcuoi.Data.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace appcuoi.Bussiness.Services
{
    public class AuthenServicecs : IAuthenservice
    {
        IUserRepository _userRepository;
        ITokenservice _tokenService;
        public AuthenServicecs(IUserRepository userRepository, ITokenservice tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public async Task<UserLoginResondDTO> loginAsync(UserLoginDTO userLoginDTO)
        {

            var user = await _userRepository.Find(userLoginDTO.Username);
            if(user == null)
            {
                return null;
            }
            if(userLoginDTO.Password != user.Password) 
            {
                return null;
            }
            var _token = _tokenService.CreateToken(user);
            return new UserLoginResondDTO
            {
                Email = user.Email,
                Username = user.Username,
                Token = _token

            };



        }
    }
}
