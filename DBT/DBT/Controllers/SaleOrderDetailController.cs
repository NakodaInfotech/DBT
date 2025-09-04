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
    public class SaleOrderDetailController : ApiController
    {
        DataSet ds;
        LoginDL objDL = new LoginDL();

        [HttpPost]
        [ResponseType(typeof(List<SOMODEL>))]
        public HttpResponseMessage SaleOrderDetail([FromBody] LoginModel UserData)
        {
            try
            {
                ds = objDL.SaleOrderDetail(UserData);
                if (ds != null && ds.Tables.Count > 0)
                {
                    var SOList = new List<SOMODEL>();

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        int sono = Convert.ToInt32(row["SONO"]);
                        int yearId = Convert.ToInt32(row["YEARID"]);

                        var SO = new SOMODEL
                        {
                            SONO = sono,
                            SODATE = Convert.ToDateTime(row["SODATE"]).ToString("yyyy-MM-dd"),
                            DELDATE = Convert.ToDateTime(row["DELDATE"]).ToString("yyyy-MM-dd"),
                            PARTYNAME = row["PARTYNAME"].ToString(),
                            AGENTNAME = row["AGENTNAME"].ToString(),
                            TRANSNAME = row["TRANSNAME"].ToString(),
                            CITY = row["CITY"].ToString(),
                            PARTYPONO = row["PARTYPONO"].ToString(),
                            CRDAYS = row["CRDAYS"].ToString(),
                            ADDRESS = row["ADDRESS"].ToString(),
                            GSTIN = row["GSTIN"].ToString(),
                            SPECIALREMARKS = row["SPECIALREMARKS"].ToString(),
                            USERNAME = row["USERNAME"].ToString(),
                            SHIPTO = row["SHIPTO"].ToString(),
                            TOTALQTY = Convert.ToDecimal(row["TOTALQTY"]),
                            TOTALMTRS = Convert.ToDecimal(row["TOTALMTRS"]),
                            YEARID = yearId,
                            SODETAILS = GetGroupedSODetails(sono, yearId)
                        };

                        SOList.Add(SO);
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, new { Table = SOList });
                }

                return Request.CreateResponse(HttpStatusCode.NotFound, "ERROR");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private List<SODetailGroupedModel> GetGroupedSODetails(int SONO, int YEARID)
        {
            var allDetails = new List<SODetailModelWithItem>();

            string query = @"
                SELECT 
                    ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME,
                    ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN,
                    ISNULL(COLORMASTER.COLOR_name, '') AS SHADE,
                    SALEORDER_DESC.SO_QTY AS QTY,
                    SALEORDER_DESC.SO_MTRS AS MTRS,
                    SALEORDER_DESC.SO_RATE AS RATE,
					ISNULL(UNITMASTER.UNIT_ABBR,'') AS UNIT,
					ISNULL( SALEORDER_DESC.SO_CUT,0) AS CUT,
					ISNULL(SALEORDER_DESC.SO_GRIDREMARKS,'') AS REMARKS
                FROM SALEORDER_DESC
                LEFT JOIN COLORMASTER ON SALEORDER_DESC.SO_COLORID = COLORMASTER.COLOR_id
                LEFT JOIN DESIGNMASTER ON SALEORDER_DESC.SO_DESIGNID = DESIGNMASTER.DESIGN_id
                LEFT JOIN ITEMMASTER ON SALEORDER_DESC.SO_ITEMID = ITEMMASTER.item_id
				LEFT JOIN UNITMASTER ON SALEORDER_DESC.SO_UNITID = UNITMASTER.unit_id
                WHERE SALEORDER_DESC.SO_YEARID = @YEARID AND SALEORDER_DESC.SO_NO = @SONO";

            string connString = ConfigurationManager.AppSettings["ConnectionString"];

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SONO", SONO);
                    cmd.Parameters.AddWithValue("@YEARID", YEARID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allDetails.Add(new SODetailModelWithItem
                            {
                                ITEMNAME = reader["ITEMNAME"].ToString(),
                                DESIGN = reader["DESIGN"].ToString(),
                                COLOR = reader["SHADE"].ToString(),
                                UNIT = reader["UNIT"].ToString(),
                                REMARKS = reader["REMARKS"].ToString(),
                                QTY = Convert.ToDecimal(reader["QTY"]),
                                MTRS = Convert.ToDecimal(reader["MTRS"]),
                                RATE = Convert.ToDecimal(reader["RATE"]),
                                CUT = Convert.ToDecimal(reader["CUT"])
                            });
                        }
                    }
                }
            }

            return allDetails
                .GroupBy(d => d.ITEMNAME)
                .Select(g => new SODetailGroupedModel
                {
                    ITEMNAME = g.Key,
                    ITEMDETAILS = g.Select(x => new SODetailModel
                    {
                        DESIGN = x.DESIGN,
                        COLOR = x.COLOR,
                        UNIT = x.UNIT,
                        REMARKS = x.REMARKS,
                        QTY = x.QTY,
                        MTRS = x.MTRS,
                        RATE = x.RATE,
                        CUT = x.CUT
                    }).ToList()
                }).ToList();
        }
    }
}
