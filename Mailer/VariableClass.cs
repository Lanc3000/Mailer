using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer
{
    public static class VariableClass
    {
        private static Dictionary<string, string> dicSenders = new Dictionary<string, string>() {
            {"example4@yandex.ru", PasswordClass.getPassword("1234l;i") },
            {"reinc@yandex.ru", PasswordClass.getPassword(";liq34tjk") }
        };
        public static Dictionary<string, string> Senders { get { return dicSenders; } }
    }
}
