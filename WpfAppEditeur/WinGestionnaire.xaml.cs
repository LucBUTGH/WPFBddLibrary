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
    /// Logique d'interaction pour WinGestionnaire.xaml
    /// </summary>
    public partial class WinGestionnaire : Window
    {

        private MainWindow _mainWindow;
        private BddEditeur bdd = new BddEditeur(Properties.Settings.Default.AdrIpServeur, Properties.Settings.Default.Port, Properties.Settings.Default.Utilisateur, Properties.Settings.Default.Mdp);
        public WinGestionnaire(MainWindow window)
        {
            InitializeComponent();
            _mainWindow = window;
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(bdd.userExists(txtUser.Text, txtMdp.Text))
            {
                Properties.Settings.Default.Utilisateur = txtUser.Text;
                Properties.Settings.Default.Mdp = txtMdp.Text;
                if (bdd.isAdmin(txtUser.Text))
                {
                    MessageBox.Show("Connecté en tant qu'admin");
                    _mainWindow.AfficherItems();

                }
                else
                {
                    MessageBox.Show("Connecté en tant qu'employé");
                }
            }
            else
            {
                MessageBox.Show("Erreur");
            }
            this.Close();
        }
    }
}
