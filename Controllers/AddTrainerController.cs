using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttendanceMarking.Models;
using System.Web.Security;


namespace AttendanceMarking.Controllers
{
    public class AddTrainerController : Controller
    {
        // GET: AddQuestion
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddTrainer()
        {
            return View();
        }

        //The form's data in Register view is posted to this method. 
        //We have binded the Register View with Register ViewModel, so we can accept object of Register class as parameter.
        //This object contains all the values entered in the form by the user.
        [HttpPost]
        public ActionResult SaveAddTrainer(TrainerDetail registerDetails)
        {
            //We check if the model state is valid or not. We have used DataAnnotation attributes.
            //If any form value fails the DataAnnotation validation the model state becomes invalid.
            if (ModelState.IsValid)
            {
                //create database context using Entity framework 
                using (var databaseContext = new Attendance_MarkingEntities())
                {
                    //If the model state is valid i.e. the form values passed the validation then we are storing the User's details in DB.
                    TrainerDetail reglog = new TrainerDetail();

                    //Save all details in RegitserUser object

                    reglog.TrainerId = registerDetails.TrainerId;
                    reglog.TrainerName = registerDetails.TrainerName;
                    reglog.ContactNumber = registerDetails.ContactNumber;
                    reglog.Skills = registerDetails.Skills;
                    reglog.Email = registerDetails.Email;

                    //Calling the SaveDetails method which saves the details.
                    databaseContext.TrainerDetails.Add(reglog);
                    databaseContext.SaveChanges();
                }

                ViewBag.Message = " Details Sucessfully Saved";
                //return View("Register");
                return View("AddTrainer");

            }
            else
            {

                //If the validation fails, we are returning the model object with errors to the view, which will display the error messages.
                return View("AddTrainer", registerDetails);
            }
        }

    }
}