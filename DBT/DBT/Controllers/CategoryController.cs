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
    public class CategoryController : ApiController
    {
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage FetchCategoryList([FromBody] LoginModel UserData)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
            DataSet ds = new DataSet();
            ds = objDL.Category(UserData.YearID);
            var CategoryList = (from i in ds.Tables[0].AsEnumerable()
                             select new DropdownList
                             {
                                 Text = i["category_name"].ToString(),
                                 Value = i["category_id"].ToString()
                             }).ToList<DropdownList>();
            response = Request.CreateResponse(HttpStatusCode.OK, new { Category = CategoryList });
            return response;
        }
    }
}
