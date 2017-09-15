﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF
{
    [ServiceContract]
    public interface IRepository
    {
        [OperationContract]
        string TestServer();

        [OperationContract]
        bool AddNewQuery(string name, string description, string url, string script, DateTime expiry, DateTime timestamp);

        [OperationContract]
        List<Query> getQueryByName(string name);
        [OperationContract]
        List<Query> getAllQuery();
        [OperationContract]
        void ModifyQuery(Query query);
        [OperationContract]
        void DeleteQuery(Query query);
        [OperationContract]
        bool CheckExistingQuery(Query query);
        //get results details
        [OperationContract]
        List<string> GetResults(Query query);
        [OperationContract]
        void SetResults(Query query, string scrapingResults);

    }
}