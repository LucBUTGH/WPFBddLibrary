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
using DllBddEditeur;
using BddediteurContext;

namespace WpfAppEditeur
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private  BddEditeur bddedit = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void menuConnexionBdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               bddedit = new BddEditeur(Properties.Settings.Default.AdrIpServeur, Properties.Settings.Default.Port, Properties.Settings.Default.Utilisateur, Properties.Settings.Default.Mdp);
               // bddedit = new BddEditeur("127.0.0.1", "3306", "AdminEditeur", "@Password1234!");
               List<Bookauthor> listeAuteurs = bddedit.getallAuthors();
                MessageBox.Show("Bdd Editeur connectée");
                if (listeAuteurs!= null)
                    LstwAuteurs.ItemsSource = listeAuteurs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de la connexion à la Bdd");
            }
        }

        private void ListBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender is ListView)
                {
                    Booklist book = (Booklist)(sender as ListView).SelectedItem;

                    if (book != null)
                    {
                        del_book.IsEnabled = true;
                    }
                    else
                    {
                        del_book.IsEnabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de selection de livre");
            }
        }

        private void LstwAuteurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender is ListView)
                {
                    Bookauthor auteur = (Bookauthor)(sender as ListView).SelectedItem;
                    
                    if (auteur != null)
                    {
                        this.txtNom.Text = auteur.LastName;
                        this.txtPrenom.Text = auteur.FirstName;
                        this.txtIsbn.Text = auteur.ISBN;
                        this.ListBooks.Visibility= Visibility.Visible;
                        ListBooks.Items.Clear();
                        foreach(var book in bddedit.GetBooksOfAuthor(auteur))
                        {
                            ListBooks.Items.Add(book);
                        }
                        btnAddBook.IsEnabled=true;
                        deselect.IsEnabled=true;
                        btnAddAuthor.IsEnabled=false;
                    }
                    else
                    {
                        btnAddBook.IsEnabled = false;
                        deselect.IsEnabled = false;
                        btnAddAuthor.IsEnabled= true;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de selection de personnel");
            }
        }
        private void menuParametresBdd_Click(object sender, RoutedEventArgs e)
        {
            WinParametresBdd param = new WinParametresBdd();
            param.txtServeur.Text = Properties.Settings.Default.AdrIpServeur;
            param.txtPort.Text = Properties.Settings.Default.Port;
            param.txtUser.Text = Properties.Settings.Default.Utilisateur;
            param.txtMdp.Text = Properties.Settings.Default.Mdp;
            if (param.ShowDialog() == true)
            {
                Properties.Settings.Default.AdrIpServeur = param.txtServeur.Text;
                Properties.Settings.Default.Port = param.txtPort.Text;
                Properties.Settings.Default.Utilisateur = param.txtUser.Text;
                Properties.Settings.Default.Mdp = param.txtMdp.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void MenuGestionnaire_Click(object sender, RoutedEventArgs e)
        {
            WinGestionnaire gest = new WinGestionnaire(this);
            gest.txtUser.Text = Properties.Settings.Default.Utilisateur;
            gest.txtMdp.Text = Properties.Settings.Default.Mdp;
            if (gest.ShowDialog() == true)
            {
                Properties.Settings.Default.Utilisateur = gest.txtUser.Text;
                Properties.Settings.Default.Mdp = gest.txtMdp.Text;
                Properties.Settings.Default.Save();
            }
        }

        public void AfficherItems()
        {
            addUser.Visibility = Visibility.Visible;
            editUser.Visibility = Visibility.Visible;
            btnAddAuthor.Visibility = Visibility.Visible;
            del_book.Visibility = Visibility.Visible;
            btnAddBook.Visibility = Visibility.Visible;
        }

        private void logout_click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Utilisateur = null;
            Properties.Settings.Default.Mdp = null;
        }

        private void quit_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        } 

        private void add_newbook(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is ListView)
                {
                    Bookauthor auteur = (Bookauthor)(sender as ListView).SelectedItem;
                    NewBook book = new NewBook(this);
                    book.txtISBN.Text = auteur.ISBN;
                    book.txtName.Text = null;
                    book.txtDate.Text = null;
                }
            }
            catch { throw; }
        }

        private void add_newauthor(object sender, RoutedEventArgs e)
        {
            NewBook book = new NewBook(this);
            book.txtISBN.Text = null;
            book.txtName.Text = null;
            book.txtDate.Text = null;
            
        }

        private void delete_book(object sender, RoutedEventArgs e)
        {
            Booklist selectedItem = (Booklist)ListBooks.SelectedItem;
            MessageBox.Show("Le livre " + selectedItem.Title + " a été supprimé !");
            ListBooks.Items.Remove(selectedItem);
            bddedit.DeleteBook(selectedItem);
        }

        private void deselect_author(object sender, RoutedEventArgs e)
        {

            LstwAuteurs.UnselectAll();
            ListBooks.Items.Clear();
            txtIsbn.Text = string.Empty;
            txtNom.Text = string.Empty;
            txtPrenom.Text = string.Empty;
        }


    }
}
