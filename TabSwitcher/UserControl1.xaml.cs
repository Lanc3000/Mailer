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

namespace TabSwitcher
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public event RoutedEventHandler btnNextClick;
        public event RoutedEventHandler btnPreviosClick;
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            btnNextClick?.Invoke(sender, e);
        }

        private void btnPrevios_Click(object sender, RoutedEventArgs e)
        {
            btnPreviosClick?.Invoke(sender, e);
        }
    }
}
