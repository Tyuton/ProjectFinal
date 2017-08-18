using ProjetFinal.UI.WPF.Model;
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
    public partial class ModifyQuery : Window
    {
        public MainWindow mainWindow = null;
        public ModifyQuery(MainWindow w)
        {
            InitializeComponent();
            mainWindow = w;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // DataContext = 
            QueryName.Text = ((Query)mainWindow.Queries.SelectedItem).Nom;
        }
    }
}
