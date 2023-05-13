using BirdFarm.ModelsBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace BirdFarm.Interfaces
{
    public interface IAdminService
    {
        Task<List<User>> GetAll();
        Task Delete(int id);
        Task EggsDelete(int id);
        Task<User> GetById(int id);
        Task UpdateUser(User user);

        Task AddEgg(Egg egg);
        Task UpdateEgg(Egg egg);
    }
}
