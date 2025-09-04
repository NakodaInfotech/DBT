using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DBT.Controllers
{
    public class ReportsController : ApiController
    {

        //[RoutePrefix("api/Details")]
        //    public class DetailsController : ApiController
        //    {
        //        CodeXEntities cX = new CodeXEntities();

        //        [AllowAnonymous]
        //        [Route("Report/SendReport")]
        //        [HttpPost]
        //        public HttpResponseMessage ExportReport(Users user)
        //        {
        //            string EmailTosend = WebUtility.UrlDecode(user.Email);
        //            List<Users> model = new List<Users>();
        //            var data = cX.tbl_Registration;
        //            var rd = new ReportDocument();

        //            foreach (var details in data)
        //            {
        //                Users obj = new Users();
        //                obj.Email = details.Email;
        //                obj.FirstName = details.FirstName;
        //                obj.LastName = details.LastName;
        //                model.Add(obj);

        //            }

        //            rd.Load(Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Reports"), "UserRegistration.rpt"));
        //            ConnectionInfo connectInfo = new ConnectionInfo()
        //            {
        //                ServerName = "Debendra",
        //                DatabaseName = "CodeX",
        //                UserID = "sa",
        //                Password = "123"
        //            };
        //            rd.SetDatabaseLogon("sa", "123");
        //            foreach (Table tbl in rd.Database.Tables)
        //            {
        //                tbl.LogOnInfo.ConnectionInfo = connectInfo;
        //                tbl.ApplyLogOnInfo(tbl.LogOnInfo);
        //            }
        //            rd.SetDataSource(model);
        //            using (var stream = rd.ExportToStream(ExportFormatType.PortableDocFormat))
        //            {
        //                SmtpClient smtp = new SmtpClient
        //                {
        //                    Port = 587,
        //                    UseDefaultCredentials = true,
        //                    Host = "smtp.gmail.com",
        //                    EnableSsl = true
        //                };

        //                smtp.UseDefaultCredentials = false;
        //                smtp.Credentials = new NetworkCredential("de****@gmail.com", "**********");
        //                var message = new System.Net.Mail.MailMessage("debendra256@gmail.com", EmailTosend, "User Registration Details", "Hi Please check your Mail  and find the attachement.");
        //                message.Attachments.Add(new Attachment(stream, "UsersRegistration.pdf"));

        //                smtp.Send(message);
        //            }

        //            var Message = string.Format("Report Created and sended to your Mail.");
        //            HttpResponseMessage response1 = Request.CreateResponse(HttpStatusCode.OK, Message);
        //            return response1;
        //        }


        //    }
        //}
    }

}