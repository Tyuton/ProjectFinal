﻿using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
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
            ChannelFactory<IRepositoryService1> CanalQuery = new ChannelFactory<IRepositoryService1>("CanalQuery");
            IRepositoryService1 service2 = CanalQuery.CreateChannel();

            listRequetes = new List<QueryContract>();
            listRequetes = service2.GetAllQueryContract();

            return View(listRequetes);
        }

        public ActionResult _ListeURL(string id)
        {
            ChannelFactory<IRepositoryService1> CanalQuery = new ChannelFactory<IRepositoryService1>("CanalQuery");
            IRepositoryService1 service2 = CanalQuery.CreateChannel();

            listRequetes = new List<QueryContract>();
            listRequetes = service2.GetAllQueryContract();

            IEnumerable<PageContract> ListUrl = listRequetes.Where(q => q.Id.ToString() == id).Select(q => q.ListePages).ToList().FirstOrDefault();
            return PartialView(ListUrl);
        }


        public ActionResult _ListeSelector(string id)
        {
            ChannelFactory<IRepositoryService1> CanalQuery = new ChannelFactory<IRepositoryService1>("CanalQuery");
            IRepositoryService1 service2 = CanalQuery.CreateChannel();
            
            var listSelector = service2.GetSelectorContractById(id);
            return PartialView(listSelector);
        }


    }
}