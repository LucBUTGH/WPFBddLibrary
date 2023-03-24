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
    /// Logique d'interaction pour WinParametresBdd.xaml
    /// </summary>
    public partial class WinParametresBdd : Window
    {
        public WinParametresBdd()
        {
            InitializeComponent();
        }

        private void btnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            if (!CValidateByRegex.IsAdressIpv4(this.txtServeur.Text))
            {
                MessageBox.Show("L'adresse Ipv4 du serveur n'est pas valide", "Erreur d'adresse Ipv4");
                return;
            }
            if (!CValidateByRegex.IsPortNumber(this.txtPort.Text))
            {
                MessageBox.Show("Le port n'est pas valide", "Erreur de port");
                return;
            }
            this.DialogResult = true;
            this.Close();
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
