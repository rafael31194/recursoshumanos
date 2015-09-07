using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3.Utilerias
{
   public class sendEmail
    {
       public bool EnviarDatosCorreo(string destinatario, string subject, string message, ReportViewer ReportControl, ref string error)
       {
           bool result = false;
           try
           {
               Warning[] warnings;
               string[] streamids;
               string mimeType;
               string encoding;
               string extension;

               byte[] bytes = ReportControl.LocalReport.Render(
                  "PDF", null, out mimeType, out encoding,
                   out extension,
                  out streamids, out warnings);


               // add the attachment from a stream
               System.IO.MemoryStream memStream = new System.IO.MemoryStream(bytes);

               System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(memStream);
               streamWriter.Flush();

               // this is quite important
               memStream.Position = 0;

               System.Net.Mail.Attachment thisAttachment = new System.Net.Mail.Attachment(memStream, "aplication/pdf");
               thisAttachment.ContentDisposition.FileName = "Curriculum.pdf";




               //Configurando el cliente SMTP
               SmtpClient client = new SmtpClient();
               client.Host = "smtp.gmail.com";
               client.Port = 587;
               client.EnableSsl = true;
               client.DeliveryMethod = SmtpDeliveryMethod.Network;
               client.UseDefaultCredentials = false;
               client.Credentials = new NetworkCredential("helpdesk.enviar@gmail.com", "contraenviar");
               //Preparando archivo adjunto


               //Enviando correo
               MailMessage mail = new MailMessage();
               mail.From = new MailAddress("helpdesk.enviar@gmail.com");
               mail.To.Add(new MailAddress(destinatario));
               mail.Subject = subject;
               mail.IsBodyHtml = false;
               mail.Body = message;
               mail.Attachments.Add(thisAttachment);
               client.Send(mail);

               result = true;
           }
           catch (Exception ex)
           {
               result = false;
               error = ex.Message;
           }
           return result;
       }
    }
}
