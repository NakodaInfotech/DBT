using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Globalization;

namespace DL
{
    public class LoginDL
    {

        public DataSet LoginConnection(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {

                        string spname = "";
                        spname = "SP_API_GETUSERID";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@UserName",objCommonSchema.UserName ==null?(object)DBNull.Value :(objCommonSchema.UserName )),
                                new SqlParameter("@PassWord",objCommonSchema.PassWord ==null?(object)DBNull.Value :(objCommonSchema.PassWord )),
                                new SqlParameter("@DEVICEID",objCommonSchema.DeviceID ==null?(object)DBNull.Value :(objCommonSchema.DeviceID )),
                            };
                        objTran.Commit();
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);

                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet SO_NO(int CmpID, int YearID)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "USP_GET_SO_NO";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@CmpID",CmpID ==0?(object)DBNull.Value :(CmpID)),
                                new SqlParameter("@YearID",YearID ==0?(object)DBNull.Value :(YearID)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet SO_Save(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "USP_API_TRANS_SALE_SALEORDER_SAVE";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@SONO",objCommonSchema.SO_NO ==null?(object)DBNull.Value :(objCommonSchema.SO_NO)),
                                new SqlParameter("@sodate", objCommonSchema.SO_Date == null ? (object)DBNull.Value : DateTime.ParseExact(objCommonSchema.SO_Date.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture)),
                                new SqlParameter("@NAME",objCommonSchema.BuyersName ==null?(object)DBNull.Value :(objCommonSchema.BuyersName)),

                                new SqlParameter("@AGENT",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@poNO",objCommonSchema.PartyPO_NO ==null?(object)DBNull.Value :(objCommonSchema.PartyPO_NO)),


                                new SqlParameter("@TRANS1",objCommonSchema.TransportName ==null?(object)DBNull.Value :(objCommonSchema.TransportName)),

                                new SqlParameter("@CITY",objCommonSchema.ToCity ==null?(object)DBNull.Value :(objCommonSchema.ToCity)),
                                new SqlParameter("@REFNO",null),

                                new SqlParameter("@PACKING",objCommonSchema.DeliveryTo ==null?(object)DBNull.Value :(objCommonSchema.DeliveryTo)),

                                new SqlParameter("@totalqty",objCommonSchema.totalqty ==0?(object)DBNull.Value :(objCommonSchema.totalqty)),
                                new SqlParameter("@totalMTRS",objCommonSchema.totalMTRS ==0?(object)DBNull.Value :(objCommonSchema.totalMTRS)),



                                new SqlParameter("@Remarks",objCommonSchema.Remarks ==null?(object)DBNull.Value :(objCommonSchema.Remarks)),

                                new SqlParameter("@SALESMAN",null),

                                new SqlParameter("@CmpID",objCommonSchema.CmpID ==0?(object)DBNull.Value :(objCommonSchema.CmpID )),
                                new SqlParameter("@YearID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@UserID",objCommonSchema.UserID ==0?(object)DBNull.Value :(objCommonSchema.UserID)),                                
                                //GRID DETAILS
                                new SqlParameter("@gridsrno",objCommonSchema.GridSrNO ==null?(object)DBNull.Value :(objCommonSchema.GridSrNO)),
                                new SqlParameter("@MERCHANT",objCommonSchema.ItemName ==null?(object)DBNull.Value :(objCommonSchema.ItemName)),
                                new SqlParameter("@DESIGN",objCommonSchema.DesignName ==null?(object)DBNull.Value :(objCommonSchema.DesignName)),
                                new SqlParameter("@GRIDREMARKS",objCommonSchema.Description ==null?(object)DBNull.Value :(objCommonSchema.Description)),
                                new SqlParameter("@COLOR",objCommonSchema.Shade ==null?(object)DBNull.Value :(objCommonSchema.Shade)),
                                new SqlParameter("@qty",objCommonSchema.Qty ==null?(object)DBNull.Value :(objCommonSchema.Qty)),
                                new SqlParameter("@QTYUNIT",null),
                                new SqlParameter("@cut",objCommonSchema.Cut ==null?(object)DBNull.Value :(objCommonSchema.Cut)),
                                new SqlParameter("@MTRS",objCommonSchema.Meters ==null?(object)DBNull.Value :(objCommonSchema.Meters)),
                                new SqlParameter("@rate",objCommonSchema.Rate ==null?(object)DBNull.Value :(objCommonSchema.Rate)),
                                new SqlParameter("@TEMPSONO",objCommonSchema.TEMPSONO ==0?(object)DBNull.Value :(objCommonSchema.TEMPSONO)),
                                new SqlParameter("@MODE",objCommonSchema.MODE ==null?(object)DBNull.Value :(objCommonSchema.MODE)),





                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet AgentAndTransport(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "USP_GET_AgentAndTransport";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@BuyerID",objCommonSchema.BuyersName ==null?(object)DBNull.Value :(objCommonSchema.BuyersName)),
                                new SqlParameter("@CmpID",objCommonSchema.CmpID ==0?(object)DBNull.Value :(objCommonSchema.CmpID )),
                                new SqlParameter("@YearID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),

                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }


        public DataSet SO_Edit(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_SELECTSO_FOR_EDIT";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@SONO",objCommonSchema.SO_NO ==null?(object)DBNull.Value :(objCommonSchema.SO_NO)),
                                new SqlParameter("@Cmpid",objCommonSchema.CmpID==0?(object)DBNull.Value :(objCommonSchema.CmpID)),
                                new SqlParameter("@LocationID",objCommonSchema.locationid ==0?(object)DBNull.Value :(objCommonSchema.locationid)),
                                new SqlParameter("@YearID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),

                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet LoginUserID(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "USP_GET_USERID";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@UserName",objCommonSchema.UserName ==null?(object)DBNull.Value :(objCommonSchema.UserName )),
                                new SqlParameter("@CmpID",objCommonSchema.CmpID ==0? (object)DBNull.Value :(objCommonSchema.CmpID )),
                                new SqlParameter("@YearID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID )),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet CompanyMaster()
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "USP_GET_CMPDETAILS";
                        var param = new SqlParameter[]
                            {

                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet YearMaster(int CmpId)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETACCYEAR";
                        var param = new SqlParameter[]
                            {
                                  new SqlParameter("@CMPID",CmpId),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet CityMaster(int YearID)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETCITY";
                        var param = new SqlParameter[]
                            {
                                  new SqlParameter("@YearID",YearID),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet Ledger(int YearID)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETLEDGERS";
                        var param = new SqlParameter[]
                            {
                                  new SqlParameter("@YearID",YearID),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet BuyersName(int YearID)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "USP_GET_BuyersName";
                        var param = new SqlParameter[]
                            {
                                  new SqlParameter("@YearID",YearID),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet AgentName(int YearID)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETAGENTS";
                        var param = new SqlParameter[]
                            {
                                  new SqlParameter("@YearID",YearID),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet CompanyName(int UserID)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETCOMPANY";
                        var param = new SqlParameter[]
                            {
                                  new SqlParameter("@USERID",UserID),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet DeliveryTo(int YearID)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "USP_GET_DeliveryTo";
                        var param = new SqlParameter[]
                            {
                                  new SqlParameter("@YearID",YearID),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet Transport(int YearID)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "USP_GET_Transport";
                        var param = new SqlParameter[]
                            {
                                  new SqlParameter("@YearID",YearID),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }
                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet Item(int YearID)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETITEMNAME";
                        var param = new SqlParameter[]
                            {
                                  new SqlParameter("@YEARID",YearID),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }
                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet Design(int YearID)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETDESIGNNO";
                        var param = new SqlParameter[]
                            {
                                  new SqlParameter("@YEARID",YearID),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }
                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet Area(int YearID)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETAREA";
                        var param = new SqlParameter[]
                            {
                                  new SqlParameter("@YEARID",YearID),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }
                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet Group(int YearID)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETGROUP";
                        var param = new SqlParameter[]
                            {
                                  new SqlParameter("@YEARID",YearID),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }
                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet Color(int YearID, int DesignID)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "USP_GET_Color";
                        var param = new SqlParameter[]
                            {
                                  new SqlParameter("@YearID",YearID),
                                  new SqlParameter("@DesignID",DesignID),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }
                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet Shade(int YearID)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETSHADE";
                        var param = new SqlParameter[]
                            {
                                  new SqlParameter("@YearID",YearID),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }
                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet Category(int YearID)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETCATEGORY";
                        var param = new SqlParameter[]
                            {
                                  new SqlParameter("@YearID",YearID),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }
                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet Common(int YearID, string SpName)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = SpName;
                        var param = new SqlParameter[]
                            {
                                  new SqlParameter("@YearID",YearID),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }
                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet Description(int YearID, int ItemID, int PartyID)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "USP_GET_Description";
                        var param = new SqlParameter[]
                            {
                                  new SqlParameter("@YearID",YearID),
                                  new SqlParameter("@ItemID",ItemID),
                                  new SqlParameter("@PartyID",PartyID),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }
                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet Rate(int YearID, int ItemID, int PartyID)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "USP_GET_Rate";
                        var param = new SqlParameter[]
                            {
                                  new SqlParameter("@YearID",YearID),
                                  new SqlParameter("@ItemID",ItemID),
                                  new SqlParameter("@PartyID",PartyID),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }
                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet Dashboard(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETDASHBOARD";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet Stock(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETSTOCK";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@ITEMNAME",objCommonSchema.ItemName ==null?(object)DBNull.Value :(objCommonSchema.ItemName)),
                                new SqlParameter("@DESIGNNO",objCommonSchema.DesignName ==null?(object)DBNull.Value :(objCommonSchema.DesignName)),
                                new SqlParameter("@COLOR",objCommonSchema.Color ==null?(object)DBNull.Value :(objCommonSchema.Color)),
                                new SqlParameter("@CATEGORY",objCommonSchema.Category ==null?(object)DBNull.Value :(objCommonSchema.Category)),
                                new SqlParameter("@GODOWN",objCommonSchema.Godown ==null?(object)DBNull.Value :(objCommonSchema.Godown)),
                                new SqlParameter("@QUALITY",objCommonSchema.Quality ==null?(object)DBNull.Value :(objCommonSchema.Quality)),
                                new SqlParameter("@PIECETYPE",objCommonSchema.PieceType ==null?(object)DBNull.Value :(objCommonSchema.PieceType)),
                                new SqlParameter("@UNIT",objCommonSchema.Unit ==null?(object)DBNull.Value :(objCommonSchema.Unit)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet ItemTransaction(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETTRANSDETAILS";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                                new SqlParameter("@TYPE",objCommonSchema.Type ==null?(object)DBNull.Value :(objCommonSchema.Type)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet ItemDetails(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETITEMDETAILS";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@ItemID",objCommonSchema.ItemID ==0?(object)DBNull.Value :(objCommonSchema.ItemID)),
                                new SqlParameter("@DesignID",objCommonSchema.DesignID ==0?(object)DBNull.Value :(objCommonSchema.DesignID)),
                                new SqlParameter("@ColorID",objCommonSchema.ColorID ==0?(object)DBNull.Value :(objCommonSchema.ColorID)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet Quality(int YearID)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETQUALITY";
                        var param = new SqlParameter[]
                            {
                                  new SqlParameter("@YEARID",YearID),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }
                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet LedgerBalance(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETLEDGERBALANCE";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@CITY",objCommonSchema.City ==null?(object)DBNull.Value :(objCommonSchema.City)),
                                new SqlParameter("@AREA",objCommonSchema.Area ==null?(object)DBNull.Value :(objCommonSchema.Area)),
                                new SqlParameter("@GROUP",objCommonSchema.Group ==null?(object)DBNull.Value :(objCommonSchema.Group)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet LedgerDetails(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETLEDGERDETAILS";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet RecBalance(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETRECBALANCE";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@CITY",objCommonSchema.City ==null?(object)DBNull.Value :(objCommonSchema.City)),
                                new SqlParameter("@AREA",objCommonSchema.Area ==null?(object)DBNull.Value :(objCommonSchema.Area)),
                                new SqlParameter("@GROUP",objCommonSchema.Group ==null?(object)DBNull.Value :(objCommonSchema.Group)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet PayBalance(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETPAYBALANCE";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@CITY",objCommonSchema.City ==null?(object)DBNull.Value :(objCommonSchema.City)),
                                new SqlParameter("@AREA",objCommonSchema.Area ==null?(object)DBNull.Value :(objCommonSchema.Area)),
                                new SqlParameter("@GROUP",objCommonSchema.Group ==null?(object)DBNull.Value :(objCommonSchema.Group)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetTopSale(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETTOPSALESREPORT";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@CITY",objCommonSchema.City ==null?(object)DBNull.Value :(objCommonSchema.City)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetTopAgentSale(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETTOPAGENTSALESREPORT";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@CITY",objCommonSchema.City ==null?(object)DBNull.Value :(objCommonSchema.City)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetTopPurchase(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETTOPPURCHASEREPORT";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@CITY",objCommonSchema.City ==null?(object)DBNull.Value :(objCommonSchema.City)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetTopAgentPurchase(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETTOPAGENTPURCHASEREPORT";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@CITY",objCommonSchema.City ==null?(object)DBNull.Value :(objCommonSchema.City)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetTopItemSale(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETTOPITEMSALESREPORT";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@CITY",objCommonSchema.City ==null?(object)DBNull.Value :(objCommonSchema.City)),
                                new SqlParameter("@ITEMNAME",objCommonSchema.City ==null?(object)DBNull.Value :(objCommonSchema.ItemName)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetTopItemPurchase(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETTOPITEMPURCHASEREPORT";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@CITY",objCommonSchema.City ==null?(object)DBNull.Value :(objCommonSchema.City)),
                                new SqlParameter("@ITEMNAME",objCommonSchema.City ==null?(object)DBNull.Value :(objCommonSchema.ItemName)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetDayBook(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETDAYBOOK";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetRecOutstanding(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETRECOUTSTANDING";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetPayOutstanding(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETPAYOUTSTANDING";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }
        
        public DataSet GetSOReport(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETSALEORDERDETAILS";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@ITEMNAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.ItemName)),
                                new SqlParameter("@DESIGN",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.DesignName)),
                                new SqlParameter("@COLOR",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Color)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                                new SqlParameter("@TYPE",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Type)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetPOReport(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETPURCHASEORDERDETAILS";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@ITEMNAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.ItemName)),
                                new SqlParameter("@DESIGN",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.DesignName)),
                                new SqlParameter("@COLOR",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Color)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                                new SqlParameter("@TYPE",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Type)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetMonthlySales(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETMONTHLYSALES";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetMonthlyPurchase(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETMONTHLYPURCHASE";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetAllSaleBills(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETALLSALEBILLS";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetAllPurchaseBills(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETALLPURCHASEBILLS";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetAgentSales(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETAGENTSALES";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetAgentPurchase(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETAGENTPURCHASE";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetSOSummary(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETSALEORDERSUMMARY";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@ITEMNAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.ItemName)),
                                new SqlParameter("@DESIGN",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.DesignName)),
                                new SqlParameter("@COLOR",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Color)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                                new SqlParameter("@TYPE",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Type)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetPOSummary(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETPURCHASEORDERSUMMARY";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@ITEMNAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.ItemName)),
                                new SqlParameter("@DESIGN",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.DesignName)),
                                new SqlParameter("@COLOR",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Color)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                                new SqlParameter("@TYPE",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Type)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetAgentPayBal(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETAGENTPAYBALANCE";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetAgentRecBal(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETAGENTRECBALANCE";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetAgentRecOut(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETAGENTRECOUTSTANDING";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetAgentPayOut(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETAGENTPAYOUTSTANDING";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetRack(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETRACK";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet RackUpdate(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETRACKUPDATESAVE";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@RACKID",objCommonSchema.RACKID ==null?(object)DBNull.Value :(objCommonSchema.RACKID)),
                                new SqlParameter("@BARCODE",objCommonSchema.BARCODE ==null?(object)DBNull.Value :(objCommonSchema.BARCODE )),
                                new SqlParameter("@CMPID",objCommonSchema.CmpID ==0?(object)DBNull.Value :(objCommonSchema.CmpID)),
                                new SqlParameter("@USERID",objCommonSchema.UserID ==0?(object)DBNull.Value :(objCommonSchema.UserID)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet StockTaking(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_STOCKTAKINGSAVE";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@RACKID",objCommonSchema.RACKID ==null?(object)DBNull.Value :(objCommonSchema.RACKID)),
                                new SqlParameter("@BARCODE",objCommonSchema.BARCODE ==null?(object)DBNull.Value :(objCommonSchema.BARCODE )),
                                new SqlParameter("@CMPID",objCommonSchema.CmpID ==0?(object)DBNull.Value :(objCommonSchema.CmpID)),
                                new SqlParameter("@USERID",objCommonSchema.UserID ==0?(object)DBNull.Value :(objCommonSchema.UserID)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@REMARKS",objCommonSchema.remarks ==null?(object)DBNull.Value :(objCommonSchema.remarks )),

                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetBarcodeDetails(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETBARCODEDETAILS";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@BARCODE",objCommonSchema.BARCODE ==null?(object)DBNull.Value :(objCommonSchema.BARCODE )),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet SaleOrderSave(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_SALEORDERSAVE";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@DATE",objCommonSchema.Date ==null?(object)DBNull.Value :(objCommonSchema.Date)),
                                new SqlParameter("@NAMEID",objCommonSchema.NameID ==0?(object)DBNull.Value :(objCommonSchema.NameID)),
                                new SqlParameter("@SHIPTOID",objCommonSchema.ShipToID ==0?(object)DBNull.Value :(objCommonSchema.ShipToID)),
                                new SqlParameter("@TRANSID",objCommonSchema.TransID ==0?(object)DBNull.Value :(objCommonSchema.TransID)),
                                new SqlParameter("@AGENTID",objCommonSchema.AgentID ==0?(object)DBNull.Value :(objCommonSchema.AgentID)),
                                new SqlParameter("@CITYID",objCommonSchema.CityID ==0?(object)DBNull.Value :(objCommonSchema.CityID)),
                                new SqlParameter("@CMPID",objCommonSchema.CmpID ==0?(object)DBNull.Value :(objCommonSchema.CmpID)),
                                new SqlParameter("@USERID",objCommonSchema.UserID ==0?(object)DBNull.Value :(objCommonSchema.UserID)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@ITEMNAME",objCommonSchema.ItemName ==null?(object)DBNull.Value :(objCommonSchema.ItemName)),
                                new SqlParameter("@DESIGN",objCommonSchema.DesignName ==null?(object)DBNull.Value :(objCommonSchema.DesignName)),
                                new SqlParameter("@COLOR",objCommonSchema.Color ==null?(object)DBNull.Value :(objCommonSchema.Color)),
                                new SqlParameter("@GRIDREMARKS",objCommonSchema.GridRemarks ==null?(object)DBNull.Value :(objCommonSchema.GridRemarks)),
                                new SqlParameter("@QTY",objCommonSchema.Qty ==null?(object)DBNull.Value :(objCommonSchema.Qty)),
                                new SqlParameter("@MTRS",objCommonSchema.Mtrs ==null?(object)DBNull.Value :(objCommonSchema.Mtrs)),
                                new SqlParameter("@RATE",objCommonSchema.Rate ==null?(object)DBNull.Value :(objCommonSchema.Rate)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }


        public DataSet GetTransDetails(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETTRANSPORTNAME";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet ShiptoDetail(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETSHIPTODETAILS";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@SHIPTOID",objCommonSchema.ShipToID ==0?(object)DBNull.Value :(objCommonSchema.ShipToID)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }


        public DataSet PartyDetail(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETPARTYDETAILS";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAMEID",objCommonSchema.NameID ==0?(object)DBNull.Value :(objCommonSchema.NameID)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet SaleOrderDetail(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_SALEORDERDETAILS";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@SONO",objCommonSchema.SoNo ==0?(object)DBNull.Value :(objCommonSchema.SoNo)),
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENTNAME",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@CMPID",objCommonSchema.CmpID ==0?(object)DBNull.Value :(objCommonSchema.CmpID)),
                                new SqlParameter("@USERID",objCommonSchema.UserID ==0?(object)DBNull.Value :(objCommonSchema.UserID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                                new SqlParameter("@FROM",objCommonSchema.FROM ==0?(object)DBNull.Value :(objCommonSchema.FROM)),
                                new SqlParameter("@TO",objCommonSchema.TO ==0?(object)DBNull.Value :(objCommonSchema.TO)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet PurchaseOrderDetail(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_PURCHASEORDERDETAILS";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@PONO",objCommonSchema.PoNo ==0?(object)DBNull.Value :(objCommonSchema.PoNo)),
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENTNAME",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@CMPID",objCommonSchema.CmpID ==0?(object)DBNull.Value :(objCommonSchema.CmpID)),
                                new SqlParameter("@USERID",objCommonSchema.UserID ==0?(object)DBNull.Value :(objCommonSchema.UserID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                                new SqlParameter("@FROM",objCommonSchema.FROM ==0?(object)DBNull.Value :(objCommonSchema.FROM)),
                                new SqlParameter("@TO",objCommonSchema.TO ==0?(object)DBNull.Value :(objCommonSchema.TO)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GatePassDetail(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GATEPASSDETAILS";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@GPNO",objCommonSchema.GPNO ==0?(object)DBNull.Value :(objCommonSchema.GPNO)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }


        public DataSet GetTopSales(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETTOPSALESREPORTS";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@TYPE",objCommonSchema.Type ==null?(object)DBNull.Value :(objCommonSchema.Type)),
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@CITY",objCommonSchema.City ==null?(object)DBNull.Value :(objCommonSchema.City)),
                                new SqlParameter("@ITEMNAME",objCommonSchema.ItemName ==null?(object)DBNull.Value :(objCommonSchema.ItemName)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetTopPurchases(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETTOPPURCHASEREPORTS";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@TYPE",objCommonSchema.Type ==null?(object)DBNull.Value :(objCommonSchema.Type)),
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@CITY",objCommonSchema.City ==null?(object)DBNull.Value :(objCommonSchema.City)),
                                new SqlParameter("@ITEMNAME",objCommonSchema.City ==null?(object)DBNull.Value :(objCommonSchema.ItemName)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetChallan(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETCHALLAN";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAMEID",objCommonSchema.NameID ==0?(object)DBNull.Value :(objCommonSchema.NameID)),
                                new SqlParameter("@AGENTID",objCommonSchema.AgentID ==0?(object)DBNull.Value :(objCommonSchema.AgentID)),
                                new SqlParameter("@TRANSID",objCommonSchema.TransID ==0?(object)DBNull.Value :(objCommonSchema.TransID)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                                new SqlParameter("@GPNO",objCommonSchema.GPNO ==0?(object)DBNull.Value :(objCommonSchema.GPNO)),

                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetChallanBarcode(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETCHALLANDETAILS";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@CHALLANNO",objCommonSchema.ChallanNo ==null?(object)DBNull.Value :(objCommonSchema.ChallanNo)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@ISEDIT",objCommonSchema.ISEDIT ==0?(object)DBNull.Value :(objCommonSchema.ISEDIT)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetSaleGatePassSave(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_SALESGATEPASS_SAVE";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@DATE",objCommonSchema.Date ==null?(object)DBNull.Value :(objCommonSchema.Date)),
                                new SqlParameter("@TRANSID",objCommonSchema.TransID ==0?(object)DBNull.Value :(objCommonSchema.TransID)),
                                new SqlParameter("@REMARKS",objCommonSchema.remarks ==null?(object)DBNull.Value :(objCommonSchema.remarks)),
                                new SqlParameter("@VEHICLENO",objCommonSchema.VehicleNo ==null?(object)DBNull.Value :(objCommonSchema.VehicleNo)),
                                new SqlParameter("@IMAGE",objCommonSchema.Image ==null?(object)DBNull.Value :(objCommonSchema.Image)),
                                new SqlParameter("@CMPID",objCommonSchema.CmpID ==0?(object)DBNull.Value :(objCommonSchema.CmpID)),
                                new SqlParameter("@USERID",objCommonSchema.UserID ==0?(object)DBNull.Value :(objCommonSchema.UserID)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@GdnNo",objCommonSchema.GdnNo ==null?(object)DBNull.Value :(objCommonSchema.GdnNo)),
                                new SqlParameter("@GDNTYPE",objCommonSchema.GDNTYPE ==null?(object)DBNull.Value :(objCommonSchema.GDNTYPE)),
                                new SqlParameter("@BARCODE",objCommonSchema.BARCODE ==null?(object)DBNull.Value :(objCommonSchema.BARCODE)),
                                };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;

                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetSaleGatePassUpdate(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_SALESGATEPASS_UPDATE";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@DATE",objCommonSchema.Date ==null?(object)DBNull.Value :(objCommonSchema.Date)),
                                new SqlParameter("@TRANSID",objCommonSchema.TransID ==0?(object)DBNull.Value :(objCommonSchema.TransID)),
                                new SqlParameter("@REMARKS",objCommonSchema.remarks ==null?(object)DBNull.Value :(objCommonSchema.remarks)),
                                new SqlParameter("@VEHICLENO",objCommonSchema.VehicleNo ==null?(object)DBNull.Value :(objCommonSchema.VehicleNo)),
                                new SqlParameter("@IMAGE",objCommonSchema.Image ==null?(object)DBNull.Value :(objCommonSchema.Image)),
                                new SqlParameter("@CMPID",objCommonSchema.CmpID ==0?(object)DBNull.Value :(objCommonSchema.CmpID)),
                                new SqlParameter("@USERID",objCommonSchema.UserID ==0?(object)DBNull.Value :(objCommonSchema.UserID)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@GdnNo",objCommonSchema.GdnNo ==null?(object)DBNull.Value :(objCommonSchema.GdnNo)),
                                new SqlParameter("@GDNTYPE",objCommonSchema.GDNTYPE ==null?(object)DBNull.Value :(objCommonSchema.GDNTYPE)),
                                new SqlParameter("@BARCODE",objCommonSchema.BARCODE ==null?(object)DBNull.Value :(objCommonSchema.BARCODE)),
                                new SqlParameter("@TEMPENTRYNO",objCommonSchema.TEMPENTRYNO ==0?(object)DBNull.Value :(objCommonSchema.TEMPENTRYNO)),

                                };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;

                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }



        public DataSet GetSaleInvoiceDetails(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_SALEINVOICEDETAILS";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENTNAME",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@INVNO",objCommonSchema.INVNO ==0?(object)DBNull.Value :(objCommonSchema.INVNO)),
                                new SqlParameter("@REGNAME",objCommonSchema.REGNAME ==null?(object)DBNull.Value :(objCommonSchema.REGNAME)),
                                new SqlParameter("@CMPID",objCommonSchema.CmpID ==0?(object)DBNull.Value :(objCommonSchema.CmpID)),
                                new SqlParameter("@USERID",objCommonSchema.UserID ==0?(object)DBNull.Value :(objCommonSchema.UserID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROM",objCommonSchema.FROM ==0?(object)DBNull.Value :(objCommonSchema.FROM)),
                                new SqlParameter("@TO",objCommonSchema.TO ==0?(object)DBNull.Value :(objCommonSchema.TO)),
                                };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;

                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

        public DataSet GetPurchaseInvoiceDetail(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_PURCHASEINVOICEDETAILS";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENTNAME",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@INVNO",objCommonSchema.INVNO ==0?(object)DBNull.Value :(objCommonSchema.INVNO)),
                                new SqlParameter("@REGNAME",objCommonSchema.REGNAME ==null?(object)DBNull.Value :(objCommonSchema.REGNAME)),
                                new SqlParameter("@CMPID",objCommonSchema.CmpID ==0?(object)DBNull.Value :(objCommonSchema.CmpID)),
                                new SqlParameter("@USERID",objCommonSchema.UserID ==0?(object)DBNull.Value :(objCommonSchema.UserID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROM",objCommonSchema.FROM ==0?(object)DBNull.Value :(objCommonSchema.FROM)),
                                new SqlParameter("@TO",objCommonSchema.TO ==0?(object)DBNull.Value :(objCommonSchema.TO)),
                                };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;

                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }



        public DataSet GetGDNDetails(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GDNDETAILS";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENTNAME",objCommonSchema.AgentName ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@GDNNO",objCommonSchema.GdnNo ==null?(object)DBNull.Value :(objCommonSchema.GdnNo)),
                                new SqlParameter("@CMPID",objCommonSchema.CmpID ==0?(object)DBNull.Value :(objCommonSchema.CmpID)),
                                new SqlParameter("@USERID",objCommonSchema.UserID ==0?(object)DBNull.Value :(objCommonSchema.UserID)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@FROM",objCommonSchema.FROM ==0?(object)DBNull.Value :(objCommonSchema.FROM)),
                                new SqlParameter("@TO",objCommonSchema.TO ==0?(object)DBNull.Value :(objCommonSchema.TO)),

                                };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;

                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }


        public DataSet GetRegister(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETREGISTER";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        objTran.Commit();
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }
        public DataSet Catalogue(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETCATALOGUE";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@ITEMNAME",objCommonSchema.ItemName ==null?(object)DBNull.Value :(objCommonSchema.ItemName)),
                                new SqlParameter("@DESIGNNO",objCommonSchema.DesignName ==null?(object)DBNull.Value :(objCommonSchema.DesignName)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                                new SqlParameter("@INCLUDESTOCK", objCommonSchema.INCLUDESTOCK ? (object)true : (object)DBNull.Value)

                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }


        public DataSet OrderVerification(LoginModel objCommonSchema)
        {
            using (SqlConnection con = SQLHelper.OpenConnection())
            {
                using (SqlTransaction objTran = con.BeginTransaction())
                {
                    try
                    {
                        string spname = "";
                        spname = "SP_API_GETORDERVERIFICATION";
                        var param = new SqlParameter[]
                            {
                                new SqlParameter("@NAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Name)),
                                new SqlParameter("@AGENT",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.AgentName)),
                                new SqlParameter("@ITEMNAME",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.ItemName)),
                                new SqlParameter("@DESIGN",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.DesignName)),
                                new SqlParameter("@COLOR",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Color)),
                                new SqlParameter("@FROMDATE",objCommonSchema.From_Date ==null?(object)DBNull.Value :(objCommonSchema.From_Date)),
                                new SqlParameter("@TODATE",objCommonSchema.To_Date ==null?(object)DBNull.Value :(objCommonSchema.To_Date)),
                                new SqlParameter("@TYPE",objCommonSchema.Name ==null?(object)DBNull.Value :(objCommonSchema.Type)),
                                new SqlParameter("@YEARID",objCommonSchema.YearID ==0?(object)DBNull.Value :(objCommonSchema.YearID)),
                            };
                        DataSet record = SQLHelper.ExecuteDataset(con, objTran, CommandType.StoredProcedure, spname, param);
                        return record;
                    }

                    catch (Exception ex)
                    {
                        objTran.Rollback();
                        return null;
                    }
                }
            }
        }

    }
}
