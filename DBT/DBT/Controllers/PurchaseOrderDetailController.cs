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
    public class PurchaseOrderDetailController : ApiController
    {
        DataSet ds;
        LoginDL objDL = new LoginDL();

        [HttpPost]
        [ResponseType(typeof(List<POMODEL>))]
        public HttpResponseMessage PurchaseOrderDetail([FromBody] LoginModel UserData)
        {
            try
            {
                ds = objDL.PurchaseOrderDetail(UserData);
                if (ds != null && ds.Tables.Count > 0)
                {
                    var POList = new List<POMODEL>();

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        int POno = Convert.ToInt32(row["PONO"]);
                        int yearId = Convert.ToInt32(row["YEARID"]);

                        var PO = new POMODEL
                        {
                            PONO = POno,
                            PODATE = Convert.ToDateTime(row["PODATE"]).ToString("yyyy-MM-dd"),
                            DELDATE = Convert.ToDateTime(row["DELDATE"]).ToString("yyyy-MM-dd"),
                            PARTYNAME = row["PARTYNAME"].ToString(),
                            AGENTNAME = row["AGENTNAME"].ToString(),
                            TRANSNAME = row["TRANSNAME"].ToString(),
                            DELPERIOD = row["DELPERIOD"].ToString(),
                            CRDAYS = row["CRDAYS"].ToString(),
                            ADDRESS = row["ADDRESS"].ToString(),
                            GSTIN = row["GSTIN"].ToString(),
                            SPECIALREMARKS = row["SPECIALREMARKS"].ToString(),
                            USERNAME = row["USERNAME"].ToString(),
                            TOTALMTRS = Convert.ToDecimal(row["TOTALMTRS"]),
                            DISC = Convert.ToDecimal(row["DISC"]),
                            YEARID = yearId,
                            PODETAILS = GetGroupedPODetails(POno, yearId)
                        };

                        POList.Add(PO);
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, new { Table = POList });
                }

                return Request.CreateResponse(HttpStatusCode.NotFound, "ERROR");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private List<PODetailGroupedModel> GetGroupedPODetails(int PONO, int YEARID)
        {
            var allDetails = new List<PODetailModelWithItem>();

            string query = @"
               
SELECT        ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, PURCHASEORDER_DESC.PO_MTRS AS MTRS, 
                         PURCHASEORDER_DESC.PO_RATE AS RATE,  ISNULL(PURCHASEORDER_DESC.PO_GRIDREMARKS, '') AS REMARKS, PURCHASEORDER_DESC.PO_AMT AS AMOUNT, 
                         isnull(LEDGERS.Acc_cmpname,'') as DYEING
FROM            PURCHASEORDER_DESC LEFT OUTER JOIN
                         LEDGERS ON PURCHASEORDER_DESC.PO_YEARID = LEDGERS.Acc_yearid AND PURCHASEORDER_DESC.PO_TOLEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN
                         COLORMASTER ON PURCHASEORDER_DESC.PO_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN
                         DESIGNMASTER ON PURCHASEORDER_DESC.PO_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN
                         ITEMMASTER ON PURCHASEORDER_DESC.PO_ITEMID = ITEMMASTER.item_id
WHERE        (PURCHASEORDER_DESC.PO_YEARID = @YEARID) AND (PURCHASEORDER_DESC.PO_NO = @PONO)";

            string connString = ConfigurationManager.AppSettings["ConnectionString"];

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PONO", PONO);
                    cmd.Parameters.AddWithValue("@YEARID", YEARID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allDetails.Add(new PODetailModelWithItem
                            {
                                ITEMNAME = reader["ITEMNAME"].ToString(),
                                DESIGN = reader["DESIGN"].ToString(),
                                COLOR = reader["SHADE"].ToString(),
                                REMARKS = reader["REMARKS"].ToString(),
                                DYEING = reader["DYEING"].ToString(),
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
                .Select(g => new PODetailGroupedModel
                {
                    ITEMNAME = g.Key,
                    ITEMDETAILS = g.Select(x => new PODetailModel
                    {
                        DESIGN = x.DESIGN,
                        COLOR = x.COLOR,
                        REMARKS = x.REMARKS,
                        DYEING = x.DYEING,
                        MTRS = x.MTRS,
                        RATE = x.RATE,
                        AMOUNT = x.AMOUNT
                    }).ToList()
                }).ToList();
        }
    }
}
