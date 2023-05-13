using BirdFarm.Models.Coomon;
using BirdFarm.ModelsBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BirdFarm.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(User userCreateDto);

        Task<User> GetAsync(DtoUser userAuthDto);

        Task<User> GetCheckAsync(User checkUser);

        Task<bool> CheckNull(User model);

        Task<List<Egg>> GetEggsAsync();
      

    }
}
