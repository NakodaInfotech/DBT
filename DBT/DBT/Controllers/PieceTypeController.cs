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
    public class PieceTypeController : ApiController
    {
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(LoginModel))]
        [HttpPost]
        public HttpResponseMessage FetchPieceTypeList([FromBody] LoginModel UserData)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
            DataSet ds = new DataSet();
            ds = objDL.Common(UserData.YearID, "SP_API_GETPIECETYPE");
            var PieceTypeList = (from i in ds.Tables[0].AsEnumerable()
                              select new DropdownList
                              {
                                  Text = i["PIECETYPE_name"].ToString(),
                                  Value = i["PIECETYPE_id"].ToString()
                              }).ToList<DropdownList>();
            response = Request.CreateResponse(HttpStatusCode.OK, new { PieceType = PieceTypeList });
            return response;
        }
    }
}
