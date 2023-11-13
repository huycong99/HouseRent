using appcuoi.Bussiness.DTOs;
using appcuoi.Bussiness.DTOs.Respond;

namespace appcuoi.Bussiness.IServices
{
    public interface IAuthenservice
    {
        Task<UserLoginResondDTO> loginAsync(UserLoginDTO userLoginDTO);

    }
}
