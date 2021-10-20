using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JSON_Serialization
{
    /// <summary>
    /// Interaction logic for WndInfo.xaml
    /// </summary>
    public partial class WndInfo : Window
    {
        public WndInfo(Platform chosen)
        {
            InitializeComponent();

        }
        public void SetupWindow(Platform chosen)
        {
            this.Title = chosen.Name;
            txtName.Text = chosen.Name;
            txtPlatform.Text = chosen.platform;
            txtReleaseDate.Text = chosen.ReleaseDate.ToString();
            txtSummary.Text = chosen.Summary;
            txtMetaScore.Text = chosen.MetaScore.ToString();
            txtUserReview.Text = chosen.UserReview;

        }
    }
}
