using System.Net;
using System.Net.Http;
using System.Web.Http;
using model_binder.Models;
using System.Collections.Generic;

namespace model_binder.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage VerifyEmail(TestData data)
        {
            string a = "";
            foreach (var val in data.Message)
            {
                a = a + "---" + val;
            }

            return Request.CreateResponse(HttpStatusCode.Accepted, a);
        }
    }
}