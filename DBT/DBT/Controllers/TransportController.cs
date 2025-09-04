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
    public class TransportController : ApiController
    {
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage FetchTransportList([FromBody]LoginModel UserData)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
            DataSet ds = new DataSet();
            ds = objDL.Transport(UserData.YearID);
            var TransportList = (from i in ds.Tables[0].AsEnumerable()
                                  select new DropdownList
                                  {
                                      Text = i["Transport_Name"].ToString(),
                                      Value = i["Transport_ID"].ToString()
                                  }).ToList<DropdownList>();
            response = Request.CreateResponse(HttpStatusCode.OK, new { Transport = TransportList });
            return response;
        }
    }
}
