using DL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace DBT.Controllers
{
    public class DeliveryToController : ApiController
    {
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage FetchDeliveryToList([FromBody]LoginModel UserData)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
            DataSet ds = new DataSet();
            ds = objDL.DeliveryTo(UserData.YearID);
            var DeliveryToList = (from i in ds.Tables[0].AsEnumerable()
                             select new DropdownList
                             {
                                 Text = i["DeliveryToName"].ToString(),
                                 Value = i["DeliveryTo_ID"].ToString()
                             }).ToList<DropdownList>();
            response = Request.CreateResponse(HttpStatusCode.OK, new { DeliveryTo = DeliveryToList });
            return response;
        }
    }
}
