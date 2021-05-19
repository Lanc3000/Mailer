using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;


namespace Mailer
{   //Класс планировщик, который создает расписание, следит за его выполнением и напоминает о событиях
    // помогает автоматизировать рассылку писем в соответствии с расписанием
    public class SchedulerClass
    {
        DispatcherTimer timer = new DispatcherTimer(); // таймер
        EmailSendServiceClass emailSender; // объект класса, отвечающего за отправку писем
        DateTime dtSend; //дата и время отправки
        IQueryable<Email> emails; //коллекция emailов адресатов

        //Метод, который превращает строку из текстбокса tbTimePicker в TimeSpan
        public TimeSpan GetSendTime(string strSendTime)
        {
            TimeSpan tsSendTime = new TimeSpan();
            try
            {
                tsSendTime = TimeSpan.Parse(strSendTime);
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Ошибка: {ex.Message}");
            }
            return tsSendTime;
        }

        // Отправка писем
        public void SendEmails(DateTime dtSend, EmailSendServiceClass emailSender, IQueryable<Email> emails)
        {
            this.emailSender = emailSender;
            this.dtSend = dtSend;
            this.emails = emails;
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(dtSend.ToShortTimeString() == DateTime.Now.ToShortTimeString())
            {
                emailSender.SendMails(emails);
                timer.Stop();
                MessageBox.Show("Письма отправлены");
            }
        }
    }
}
