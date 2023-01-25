using System.Net.Mail;

namespace Sinema.MVCUI.Models
{
    public class EmailHelper
    {

        public bool SenMail(string email, string mesaj)
        {

            #region Mail Message tanimlari

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("aliveli6270@gmail.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = "Mail adresinizi onaylayin";
            mailMessage.Body = mesaj;
            mailMessage.IsBodyHtml = true;


            #endregion


            #region SMTP Ayarlari

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential("aliveli6270@gmail.com", "aliveli1234567890");
            smtpClient.EnableSsl = true;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            #endregion

            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {

                return false;
            }


            return true;
        }
    }
}
