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

namespace Exam1Practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Show> TVShows = new List<Show>();
        public MainWindow()
        {
            InitializeComponent();

            var lines = File.ReadAllLines("TV Show Data.txt").Skip(1);

            foreach (var line in lines)
            {
                TVShows.Add(new Show(line));
            }

            PopulateListBox(TVShows);
            PopulateRatedFilter();
            PopulateCountryFilter();
            PopulateLanguageFliter();

        }

        private void UpdateFilters()
        {
            if (cboRating.SelectedValue is null || cboCountry.SelectedValue is null || cboLanguage.SelectedValue is null)
            {
                return;
            }
            List<Show> filteredShows;
            filteredShows = FilterRatings(TVShows);
            filteredShows = FilterCountry(filteredShows);
            filteredShows = FilterLanguage(filteredShows);

            PopulateListBox(filteredShows);
        }

        private List<Show> FilterLanguage(List<Show> shows)
        {
            string lang = cboLanguage.SelectedValue.ToString();
            List<Show> filteredshows = new List<Show>();

            foreach (var show in shows)
            {
                if (lang.ToLower() == "all")
                {
                    filteredshows.Add(show);
                }
                else if (show.Language.Contains(lang))
                {
                    filteredshows.Add(show);
                }
            }
            return filteredshows;
        }

        private List<Show> FilterCountry(List<Show> shows)
        {
            string place = cboCountry.SelectedValue.ToString();
            List<Show> filteredshows = new List<Show>();

            foreach (var show in shows)
            {
                if (place.ToLower() == "all")
                {
                    filteredshows.Add(show);
                }
                else if (show.Country.Contains(place))
                {
                    filteredshows.Add(show);
                }
            }
            return filteredshows;
        }

        private List<Show> FilterRatings(List<Show> shows)
        {
            string rating = cboRating.SelectedValue.ToString();
            List<Show> filteredshows = new List<Show>();

            foreach (var show in shows)
            {
                if (rating.ToLower() == "all")
                {
                    filteredshows.Add(show);
                }
                else if (show.Rated.Contains(rating))
                {
                    filteredshows.Add(show);
                }
            }
            return filteredshows;
        }

        private void PopulateLanguageFliter()
        {
            cboLanguage.Items.Add("All");
            cboLanguage.SelectedIndex = 0;

            foreach (var show in TVShows)
            {
                var value = show.Language.Split(',');
                foreach (var val in value)
                {
                    if (string.IsNullOrWhiteSpace(val))
                    {
                        continue;
                    }
                    var Trimmed = val.Trim(' ', '"', ',', '.');
                    if (!cboLanguage.Items.Contains(Trimmed))
                    {
                        cboLanguage.Items.Add(Trimmed);
                    }
                }
            }
        }

        private void PopulateCountryFilter()
        {
            cboCountry.Items.Add("All");
            cboCountry.SelectedIndex = 0;

            foreach (var show in TVShows)
            {
                var value = show.Country.Split(',');
                foreach (var val in value)
                {
                    if (string.IsNullOrWhiteSpace(val))
                    {
                        continue;
                    }
                    var Trimmed = val.Trim(' ', '"', ',', '.');
                    if (!cboCountry.Items.Contains(Trimmed))
                    {
                        cboCountry.Items.Add(Trimmed);
                    }
                }
            }
        }

        private void PopulateRatedFilter()
        {
            cboRating.Items.Add("All");
            cboRating.SelectedIndex = 0;

            foreach (var show in TVShows)
            {
                if (string.IsNullOrWhiteSpace(show.Rated))
                {
                    continue;
                }
                string cleaned = show.Rated.Trim();
                if (!cboRating.Items.Contains(cleaned))
                {
                    cboRating.Items.Add(cleaned);
                }
            }
        }

        private void PopulateListBox(List<Show> TvShows)
        {
             lstShows.Items.Clear();

            foreach (var show in TvShows)
            {
                lstShows.Items.Add(show);
            }
        }

        private void cboRating_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFilters();
        }

        private void cboCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFilters();
        }

        private void cboLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFilters();
        }
    }
}
