using BOL;
using BOL.Automate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using WebScraper.WCF;

namespace UIL.Controllers
{
    public class addNewQueryController : Controller
    {
        List<QueryContract> listRequetes = null;

        // GET: addNewQuery
        [HttpGet]
        public ActionResult manageQueries()
        {
            //TODO use lock variables/list of locks 
            // Client WCF
            ChannelFactory<IRepositoryService1> CanalQuery = new ChannelFactory<IRepositoryService1>("Canal2");
            IRepositoryService1 service2 = CanalQuery.CreateChannel();

            listRequetes = new List<QueryContract>();
            listRequetes = service2.GetAllQueryContract();
            
                return View(listRequetes);
        }

        public ActionResult _ListeURL(string id)
        {
            ChannelFactory<IRepositoryService1> CanalQuery = new ChannelFactory<IRepositoryService1>("Canal2");
            IRepositoryService1 service2 = CanalQuery.CreateChannel();

            listRequetes = new List<QueryContract>();
            listRequetes = service2.GetAllQueryContract();

            IEnumerable<PageContract> ListUrl = listRequetes.Where(q => q.Id.ToString() == id).Select(q => q.ListePages).ToList().FirstOrDefault();

            if (ListUrl == null)
                return Content("Pas d'url");
            else
                return PartialView(ListUrl);
        }


        public ActionResult _ListeSelector(string id)
        {
            ChannelFactory<IRepositoryService1> CanalQuery = new ChannelFactory<IRepositoryService1>("Canal2");
            IRepositoryService1 service2 = CanalQuery.CreateChannel();

            
            var listSelector = service2.GetSelectorContractById(id);
            //if (listRequetes == null)
            //    return Content("Pas de selecteurs");
            //else
                return PartialView(listSelector);
            
            
        }

        public ActionResult _DisplayData(SelectorContract selector)
        {
            ChannelFactory<IRepositoryService1> CanalQuery = new ChannelFactory<IRepositoryService1>("Canal2");
            IRepositoryService1 service2 = CanalQuery.CreateChannel();

            var listResult = service2.GetSelectorResultsDetails(selector);
            if (listResult == null)
                return Content("Pas de résultats");
            else
                return PartialView(listResult);

        }

        public ActionResult ExectuteQuery(QueryContract query)
        {
            //Method Static

            int i = WebScraperEngine.ExecuteQueryAndSaveResultsById(query.Id.ToString());

            if (i == -1)
            {
                return Content("Erreur : la commande d'exécution a échouée !");
            }
            else
            {
                return Content("Félicitations : la commande d'exécution a réussi !");

            }

        }

        public ActionResult SaveNewQuery(QueryContract query)
        {
            ChannelFactory<IRepositoryService1> CanalQuery = new ChannelFactory<IRepositoryService1>("Canal2");
            IRepositoryService1 service2 = CanalQuery.CreateChannel();

            return Content("Pas encore implémenté");

            //query.Id = 

            //service2.AddNewQuery()
        }

    }
}