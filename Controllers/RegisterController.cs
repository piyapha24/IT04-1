using IT04_1.Data;
using IT04_1.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace IT04_1.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;
        public RegisterController(
            ApplicationDbContext dBContext,
            IToastNotification toastNotification
        )
        {
            _context = dBContext;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(ApplicationUser applicationUser, IFormFile Profile) 
        {
            try
            {
                if (Profile != null && Profile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        // อ่านไฟล์ภาพจาก IFormFile
                        await Profile.CopyToAsync(memoryStream);

                        // แปลงเป็น Base64 string
                        applicationUser.Profile = Convert.ToBase64String(memoryStream.ToArray());
                    }
                }

                var user = new ApplicationUser 
                {
                    FirstName = applicationUser.FirstName,
                    LastName = applicationUser.LastName,
                    Email = applicationUser.Email,
                    Phone = applicationUser.Phone,
                    Profile = applicationUser.Profile,
                    BirthDay = applicationUser.BirthDay,
                    Occupation = applicationUser.Occupation,
                    Sex = applicationUser.Sex
                };

                await _context.applicationUsers.AddAsync(user);
                await _context.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("save data success Id : " + user.Id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
