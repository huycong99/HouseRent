using appcuoi.Bussiness.DTOs;
using appcuoi.Data.Context;
using appcuoi.Data.IRepositories;
using appcuoi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace appcuoi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        AppDbContext _dbContext;
        public UserRepository(AppDbContext appDbContext) 
        {
            _dbContext = appDbContext;
        }
        // add
        public async Task Add(Users user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();    
        }

        public async Task Delete(Users user)
        {
             _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        //find
        public async Task<Users> Find(string username)
        {
            
            return await _dbContext.Users.Include(c=>c.Roles).FirstOrDefaultAsync(s => s.Username==username);
            
        }

        public async Task<Users> Find(string username, string password)
        {
            return await _dbContext.Users.Include(c=>c.Roles).FirstOrDefaultAsync(s=>s.Username==username&& s.Password==password);  
            
        }

        public async Task<List<Users>> FindAll()
        {
            return await _dbContext.Users.Include(c=>c.Roles).ToListAsync();
        }

        public async Task<List<Users>> FindAllInactive()
        {
           return await _dbContext.Users.Where(x=>x.ActiveStatus=="Inactive").ToListAsync();
        }

        public async Task Update()
        {
            
            await _dbContext.SaveChangesAsync();
        }
    }
}
