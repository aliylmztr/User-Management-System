using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserManagement.Data.Models;
using UserManagement.Repositories;
using X.PagedList;

namespace UserManagement.Controllers
{
    public class AddressController : Controller
    {
        Context c = new Context();
        AddressRepository addressRepository = new AddressRepository();
        public IActionResult Index(int page = 1)
        {            
            return View(addressRepository.ListT("User").ToPagedList(page, 5));
        }

        [HttpGet]
        public IActionResult AddAddress()
        {
            List<SelectListItem> values = (from x in c.Users.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Username,
                                               Value = x.UserId.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddAddress(Address p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddAddress");
            }
            addressRepository.AddT(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAddress(int id)
        {
            addressRepository.DeleteT(new Address {AddressId = id});
            return RedirectToAction("Index");
        }

        public IActionResult GetAddress(int id)
        {
            var x = addressRepository.GetT(id);
            List<SelectListItem> values = (from y in c.Users.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.Username,
                                               Value = y.UserId.ToString()
                                           }).ToList();
            ViewBag.v1 = values;            
            Address a = new Address()
            {
                AddressId = x.AddressId,
                Name = x.Name,
                City = x.City,
                County = x.County,
                Neighbourhood = x.Neighbourhood,
                LongAddress = x.LongAddress,
                UserId = x.UserId
            };
            return View(a);
        }

        [HttpPost]
        public IActionResult UpdateAddress(Address p)
        {
            var x = addressRepository.GetT(p.AddressId);
            x.Name = p.Name;
            x.City = p.City;
            x.County = p.County;
            x.Neighbourhood = p.Neighbourhood;
            x.LongAddress = p.LongAddress;
            x.UserId = p.UserId;
            addressRepository.UpdateT(x);
            return RedirectToAction("Index");
        }
    }
}