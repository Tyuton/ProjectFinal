using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("\t\tBienvenue sur l'application d'Amin et Jonathan" +
            //                  "\n\t\tVeuillez entrer une nouvelle requête");

            Repository repo = new Repository();

            repo.AddNewQuery("Ali",// query name
                "Ali's query", //description
                "www.ffr.fr", // url
                "<script>", //selector script
                new DateTime(2017,9,29), // expire les 29/9/2017
                new DateTime(0,0,1) // répéter chaque 1 jour
                );

            var queries = repo.getQueryByName("Ali");

            // Exécution : "simulation du scraping" 
            
            repo.SetResults(queries[0],"scraping results");

            var v = repo.GetResults(queries[0]);
            //Console.Read();

            foreach (var item in v)
            {
                Console.WriteLine("result. {0}", item);
            }
              

        }
    }
}
