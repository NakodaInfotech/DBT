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
    public class DescriptionController : ApiController
    {
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage FetchDescriptionList([FromBody]LoginModel UserData)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
            DataSet ds = new DataSet();
            ds = objDL.Description(UserData.YearID, UserData.ItemID, UserData.PartyID);
            var DescriptionList = (from i in ds.Tables[0].AsEnumerable()
                             select new DropdownList
                             {
                                 Text = i["Description_Name"].ToString(),
                                 Value = i["Description_ID"].ToString()
                             }).ToList<DropdownList>();
            response = Request.CreateResponse(HttpStatusCode.OK, new { Description = DescriptionList });
            return response;
        }

    }
}
