using appcuoi.Data.Models;

namespace appcuoi.Bussiness.IServices
{
    public interface ITokenservice
    {
        public string CreateToken(Users users);
    }
}
