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
    public class GodownController : ApiController
    {
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage FetchGodownList([FromBody] LoginModel UserData)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
            DataSet ds = new DataSet();
            ds = objDL.Common(UserData.YearID, "SP_API_GETGODOWN");
            var GodownList = (from i in ds.Tables[0].AsEnumerable()
                                select new DropdownList
                                {
                                    Text = i["GODOWN_name"].ToString(),
                                    Value = i["GODOWN_id"].ToString()
                                }).ToList<DropdownList>();
            response = Request.CreateResponse(HttpStatusCode.OK, new { Godown = GodownList });
            return response;
        }
    }
}
