using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace CRUD_MVC.Controllers
{
    public class StudentInfoController : Controller
    {
        // GET: StudentInfo
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(string namee,int phone,string email,string pass,string returnUrl)
        {
            if(StudentManager.Insert(namee,phone,email,pass))
            {
                return Redirect(returnUrl ?? Url.Action("Msg", "Home"));
            }
            else { return View(); }
            
        }

       
        public ActionResult DisPlay()
        {
            List<Student> std = StudentManager.GetAllStudent();
            ViewData["Student"] = std;
            return View();
        }

    }
}