using appcuoi.Data.Context;
using appcuoi.Data.IRepositories;
using appcuoi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace appcuoi.Data.Repositories
{
    public class HouseRepository:IHouseRepository
    {
        AppDbContext _dbContext;
        public HouseRepository(AppDbContext appDbContext) 
        {
            _dbContext = appDbContext;
        }

        public async Task Add(Houses houses)
        {
            await _dbContext.Houses.AddAsync(houses);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Houses>> FindAll()
        {
            return await _dbContext.Houses.Include(c=>c.User).Include(c=>c.Street.Ward.District).Include(c=>c.Street).Include(c=>c.Street.Ward).ToListAsync();
        }

        public async  Task<List<Houses>> FindByDistrict(string districtnmae)
        {
            var list = await _dbContext.Houses.Include(c => c.User).Include(c => c.Street.Ward.District).Include(c => c.Street).Include(c => c.Street.Ward).Where(s => s.Street.Ward.District.DistrictName == districtnmae).ToListAsync();
            return list;
        }

        public async Task<Houses> FindById(int houseId)
        {
            var house= await _dbContext.Houses.Include(c => c.User).Include(c => c.Street.Ward.District).Include(c => c.Street).Include(c => c.Street.Ward).FirstOrDefaultAsync(s=>s.HouseId==houseId);
            return house;
        }

        public async Task<List<Houses>> FindByName(string landlordname)
        {
            var list = await _dbContext.Houses.Include(c => c.User).Include(c => c.Street.Ward.District).Include(c => c.Street).Include(c => c.Street.Ward).Where(s=>s.User.Username==landlordname).ToListAsync();
            return list;
        }

        public async Task<List<Houses>> FindByStreet(string streetname)
        {
            var list = await _dbContext.Houses.Include(c => c.User).Include(c => c.Street.Ward.District).Include(c => c.Street).Include(c => c.Street.Ward).Where(s => s.Street.StreetName == streetname).ToListAsync();
            return list;
        }

        public async Task<List<Houses>> FindByWard(string wardname)
        {
            var list = await _dbContext.Houses.Include(c => c.User).Include(c => c.Street.Ward.District).Include(c => c.Street).Include(c => c.Street.Ward).Where(s => s.Street.Ward.WardName == wardname).ToListAsync();
            return list;
        }

        public async Task Update()
        {
            
            await _dbContext.SaveChangesAsync();
        }
    }
}
