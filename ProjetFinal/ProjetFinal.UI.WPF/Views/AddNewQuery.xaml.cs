using ProjetFinal.UI.WPF.Model;
using ProjetFinal.UI.WPF.ViewModel;
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
using System.Windows.Shapes;

namespace ProjetFinal.UI.WPF.Views
{
    /// <summary>
    /// Interaction logic for AddNewQuery.xaml
    /// </summary>
    public partial class AddNewQuery : Window
    {
        private MainWindow mainWindow = null;
        private Query newQuery = null;

        public AddNewQuery(MainWindow w)
        {
            InitializeComponent();
            mainWindow = w;
            newQuery = new Query();
            this.DataContext = new ViewModelAddNewQueries();
            //urls.DataContext = newQuery.urls;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // DataContext =             
            this.Title = "Create a new query, URLs and selectors";
        }

        //ADD new URL
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelAddNewQueries)this.DataContext).AddToListURL(URL.Text);
            lbURLs.ItemsSource = null;
            lbURLs.ItemsSource = ((ViewModelAddNewQueries)this.DataContext).listURL;
            URL.Text = "www.exemple.fr";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ((ViewModelAddNewQueries)this.DataContext).AddToListSelector(((URL)lbURLs.SelectedItem), tbScript.Text);
            listSelectors.ItemsSource = null;
            listSelectors.ItemsSource = ((URL)lbURLs.SelectedItem).selectors;
            tbScript.Text = "";
        }

        private void lbURLs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (((ListBox)sender).SelectedItem != null)
            {
                listSelectors.ItemsSource = null;
                listSelectors.ItemsSource = ((URL)((ListBox)sender).SelectedItem).selectors;

            
            }

            //if (tbScript.Text != null && tbScript.Text != "")
            //{
            //    btAddScript.IsEnabled = true;
            //}
            //else
            //{
            //    btAddScript.IsEnabled = false;
            //}
        }
    }
}
