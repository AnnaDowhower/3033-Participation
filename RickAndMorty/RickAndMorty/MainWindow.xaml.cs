using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace JSON_RickAndMorty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            cboCharacters.Items.Clear();

            using (var client = new HttpClient())
            {

                string jsonData = client.GetStringAsync("https://rickandmortyapi.com/api/character").Result;
                RickAndMortyAPI api = JsonConvert.DeserializeObject<RickAndMortyAPI>(jsonData);

                int page = api.pages;
                for (int i = 0; i < page; i++)
                {
                    string jsonData2 = client.GetStringAsync($"https://rickandmortyapi.com/api/character?page={i}").Result;
                    RickAndMortyAPI api2 = JsonConvert.DeserializeObject<RickAndMortyAPI>(jsonData2);

                    //api2.pages = i;
                    foreach (Character item in api2.results)
                    {
                        cboCharacters.Items.Add(item);
                    }
                }
            }

        }

        private void cboCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Character selected = (Character)cboCharacters.SelectedItem;

            imgCharacter.Source = new BitmapImage(new Uri(selected.image));
            lblName.Content = selected.name;

        }
    }
}