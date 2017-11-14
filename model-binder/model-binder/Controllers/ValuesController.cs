using System.Net;
using System.Net.Http;
using System.Web.Http;
using model_binder.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.ModelBinding;

namespace model_binder.Controllers
{
    public class ValuesController : ApiController
    {
        // Using TypeConvertor 

        private string[] ExpectedServices = new string[] {"Marketing", "Rewards"};

        [HttpGet]
        public HttpResponseMessage VerifyEmail(TestData data)
        {
            //SystemServicesValidator.ValidateRequest(data);

            string a = "";
            foreach (var val in data.Message)
            {
                ExpectedServices.Contains(val);
                a = a + "---" + val;
            }

            return Request.CreateResponse(HttpStatusCode.Accepted, a);
        }

        //http://localhost:11293/api/values/VerifyEmail?data=mard,sdf,sdf,sdf,s,df,sdfs,s


        // Using Model Binding
        //[HttpGet]
        //public HttpResponseMessage VerifyEmail([ModelBinder(typeof(CustomModelBinder))] TestData data)
        //{
        //    string a = "";
        //    foreach (var val in data.Message)
        //    {
        //        a = a + "---" + val;
        //    }

        //    return Request.CreateResponse(HttpStatusCode.Accepted, a);
        //}
    }
}