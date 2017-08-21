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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjetFinal.UI.WPF.Views;

namespace ProjetFinal.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Quitter_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new ViewModelQueries();
        }

        private void Queries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
        }

        private void URLs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void URLs_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddNewQuery newqueryWindow = new AddNewQuery(this);
            newqueryWindow.Show();
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            //ModifyQuery modifyQ = new ModifyQuery(this);
            //modifyQ.Show();
        }
    }
}
