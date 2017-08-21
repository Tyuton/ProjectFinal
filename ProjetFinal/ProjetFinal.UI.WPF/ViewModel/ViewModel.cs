using ProjetFinal.UI.WPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal.UI.WPF.ViewModel
{
    class ViewModelQueries : INotifyPropertyChanged
    {
        private Repository repo = null;

        public List<Query> listQueries
        {
            get
            {
                return repo.getAllQuery();
            }
            set { }
        }

        private List<URL> listurl = null;
        public List<URL> listURL
        {
            get { return listurl; }
            set
            {
                listurl = value;
                RaisePropertyChanged("listURL"); //SelectedItem.urls
            }
        }

        public ViewModelQueries()
        {
            repo = new Repository();
            listQueries = repo.getAllQuery();
            if (listQueries != null)
                listURL = listQueries[0].urls;
        }


        //INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));                
            }
        }

    }

    class ViewModelAddNewQueries 
    {
        private Query newQuery = new Query();
        private List<URL> listurl = null;
        public List<URL> listURL
        {
            get { return listurl; }
            set
            {
                listurl = value;
                
            }
        }

        internal void AddToListSelector(URL selectedURL, string newScript)
        {
            Selector newSelector = new Selector() { script = newScript };
            selectedURL.selectors.Add(new Selector() { script = "TODO <scripe>" });
            selectedURL.selectors.Add(newSelector);
        }
                
        public void AddToListURL(string newurl)
        {
            URL newUrl = new URL() { url = newurl };            
            newQuery.urls.Add(newUrl);
        }
        public ViewModelAddNewQueries()
        {            
            listURL = newQuery.urls;
        }





    }

}
