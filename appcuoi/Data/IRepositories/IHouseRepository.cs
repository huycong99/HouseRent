using appcuoi.Data.Models;

namespace appcuoi.Data.IRepositories
{
    public interface IHouseRepository
    {
        Task Add(Houses houses);
        Task<Houses> FindById(int houseId);

        Task<List<Houses>> FindAll();
        Task<List<Houses>> FindByName(string landlordname);
        Task<List<Houses>> FindByStreet(string streetname);
        Task<List<Houses>> FindByWard(string wardname);
        Task<List<Houses>> FindByDistrict(string districtnmae);
        Task Update();


    }
}
