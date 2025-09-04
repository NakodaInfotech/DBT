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
    public class DesignController : ApiController
    {
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage FetchDesignList([FromBody]LoginModel UserData)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
            DataSet ds = new DataSet();
            ds = objDL.Design(UserData.YearID);
            var DesignList = (from i in ds.Tables[0].AsEnumerable()
                            select new DropdownList
                            {
                                Text = i["DESIGN_NO"].ToString(),
                                Value = i["DESIGN_id"].ToString()
                            }).ToList<DropdownList>();
            response = Request.CreateResponse(HttpStatusCode.OK, new { Design = DesignList });
            return response;
        }
    }
}
