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
            Repository repo = new Repository();

            Console.WriteLine("\t\tBienvenue sur l'application d'Amin et Jonathan" +
                              "\n\t\tVeuillez entrer une nouvelle requête");

            repo.AddNewQuery();
            
            Console.Read();
            
              

        }
    }
}
