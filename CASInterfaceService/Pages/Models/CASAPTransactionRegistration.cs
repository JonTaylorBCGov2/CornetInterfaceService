using Microsoft.AspNetCore.Authentication.Twitter;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CASInterfaceService.Pages.Models
{
    public class CASAPTransactionRegistration
    {
        List<CASAPTransaction> casAPTransactionList;
        static CASAPTransactionRegistration casregd = null;

        // TEST  - molson.cas.gov.bc.ca - 142.34.166.75  - 7015
        // TRAIN - molson.cas.gov.bc.ca - 142.34.166.75  - 7013
        // PROD  - labatt.cas.gov.bc.ca - 142.34.166.201 - 7010

        //private const string URL = "https://<server>:<port>ords/cas/cfs/apinvoice/";
        private const string URL = "https://molson.cas.gov.bc.ca:7015/ords/cas/cfs/apinvoice/";
        //private const string TokenURL = "https://<server>:<port>/ords/casords/oauth/token";
        //private const string TokenURL = "https://molson.cas.gov.bc.ca:7015/ords/casords/oauth/token";
        private const string TokenURL = "https://wsgw.test.jag.gov.bc.ca/victim/ords/cas/oauth/token";
        private const string clientID = "cybkCJ8PobmEvr3rkpnkeA..";
        private const string secret = "f0M4zm2Zi-JHWXuT6swgcg..";

        private CASAPTransactionRegistration()
        {
            casAPTransactionList = new List<CASAPTransaction>();
        }

        public static CASAPTransactionRegistration getInstance()
        {
            if (casregd == null)
            {
                casregd = new CASAPTransactionRegistration();
                return casregd;
            }
            else
            {
                return casregd;
            }
        }

        public void Add(CASAPTransaction casapTransaction)
        {
            casAPTransactionList.Add(casapTransaction);
        }

        public List<CASAPTransaction> getAllCASAPTransaction()
        {
            return casAPTransactionList;
        }

        public List<CASAPTransaction> getUpdateCASAPTransaction()
        {
            return casAPTransactionList;
        }

        public async void sendTransactionsToCAS(CASAPTransaction casapTransaction)
        {
            //HttpClient client = new HttpClient();

            try
            {
                Console.WriteLine("Starting sendTransactionsToCAS.");

                //===================================
                //JT - Working version of connectivity to get token and connect, but I think the proper request is not quite correct
                //Console.WriteLine("Start GetToken");
                //var restClient = new RestClient(TokenURL);
                //var request = new RestRequest(Method.POST);
                //request.AddHeader("cache-control", "no-cache");
                ////request.AddHeader("content-type", "application/x-www-form-urlencoded");
                //request.AddHeader("content-type", "application/json");
                ////request.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials&client_id=" + clientID + "&client_secret=" + secret, ParameterType.RequestBody);
                //request.AddParameter("application/json", "grant_type=client_credentials&client_id=" + clientID + "&client_secret=" + secret, ParameterType.RequestBody);
                //IRestResponse response = restClient.Execute(request);
                //Console.WriteLine("Token: " + response.ToString());
                //Console.WriteLine("End GetToken");

                //Console.WriteLine("Start GetResponse");
                //var restResponse = new RestClient(URL);
                //var requestResponse = new RestRequest(Method.POST);
                //request.AddHeader("cache-control", "no-cache");
                //request.AddHeader("content-type", "application/x-www-form-urlencoded");
                //request.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials&token=" + response, ParameterType.RequestBody);
                //IRestResponse responseValue = restClient.Execute(request);
                //Console.WriteLine("Response: " + responseValue.ToString());
                //Console.WriteLine("End GetResponse");
                //===================================


                //===================================
                HttpClientHandler handler = new HttpClientHandler();
                //{
                //    Proxy = new WebProxy(TokenURL),
                //    UseProxy = true,
                //};

                Console.WriteLine("GET: + " + TokenURL);

                HttpClient client = new HttpClient(handler);
                var byteArray = Encoding.ASCII.GetBytes("Y3lia0NKOFBvYm1FdnIzcmtwbmtlQS4uOmYwTTR6bTJaaS1KSFdYdVQ2c3dnY2cuLg==");
                //var byteArray = Encoding.ASCII.GetBytes("cybkCJ8PobmEvr3rkpnkeA..:f0M4zm2Zi-JHWXuT6swgcg.."); // NOT THIS ONE
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToString(byteArray));

                HttpResponseMessage response = await client.GetAsync(TokenURL);
                HttpContent content = response.Content;

                Console.WriteLine("Response StatusCode: " + (int)response.StatusCode);

                // ... Read the string.
                string result = await content.ReadAsStringAsync();

                // ... Display the result.
                if (result != null &&
                result.Length >= 50)
                {
                    Console.WriteLine(result.Substring(0, 50) + "...");
                }
                //===================================



                //===================================
                // MANO test for connectivity
                //Console.WriteLine("Start TEST");
                //HttpWebRequest HttpWReq =
                //(HttpWebRequest)WebRequest.Create(TokenURL);

                //HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
                //// Insert code that uses the response object.
                //Console.WriteLine(HttpWResp.StatusCode.ToString());
                //Console.WriteLine(HttpWResp.StatusDescription.ToString());
                //HttpWResp.Close();
                //Console.WriteLine("End TEST");
                //===================================



                ////============================
                ////https://seesharpdotnet.wordpress.com/2017/07/30/making-a-post-request-to-an-oauth2-secured-api-using-restsharp/
                ////var url = "https://my.api.endpoint/GetToken";
                //var apiKey = "api_key";
                //var apiPassword = "api_password";

                ////create RestSharp client and POST request object
                //var client = new RestClient(TokenURL);
                //var request = new RestRequest(Method.POST);

                ////add GetToken() API method parameters
                //request.Parameters.Clear();
                //request.AddParameter("grant_type", "password");
                //request.AddParameter("username", clientID);// apiKey);
                //request.AddParameter("password", secret);// apiPassword);

                ////make the API request and get the response
                //IRestResponse response = client.Execute<AccessToken>(request);

                //if (response.ContentLength == -1)
                //{
                //    // No Token, so fail
                //    //Console.WriteLine("Unable to collect token, check username: " + apiKey + " and password: " + apiPassword);
                //    Console.WriteLine("Unable to collect token, check username: " + clientID + " and password: " + secret);
                //}
                //else
                //{ 
                //    //return an AccessToken
                //    var access_token = JsonConvert.DeserializeObject<AccessToken>(response.Content);
                //    //=================================
                //    //var url = "https://my.api.endpoint/DoStuff";

                //    //create RestSharp client and POST request object
                //    client = new RestClient(URL);
                //    request = new RestRequest(Method.POST);

                //    //request headers
                //    request.RequestFormat = DataFormat.Json;
                //    request.AddHeader("Content-Type", "application/json");

                //    //object containing input parameter data for DoStuff() API method
                //    var apiInput = casapTransaction;// new { name = "Matt", age = 34 };

                //    //add parameters and token to request
                //    request.Parameters.Clear();
                //    request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput), ParameterType.RequestBody);
                //    request.AddParameter("Authorization", "Bearer " + access_token, ParameterType.HttpHeader);

                //    //make the API request and get a response
                //    //IRestResponse subResponse = client.Execute<ApiResponse>(request);
                //    IRestResponse subResponse = client.Execute<RestResponse>(request);

                //    long gt = 0;
                //    gt = gt + 1;

                //    //ApiResponse is a class to model the data we want from the API response
                //    //ApiResponse apiResponse = new ApiResponse(JsonConvert.DeserializeObject<ApiResponse>(subResponse.Content));
                //    //RestResponse apiResponse = new RestResponse(JsonConvert.DeserializeObject<RestResponse>(subResponse.Content));
                //    //CASAPTransaction apiResponse = new CASAPTransaction(JsonConvert.DeserializeObject<CASAPTransaction>(subResponse.Content));
                //    //=========================================

                //}
                ////=========================================





                //=========================================
                //First try, probably not quite correct
                //// Send current data in memory to CAS
                ////HttpClient client = new HttpClient();
                //client.BaseAddress = new Uri(URL);

                //// Add an Accept header for JSON format.
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenURL);


                //// Send content to CAS
                //var content = new StringContent(casapTransaction.ToString(), Encoding.UTF8, "application/json");
                //HttpResponseMessage responseX = await client.PostAsync(client.BaseAddress.ToString(), content);
                //=========================================



            }
            catch (Exception e)
            {
                var errorContent = new StringContent(casapTransaction.ToString(), Encoding.UTF8, "application/json");
                Console.WriteLine("Error in sendTransactionsToCAS. ");// + client.BaseAddress.ToString() + errorContent + client + e.ToString());
                throw e;
            }
        }
        public async void getTransactionsFromCAS()//CASAPTransaction casapTransaction)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();

                Console.WriteLine("GET: + " + TokenURL);

                HttpClient client = new HttpClient(handler);

                var byteArray = Encoding.ASCII.GetBytes("Y3lia0NKOFBvYm1FdnIzcmtwbmtlQS4uOmYwTTR6bTJaaS1KSFdYdVQ2c3dnY2cuLg==");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                HttpResponseMessage response = await client.GetAsync(TokenURL);
                HttpContent content = response.Content;

                Console.WriteLine("Response StatusCode: " + (int)response.StatusCode);

                // ... Read the string.
                string result = await content.ReadAsStringAsync();

                // ... Display the result.
                if (result != null && result.Length >= 50)
                {
                    Console.WriteLine(result.Substring(0, 50) + "...");
                }
            }
            catch (Exception e)
            {
                var errorContent = new StringContent("Didn't work", Encoding.UTF8, "application/json");
                Console.WriteLine("Error in getTransactionsFromCAS. ");// + client.BaseAddress.ToString() + errorContent + client + e.ToString());
                throw e;
            }
        }
    }
}
