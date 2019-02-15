using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CASInterfaceService.Pages.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace CASInterfaceService.Pages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CASAPRetreiveController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<CASAPTransaction> GetAllTransactions()
        {
            return CASAPTransactionRegistration.getInstance().getAllCASAPTransaction();
        }
        [HttpGet("GetAllTransactionRecords")]
        public JsonResult GetAllTransactionRecords()
        {
            return Json(CASAPTransactionRegistration.getInstance().getAllCASAPTransaction());
        }
        [HttpGet("GetTransactionUpdateRecords")]
        public JsonResult GetTransactionUpdateRecords()
        {
            return Json(CASAPTransactionRegistration.getInstance().getAllCASAPTransaction());
        }

        [Route("/api/protected")]
        [Authorize]
        [HttpGet("Protected")]
        public string Protected()
        {
            return "Only if you have a valid token!";
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class CASAPRetrieveController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<CASAPTransaction> GetAllTransactions()
        {
            return CASAPTransactionRegistration.getInstance().getAllCASAPTransaction();
        }
        [HttpGet("GetAllTransactionRecords")]
        public JsonResult GetAllTransactionRecords()
        {
            return Json(CASAPTransactionRegistration.getInstance().getAllCASAPTransaction());
        }
        [HttpGet("GetTransactionUpdateRecords")]
        public JsonResult GetTransactionUpdateRecords()
        {
            return Json(CASAPTransactionRegistration.getInstance().getAllCASAPTransaction());
        }

        [Route("/api/protected")]
        [Authorize]
        [HttpGet("Protected")]
        public string Protected()
        {
            return "Only if you have a valid token!";
        }
    }
}
