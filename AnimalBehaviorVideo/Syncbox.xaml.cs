using Microsoft.Win32;
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
using System.Windows.Threading;

namespace AnimalBehaviorVideo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Syncbox : Window
    {

        public int HhI;
        public int MmI;
        public int SsI;


        public Syncbox()
        {
            InitializeComponent();


        }

        private void txt_time_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_time.Text == "hh:mm:ss")
            {
                txt_time.Text = "";
            }
        }

        private void txt_time_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_time.Text == "")
            {
                txt_time.Text = "hh:mm:ss";
            }
        }

        private void btn_syncbox_OK_Click(object sender, RoutedEventArgs e)
        {
            //set state as true from beginning -> turn to false if error happens along the way
            bool dialogResultState = true;

            string txt = txt_time.Text;
            string hh = txt.Substring(0, 2);
            string mm = txt.Substring(3, 2);
            string ss = txt.Substring(6, 2);


            //try to parse from string to int
            try
            {
                HhI = Int32.Parse(hh, System.Globalization.NumberStyles.Integer);
                MmI = Int32.Parse(mm, System.Globalization.NumberStyles.Integer);
                SsI = Int32.Parse(ss, System.Globalization.NumberStyles.Integer);
            }
            catch (FormatException)
            {
                dialogResultState = false;
            }

            //check where the values of the time is valid
            if(HhI < 0 || HhI > 24)
            {
                dialogResultState = false;
            }
            else if (MmI < 0 || MmI > 60)
            {
                dialogResultState = false;
            }
            else if (SsI < 0 || SsI > 60)
            {
                dialogResultState = false;
            }

            //makes messagebox if error happend, and return false else returns true
            if(dialogResultState == false)
            {
                var msgResult = MessageBox.Show("Wrong input!");
                DialogResult = false;
            }
            else
            {
                DialogResult = true;
            }
        }

    }
}
