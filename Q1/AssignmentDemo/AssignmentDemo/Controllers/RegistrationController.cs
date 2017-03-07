using AssignmentDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentDemo.Controllers
{
    public class RegistrationController : Controller
    {
        //
        // GET: /Registration/

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Index1()
        {
            RegistrationDBEntities entobj = new RegistrationDBEntities();
            List<tblRegistration> reg = entobj.tblRegistrations.ToList();
            return View(reg);
        }

        [HttpPost]
        public ActionResult AddDetails(FormCollection e)
        {
            string _msg = string.Empty;
            RegistrationDBEntities entobj = new RegistrationDBEntities();
            tblRegistration reg = new tblRegistration();
            if (e["UserID"]!="0")
            {
                int UserID = Convert.ToInt32(e["UserID"]);
                reg = entobj.tblRegistrations.Where(x => x.UserID == UserID).FirstOrDefault();
            }
           
            tblRegistration Registarion = new tblRegistration();
            Registarion.UserName = e["UserName"];
            Registarion.Password = e["Password"];
            Registarion.LastName = e["LastName"];
            Registarion.ConfirmPassword = e["ConfirmPassword"];
            Registarion.EmailID = e["EmailID"];
            Registarion.FirstName = e["FirstName"];
            Registarion.Location = e["Location"];
            Registarion.PhoneNo = e["PhoneNo"];
            if (reg.UserID != 0)
            {
                reg.UserName = e["UserName"];
                reg.Password = e["Password"];
                reg.LastName = e["LastName"];
                reg.ConfirmPassword = e["ConfirmPassword"];
                reg.EmailID = e["EmailID"];
                reg.FirstName = e["FirstName"];
                reg.Location = e["Location"];
                reg.PhoneNo = e["PhoneNo"];
                _msg = "Record Updated Successfully!";
            }
            else
            {
                entobj.tblRegistrations.Add(Registarion);
                _msg = "Record Saved Successfully!";
            }
            entobj.SaveChanges();
            
            return new JsonResult() { Data = new { message = _msg, flag = 0, flagClass = "alert-success" } };
        }


        //[HttpPost]
        //public ActionResult AddDetails(tblRegistration e)
        //{
        //    string _msg = string.Empty;
        //    RegistrationDBEntities entobj = new RegistrationDBEntities();
        //    tblRegistration reg = entobj.tblRegistrations.Where(x => x.UserID ==e.UserID).FirstOrDefault();
        //    tblRegistration Registarion = new tblRegistration();
        //    //Registarion.UserName = e.UserName;
        //    //Registarion.Password = e.Password;
        //    //Registarion.LastName = e.LastName;
        //    //Registarion.ConfirmPassword = e.ConfirmPassword;
        //    //Registarion.EmailID = e.EmailID;
        //    //Registarion.FirstName = e.FirstName;
        //    //Registarion.Location = e.Location;
        //    //Registarion.PhoneNo = e.PhoneNo;
        //    if (reg != null)
        //    {
        //        Registarion.UserName = e.UserName;
        //        Registarion.Password = e.Password;
        //        Registarion.LastName = e.LastName;
        //        Registarion.ConfirmPassword = e.ConfirmPassword;
        //        Registarion.EmailID = e.EmailID;
        //        Registarion.FirstName = e.FirstName;
        //        Registarion.Location = e.Location;
        //        Registarion.PhoneNo = e.PhoneNo;

        //    }
        //    else
        //    {
        //        entobj.tblRegistrations.Add(Registarion);

        //    }
        //    entobj.SaveChanges();
        //    _msg = "Record Saved Successfully!";
        //    return new JsonResult() { Data = new { message = _msg, flag = 0, flagClass = "alert-success" } };
        //}
        public ActionResult DelDetails(int userid)
        {
            string _msg = string.Empty;
            RegistrationDBEntities entobj = new RegistrationDBEntities();
            tblRegistration reg = entobj.tblRegistrations.Where(x => x.UserID == userid).FirstOrDefault();
            entobj.tblRegistrations.Remove(reg);
            entobj.SaveChanges();
              return new JsonResult() { Data = new { message = "Record Deleted Successfully!", flag = 0, flagClass = "alert-success" } };
        }
        public ActionResult Edit(int userid)
        {
            
            string _msg = string.Empty;
            RegistrationDBEntities entobj = new RegistrationDBEntities();
            tblRegistration reg = entobj.tblRegistrations.Where(x => x.UserID == userid).FirstOrDefault();
            
         
            if (reg != null)
            {
                return new JsonResult() { Data = new {data=reg, message = "Record Updated Successfully!", flag = 0, flagClass = "alert-success" } };
            }
            else
            {
                return new JsonResult() { Data = new {data=reg, message = "Record Not Updated Successfully!", flag = 0, flagClass = "alert-success" } };
            }
            
           
            
        }
    }
}
