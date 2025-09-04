using DL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Configuration;

namespace DBT.Controllers
{
    public class GDNDetailsController : ApiController
    {
        DataSet ds;
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(List<GDNModel>))]
        [HttpPost]
        public HttpResponseMessage GDNDetails([FromBody] LoginModel UserData)
        {
            try
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, "ERROR");

                // Fetch data using the existing data layer method
                ds = objDL.GetGDNDetails(UserData);

                // If data is returned
                if (ds != null && ds.Tables.Count > 0)
                {
                    var gdnList = new List<GDNModel>();

                    // Iterate through the main table
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var gdn = new GDNModel
                        {
                            GDNNO = Convert.ToInt32(row["GDNNO"]),
                            DATE = Convert.ToDateTime(row["DATE"]).ToString("yyyy-MM-dd"),
                            NAME = row["NAME"].ToString(),
                            AGENT = row["AGENT"].ToString(),
                            TOTALPCS = Convert.ToDecimal(row["TOTALPCS"]),
                            TOTALMTRS = Convert.ToDecimal(row["TOTALMTRS"]),
                            DISPATCHTO = row["DISPATCHTO"].ToString(),
                            YEARID = Convert.ToInt32(row["YEARID"]),
                            CITYNAME = row["CITYNAME"].ToString(),
                            TRANSNAME = row["TRANSNAME"].ToString(),
                            BALENO = Convert.ToInt32(row["BALENO"]),
                            PARTYADD = row["PARTYADD"].ToString(),
                            PARTYGSTIN = row["PARTYGSTIN"].ToString(),
                            PARTYSTATE = row["PARTYSTATE"].ToString(),
                            PARTYSTATEREMARK = row["PARTYSTATEREMARK"].ToString(),
                            DISPATCHADD = row["DISPATCHADD"].ToString(),
                            DISPATCHGSTIN = row["DISPATCHGSTIN"].ToString(),
                            DISPATCHSTATE = row["DISPATCHSTATE"].ToString(),
                            DISPATCHSTATEREMARK = row["DISPATCHSTATEREMARK"].ToString(),
                            USERNAME = row["USERNAME"].ToString(),
                            TERMSANDCONDITIONS = row["TERMSANDCONDITIONS"].ToString(),

                            GDNDETAILS = GetGDNDetails(Convert.ToInt32(row["GDNNO"]), Convert.ToInt32(row["YEARID"])) // Get related details
                        };

                        gdnList.Add(gdn);
                    }

                    response = Request.CreateResponse(HttpStatusCode.OK, new { Table = gdnList });
                }

                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Error = ex.Message });
            }
        }

        // Method to fetch details for each GDN item (can be from a different table or the same dataset)
       private List<GDNGroupedDetailModel> GetGDNDetails(int gdnno, int YEARID)
{
    var rawList = new List<dynamic>();

    string query = @"SELECT        ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(GDN_DESC.GDN_PCS, 0) AS PCS, 
                         ISNULL(GDN_DESC.GDN_MTRS, 0) AS MTRS, ISNULL(GDN_DESC.GDN_RATE, 0) AS RATE, ISNULL(GDN_DESC.GDN_BARCODE, '') AS BARCODE, HSNMASTER.HSN_CODE as HSN, ISNULL(ITEMMASTER.ITEM_WIDTH,'') AS WIDTH, ISNULL(GDN_DESC.GDN_CUT, 0) AS CUTS
FROM            HSNMASTER RIGHT OUTER JOIN
                         ITEMMASTER ON HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid AND HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID RIGHT OUTER JOIN
                         GDN_DESC LEFT OUTER JOIN
                         COLORMASTER ON GDN_DESC.GDN_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN
                         DESIGNMASTER ON GDN_DESC.GDN_DESIGNID = DESIGNMASTER.DESIGN_id ON ITEMMASTER.item_id = GDN_DESC.GDN_ITEMID
                    WHERE GDN_DESC.GDN_NO = @GDNNO AND GDN_DESC.GDN_YEARID = @YEARID";

            string connString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection conn = new SqlConnection(connString))
            { 
                conn.Open();
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@GDNNO", gdnno);
            cmd.Parameters.AddWithValue("@YEARID", YEARID);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    rawList.Add(new
                    {
                        ITEMNAME = reader["ITEMNAME"].ToString(),
                        HSN = reader["HSN"].ToString(),
                        WIDTH = reader["WIDTH"].ToString(),
                        DESIGN = reader["DESIGN"].ToString(),
                        SHADE = reader["SHADE"].ToString(),
                        PCS = Convert.ToDecimal(reader["PCS"]),
                        CUTS = Convert.ToDecimal(reader["CUTS"]),
                        MTRS = Convert.ToDecimal(reader["MTRS"]),
                        RATE = Convert.ToDecimal(reader["RATE"]),
                        BARCODE = reader["BARCODE"].ToString()
                    });
                }
            }
        }
    }

    // Group by ITEMNAME + HSN + WIDTH
    var groupedList = new List<GDNGroupedDetailModel>();

    foreach (var group in rawList.GroupBy(x => new { x.ITEMNAME, x.HSN, x.WIDTH }))
    {
        var groupItem = new GDNGroupedDetailModel
        {
            ITEMNAME = group.Key.ITEMNAME,
            HSN = group.Key.HSN,
            WIDTH = group.Key.WIDTH,
            ITEMDETAILS = new List<GDNDetailModel>()
        };

        foreach (var item in group)
        {
            groupItem.ITEMDETAILS.Add(new GDNDetailModel
            {
                DESIGN = item.DESIGN,
                SHADE = item.SHADE,
                PCS = item.PCS,
                CUTS = item.CUTS,
                MTRS = item.MTRS,
                RATE = item.RATE,
                BARCODE = item.BARCODE
            });
        }

        groupedList.Add(groupItem);
    }

    return groupedList;
}

    }
}
