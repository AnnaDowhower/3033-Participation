using Newtonsoft.Json;
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

namespace JSON_Serialization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Platform>  games = new List<Platform>();
        public MainWindow()
        {
            InitializeComponent();

            var lines = File.ReadAllLines("all_games.csv").Skip(1);

            foreach (var line in lines)
            {
                games.Add(new Platform(line));
            }

            PopulateComboBox();
        }

        private void PopulateListBox(List<Platform> FilteredGames)
        {
            lstGames.Items.Clear();

            foreach (var game in FilteredGames)
            {
                lstGames.Items.Add(game);
            }
        }

        private List<Platform> FilterListBox(List<Platform> games)
        {
            string plat = cboPlatforms.SelectedValue.ToString();

            List<Platform> filteredGames = new List<Platform>();

            foreach (var game in games)
            {
                if (plat.ToLower() == "all")
                {
                    filteredGames.Add(game);
                }
                else if (game.platform.Contains(plat))
                {
                    filteredGames.Add(game);
                }
            }
            return filteredGames;
        }

        private void PopulateComboBox()
        {
            cboPlatforms.Items.Add("All");
            foreach (var game in games)
            {
                if (string.IsNullOrWhiteSpace(game.platform))
                {
                    continue;
                }
                if (!cboPlatforms.Items.Contains(game.platform))
                {
                    cboPlatforms.Items.Add(game.platform);
                }
            }
        }

        private void lstGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Platform chosen = (Platform)lstGames.SelectedItem;
            WndInfo wnd = new WndInfo(chosen);
            wnd.SetupWindow(chosen);
            wnd.Show();
        }
        private void UpdateDataForFilter()
        {
            if (cboPlatforms.SelectedValue is null)
            {
                return;
            }
            List<Platform> FilteredGames;
            FilteredGames = FilterListBox(games);
            PopulateListBox(FilteredGames);

            PopulateListBox(FilteredGames);
        }
        private void cboPlatforms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataForFilter();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(lstGames.Items, Formatting.Indented);
            File.WriteAllText($"{cboPlatforms.SelectedValue.ToString()}_games.json", json);
        }
    }
}
