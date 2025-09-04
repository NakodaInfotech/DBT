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
    public class RateController : ApiController
    {
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage FetchRateList([FromBody]LoginModel UserData)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
            DataSet ds = new DataSet();
            ds = objDL.Rate(UserData.YearID, UserData.ItemID, UserData.PartyID);
            var RateList = (from i in ds.Tables[0].AsEnumerable()
                                   select new DropdownList
                                   {
                                       Text = i["Rate"].ToString(),
                                       Value = i["ID"].ToString()
                                   }).ToList<DropdownList>();
            response = Request.CreateResponse(HttpStatusCode.OK, new { Rate = RateList });
            return response;
        }
    }
}
