using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityMvc.Controllers
{
    public class AccessCheckerController : Controller
    {
        //accessibale by everyone, even if users are not logged in.
        public IActionResult AllAccess()
        {
            return View();
        }

        //accessible by logged in users
        public IActionResult AuthorizedAccess()
        {
            return View();
        }

        //Accessible by users who have user role
        public IActionResult UserAccess()
        {
            return View();
        }


        //Accessible by users who have admin role
        public IActionResult AdminAccess()
        {
            return View();
        }

        //Accessible by Admin user with a claim of create to be true

        public IActionResult Admin_CreateAccess()
        {
            return View();
        }
        //Accessible by Amin user with claim of create edit and delete (AND NOT OR)
        public IActionResult Admin_Create_Edit_DeleteAccess()
        {
            return View();
        }
        //accessible by admin user with create. edit and delete
        public IActionResult Adm_Create_Edit_DeleteAccess_SuperAdmin()
        {
            return View();
        }
    }
}
