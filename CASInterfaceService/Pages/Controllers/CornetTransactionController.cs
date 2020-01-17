using System;
using CASInterfaceService.Pages.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CASInterfaceService.Pages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CornetTransactionController : Controller
    {
        // POST: api/<controller>
        [HttpPost]
        public CornetTransactionRegistrationReply RegisterCornetTransaction(CornetTransaction cornetTransaction)
        {
            Console.WriteLine(DateTime.Now + " In RegisterCornetTransaction");
            CornetTransactionRegistrationReply cornetregreply = new CornetTransactionRegistrationReply();
            CornetTransactionRegistration.getInstance().Add(cornetTransaction);
            cornetregreply.ResponseMessage = "Success";
            cornetregreply.ResponseCode = "1";

            // Responses as follows:
            // 200 - Status OK - Automatically Done
            // 400 - Bad Request (Malformed JSON) - Automatically Done
            // 500 - Internal Server Error (Something wrong on our end)
            // 201 - If anything is being created on our end based on the notification sent
            // This next line is just a sample of how to do it:
            //this.HttpContext.Response.StatusCode = 444;

            return cornetregreply;
        }

        [HttpPost("InsertCornetTransaction")]
        public IActionResult InsertCornetTransaction(CornetTransaction cornetTransaction)
        {
            try
            {
                Console.WriteLine(DateTime.Now + " In InsertCornetTransaction");
                CornetTransactionRegistrationReply casregreply = new CornetTransactionRegistrationReply();
                CornetTransactionRegistration.getInstance().Add(cornetTransaction);
                casregreply.ResponseMessage = "Success";

                return Ok(casregreply);
            }
            catch(Exception e)
            {
                Console.WriteLine(DateTime.Now + " Error in InsertCornetTransaction. " + e.ToString());
                return StatusCode(e.HResult);
            }

        }
    }
}
