using System;
using System.Collections.Generic;
using System.IO;
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

namespace Contact_List
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Contact> Contacts = new List<Contact>();

        public MainWindow()
        {
            InitializeComponent();

            var lines = File.ReadAllLines("contacts.txt").Skip(1);

            foreach (var line in lines)
            {
                Contacts.Add(new Contact(line));
            }
            PopulateListBox(Contacts);

        }
        private void PopulateListBox(List<Contact> contacts)
        {
            foreach (Contact person in contacts)
            {
                lstContacts.Items.Add(person);
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            Contact selectedPerson = (Contact)lstContacts.SelectedItem;
            txtFname.Text = selectedPerson.FirstName;
            txtLname.Text = selectedPerson.LastName;
            txtEmail.Text = selectedPerson.Email;
            lblID.Content = selectedPerson.Id;

            imgPhoto.Source = new BitmapImage(new Uri(selectedPerson.Photo));
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lblID.Content = "";
        }
    }
}
