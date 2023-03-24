using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllBddEditeur;
using BddediteurContext;
namespace TestEditeur
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                BddEditeur bdd = new BddEditeur("127.0.0.1", "3306", "AdminEditeur", "@Password1234!");
                 List<Bookauthor> listeauteurs= bdd.getallAuthors();
                foreach (Bookauthor aut in listeauteurs)
                    Console.WriteLine(aut.FirstName + "\t" + aut.LastName + "\t\t" + aut.ISBN);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            }
    }
}
