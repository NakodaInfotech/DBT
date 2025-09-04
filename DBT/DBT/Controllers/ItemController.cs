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
    public class ItemController : ApiController
    {
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage FetchItemList([FromBody]LoginModel UserData)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
            DataSet ds = new DataSet();
            ds = objDL.Item(UserData.YearID);
            var ItemList = (from i in ds.Tables[0].AsEnumerable()
                                 select new DropdownList
                                 {
                                     Text = i["Item_Name"].ToString(),
                                     Value = i["Item_ID"].ToString()
                                 }).ToList<DropdownList>();
            response = Request.CreateResponse(HttpStatusCode.OK, new { Item = ItemList });
            return response;
        }
    }
}
