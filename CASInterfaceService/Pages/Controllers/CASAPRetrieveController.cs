using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CASInterfaceService.Pages.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace CASInterfaceService.Pages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CASAPRetreiveController : Controller
    {
        private const string URL = "https://wsgw.test.jag.gov.bc.ca/victim/ords/cas/cfs/apinvoice/";
        private const string TokenURL = "https://wsgw.test.jag.gov.bc.ca/victim/ords/cas/oauth/token";
        private string clientID = "";
        private string secret = "";

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
        [HttpPost("GetTransactionRecords")]
        public async Task<JObject> GetTransactionRecords(CASAPQuery casAPQuery)
        {
            // Get the header
            var re = Request;
            var headers = re.Headers;

            // Get clientID and secret from header
            secret = headers["secret"].ToString();
            clientID = headers["clientID"].ToString();

            Console.WriteLine("In RegisterCASAPTransaction");
            CASAPTransactionRegistrationReply casregreply = new CASAPTransactionRegistrationReply();
            CASAPQueryRegistration.getInstance().Add(casAPQuery);

            //return Json(CASAPTransactionRegistration.getInstance().getAllCASAPTransaction());

            //string outputMessage;
            //JsonResult outputJsonMessage;
            string xresponseToken;

            try
            {
                // Start by getting token
                Console.WriteLine("Starting sendTransactionsToCAS.");

                HttpClientHandler handler = new HttpClientHandler();
                Console.WriteLine("GET: + " + TokenURL);

                HttpClient client = new HttpClient(handler);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", clientID, secret))));

                var request = new HttpRequestMessage(HttpMethod.Post, TokenURL);

                var formData = new List<KeyValuePair<string, string>>();
                formData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

                Console.WriteLine("Add credentials");
                request.Content = new FormUrlEncodedContent(formData);
                var response = await client.SendAsync(request);

                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                Console.WriteLine("Response Received: " + response.StatusCode);
                response.EnsureSuccessStatusCode();

                // Put token alone in responseToken
                string responseBody = await response.Content.ReadAsStringAsync();
                var jo = JObject.Parse(responseBody);
                string responseToken = jo["access_token"].ToString();

                Console.WriteLine("Received token successfully, now to send request to CAS.");

                // Token received, now send package using token
                using (var packageClient = new HttpClient())
                {
                    packageClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", responseToken);
                    var jsonString = JsonConvert.SerializeObject(casAPQuery);
                    HttpContent postContent = new StringContent(jsonString);

                    HttpResponseMessage packageResult = await packageClient.GetAsync(URL + casAPQuery.invoiceNumber + "/" + casAPQuery.supplierNumber + "/" + casAPQuery.supplierSiteNumber);


                    // Put token alone in responseToken
                    string xresponseBody = await packageResult.Content.ReadAsStringAsync();
                    var xjo = JObject.Parse(xresponseBody);
                    xresponseToken = xjo["payment_status"].ToString();

                    return xjo;

                }
            }
            catch (Exception e)
            {
                var errorContent = new StringContent(casAPQuery.ToString(), Encoding.UTF8, "application/json");
                Console.WriteLine("Error in sendTransactionsToCASShort. ");// + client.BaseAddress.ToString() + errorContent + client + e.ToString());
                throw e;
            }
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
            // Call CAS to get the proper data
            CASAPTransactionRegistration.getInstance().getTransactionsFromCAS();

            return CASAPTransactionRegistration.getInstance().getAllCASAPTransaction();
        }
        [HttpGet("GetAllTransactionRecords")]
        public JsonResult GetAllTransactionRecords()
        {
            // Call CAS to get the proper data
            CASAPTransactionRegistration.getInstance().getTransactionsFromCAS();

            return Json(CASAPTransactionRegistration.getInstance().getAllCASAPTransaction());
        }
        [HttpGet("GetTransactionUpdateRecords")]
        public JsonResult GetTransactionUpdateRecords()
        {
            // Call CAS to get the proper data
            CASAPTransactionRegistration.getInstance().getTransactionsFromCAS();

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
