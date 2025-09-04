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
    public class QualityController : ApiController
    {
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage FetchQualityList([FromBody] LoginModel UserData)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
            DataSet ds = new DataSet();
            ds = objDL.Quality(UserData.YearID);
            var QualityList = (from i in ds.Tables[0].AsEnumerable()
                             select new DropdownList
                             {
                                 Text = i["QUALITY_NAME"].ToString(),
                                 Value = i["QUALITY_id"].ToString()
                             }).ToList<DropdownList>();
            response = Request.CreateResponse(HttpStatusCode.OK, new { Quality = QualityList });
            return response;
        }

    }
}
