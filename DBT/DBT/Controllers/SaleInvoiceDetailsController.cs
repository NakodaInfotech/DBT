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
    public class SaleInvoiceDetailsController : ApiController
    {
        DataSet ds;
        LoginDL objDL = new LoginDL();

        [ResponseType(typeof(List<INVModel>))]
        [HttpPost]
        public HttpResponseMessage INVDetails([FromBody] LoginModel UserData)
        {
            try
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, "ERROR");

                // Fetch data using the existing data layer method
                ds = objDL.GetSaleInvoiceDetails(UserData);

                // If data is returned
                if (ds != null && ds.Tables.Count > 0)
                {
                    var INVList = new List<INVModel>();

                    // Iterate through the main table
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var INV = new INVModel
                        {
                            INVNO = Convert.ToInt32(row["INVNO"]),
                            INVDATE = Convert.ToDateTime(row["INVDATE"]).ToString("yyyy-MM-dd"),
                            PRINTINITIALS = row["PRINTINITIALS"].ToString(),
                            NAME = row["NAME"].ToString(),
                            REGNAME = row["REGNAME"].ToString(),
                            AGENTNAME = row["AGENTNAME"].ToString(),
                            TOTALPCS = Convert.ToDecimal(row["TOTALPCS"]),
                            TOTALMTRS = Convert.ToDecimal(row["TOTALMTRS"]),
                            DISPATCHTO = row["DISPATCHTO"].ToString(),  
                            YEARID = Convert.ToInt32(row["YEARID"]),
                            CITYNAME = row["CITYNAME"].ToString(),
                            TRANSNAME = row["TRANSNAME"].ToString(),
                            BALENO = Convert.ToInt32(row["BALENO"]),
                            CHALLANNO = row["CHALLANNO"].ToString(),
                            CHALLANDATE = Convert.ToDateTime(row["CHALLANDATE"]).ToString("yyyy-MM-dd"),
                            CRDAYS = Convert.ToInt32(row["CRDAYS"]),
                            DUEDATE = Convert.ToDateTime(row["DUEDATE"]).ToString("yyyy-MM-dd"),
                            PARTYADD = row["PARTYADD"].ToString(),
                            PARTYGSTIN = row["PARTYGSTIN"].ToString(),
                            PARTYSTATE = row["PARTYSTATE"].ToString(),
                            PARTYSTATEREMARK = row["PARTYSTATEREMARK"].ToString(),
                            DISPATCHADD = row["DISPATCHADD"].ToString(),
                            DISPATCHGSTIN = row["DISPATCHGSTIN"].ToString(),
                            DISPATCHSTATE = row["DISPATCHSTATE"].ToString(),
                            DISPATCHSTATEREMARK = row["DISPATCHSTATEREMARK"].ToString(),
                            ACKNO = row["ACKNO"].ToString(),
                            IRNNO = row["IRNNO"].ToString(),
                            ACKDATE = Convert.ToDateTime(row["ACKDATE"]).ToString("yyyy-MM-dd"),
                            TOTALWITHMATVALUE = Convert.ToDecimal(row["TOTALWITHMATVALUE"]),
                            TOTALCGSTPER = Convert.ToDecimal(row["TOTALCGSTPER"]),
                            TOTALSGSTPER = Convert.ToDecimal(row["TOTALSGSTPER"]),
                            TOTALIGSTPER = Convert.ToDecimal(row["TOTALIGSTPER"]),
                            TOTALCGSTAMT = Convert.ToDecimal(row["TOTALCGSTAMT"]),
                            TOTALSGSTAMT = Convert.ToDecimal(row["TOTALSGSTAMT"]),
                            TOTALIGSTAMT = Convert.ToDecimal(row["TOTALIGSTAMT"]),
                            ROUNDOFF = Convert.ToDecimal(row["ROUNDOFF"]),
                            INWORDS = row["INWORDS"].ToString(),
                            REMARKS = row["REMARKS"].ToString(),
                            USERNAME = row["USERNAME"].ToString(),
                            TERMSANDCONDITIONS = row["TERMSANDCONDITIONS"].ToString(),
                            EWAYBILLNO = row["EWAYBILLNO"].ToString(),
                            LRNO = row["LRNO"].ToString(),
                            LRDATE = Convert.ToDateTime(row["LRDATE"]).ToString("yyyy-MM-dd"),
                            TCSPER = Convert.ToDecimal(row["TCSPER"]),
                            TCSAMT = Convert.ToDecimal(row["TCSAMT"]),
                            TOTALTAXAMT = Convert.ToDecimal(row["TAXAMT"]),
                            GRANDTOTAL = Convert.ToDecimal(row["GRANDTOTAL"]),
                            // Check if QRCODE is DBNull or null before converting to Base64
                            QRCODE = row["QRCODE"] != DBNull.Value && row["QRCODE"] != null
                        ? Convert.ToBase64String((byte[])row["QRCODE"])  // Convert to Base64 if not null
                        : string.Empty,  // Or assign an empty string if QRCODE is null
                            //CHARGES = row["CHARGES"].ToString(),
                            //CHARGESPER = Convert.ToDecimal(row["CHARGESPER"]),
                            //CHARGESAMT = Convert.ToDecimal(row["CHARGESAMT"]),
                            INVDETAILS = GetINVDetails(Convert.ToInt32(row["INVNO"]), Convert.ToInt32(row["YEARID"]), row["REGNAME"].ToString()) ,// Get related details
                            INVCHARGES = GetINVCharges(Convert.ToInt32(row["INVNO"]), Convert.ToInt32(row["YEARID"]), row["REGNAME"].ToString())
                        };

                        INVList.Add(INV);
                    }

                    response = Request.CreateResponse(HttpStatusCode.OK, new { Table = INVList });
                }

                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Error = ex.Message });
            }
        }

        // Method to fetch details for each INV item (can be from a different table or the same dataset)
        private List<FlatINVDetailModel> GetINVDetails(int INVno, int YEARID, string REGNAME)
        {
            var list = new List<FlatINVDetailModel>();

            string query = @"SELECT ISNULL(INVOICEMASTER_DESC.INVOICE_PCS, '') AS PCS, 
                            ITEMMASTER.item_name AS ITEMNAME, 
                            ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, 
                            ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, 
                            ISNULL(HSNMASTER.HSN_CODE, '') AS HSN, 
                            ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, 
                            ISNULL(INVOICEMASTER_DESC.INVOICE_CUT, 0) AS CUTS, 
                            ISNULL(INVOICEMASTER_DESC.INVOICE_MTRS, 0) AS MTRS, 
                            ISNULL(INVOICEMASTER_DESC.INVOICE_RATE, 0) AS RATE, 
                            REGISTERMASTER.register_name AS REGNAME , 
                            ISNULL(INVOICEMASTER_DESC.INVOICE_AMOUNT, '') AS AMOUNT, 
                            ISNULL(INVOICEMASTER_DESC.INVOICE_PER, '') AS UOM,ISNULL(INVOICEMASTER_DESC.INVOICE_PRINTDESC, '') AS PRINTDESC,  VERSION.VERSION_CLIENTNAME as CLIENTNAME
                     FROM INVOICEMASTER_DESC 
                     INNER JOIN REGISTERMASTER ON INVOICEMASTER_DESC.INVOICE_YEARID = REGISTERMASTER.register_yearid AND INVOICEMASTER_DESC.INVOICE_REGISTERID = REGISTERMASTER.register_id 
                     LEFT OUTER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID 
                     LEFT OUTER JOIN DESIGNMASTER ON INVOICEMASTER_DESC.INVOICE_DESIGNID = DESIGNMASTER.DESIGN_id AND INVOICEMASTER_DESC.INVOICE_YEARID = DESIGNMASTER.DESIGN_yearid 
                     LEFT OUTER JOIN COLORMASTER ON INVOICEMASTER_DESC.INVOICE_YEARID = COLORMASTER.COLOR_yearid AND INVOICEMASTER_DESC.INVOICE_COLORID = COLORMASTER.COLOR_id 
                     LEFT OUTER JOIN ITEMMASTER ON INVOICEMASTER_DESC.INVOICE_YEARID = ITEMMASTER.item_yearid AND INVOICEMASTER_DESC.INVOICE_ITEMID = ITEMMASTER.item_id CROSS JOIN
                         VERSION
                     WHERE INVOICEMASTER_DESC.INVOICE_NO = @INVNO AND INVOICEMASTER_DESC.INVOICE_YEARID = @YEARID AND REGISTERMASTER.register_name = @REGNAME";

            string connString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@INVNO", INVno);
                    cmd.Parameters.AddWithValue("@YEARID", YEARID);
                    cmd.Parameters.AddWithValue("@REGNAME", REGNAME);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemName = reader["ITEMNAME"].ToString();
                            string printdesc = reader["PRINTDESC"].ToString();
                            string clientName = reader["CLIENTNAME"].ToString();

                            string finalItemName = itemName;

                            if (clientName?.ToUpper() == "MASHOK" && !string.IsNullOrWhiteSpace(printdesc))
                            {
                                finalItemName = $"{itemName}\n{printdesc}";
                            }

                            list.Add(new FlatINVDetailModel
                            {
                                ITEMNAME = finalItemName,
                                HSN = reader["HSN"].ToString(),
                                WIDTH = reader["WIDTH"].ToString(),
                                DESIGN = reader["DESIGN"].ToString(),
                                SHADE = reader["SHADE"].ToString(),
                                PCS = Convert.ToDecimal(reader["PCS"]),
                                MTRS = Convert.ToDecimal(reader["MTRS"]),
                                RATE = Convert.ToDecimal(reader["RATE"]),
                                AMOUNT = Convert.ToDecimal(reader["AMOUNT"]),
                                UOM = reader["UOM"].ToString()
                            });
                        }
                    }
                }
            }

            return list;
        }


        private List<INVChargesModel> GetINVCharges(int INVno, int YEARID, string REGNAME)
        {
            var list = new List<INVChargesModel>();

            string query = @"SELECT        isnull(INVOICEMASTER_CHGS.INVOICE_PER,0) as CHARGESPER, ISNULL(INVOICEMASTER_CHGS.INVOICE_AMT,0) AS CHARGESAMT, ISNULL(LEDGERS.Acc_cmpname,'') AS CHARGES
                             FROM            INVOICEMASTER_CHGS INNER JOIN
                                REGISTERMASTER ON INVOICEMASTER_CHGS.INVOICE_yearid = REGISTERMASTER.register_yearid AND INVOICEMASTER_CHGS.INVOICE_REGISTERID = REGISTERMASTER.register_id INNER JOIN
                                LEDGERS ON INVOICEMASTER_CHGS.INVOICE_CHARGESID = LEDGERS.Acc_id AND INVOICEMASTER_CHGS.INVOICE_yearid = LEDGERS.Acc_yearid 
                              WHERE INVOICEMASTER_CHGS.INVOICE_NO = @INVNO 
                                AND INVOICEMASTER_CHGS.INVOICE_YEARID = @YEARID 
                                AND REGISTERMASTER.register_name = @REGNAME";

            string connString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@INVNO", INVno);
                    cmd.Parameters.AddWithValue("@YEARID", YEARID);
                    cmd.Parameters.AddWithValue("@REGNAME", REGNAME);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new INVChargesModel
                            {
                                CHARGES = reader["CHARGES"].ToString(),
                                CHARGESPER = Convert.ToDecimal(reader["CHARGESPER"]),
                                CHARGESAMT = Convert.ToDecimal(reader["CHARGESAMT"])
                            });
                        }
                    }
                }
            }

            return list;
        }



    }
}
