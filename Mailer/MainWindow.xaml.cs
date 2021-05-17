using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;

namespace Mailer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            cbSenderSelect.ItemsSource = VariableClass.Senders;
            cbSenderSelect.DisplayMemberPath = "Key";
            cbSenderSelect.SelectedValuePath = "Value";

            DBclass db = new DBclass();
            dgEmails.ItemsSource = db.Emails; // привязка данных из БД к элементу управления DataGrid (отображение адресатов)
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            wndAbout about = new wndAbout();
            about.ShowDialog();
        }

        private void btSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var toAddress = new MailAddress(tbToAddress.Text);
                var fromAddress = new MailAddress(tbFromAddress.Text);
                //string subject = tbMesSubject.Text;
                string body = tbMesBody.Text;
                string password = pbPassword.Password;

                //тут будет вызов метода парсящего строку с адрессом и в зависимости от почтовой службы
                //выбирающего нужные настройки
                // а пока messagebox для заглушки
                MessageBox.Show($"Отправленно от: {fromAddress}\n" +
                    $"На адрес: {toAddress}\n" +
                    $"Тема: none\n" +
                    $"Сообщение: {body}");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClock_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedItem = tabPlanner;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSendNow_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
