
using BirdFarm.Interfaces;
using BirdFarm.ModelsBD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;


namespace Notebook.Controllers
{
    public class AdminController : Controller
    {
      
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;

        public AdminController(IAdminService adminService, IUserService userService)
        {
            _adminService = adminService;
            _userService = userService;
        }
        public IActionResult AddBird()
        {
            return View();
        }
        public async Task<IActionResult> BirdList()
        {
            return View(await _adminService.GetAllBird());
        }
        public async Task<IActionResult> SaveBird(Bird bird)
        {
           await _adminService.AddBird(bird);
            return RedirectToAction("EggsList");
        }
        public async Task<IActionResult> BirdDeletet(int id)
        {
            _adminService.DeleteBird(id);
            return RedirectToAction("BirdList");
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(int id)
        {
        
            var user = await _adminService.GetById(id);
            if (user == null)
            {
             
                return NotFound();
            }
          
            return View(user);
        }
        public IActionResult AddEgg()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditEggs(int id)
        {
           
            return View(await _adminService.GetByIdEgg(id));
        }
        [HttpGet]
        public async Task<IActionResult> EggsList()
        {
         return View( await _userService.GetEggsAsync());
        }
        [HttpPost]
        public async Task<IActionResult> SaveEditEgg(Egg egg)
        {
           await _adminService.UpdateEgg(egg);
            return RedirectToAction("EggsList");
        }
        [HttpGet]
        public async Task<IActionResult> EggsDeletet(int id)
        {
           await _adminService.EggsDelete(id);
            return RedirectToAction("EggsList");
        }
        [HttpPost]
        public async Task<IActionResult> AddEgg(Egg egg)
        {
          await _adminService.AddEgg(egg);
          return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(int id, [Bind("Id,Email,Password,Role")] User user)
        {
            if (id != user.Id)
            {
            
                return NotFound();
            }

            try
            {
                await _adminService.UpdateUser(user);
              
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("GetAllUser");
                }
                else
                {
                    return RedirectToAction("UserTools", "UserWork");
                }
            
            }
            catch (DbUpdateConcurrencyException ex)
            {
              
                ModelState.AddModelError("", "The user has been updated by another user. Please refresh and try again.");
                return View("EditUser", user);
            }
          
        }
     
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _adminService.Delete(id);

            return RedirectToAction("GetAllUser");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var users = await _adminService.GetAll();
              
                return View("ViewAllUser", users);
            }
            catch (Exception ex)
            {
              
                throw;
            }
        }
        public IActionResult ViewAllUser(List<User> user)
        {

            return View(user);
        }

        public IActionResult Tools()
        {
            return View();
        }

       
    }
}
