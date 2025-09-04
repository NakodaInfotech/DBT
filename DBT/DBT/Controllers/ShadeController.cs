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
    public class ShadeController : ApiController
    {
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage FetchShadeList([FromBody] LoginModel UserData)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
            DataSet ds = new DataSet();
            ds = objDL.Shade(UserData.YearID);
            var ShadeList = (from i in ds.Tables[0].AsEnumerable()
                             select new DropdownList
                             {
                                 Text = i["COLOR_NAME"].ToString(),
                                 Value = i["COLOR_id"].ToString()
                             }).ToList<DropdownList>();
            response = Request.CreateResponse(HttpStatusCode.OK, new { Shade = ShadeList });
            return response;
        }

    }
}
