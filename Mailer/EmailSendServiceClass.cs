using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace Mailer
{
    public class EmailSendServiceClass
    {
        #region vars
        private string strLogin; // email с которого будет рассылаться почта
        private string strPassword; // пароль к email
        private string strSmtp = "smtp.yandex.ru"; //smtp сервер
        private int iSmtpPort = 25; //порт для сервера
        private string strBody; //текст письма
        private string strSubject; // тема письма
        #endregion
        public EmailSendServiceClass(string sLogin, string sPassword)
        {
            strLogin = sLogin;
            strPassword = sPassword;
        }
        private void SendMail(string mail, string name) //отправка email конкретному адресату
        {
            using (MailMessage mm = new MailMessage(strLogin, mail))
            {
                mm.Subject = strSubject;
                mm.Body = "Письмо из WPF";
                mm.IsBodyHtml = false;
                SmtpClient sc = new SmtpClient(strSmtp, iSmtpPort);
                sc.EnableSsl = true;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.UseDefaultCredentials = false;
                sc.Credentials = new NetworkCredential(strLogin, strPassword);
                try
                {
                    sc.Send(mm);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                }
            }
        }
        public void SendMails(IQueryable<Email> emails)
        {
            foreach (Email email in emails)
            {
                SendMail(email.Value, email.Name);
            }
        }
    }
}
