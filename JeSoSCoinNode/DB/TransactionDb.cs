// Created by I Putu Kusuma Negara
// markbrain2013[at]gmail.com
// 
// Ubudkuscoin is free software distributed under the MIT software license,
// Redistribution and use in source and binary forms with or without
// modifications are permitted.

//In developement by Scryce Programmer - jesos.org@hotmail.com - Abr 2023
//Repository: https://github.com/JesosCoin/JeSoSCoinCore

using JesosCoinNode.Grpc;
using JesosCoinNode.Others;
using LiteDB;
using System.Collections.Generic;

namespace JesosCoinNode.DB
{
    /// <summary>
    /// Transaction DB, for add, update transaction
    /// </summary>
    public class TransactionDb
    {
        private readonly LiteDatabase _db;

        public TransactionDb(LiteDatabase db)
        {
            _db = db;
        }

        /// <summary>
        /// Add some transaction in smae time
        /// </summary>
        public bool AddBulk(List<Transaction> transactions)
        {
            try
            {
                var collection = GetAll();

                collection.InsertBulk(transactions);

                return true;
            }
            catch
            {
                return false;
            }
        }

        
#pragma warning disable CS1587 // XML comment is not placed on a valid language element
/// <summary>
        /// Add a transaction
        /// </summary>
        //public bool Add(Transaction transaction)
        //{
        //    try
        //    {
        //        var transactions = GetAll();

        //        transactions.Insert(transaction);

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        /// <summary>
        /// Get All Transactions by Address and with paging
        /// </summary>
        public IEnumerable<Transaction> GetRangeByAddress(string address, int pageNumber, int resultsPerPage)
#pragma warning restore CS1587 // XML comment is not placed on a valid language element
        {
            var transactions = GetAll();
            if (transactions is null || transactions.Count() < 1)
            {
                return null;
            }

            transactions.EnsureIndex(x => x.Sender);
            transactions.EnsureIndex(x => x.Recipient);

            var query = transactions.Query()
                .OrderByDescending(x => x.TimeStamp)
                .Where(x => x.Sender == address || x.Recipient == address)
                .Offset((pageNumber - 1) * resultsPerPage)
                .Limit(resultsPerPage).ToList();

            return query;
        }

        /// <summary>
        /// Get Transaction by Hash
        /// </summary>
        public Transaction GetByHash(string hash)
        {
            var transactions = GetAll();
            if (transactions is null || transactions.Count() < 1)
            {
                return null;
            }

            transactions.EnsureIndex(x => x.Hash);

            return transactions.FindOne(x => x.Hash == hash);
        }

        /// <summary>
        /// Get transactions
        /// </summary>
        public IEnumerable<Transaction> GetRange(int pageNumber, int resultPerPage)
        {
            var transactions = GetAll();
            if (transactions is null || transactions.Count() < 1)
            {
                return null;
            }

            transactions.EnsureIndex(x => x.TimeStamp);

            var query = transactions.Query()
                .OrderByDescending(x => x.TimeStamp)
                .Offset((pageNumber - 1) * resultPerPage)
                .Limit(resultPerPage).ToList();

            return query;
        }

        //public IEnumerable<Transaction> GetLast(int num)
        //{
        //    var transactions = GetAll();
        //    if (transactions is null || transactions.Count() < 1)
        //    {
        //        return null;
        //    }

        //    transactions.EnsureIndex(x => x.TimeStamp);

        //    var query = transactions.Query()
        //        .OrderByDescending(x => x.TimeStamp)
        //        .Limit(num).ToList();

        //    return query;
        //}

        /// <summary>
        /// get one transaction by address
        /// </summary>
        //public Transaction GetByAddress(string address)
        //{
        //    var transactions = GetAll();
        //    if (transactions is null || transactions.Count() < 1)
        //    {
        //        return null;
        //    }

        //    transactions.EnsureIndex(x => x.TimeStamp);
        //    var transaction = transactions.FindOne(x => x.Sender == address || x.Recipient == address);
        //    return transaction;
        //}

        private ILiteCollection<Transaction> GetAll()
        {
            return _db.GetCollection<Transaction>(Constants.TBL_TRANSACTIONS);
        }
    }
}