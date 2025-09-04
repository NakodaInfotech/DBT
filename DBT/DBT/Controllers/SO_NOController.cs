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
    public class SO_NOController : ApiController
    {
        DataSet ds;
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage SO_NO([FromBody]LoginModel UserData)
        {
            try
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, "1");

                ds = objDL.SO_NO(UserData.CmpID, UserData.YearID);
                if ((ds != null) && (ds.Tables.Count > 0))
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            UserData.SO_NO = ds.Tables[0].Rows[i]["SO_NO"].ToString();
                        }
                    }
                }
                if (UserData.SO_NO == "")
                {
                    UserData.SO_NO = "1";
                }

                response = Request.CreateErrorResponse(HttpStatusCode.OK, UserData.SO_NO);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
