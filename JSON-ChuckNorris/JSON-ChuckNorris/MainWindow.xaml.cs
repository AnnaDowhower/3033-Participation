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

namespace JSON_ChuckNorris
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
                string json = client.GetStringAsync("https://api.chucknorris.io/jokes/categories").Result;  //how to start every json

                var results = JsonConvert.DeserializeObject<List<string>>(json);

                cboCategory.Items.Add("All");
                cboCategory.SelectedIndex = 0;

                foreach (string category in results)
                {
                    cboCategory.Items.Add(category);
                }
            }


        }

        private void btnGetJoke_Click(object sender, RoutedEventArgs e)
        {
            string cat = cboCategory.SelectedItem.ToString();
            string url = $"https://api.chucknorris.io/jokes/random?category={cat}";
            
            using (var client = new HttpClient())
            {
                string joke = client.GetStringAsync($"{url}").Result;

                var result = JsonConvert.DeserializeObject<Result>(joke);

                lblJoke.Content = result;
            }
        }
    }
}
