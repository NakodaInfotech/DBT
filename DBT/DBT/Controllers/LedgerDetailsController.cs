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
    public class LedgerDetailsController : ApiController
    {
        DataSet ds;
        LoginDL objDL = new LoginDL();


        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage LedgerDetails([FromBody] LoginModel UserData)
        {
            try
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, "ERROR");
                UserData.SO_Status = "ERROR";
                ds = objDL.LedgerDetails(UserData);

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
