using ProjetFinal.UI.WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal.UI.WPF.ViewModel
{
    class ViewModelQueries
    {
        private Repository repo = new Repository();

        public List<Query> listQueries { get; set; }

        public ViewModelQueries()
        {
            listQueries = repo.getAllQuery();
        }
    }
    
    
}
