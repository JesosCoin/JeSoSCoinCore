// Created by I Putu Kusuma Negara
// markbrain2013[at]gmail.com
// 
// Ubudkuscoin is free software distributed under the MIT software license,
// Redistribution and use in source and binary forms with or without
// modifications are permitted.

//In developement by Scryce Programmer - jesos.org@hotmail.com - Abr 2023
//Repository: https://github.com/JesosCoin/JeSoSCoinCore

using System;
using JeSoSCoinNode.Grpc;
using JeSoSCoinNode.Services;

namespace JeSoSCoinNode.Facade
{
    public class TransactionPoolFacade
    {
        public TransactionPoolFacade()
        {
            Console.WriteLine("--- Transaction pool innitialized.");
        }

        //public bool TransactionExists(Transaction txn)
        //{
        //    var transaction = ServicePool.DbService.PoolTransactionsDb.GetByHash(txn.Hash);
        //    if (transaction is null)
        //    {
        //        return false;
        //    }

        //    return false;
        //}
    }
}