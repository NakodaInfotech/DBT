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
using System.Configuration;
using System.Web.Http.Description;

namespace DBT.Controllers
{
    public class PurchaseInvoiceDetailsController : ApiController
    {
        DataSet ds;
        LoginDL objDL = new LoginDL();

        [HttpPost]
        [ResponseType(typeof(List<PIMODEL>))]
        public HttpResponseMessage PurchaseInvoiceDetail([FromBody] LoginModel UserData)
        {
            try
            {
                ds = objDL.GetPurchaseInvoiceDetail(UserData);
                if (ds != null && ds.Tables.Count > 0)
                {
                    var PIList = new List<PIMODEL>();

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        int PIno = Convert.ToInt32(row["PINO"]);
                        int yearId = Convert.ToInt32(row["YEARID"]);
                        string regname = row["REGNAME"].ToString();

                        var PI = new PIMODEL
                        {
                            PINO = PIno,
                            PIDATE = Convert.ToDateTime(row["PIDATE"]).ToString("yyyy-MM-dd"),
                            PARTYNAME = row["PARTYNAME"].ToString(),
                            AGENTNAME = row["AGENTNAME"].ToString(),
                            TRANSNAME = row["TRANSNAME"].ToString(),
                            REMARKS = row["REMARKS"].ToString(),
                            TOTALPCS = Convert.ToDecimal(row["TOTALPCS"]),
                            TOTALMTRS = Convert.ToDecimal(row["TOTALMTRS"]),
                            GRANDTOTAL = Convert.ToDecimal(row["GRANDTOTAL"]),
                            YEARID = yearId,
                            PIDETAILS = GetGroupedPIDetails(PIno, yearId , regname)
                        };

                        PIList.Add(PI);
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, new { Table = PIList });
                }

                return Request.CreateResponse(HttpStatusCode.NotFound, "ERROR");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private List<PIDetailGroupedModel> GetGroupedPIDetails(int PINO, int YEARID, string regname)
        {
            var allDetails = new List<PIDetailModelWithItem>();

            string query = @"
                SELECT 
                    ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME,
                    ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN,
                    ISNULL(COLORMASTER.COLOR_name, '') AS SHADE,
                    PURCHASEMASTER_DESC.BILL_QTY AS PCS,
                    PURCHASEMASTER_DESC.BILL_MTRS AS MTRS,
                    PURCHASEMASTER_DESC.BILL_RATE AS RATE,
                    PURCHASEMASTER_DESC.BILL_AMT AS AMOUNT
               FROM            PURCHASEMASTER_DESC LEFT OUTER JOIN
                         REGISTERMASTER ON PURCHASEMASTER_DESC.BILL_REGISTERID = REGISTERMASTER.register_id LEFT OUTER JOIN
                         COLORMASTER ON PURCHASEMASTER_DESC.BILL_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN
                         DESIGNMASTER ON PURCHASEMASTER_DESC.BILL_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN
                         ITEMMASTER ON PURCHASEMASTER_DESC.BILL_ITEMID = ITEMMASTER.item_id
                WHERE PURCHASEMASTER_DESC.BILL_YEARID = @YEARID AND PURCHASEMASTER_DESC.BILL_NO = @PINO AND (REGISTERMASTER.register_name= @REGNAME)";

            string connString = ConfigurationManager.AppSettings["ConnectionString"];

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PINO", PINO);
                    cmd.Parameters.AddWithValue("@YEARID", YEARID);
                    cmd.Parameters.AddWithValue("@REGNAME", regname);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allDetails.Add(new PIDetailModelWithItem
                            {
                                ITEMNAME = reader["ITEMNAME"].ToString(),
                                DESIGN = reader["DESIGN"].ToString(),
                                COLOR = reader["SHADE"].ToString(),
                                PCS = Convert.ToDecimal(reader["PCS"]),
                                MTRS = Convert.ToDecimal(reader["MTRS"]),
                                RATE = Convert.ToDecimal(reader["RATE"]),
                                AMOUNT = Convert.ToDecimal(reader["AMOUNT"])
                            });
                        }
                    }
                }
            }

            return allDetails
                .GroupBy(d => d.ITEMNAME)
                .Select(g => new PIDetailGroupedModel
                {
                    ITEMNAME = g.Key,
                    ITEMDETAILS = g.Select(x => new PIDetailModel
                    {
                        DESIGN = x.DESIGN,
                        COLOR = x.COLOR,
                        PCS = x.PCS,
                        MTRS = x.MTRS,
                        RATE = x.RATE,
                        AMOUNT = x.AMOUNT
                    }).ToList()
                }).ToList();
        }
    }
}
