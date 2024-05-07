using Microsoft.AspNetCore.Mvc;
using UserManagement.Repositories;
using UserManagement.Data.Models;
using X.PagedList;

namespace UserManagement.Controllers
{
    public class UserController : Controller
    {
        UserRepository userRepository = new UserRepository();
        public IActionResult Index(int page = 1)
        {           
            return View(userRepository.ListT().ToPagedList(page, 5));
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User p)
        {
            if(!ModelState.IsValid)
            {
                return View("AddUser");
            }
            userRepository.AddT(p);
            return RedirectToAction("Index");
        }

        public IActionResult GetUser(int id)
        {
            var x = userRepository.GetT(id);
            User user = new User()
            {
                Username = x.Username,
                Name = x.Name,
                Lastname = x.Lastname,
                Email = x.Email,
                Password = x.Password,
                UserId = x.UserId
            };
            return View(user);
        }

        [HttpPost]
        public IActionResult UpdateUser(User p)
        {
            var x = userRepository.GetT(p.UserId);
            x.Username = p.Username;
            x.Name = p.Name;
            x.Lastname = p.Lastname;
            x.Email = p.Email;
            x.Password = p.Password;
            userRepository.UpdateT(x);
            return RedirectToAction("Index");
        }
    }
}
