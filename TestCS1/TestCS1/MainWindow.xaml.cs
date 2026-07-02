using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestCS1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtOriginal.Focus();
        }

        private void btnCompress_Click(object sender, RoutedEventArgs e)
        {
            string strStart = txtOriginal.Text;
            if (strStart == "") return;
            string strEnd = "";

            try
            {
                char[] carray = strStart.ToCharArray();
                char cprev = carray[0];
                int cnt = 0;
                foreach (char c in carray)
                {
                    if (c == cprev)
                    {
                        cnt += 1;
                    }
                    else
                    {
                        strEnd += cnt == 1 ? cprev.ToString() : cprev.ToString() + cnt.ToString();
                        cnt = 1;
                    }

                    cprev = c;
                }
                strEnd += cnt == 1 ? cprev.ToString() : cprev.ToString() + cnt.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            tbCompressed.Text = strEnd;
        }
              
        private string WriteStr(string str)
        {
            string res = "";
            string s = str.Substring(0,1);
            int n = Int32.Parse(str.Substring(1));

            for (int i = 0; i < n; i++)
            {
                res += s;
            }

            return res;
        }

        private void btnDecompress_Click(object sender, RoutedEventArgs e)
        {
            string strStart = tbCompressed.Text;
            if (strStart == "") return;
            string strEnd = "";

            try
            {
                char[] carray = strStart.ToCharArray();
                string str = "";
                foreach (char c in carray)
                {
                    if (char.IsNumber(c))
                    {
                        str += c.ToString();
                    }
                    else
                    {
                        strEnd += str.Length <= 1 ? str : WriteStr(str);
                        str = c.ToString();
                    }
                }
                strEnd += str.Length == 1 ? str : WriteStr(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }

            tbDecompressed.Text = strEnd;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtOriginal.Text = "";
            tbCompressed.Text = "";
            tbDecompressed.Text = "";
            txtOriginal.Focus();
        }


    }
}
