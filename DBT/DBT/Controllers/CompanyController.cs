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
    public class CompanyController : ApiController
    {
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage FetchCompanyList([FromBody] LoginModel UserData)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
            DataSet ds = new DataSet();
            ds = objDL.CompanyName(UserData.UserID);
            response = Request.CreateResponse(HttpStatusCode.OK, ds);
            return response;
        }
    }
}
