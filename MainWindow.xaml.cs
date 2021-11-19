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

namespace barcode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Butt.Click += new RoutedEventHandler(Click);
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            string barcode = Input.Text;
            try
            {
                Convert.ToInt64(barcode);
            }
            catch (FormatException)
            {
                L.Content = "Barcode must only contain numbers";
                L.Foreground = Brushes.Red;
                return;
            }
            if (barcode.Length != 13)
            {
                L.Content = "Barcode must be 13 characters long";
                L.Foreground = Brushes.Red;
                return;
            }
            int evenSum = 0;
            int oddSum = 0;
            for (int i = 1;i < 13; i++)
            {
                if (i % 2 == 0) evenSum += Convert.ToInt32(barcode[i-1].ToString());
                else oddSum += Convert.ToInt32(barcode[i-1].ToString());
            }
            int result = (evenSum * 3) + oddSum;
            result %= 10;
            if (10-result == Convert.ToInt32(barcode[12].ToString()))
            {
                L.Content = "Barcode is valid";
                L.Foreground = Brushes.LawnGreen;
                return;
            }
            L.Content = "Barcode is invalid";
            L.Foreground = Brushes.Red;
            return;
        }
    }
}
