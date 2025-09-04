using DL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DBT.Controllers
{
    public class DropDownListController : ApiController
    {
        LoginDL objDL = new LoginDL();
        [HttpPost]
        public HttpResponseMessage FetchCompanyList()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);                        
            DataSet ds = new DataSet();
            ds = objDL.CompanyMaster();
            var CompanyList = (from i in ds.Tables[0].AsEnumerable()
                                select new DropdownList
                                {
                                    Text = i["cmp_name"].ToString(),
                                    Value = i["CMP_ID"].ToString()
                                }).ToList<DropdownList>();
            response = Request.CreateResponse(HttpStatusCode.OK, new { Company = CompanyList });

            return response;
        }
    }
}
