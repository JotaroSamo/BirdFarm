using BirdFarm.Interfaces;
using BirdFarm.ModelsBD;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BirdFarm.Controllers
{
    public class UserController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        public UserController(IAdminService adminService, IUserService userService)
        {
            _adminService = adminService;
            _userService = userService;
        }
        private int GetCurrentUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        public IActionResult UserTools()
        {
            HttpContext.Session.SetInt32("UserId", GetCurrentUserId());
            return View();
        }
        public async Task<IActionResult> ListShop()
        {

            return View(await _userService.GetEggsAsync());
        }
        public async Task<IActionResult> ListUserCart()
        {
           
            return View(await _userService.GetCart(GetCurrentUserId()));
        }
        [HttpGet]
        public async Task<IActionResult> Pay(int CountEggs, int EggId, int count)
        {
            if (count<=CountEggs)
            {
                await _userService.SaveCart(GetCurrentUserId(), EggId, count);
            }
            return RedirectToAction("ListShop");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id, int CountEggs, int EggsId)
        {
              await _userService.DeleteCart(id, CountEggs, EggsId);
            return RedirectToAction("ListUserCart");
        }
    }
}
