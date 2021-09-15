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

namespace WPF_Classes
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

        private void btnAddToy_Click(object sender, RoutedEventArgs e)
        {

            bool isEverythingGood = true;

            if (string.IsNullOrWhiteSpace(txtManufacturer.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid manufacturer");
            }
            if (string.IsNullOrWhiteSpace(txtName.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid toy name");
            }
            if (string.IsNullOrWhiteSpace(txtImage.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid image URL");
            }

            double price;
            if (double.TryParse(txtPrice.Text, out price) == false)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid price");
            }

            if (isEverythingGood == false)
            {
                return;
            }

            Toy toy = new Toy()
            {
                Manufacturer = txtManufacturer.Text,
                Name = txtName.Text,
                Price = price,
                Image = txtImage.Text,
            };

            lstToys.Items.Add(toy);

            txtImage.Clear();
            txtManufacturer.Clear();
            txtName.Clear();
            txtPrice.Clear();


        }
    }
}
