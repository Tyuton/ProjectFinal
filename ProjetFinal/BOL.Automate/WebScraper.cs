using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.ServiceModel;
using DAL;

namespace BOL.Automate
{
    // Selenuim version
    public class WebScraperEngine
    {
        // return -1 if error
        public int ExecuteQueryAndSaveResults(string QueryName)
        {
            //TODO use lock variables/list of locks 
            InitWCF();

            using (Navigator driver = new Navigator()) //using force l'appel de Dispose()
            {
                // TODO use WCF service to get list of urls/selectors

                string url = "https://competitions.ffr.fr/";
                var selector = @"return $('table#DataTables_Table_1 tr').get().map(function(row) {
                                return $(row).find('td').get().map(function(cell) {
                                    return $(cell).html();
                                    });
                                });";

                // execute Selenium scripts
                driver.open(url);
                var result = driver.browser.ExecuteScript(selector);

                // TODO save results into repository
                //...

                return 1;                
            }

            return -1;
        }

        private void InitWCF()
        {
            // Client WCF
            ChannelFactory<IRepositoryService1> Canal2 = new ChannelFactory<IRepositoryService1>("Canal2");
            IRepositoryService1 serv2 = Canal2.CreateChannel();


            var test = serv2.getQueryDescription("Ali");
            Console.WriteLine("InitWCF: " + test);
            Console.Read();
        }
    }

    class Navigator : IDisposable
    {
        public FirefoxDriver browser = null;

        public void Dispose() // libérer les resourecs
        {
            browser.Close();
        }

        internal void InputTextAndEnter(string css, string valeur)
        {

            var zone = browser.FindElement(By.Id(css));
            zone.SendKeys(valeur);
            zone.SendKeys(Keys.Return);

        }

        internal void InputTextAndEnterJS(string css, string valeur)
        {
            string js = string.Format("document.getElementById('{0}').innerHTML ='{1}';", css, valeur);
            Console.WriteLine(js);

            var v = browser.ExecuteScript(js);

            IJavaScriptExecutor js2 = (IJavaScriptExecutor)browser;
            string title = (string)js2.ExecuteScript(js);
        }

        internal void open(string siteweb)
        {
            browser = new FirefoxDriver();
            browser.Url = siteweb;
        }
    }
}
