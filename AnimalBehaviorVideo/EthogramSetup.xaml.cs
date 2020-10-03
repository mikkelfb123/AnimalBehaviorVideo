using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class EthogramSetup : Window
    {
        private ObservableCollection<EthogramModel> etho;


        public EthogramSetup(ref ObservableCollection<EthogramModel> in_ethograms)
        {
            InitializeComponent();
            //the in_ethogram is passed by reference therefor etho is a direct pointer to the ethogram list from main window
            etho = in_ethograms;
            
            listbox_ethogram.ItemsSource = etho;//binds the ethogram list to itemsource of the list!
        }

        private void btn_add_new_ethogram_Click(object sender, RoutedEventArgs e)
        {
            if(txtb_new_ethogram.Text != "Enter new ethogram....")
            {

                etho.Add(new EthogramModel() {Name = txtb_new_ethogram.Text });
            }
            txtb_new_ethogram.Text = "Enter new ethogram....";
        }

        private void btn_remove_ethogram_Click(object sender, RoutedEventArgs e)
        {
            if(listbox_ethogram.SelectedItem == null)
            {
                return;
            }

            if((EthogramModel)listbox_ethogram.SelectedItem == etho[0])
            {
                return;
            }

            MessageBoxResult result = MessageBox.Show("Would you like to remove \"" + listbox_ethogram.SelectedItem + "\" from the list?", "Remove ethogram", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                //IMPORTANT to declare object type when removing from the list.
                etho.Remove((EthogramModel) listbox_ethogram.SelectedItem);
                
            }
            else
            {
                return;
            }
        }

        private void btn_ethogram_OK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtb_new_ethogram_GotFocus(object sender, RoutedEventArgs e)
        {
            if(txtb_new_ethogram.Text == "Enter new ethogram....")
            {
                txtb_new_ethogram.Text = "";
            }
        }

        private void txtb_new_ethogram_LostFocus(object sender, RoutedEventArgs e)
        {
            string sTest = txtb_new_ethogram.Text;
            //test if text box is empty
            if(sTest == "")
            {
                txtb_new_ethogram.Text = "Enter new ethogram....";
            }
            else
            {
                //loop throught all chars in textbox string return if any of them is different from " " aka "space" 
                foreach (char c in sTest)
                {
                    if(c != ' ')
                    {
                        return;
                    }
                }
                txtb_new_ethogram.Text = "Enter new ethogram....";
            }
            return;
        }
    }
}
