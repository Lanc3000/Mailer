using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodePasswordDLL; //подключаем созданную нами библиотеку по работе с паролями

namespace Mailer
{
    public static class VariableClass
    {

        private static Dictionary<string, string> dicSenders = new Dictionary<string, string>() {
            {"example4@yandex.ru", CodePassword.getPassword("1234l;i") },
            {"reinc@yandex.ru", CodePassword.getPassword(";liq34tjk") }
        };

        public static Dictionary<string, string> Senders {
            get 
            { 
                return dicSenders; 
            } 
        }
    }
}
