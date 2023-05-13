using System.ComponentModel.DataAnnotations;
using System.Data;
using BirdFarm.ModelsBD.Role;
namespace BirdFarm.ModelsBD
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Role.Role Role { get; set; }

    }
}
