using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Logout()
        {
            return RedirectToAction("Login", "Home");
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string EmailId, string Password)
        {
            if (ModelState.IsValid)
            {

                UserContext obj = new UserContext();
                bool check = obj.LoginUser(EmailId, Password);
                if (check == true)
                {
                    return RedirectToAction("GetAllUsers");
                }
                else
                {
                    TempData["InvalidDetails"] = "Either Email or Password is in incorrect";
                    return View();
                }
            }
            else
            {
                return View();
            }
               
        }

        public ActionResult GetAllUsers()
        {
            UserContext obj = new UserContext();
            List<User> user = obj.GetUser();
            return View(user);
        }

        public ActionResult AddUser()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserContext obj = new UserContext();
                    bool check = obj.AddUser(user);
                    if (check == true)
                    {
                        TempData["InsertMsg"] = "Data has been added successfully";
                        ModelState.Clear();
                        return RedirectToAction("GetAllUsers");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
           
        }


        public ActionResult Edit(int id)
        {
            UserContext obj = new UserContext();
            var row = obj.GetUser().Find(user => user.Id == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            
            
                UserContext obj = new UserContext();
                bool check = obj.UpdateUser(user);
                if (check == true)
                {
                    TempData["UpdateMsg"] = "Data has been updated successfully";
                    ModelState.Clear();
                    return RedirectToAction("GetAllUsers");
                }
            
            return View();
        }

        public ActionResult Details(int id)
        {
            UserContext obj = new UserContext();
            var row = obj.GetUser().Find(user => user.Id == id);
            return View(row);
        }

       
    }
}