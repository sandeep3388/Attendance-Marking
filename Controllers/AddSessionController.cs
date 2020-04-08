using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttendanceMarking.Models;
using System.Web.Security;


namespace AttendanceMarking.Controllers
{
    public class AddSessionController : Controller
    {
        // GET: CourseCode
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddSession()
        {
            return View();
        }

        //The form's data in Register view is posted to this method. 
        //We have binded the Register View with Register ViewModel, so we can accept object of Register class as parameter.
        //This object contains all the values entered in the form by the user.
        [HttpPost]
        public ActionResult SaveAddCourse(Session registerDetails)
        {
            //We check if the model state is valid or not. We have used DataAnnotation attributes.
            //If any form value fails the DataAnnotation validation the model state becomes invalid.
            if (ModelState.IsValid)
            {
                //create database context using Entity framework 
                using (var databaseContext = new Attendance_MarkingEntities())
                {
                    //If the model state is valid i.e. the form values passed the validation then we are storing the User's details in DB.
                    Session reglog = new Session();

                    //Save all details in RegitserUser object

                    reglog.SessionId = registerDetails.SessionId;
                    reglog.SessionDescription = registerDetails.SessionDescription;
                    reglog.Skills = registerDetails.Skills;
                    reglog.SessionDate = registerDetails.SessionDate;
                    reglog.SessionTime = registerDetails.SessionTime;

                    //Calling the SaveDetails method which saves the details.
                    databaseContext.Sessions.Add(reglog);
                    databaseContext.SaveChanges();
                }

                ViewBag.Message = " Session Details Sucessfully Saved";
                //return View("Register");
                return View("AddSession");

            }
            else
            {

                //If the validation fails, we are returning the model object with errors to the view, which will display the error messages.
                return View("AddSession", registerDetails);
            }
        }

    }
}