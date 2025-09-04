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
    public class SaleOrderController : ApiController
    {
        DataSet ds;
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage SaleOrder([FromBody]LoginModel UserData)
        {
            try
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, "ERROR");
                UserData.SO_Status = "ERROR";
                ds = objDL.SO_Save(UserData);
                if ((ds != null) && (ds.Tables.Count > 0))
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            UserData.SO_Status = ds.Tables[0].Rows[i]["SO_STATUS"].ToString();
                            UserData.SO_NO = ds.Tables[0].Rows[i]["SO_NO"].ToString();
                        }
                        
                    }
                }
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
