
using BirdFarm.Interfaces;
using BirdFarm.ModelsBD;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BirdFarm.Services
{
    public class AdminService : IAdminService
    {
        private readonly FarmContext _farmContext;
        public AdminService(FarmContext farmContext) 
        { 
          _farmContext = farmContext;
        }

        public async Task AddEgg(Egg egg)
        {
             _farmContext.Eggs.Add(egg);
            _farmContext.SaveChanges();
        }

        public async Task Delete(int id)
        {
            
            _farmContext.Users.Remove(await GetById(id));
            await _farmContext.SaveChangesAsync();
          
        }

        public async Task EggsDelete(int id)
        {
            _farmContext.Eggs.Remove(await _farmContext.Eggs.FirstAsync(c=> c.EggID==id));
            await _farmContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await _farmContext.Users.ToListAsync();
        }


        public async Task<User> GetById(int id)
        {
            return await _farmContext.Users.FindAsync(id);

		}

        

        public async Task UpdateUser(User user)
        {
            _farmContext.Update(user);
            await _farmContext.SaveChangesAsync();
        }
    }
}
