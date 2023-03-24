using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BddediteurContext;

namespace DllBddEditeur
{
    public class BddEditeur
    {
        private BddediteurDataContext bdd = null;
        public BddEditeur()
        {
            try
            {
                bdd = new BddediteurDataContext();
            }
            catch
            {
                throw new Exception("problème pour instancier l'attribut bdd");
            }
        }
        public BddEditeur(string serveurIp, string port, string user, string mdp)
        {
            try
            {
                //connectionString = "User Id=AdminEditeur;Password=@Password1234!;Database=bddediteur;Persist Security Info=True"
                bdd = new BddediteurDataContext("User Id=" + user + ";Password=" + mdp + ";Host=" + serveurIp + ";Port=" + port + ";Database=BddEditeur;Persist Security Info=True");
            }
            catch
            {
                throw;
            }
        }
        public List<Bookauthor> getallAuthors()
        {
            try
            {
                return bdd.Bookauthors.ToList();
            }
            catch { throw; }
        }
        public List<Booklist> getallBooks()
        {
            try
            {
                return bdd.Booklists.ToList();
            }
            catch { throw; }
        }
        public List<Bookprice> GetBookprices()
        {
            try
            {
                return bdd.Bookprices.ToList();
            }
            catch { throw; }
        }
        public bool authorExiste(string n,string pr)
        {
            try
            {
                Bookauthor aut = bdd.Bookauthors.Where(s => s.LastName.ToLower() == n.ToLower() && s.FirstName.ToLower() == pr.ToLower()).FirstOrDefault();
                if (aut != null)
                    return true;
                return false;
            }
            catch { throw; }
        }

        public bool userExists(string log, string mdp)
        {
            User u = bdd.Users.Where(s => s.Login.ToLower() == log.ToLower() && s.Mdp.ToLower() == mdp.ToLower()).FirstOrDefault();
            if (u != null)
                return true;
            return false;
        }

        public bool isAdmin(string log)
        {
            try
            {
                User u = bdd.Users.Where(s => s.Login.ToLower() == log.ToLower()).FirstOrDefault();
                if (u.Autorisation)
                {
                    return true;
                }
                return false;

            }
            catch { throw; }
        }

        public bool addAuthor(string n, string p, string isb)
        {
            bool Result;
            try
            {
                Bookauthor aut = new Bookauthor();
                aut.FirstName = n;
                aut.LastName = p;
                aut.ISBN = isb;
                bdd.Bookauthors.InsertOnSubmit(aut);
                bdd.SubmitChanges();
                Result = true;
            }
            catch { Result = false; }
            return Result;
        }
        public bool addUser(string nom, string prenom, string login, string mdp)
        {
            bool Result;
            try
            {
                User u = new User();
                u.Nom = nom;
                u.Prenom = prenom;
                u.Login = login;
                u.Mdp = mdp;
                if(bdd.Users.Where(s => s.Login== login).Count() == 0)
                {
                    bdd.Users.InsertOnSubmit(u);
                    bdd.SubmitChanges();
                    Result = true;
                }
                else
                {
                    Result = false;
                }
            }
            catch { Result = false; }
            return Result;
        }
        public bool AddBook(string isb, string titre, DateTime dateP)
        {
            bool Result;
            try
            {
                Booklist livre = new Booklist();
                livre.ISBN = isb;
                livre.Title = titre;
                livre.PublicationDate = dateP;
                bdd.Booklists.InsertOnSubmit(livre);
                Result = true;
            }
            catch { Result = false; }
            return Result;
        }

        public void DeleteBook(Booklist book)
        {
            bdd.Booklists.DeleteOnSubmit(book);
            bdd.SubmitChanges();
        }

        public List<Booklist> GetBooksOfAuthor(Bookauthor author)
        {
            List<Booklist> books = new List<Booklist>();
            var res = from aut in bdd.Bookauthors join bo in bdd.Booklists
                      on aut.ISBN equals bo.ISBN
                      where aut.FirstName.Equals(author.FirstName)
                      && aut.LastName.Equals(author.LastName)
                      select bo;
            foreach (var book in res)
            {
                books.Add(book);
            }
            return books;
        }

        public void UserBecomeAdmin(String log)
        {
            if(!isAdmin(log))
            {

            }
        }
    }
}
