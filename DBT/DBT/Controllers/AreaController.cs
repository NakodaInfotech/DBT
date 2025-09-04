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
    public class AreaController : ApiController
    {
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage FetchAreaList([FromBody] LoginModel UserData)
        {
            //LoginModel objCommonSchema = new LoginModel();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
            DataSet ds = new DataSet();
            ds = objDL.Area(UserData.YearID);
            var AreaList = (from i in ds.Tables[0].AsEnumerable()
                            select new DropdownList
                            {
                                Text = i["AREANAME"].ToString(),
                                Value = i["AREAID"].ToString()
                            }).ToList<DropdownList>();
            response = Request.CreateResponse(HttpStatusCode.OK, new { AREA = AreaList });

            return response;
        }
    }
}
