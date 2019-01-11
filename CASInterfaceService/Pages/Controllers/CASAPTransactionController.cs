using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CASInterfaceService.Pages.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CASInterfaceService.Pages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CASAPTransactionController : Controller
    {
        // POST: api/<controller>
        [HttpPost]
        public CASAPTransactionRegistrationReply RegisterCASAPTransaction(CASAPTransaction casAPTransaction)
        {
            Console.WriteLine("In RegisterCASAPTransaction");
            CASAPTransactionRegistrationReply casregreply = new CASAPTransactionRegistrationReply();
            CASAPTransactionRegistration.getInstance().Add(casAPTransaction);
            casregreply.RegistrationStatus = "Success";
            return casregreply;
        }

        [HttpPost("InsertCASAPTransaction")]
        public IActionResult InsertCASAPTransaction(CASAPTransaction casAPTransaction)
        {
            Console.WriteLine("In InsertCASAPTransaction");
            CASAPTransactionRegistrationReply casregreply = new CASAPTransactionRegistrationReply();
            CASAPTransactionRegistration.getInstance().Add(casAPTransaction);
            casregreply.RegistrationStatus = "Success";

            CASAPTransactionRegistration.getInstance().sendTransactionsToCAS(casAPTransaction);
            // Now we must call CAS with this data
            //CallCAS();

            return Ok(casregreply);

        }
        //// POST: api/<controller>
        //[HttpPost]
        //public StudentRegistrationReply RegisterStudent(Student studentregd)
        //{
        //    Console.WriteLine("In registerStudent");
        //    StudentRegistrationReply stdregreply = new StudentRegistrationReply();
        //    StudentRegistration.getInstance().Add(studentregd);
        //    stdregreply.Name = studentregd.Name;
        //    stdregreply.Age = studentregd.Age;
        //    stdregreply.RegistrationNumber = studentregd.RegistrationNumber;
        //    stdregreply.RegistrationStatus = "Successful";
        //    return stdregreply;
        //}
        //[HttpPost("InsertStudent")]
        //public IActionResult InsertStudent(Student studentregd)
        //{
        //    Console.WriteLine("In registerStudent");
        //    StudentRegistrationReply stdregreply = new StudentRegistrationReply();
        //    StudentRegistration.getInstance().Add(studentregd);
        //    stdregreply.Name = studentregd.Name;
        //    stdregreply.Age = studentregd.Age;
        //    stdregreply.RegistrationNumber = studentregd.RegistrationNumber;
        //    stdregreply.RegistrationStatus = "Successful";
        //    return Ok(stdregreply);
        //}
        //[Route("student/")]
        //[HttpPost("AddStudent")]
        //public JsonResult AddStudent(Student studentregd)
        //{
        //    Console.WriteLine("In registerStudent");
        //    StudentRegistrationReply stdregreply = new StudentRegistrationReply();
        //    StudentRegistration.getInstance().Add(studentregd);
        //    stdregreply.Name = studentregd.Name;
        //    stdregreply.Age = studentregd.Age;
        //    stdregreply.RegistrationNumber = studentregd.RegistrationNumber;
        //    stdregreply.RegistrationStatus = "Successful";
        //    return Json(stdregreply);
        //}
    }
}
