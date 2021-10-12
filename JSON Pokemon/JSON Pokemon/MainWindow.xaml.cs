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

namespace JSON_Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PokemonInfo poke;
        private bool showFront;
        public MainWindow()
        {
            InitializeComponent();
            string url = "https://pokeapi.co/api/v2/pokemon?offset=0&limit=1200";

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    Pokemon api = JsonConvert.DeserializeObject<Pokemon>(json);

                    foreach (var item in api.results)
                    {
                        cboPokemon.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show($"ERROR: {response.StatusCode}");
                }
            }
        }

        private void btnChoose_Click(object sender, RoutedEventArgs e)
        {
            Results selected = (Results)cboPokemon.SelectedItem;

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(selected.url).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    poke = JsonConvert.DeserializeObject<PokemonInfo>(json);

                    imgSprite.Source = new BitmapImage(new Uri(poke.sprites.front_default));
                    showFront = false;
                }
            }
        }

        private void btnToggle_Click(object sender, RoutedEventArgs e)
        {
            if (showFront)
            {
                imgSprite.Source = new BitmapImage(new Uri(poke.sprites.front_default));
                showFront = false;
            }
            else
            {
                imgSprite.Source = new BitmapImage(new Uri(poke.sprites.back_default));
                showFront = true;
            }
        }
    }
}
