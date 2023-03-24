using DllBddEditeur;
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

namespace WpfAppEditeur
{
    /// <summary>
    /// Logique d'interaction pour NewBook.xaml
    /// </summary>
    public partial class NewBook : Window
    {
        private MainWindow _mainWindow;
        private BddEditeur bddedit = new BddEditeur(Properties.Settings.Default.AdrIpServeur, Properties.Settings.Default.Port, Properties.Settings.Default.Utilisateur, Properties.Settings.Default.Mdp);
        public NewBook(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        public void btnSave_Click(object sender, RoutedEventArgs e)
        {

            bddedit.AddBook(txtISBN.Text, txtName.Text, DateTime.Parse(txtDate.Text));
            MessageBox.Show(txtName.ToString() + " a bien été ajouté à la liste des livres !");
            this.Close();
        }

        public void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
