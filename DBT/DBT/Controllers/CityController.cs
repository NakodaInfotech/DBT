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
    public class CityController : ApiController
    {
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage FetchCityList([FromBody]LoginModel UserData)
        {
            //LoginModel objCommonSchema = new LoginModel();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
            DataSet ds = new DataSet();
            ds = objDL.CityMaster(UserData.YearID);
            var CityList = (from i in ds.Tables[0].AsEnumerable()
                            select new DropdownList
                            {
                                Text = i["CITYNAME"].ToString(),
                                Value = i["CITYID"].ToString()
                            }).ToList<DropdownList>();
            response = Request.CreateResponse(HttpStatusCode.OK, new { City = CityList });

            return response;
        }
    }
}
