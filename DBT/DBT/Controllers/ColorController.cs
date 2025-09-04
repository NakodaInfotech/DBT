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
    public class ColorController : ApiController
    {
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage FetchColorList([FromBody]LoginModel UserData)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
            DataSet ds = new DataSet();
            ds = objDL.Color(UserData.YearID, UserData.DesignID);
            var ColorList = (from i in ds.Tables[0].AsEnumerable()
                              select new DropdownList
                              {
                                  Text = i["Color_Name"].ToString(),
                                  Value = i["Color_ID"].ToString()
                              }).ToList<DropdownList>();
            response = Request.CreateResponse(HttpStatusCode.OK, new { Color = ColorList });
            return response;
        }

    }
}
