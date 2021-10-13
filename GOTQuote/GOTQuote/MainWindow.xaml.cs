using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace GOTQuote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<GOTAPI> quotes = new List<GOTAPI>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGetQuote_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                string url = "https://got-quotes.herokuapp.com/quotes";
                string json = client.GetStringAsync(url).Result;

                GOTAPI api = JsonConvert.DeserializeObject<GOTAPI>(json);

                string quote = api.quote.ToString();
                blkQuote.Text = quote;
                string name = api.character.ToString();
                blkName.Text = name;
                quotes.Add(api);
            }
        }

        private void btnCreateFile_Click(object sender, RoutedEventArgs e)
        {

            if (quotes.Count() < 1)
            {
                MessageBox.Show("You must generate a quote to create a file");
            }
            else
            {
                string json2 = JsonConvert.SerializeObject(quotes);
                File.WriteAllText("GOT_Quotes.json", json2);

                MessageBox.Show("Your file \"GOT_Quotes.json\" was created!");
            }

        }
    }
}
