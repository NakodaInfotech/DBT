using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DL;

namespace DBT.Controllers
{
    public class LoginController : ApiController
    {
        DataSet ds;
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]        
        public HttpResponseMessage Login([FromBody]LoginModel UserData)
        {
            try
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, "INVALID_USER");
                
                ds = objDL.LoginConnection(UserData);                
                response = Request.CreateResponse(HttpStatusCode.OK, ds);
                return response;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}
