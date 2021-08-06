using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniResearch.API.Database;
using UniResearch.API.Entity;

namespace UniResearch.API.Repository
{
    public class UserRepository
    {
        private readonly UniResearchContext _dbContext;
        public UserRepository(UniResearchContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GetById
        public async Task<User> GetById(int userId)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(o => o.UserId == userId);
            return user;
        }

        //Update
        public async Task Update(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

        }

        //Insert
        public async Task<User> Insert(User user)
        {
            var insertedUser = _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return insertedUser.Entity;
        }

        //Delete
        public async Task Delete(int userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(o => o.UserId == userId);
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        //Search
        public async Task<List<User>> Search(string searchText)
        {
            var users = await _dbContext.Users
                .AsNoTracking()
                .Where(o => EF.Functions.Like(o.FirstName, $"%{searchText}%")
                || EF.Functions.Like(o.LastName, $"%{searchText}%")
                || EF.Functions.Like(o.Email, $"%{searchText}%"))
                .ToListAsync();

            return users;
        }

        //GetAll
        public async Task<List<User>> GetAll()
        {
            var users = await _dbContext.Users
                .AsNoTracking()
                .ToListAsync();

            return users;
        }
    }
}
