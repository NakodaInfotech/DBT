using DL;
using Model;
using Newtonsoft.Json.Linq;
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
    public class YearController : ApiController
    {

        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage FetchYearList([FromBody]LoginModel UserData)
        {
            try
            {
            //LoginModel objCommonSchema = new LoginModel();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
            DataSet ds = new DataSet();
                ds = objDL.YearMaster(UserData.CmpID);
                var YearList = (from i in ds.Tables[0].AsEnumerable()
                                select new YearDropdownlistModel
                                {
                                    Text = i["year_startdate"].ToString(),
                                    Text1 = i["year_enddate"].ToString(),
                                    Value = i["year_id"].ToString()
                                }).ToList<YearDropdownlistModel>();
                response = Request.CreateResponse(HttpStatusCode.OK, new { Year = YearList });               
                return response;
                }
            catch (Exception ex)
            {

                throw ex;
            }
        }        
    }
}
