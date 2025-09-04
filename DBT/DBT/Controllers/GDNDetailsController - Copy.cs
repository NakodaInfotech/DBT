//using DL;
//using Model;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Description;

//namespace DBT.Controllers
//{
//    public class GDNDetailsController : ApiController
//    {
//        DataSet ds;
//        LoginDL objDL = new LoginDL();

//        [ResponseType(typeof(List<GDNModel>))]
//        [HttpPost]
//        public HttpResponseMessage GDNDetails([FromBody] GDNModel UserData)
//        {
//            try
//            {
//                if (!ModelState.IsValid)
//                {
//                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
//                }

//                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, "ERROR");

//                // Fetch data using the existing data layer method
//                ds = objDL.GetGDNDetails(UserData);

//                // If data is returned
//                if (ds != null && ds.Tables.Count > 0)
//                {
//                    var gdnList = new List<GDNModel>();

//                    // Iterate through the main table
//                    foreach (DataRow row in ds.Tables[0].Rows)
//                    {
//                        var gdn = new GDNModel
//                        {
//                            GDNNO = Convert.ToInt32(row["GDNNO"]),
//                            //DATE = Convert.ToDateTime(row["DATE"]),
//                            NAME = row["NAME"].ToString(),
//                            AGENT = Convert.ToInt32(row["AGENT"]),
//                            //TOTALPCS = Convert.ToDecimal(row["TOTALPCS"]),
//                            //TOTALMTRS = Convert.ToDecimal(row["TOTALMTRS"]),
//                            //DISPATCHTO = row["DISPATCHTO"].ToString(),
//                            YEARID = Convert.ToInt32(row["YEARID"]),

//                            GDNDETAILS = GetGDNDetails(Convert.ToInt32(row["GDNNO"]), Convert.ToInt32(row["YEARID"])) // Get related details
//                        };

//                        gdnList.Add(gdn);
//                    }

//                    response = Request.CreateResponse(HttpStatusCode.OK, new { Table = gdnList });
//                }

//                return response;
//            }
//            catch (Exception ex)
//            {
//                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Error = ex.Message });
//            }
//        }

//        // Method to fetch details for each GDN item (can be from a different table or the same dataset)
//        private List<GDNDetailModel> GetGDNDetails(int gdnno, int YEARID)
//        {
//            var detailsList = new List<GDNDetailModel>();

//            // Fetching GDN details from the same database or another query
//            string query = "SELECT        ISNULL(ITEMMASTER.item_name, '''') AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '''') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '''') AS SHADE, ISNULL(GDN_DESC.GDN_PCS, 0) AS PCS, ISNULL(GDN_DESC.GDN_MTRS, 0) AS MTRS, ISNULL(GDN_DESC.GDN_RATE, 0) AS RATE, ISNULL(GDN_DESC.GDN_BARCODE, '''') AS BARCODE FROM            GDN_DESC LEFT OUTER JOIN COLORMASTER ON GDN_DESC.GDN_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON GDN_DESC.GDN_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN ITEMMASTER ON GDN_DESC.GDN_ITEMID = ITEMMASTER.item_id  WHERE GDN_desc.GDN_NO = @GDNNO and GDN_DESC.GDN_YEARID = @YEARID";

//            using (SqlConnection conn = new SqlConnection("Data Source=NI-PC;Initial Catalog=TEXTRADE;Persist Security Info=True;User ID=sa;Password=Infosys@123"))
//            {
//                conn.Open();
//                using (SqlCommand cmd = new SqlCommand(query, conn))
//                {
//                    cmd.Parameters.AddWithValue("@GDNNO", gdnno);
//                    cmd.Parameters.AddWithValue("@YEARID", YEARID);

//                    using (SqlDataReader reader = cmd.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            var detail = new GDNDetailModel
//                            {
//                                ITEMNAME = reader["ITEMNAME"].ToString(),
//                                DESIGN = reader["DESIGN"].ToString(),
//                                SHADE = reader["SHADE"].ToString(),
//                                PCS = Convert.ToDecimal(reader["PCS"]),
//                                MTRS = Convert.ToDecimal(reader["MTRS"]),
//                                RATE = Convert.ToDecimal(reader["RATE"]),
//                                BARCODE = reader["BARCODE"].ToString()
//                            };

//                            detailsList.Add(detail);
//                        }
//                    }
//                }
//            }

//            return detailsList;
//        }
//    }
//}
