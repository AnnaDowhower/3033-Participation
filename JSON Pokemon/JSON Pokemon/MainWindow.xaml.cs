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
        public MainWindow()
        {
            InitializeComponent();

            using (var client = new HttpClient())
            {
               Pokemon pokemon = new Pokemon();

                string json = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon?offset=0&limit=1200").Result;

                //var results = JsonConvert.DeserializeObject<List<Pokemon>>(json);

                //foreach (string poke in results)
                //{
                //    cboPokemon.Items.Add(poke);
                //}
            }
        }
    }
}
