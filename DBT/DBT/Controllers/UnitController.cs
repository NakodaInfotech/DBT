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
    public class UnitController : ApiController
    {
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage FetchUnitList([FromBody] LoginModel UserData)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
            DataSet ds = new DataSet();
            ds = objDL.Common(UserData.YearID, "SP_API_GETUNIT");
            var UnitList = (from i in ds.Tables[0].AsEnumerable()
                                 select new DropdownList
                                 {
                                     Text = i["UNIT_ABBR"].ToString(),
                                     Value = i["unit_id"].ToString()
                                 }).ToList<DropdownList>();
            response = Request.CreateResponse(HttpStatusCode.OK, new { Unit = UnitList });
            return response;
        }
    }
}
