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
using ProjetFinal.UI.WPF.Model;
using System.Collections.ObjectModel;

namespace ProjetFinal.UI.WPF.Views
{
    /// <summary>
    /// Interaction logic for Modify.xaml
    /// </summary>
    public partial class Modify : Window
    {
        private MainWindow mainWindow = null;
        //private Modify modify = null;
        public Modify(MainWindow w)
        {
            InitializeComponent();
            mainWindow = w;
            Requete root1 = new Requete() { Title = "Requête1" };
            Requete childItem1 = new Requete() { Title = "URL1" };
            childItem1.Items.Add(new Requete() { Title = "Selector1" });
            childItem1.Items.Add(new Requete() { Title = "Selector2" });
            Requete childItem2 = new Requete() { Title = "URL2" };
            childItem2.Items.Add(new Requete() { Title = "Selector3" });
            childItem2.Items.Add(new Requete() { Title = "Selector4" });

            root1.Items.Add(childItem1);
            root1.Items.Add(childItem2);


            Requete root2 = new Requete() { Title = "Requête1" };
            Requete childItem3 = new Requete() { Title = "URL3" };
            childItem3.Items.Add(new Requete() { Title = "Selector5" });
            childItem3.Items.Add(new Requete() { Title = "Selector6" });
            Requete childItem4 = new Requete() { Title = "URL4" };
            childItem4.Items.Add(new Requete() { Title = "Selector7" });
            childItem4.Items.Add(new Requete() { Title = "Selector8" });

            root2.Items.Add(childItem3);
            root2.Items.Add(childItem4);

            TreeViewTest.Items.Add(root1);
            TreeViewTest.Items.Add(root2);


        }
        private void Quitter_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class Requete
    {
        public Requete()
        {
            Items = new ObservableCollection<Requete>();
        }

        public ObservableCollection<Requete> Items { get; set; }
        public string Title { get; set; }
    }

}
