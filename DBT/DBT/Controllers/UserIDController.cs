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
    public class UserIDController : ApiController
    {
        DataSet ds;
        LoginDL objDL = new LoginDL();


        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage UserID([FromBody]LoginModel UserData)
        {
            try
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, "INVALID_USER");
                UserData.LoginStatus = "INVALID_USER";
                ds = objDL.LoginUserID(UserData);
                if ((ds != null) && (ds.Tables.Count > 0))
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            UserData.LoginStatus = ds.Tables[0].Rows[i]["LOGIN_STATUS"].ToString();
                            UserData.UserID = Convert.ToInt32(ds.Tables[0].Rows[i]["USERID"]);
                        }
                    }
                }
                if (UserData.LoginStatus == "IN_VALID")
                {
                    response = Request.CreateErrorResponse(HttpStatusCode.OK, "No Data Found");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, UserData);
                }
                
                
                
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
