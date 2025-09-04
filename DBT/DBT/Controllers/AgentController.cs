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
    public class AgentController : ApiController
    {
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage FetchAgentList([FromBody]LoginModel UserData)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
            DataSet ds = new DataSet();
            ds = objDL.AgentName(UserData.YearID);
            var AgentList = (from i in ds.Tables[0].AsEnumerable()
                              select new DropdownList
                              {
                                  Text = i["AGENTNAME"].ToString(),
                                Value = i["AGENTID"].ToString()
                              }).ToList<DropdownList>();
            response = Request.CreateResponse(HttpStatusCode.OK, new { Agent = AgentList });
            return response;
        }
    }
}
