﻿using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using WebScraper.WCF;

namespace BOL.Automate
{
    // Selenuim version
    public class WebScraperEngine
    {
        private static QueryContract GetQueryContractByNameFake()
        {
            var q = new QueryContract()
            {
                Name = "Arbitres",
                Description = "FFR Arbitres",
                Id = Guid.NewGuid(),
                DataExpiryDate = DateTime.Now,
                DataTimeStamp = DateTime.Now,
            };
            PageContract p = null;
            var pl = q.ListePages = new System.Collections.Generic.List<PageContract>() {
                (p = new PageContract() {
                    URL = "https://competitions.ffr.fr/",
                    Id=Guid.NewGuid(),
                    //Query=q // pb de cycle
                })
            };
            var s = p.ListeSelectors = new System.Collections.Generic.List<SelectorContract>() {
                new SelectorContract()
                {
                    Value=@"window.resizeTo(300,500);",
                    Id=Guid.NewGuid(),
                },
                new SelectorContract()
                {
                    Value = @"return $('table#DataTables_Table_1 tr').get().map(function(row) {
                                return $(row).find('td').get().map(function(cell) {
                                    return $(cell).html();
                                    });
                                });",
                                Id= Guid.NewGuid(),
                                //Page=p //pb de cycle
                },
            };
            return q;
        }
        // return -1 if error
        public static int ExecuteQueryAndSaveResults(string QueryName)
        {
            //TODO use lock variables/list of locks 
            // Client WCF
            ChannelFactory<IRepositoryService1> Canal2 = new ChannelFactory<IRepositoryService1>("Canal2");
            IRepositoryService1 service2 = Canal2.CreateChannel();
            QueryContract qc = GetQueryContractByNameFake(); // service2.GetQueryContractByName(QueryName);

            ResultsHeaderContract RHC = null;
            List<ResultsDetailContract> ListRDC = new List<ResultsDetailContract>();
            ReadOnlyCollection<Object> seleniumResult = null;

            using (Navigator driver = new Navigator()) //using force l'appel de Dispose()
            {
                // use WCF service to get list of urls/selectors

                //string url = "https://competitions.ffr.fr/";
                //var selector = @"return $('table#DataTables_Table_1 tr').get().map(function(row) {
                //                return $(row).find('td').get().map(function(cell) {
                //                    return $(cell).html();
                //                    });
                //                });";
                if (qc.ListePages != null)
                    foreach (PageContract pc in qc.ListePages)
                    {
                        if (pc.ListeSelectors != null)
                            foreach (SelectorContract sc in pc.ListeSelectors)
                            {
                                var url = pc.URL;
                                var selector = sc.Value;
                                // execute Selenium scripts
                                driver.open(url);
                                seleniumResult = (ReadOnlyCollection<Object>)driver.browser.ExecuteScript(selector);
                                //Close driver!
                                driver.browser.Close();
                                // init Results Contract objects
                                RHC = new ResultsHeaderContract(sc);
                                // TODO save results into repository (update 22/09/2017)
                                string[] tempKEYS = new string[] { "Date", "Heure", "Compétition", "Phase", "Club local", "Club visiteur", "Score" };//TODO autofill tempKEYS
                                int rowIndex = 0;
                                if (seleniumResult != null)
                                    foreach (ReadOnlyCollection<Object> item in seleniumResult)
                                    {
                                        if (item != null && item.Count > 0
                                            && rowIndex <= 100 ) // TODELETE
                                        {
                                            for (int i = 0; i < item.Count; i++)
                                            {
                                                ListRDC.Add(new ResultsDetailContract()
                                                {
                                                    CLEF = tempKEYS[i] + "_" + rowIndex,
                                                    Id = Guid.NewGuid(),
                                                    Value = item[i].ToString(),//TODO all values are string
                                                    ResultsHeader = RHC
                                                });
                                            }
                                            rowIndex++;
                                        }
                                    }
                            }

                    }

                int n = service2.SaveResults(RHC, ListRDC);
                

                return 1;
            }

            return -1;
        }

        //private void InitWCF()
        static int Main(string[] args)
        {
            // Client WCF
            ChannelFactory<IRepositoryService1> Canal2 = new ChannelFactory<IRepositoryService1>("Canal2");
            IRepositoryService1 serv2 = Canal2.CreateChannel();

            var q = GetQueryContractByNameFake();
            //serv2.AddNewQuery(q);

            serv2.DeleteQuery(q);

            var i = ExecuteQueryAndSaveResults("Arbitres");
            Console.WriteLine("ExecuteQueryAndSaveResults...");
            Console.Read();
            return -1;



            //var test = serv2.getQueryDescription("Ali");
            q = new QueryContract() { Name = "SuperTest", Description = "ça marche :')" };
            q.Name = "Arbitres";
            q.Description = "FFR Arbitres";
            var p = q.ListePages = new System.Collections.Generic.List<PageContract>() {
                new PageContract() { URL = "https://competitions.ffr.fr/" }
            };
            var s = p[0].ListeSelectors = new System.Collections.Generic.List<SelectorContract>() {
                new SelectorContract() { Value="alert('choucroute');" }
            };


            //s[0].Value = "alert('Couscous2');";


            //var x = serv2.getQueryDescription("SuperTest");
            //var b = serv2.AddNewQuery(q);
            serv2.AddNewQuery(q);
            var x = serv2.getQueryDescription("SuperTest");
            Console.WriteLine(x);

            Console.WriteLine("InitWCF: ");
            Console.Read();

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
