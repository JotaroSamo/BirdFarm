
using BirdFarm.Models.Coomon;
using BirdFarm.ModelsBD;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BirdFarm.Interfaces
{
    public class UserService : IUserService
    {
        private readonly FarmContext _farmContext;

		public UserService(FarmContext farmContext)
        {
         _farmContext = farmContext;
		}

        public async Task<bool> CheckNull(User model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                return false;
            }
            return true;
        }

        public async Task CreateAsync(User userCreateDto)
        {

            _farmContext.Users.Add(userCreateDto);
            await _farmContext.SaveChangesAsync();
            
        }

       

        public async Task<User> GetAsync(DtoUser userAuthDto)
        {
            var user = await _farmContext.Users.FirstOrDefaultAsync(u =>
                u.Email == userAuthDto.Email && u.Password == userAuthDto.Password);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<User> GetCheckAsync(User checkUser)
        {
            var user = await _farmContext.Users.FirstOrDefaultAsync(u =>
                 u.Email == checkUser.Email);
            if (user == null)
            {
                return null;
            }
			return user;
		}

        public async Task<List<Egg>> GetEggsAsync()
        {
           return await _farmContext.Eggs.ToListAsync();
        }
    }
}
