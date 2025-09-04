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
    public class BuyersController : ApiController
    {
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage FetchBuyersList([FromBody]LoginModel UserData)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
            DataSet ds = new DataSet();
            ds = objDL.BuyersName(UserData.YearID);
            var BuyersList = (from i in ds.Tables[0].AsEnumerable()
                            select new DropdownList
                            {
                                Text = i["BuyersName"].ToString(),
                                Value = i["Buyers_ID"].ToString()
                            }).ToList<DropdownList>();
            response = Request.CreateResponse(HttpStatusCode.OK, new { Buyer = BuyersList });

            return response;
        }
    }
}
