using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{





    public class LoginModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string DeviceID { get; set; }
        public string ClientName { get; set; }

        public string LoginStatus { get; set; }

        public int isSuccess { get; set; }
        public string responseMsg { get; set; }

        public string From_Date { get; set; }
        public string To_Date { get; set; }
        public string WHERECLAUSE { get; set; }
        

        public string SO_Status { get; set; }

        public int CmpID { get; set; }
        public int YearID { get; set; }
        public int locationid { get; set; }
        public int userid { get; set; }
        public bool transfer { get; set; }
        public bool INCLUDESTOCK { get; set; }
        public int DesignID { get; set; }

        public int ColorID { get; set; }
        public int ItemID { get; set; }
        public int PartyID { get; set; }

        public string SO_NO { get; set; }

        public double totalqty { get; set; }
        public double totalMTRS { get; set; }
        public double totalBALES { get; set; }
        public double totalAMT { get; set; }

        public double DISPER { get; set; }
         
        public double DISAMT { get; set; }
        public double PFPER { get; set; }
        public double PFAMT { get; set; }
        public double TESTCHGS { get; set; }
        public double NETT { get; set; }
        public int EXCISEID { get; set; }
        public string EXCISENAME { get; set; }
        public double EXCISEAMT { get; set; }
        public string EDUCESSNAME { get; set; }
        public double EDUCESSAMT { get; set; }
        public string HSECESSNAME { get; set; }
        public double HSECESSAMT { get; set; }
        public double SUBTOTAL { get; set; }
        public string TAXNAME { get; set; }
        public double TAXAMT { get; set; }
        public string ADDTAXNAME { get; set; }
        public double ADDTAXAMT { get; set; }
        public double FRPER { get; set; }
        public double FREIGHT { get; set; }
        public string OCTROINAME { get; set; }
        public double OCTROIAMT { get; set; }
        public double INSCHGS { get; set; }
        public double ROUNDOFF { get; set; }
        public double GRANDTOTAL { get; set; }

        public string inwords { get; set; }
        public string remarks { get; set; }

        public string NOTE { get; set; }
        public string TNC { get; set; }

        public string MISC { get; set; }
        public double DISCRATE { get; set; }
        public double DISCLOT { get; set; }
        public double DD { get; set; }
        public double KATAI { get; set; }
        public double CD { get; set; }
        public double adat { get; set; }
        public int DAYS { get; set; }
        public double INTS { get; set; }
        public double ADVANCE { get; set; }
        public double BALANCE { get; set; }
        public string SALESMAN { get; set; }
        public string PACKINGTYPE { get; set; }
        public string Type { get; set; }


        public string Name { get; set; }

        public string BuyersName { get; set; }
        public string AgentName { get; set; }
        public string PartyPO_NO { get; set; }
        public string TransportName { get; set; }
        public string ToCity { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Group { get; set; }
        public string DeliveryTo { get; set; }

        public string SO_Date { get; set; }

        public string Remarks { get; set; }

        //GridDetails
        public string GridSrNO { get; set; }
        public string ItemName { get; set; }
        public string DesignName { get; set; }
        public string Color { get; set; }
        public string Category { get; set; }
        public string Godown { get; set; }
        public string Quality { get; set; }
        public string PieceType { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        public string Shade { get; set; }
        public string Qty { get; set; }
        public string Cut { get; set; }
        public string Meters { get; set; }
        public string Rate { get; set; }
        public string Amount { get; set; }

        public int TEMPSONO { get; set; }
        public string MODE { get; set; }
        public string RACKID { get; set; }
        public string BARCODE { get; set; }

        public string GridRemarks { get; set; }
        public int TransID { get; set; }
        public int NameID { get; set; }
        public int CityID { get; set; }
        public int ShipToID { get; set; }
        public int AgentID { get; set; }
        public string Date { get; set; }
        public string Mtrs { get; set; }
        public int SoNo { get; set; }
        public int PoNo { get; set; }
        public String ChallanNo { get; set; }
        public string VehicleNo { get; set; }
        public string TransName { get; set; }
        public string BaleNo { get; set; }
        public string NoOfBales { get; set; }
        public string GdnNo { get; set; }
        public string PartyPoNo { get; set; }
        public string Design { get; set; }
        public string Image { get; set; }
        public string GDNTYPE { get; set; }
        public int GPNO { get; set; }
        public int TEMPENTRYNO { get; set; }
        public int CHK { get; set; }
        public int ISEDIT { get; set; }
        public String ALLSCANNED { get; set; }
        public string REGISTERNAME { get; set; }
        public int INVNO { get; set; }
        public int FROM { get; set; }
        public int TO { get; set; }
        public int GDNNO1 { get; set; }
        public string REGNAME { get; set; }


    }
    public class GDNModel
    {
        public int GDNNO { get; set; }
        public String DATE { get; set; }
        public string NAME { get; set; }
        public string AGENT { get; set; }
        public decimal TOTALPCS { get; set; }
        public decimal TOTALMTRS { get; set; }
        public string DISPATCHTO { get; set; }
        public int YEARID { get; set; }
        public string CITYNAME { get; set; }
        public string TRANSNAME { get; set; }
        public int BALENO { get; set; }
        public string PARTYADD { get; set; }
        public string PARTYGSTIN { get; set; }
        public string PARTYSTATE { get; set; }
        public string PARTYSTATEREMARK { get; set; }
        public string DISPATCHADD { get; set; }
        public string DISPATCHGSTIN { get; set; }
        public string DISPATCHSTATE { get; set; }
        public string DISPATCHSTATEREMARK { get; set; }
        public string USERNAME { get; set; }
        public string TERMSANDCONDITIONS { get; set; }

        public List<GDNGroupedDetailModel> GDNDETAILS { get; set; }  // For storing related details
    }
    public class GDNGroupedDetailModel
    {
        public string ITEMNAME { get; set; }
        public string HSN { get; set; }
        public string WIDTH { get; set; }
        public List<GDNDetailModel> ITEMDETAILS { get; set; }
    }

    public class GDNDetailModel
    {
        public string DESIGN { get; set; }
        public string SHADE { get; set; }
        public decimal PCS { get; set; }
        public decimal CUTS { get; set; }
        public decimal MTRS { get; set; }
        public decimal RATE { get; set; }
        public string BARCODE { get; set; }
    }
    public class INVModel
    {
        public int INVNO { get; set; }
        public String INVDATE { get; set; }
        public string PRINTINITIALS { get; set; }
        public string NAME { get; set; }
        public string REGNAME { get; set; }
        public string AGENTNAME { get; set; }
        public decimal TOTALPCS { get; set; }
        public decimal TOTALMTRS { get; set; }
        public string DISPATCHTO { get; set; }
        public int YEARID { get; set; }
        public string CITYNAME { get; set; }
        public string TRANSNAME { get; set; }
        public int BALENO { get; set; }
        public String CHALLANNO { get; set; }
        public String CHALLANDATE { get; set; }
        public int CRDAYS { get; set; }
        public String DUEDATE { get; set; }
        public string PARTYADD { get; set; }
        public string PARTYGSTIN { get; set; }
        public string PARTYSTATE { get; set; }
        public string PARTYSTATEREMARK { get; set; }
        public string DISPATCHADD { get; set; }
        public string DISPATCHGSTIN { get; set; }
        public string DISPATCHSTATE { get; set; }
        public string DISPATCHSTATEREMARK { get; set; }
        public String ACKNO { get; set; }
        public string IRNNO { get; set; }
        public String ACKDATE { get; set; }
        public decimal TOTALWITHMATVALUE { get; set; }
        public decimal TOTALCGSTPER { get; set; }
        public decimal TOTALSGSTPER { get; set; }
        public decimal TOTALIGSTPER { get; set; }
        public decimal TOTALCGSTAMT { get; set; }
        public decimal TOTALSGSTAMT { get; set; }
        public decimal TOTALIGSTAMT { get; set; }
        public decimal ROUNDOFF { get; set; }
        public string INWORDS { get; set; }
        public string REMARKS { get; set; }
        public string USERNAME { get; set; }
        public string TERMSANDCONDITIONS { get; set; }
        public string EWAYBILLNO { get; set; }
        public string LRNO { get; set; }
        public String LRDATE { get; set; }
        public decimal TCSPER { get; set; }
        public decimal TCSAMT { get; set; }
        public decimal TOTALTAXAMT { get; set; }
        public decimal GRANDTOTAL { get; set; }
        public string QRCODE { get; set; }  // This will hold the Base64 string for the image

        public List<FlatINVDetailModel> INVDETAILS { get; set; }
        public List<INVChargesModel> INVCHARGES { get; set; } = new List<INVChargesModel>();

    }
    public class FlatINVDetailModel
    {
        public string ITEMNAME { get; set; }
        public string HSN { get; set; }
        public string WIDTH { get; set; }
        public string DESIGN { get; set; }
        public string SHADE { get; set; }
        public decimal PCS { get; set; }
        public decimal MTRS { get; set; }
        public decimal RATE { get; set; }
        public decimal AMOUNT { get; set; }
        public string UOM { get; set; }
    }
    public class INVChargesModel
    {
        public String CHARGES { get; set; }
        public decimal CHARGESPER { get; set; }
        public decimal CHARGESAMT { get; set; }
    }

    public class SOMODEL
    {
        public int SONO { get; set; }
        public String SODATE { get; set; }
        public String DELDATE { get; set; }
        public string PARTYNAME { get; set; }
        public string AGENTNAME { get; set; }
        public string TRANSNAME { get; set; }
        public string CITY { get; set; }
        public string PARTYPONO { get; set; }
        public string CRDAYS { get; set; }
        public string ADDRESS { get; set; }
        public string GSTIN { get; set; }
        public string SPECIALREMARKS { get; set; }
        public string USERNAME { get; set; }
        public string SHIPTO { get; set; }
        public decimal TOTALQTY { get; set; }
        public decimal TOTALMTRS { get; set; }
        public int YEARID { get; set; }

        public List<SODetailGroupedModel> SODETAILS { get; set; }
    }

    public class SODetailGroupedModel
    {
        public string ITEMNAME { get; set; }
        public List<SODetailModel> ITEMDETAILS { get; set; }
    }

    public class SODetailModel
    {
        public string DESIGN { get; set; }
        public string COLOR { get; set; }
        public string UNIT { get; set; }
        public string REMARKS { get; set; }
        public decimal QTY { get; set; }
        public decimal MTRS { get; set; }
        public decimal RATE { get; set; }
        public decimal CUT { get; set; }
    }

    // Helper model used only for grouping internally
    public class SODetailModelWithItem
    {
        public string ITEMNAME { get; set; }
        public string DESIGN { get; set; }
        public string COLOR { get; set; }
        public string UNIT { get; set; }
        public string REMARKS { get; set; }
        public decimal QTY { get; set; }
        public decimal MTRS { get; set; }
        public decimal RATE { get; set; }
        public decimal CUT { get; set; }
    }

    public class POMODEL
    {
        public int PONO { get; set; }
        public String PODATE { get; set; }
        public String DELDATE { get; set; }
        public string PARTYNAME { get; set; }
        public string AGENTNAME { get; set; }
        public string TRANSNAME { get; set; }
        public string DELPERIOD { get; set; }
        public string CRDAYS { get; set; }
        public string ADDRESS { get; set; }
        public string GSTIN { get; set; }
        public string SPECIALREMARKS { get; set; }
        public string USERNAME { get; set; }
        public decimal TOTALMTRS { get; set; }
        public decimal DISC { get; set; }
        public int YEARID { get; set; }

        public List<PODetailGroupedModel> PODETAILS { get; set; }
    }

    public class PODetailGroupedModel
    {
        public string ITEMNAME { get; set; }
        public List<PODetailModel> ITEMDETAILS { get; set; }
    }

    public class PODetailModel
    {
        public string DESIGN { get; set; }
        public string COLOR { get; set; }
        public string REMARKS { get; set; }
        public string DYEING { get; set; }
        public decimal AMOUNT { get; set; }
        public decimal MTRS { get; set; }
        public decimal RATE { get; set; }
    }

    // Helper model used only for grouping internally
    public class PODetailModelWithItem
    {
        public string ITEMNAME { get; set; }
        public string DESIGN { get; set; }
        public string COLOR { get; set; }
        public string DYEING { get; set; }
        public decimal AMOUNT { get; set; }
        public string REMARKS { get; set; }
        public decimal MTRS { get; set; }
        public decimal RATE { get; set; }
    }

    public class PIMODEL
    {
        public int PINO { get; set; }
        public String PIDATE { get; set; }
        public string PARTYNAME { get; set; }
        public string AGENTNAME { get; set; }
        public string TRANSNAME { get; set; }
        public decimal TOTALMTRS { get; set; }
        public decimal TOTALPCS { get; set; }
        public string REMARKS { get; set; }
        public decimal GRANDTOTAL { get; set; }
        public int YEARID { get; set; }
        public string REGNAME { get; set; }
        public List<PIDetailGroupedModel> PIDETAILS { get; set; }
    }

    public class PIDetailGroupedModel
    {
        public string ITEMNAME { get; set; }
        public List<PIDetailModel> ITEMDETAILS { get; set; }
    }

    public class PIDetailModel
    {
        public string DESIGN { get; set; }
        public string COLOR { get; set; }
        public decimal PCS { get; set; }
        public decimal AMOUNT { get; set; }
        public decimal MTRS { get; set; }
        public decimal RATE { get; set; }

    }

    // Helper model used only for grouping internally
    public class PIDetailModelWithItem
    {
        public string ITEMNAME { get; set; }
        public string DESIGN { get; set; }
        public string COLOR { get; set; }
        public decimal PCS { get; set; }
        public decimal AMOUNT { get; set; }
        public decimal MTRS { get; set; }
        public decimal RATE { get; set; }
    }

    

}
