// Created by I Putu Kusuma Negara
// markbrain2013[at]gmail.com
// 
// Ubudkuscoin is free software distributed under the MIT software license,
// Redistribution and use in source and binary forms with or without
// modifications are permitted.

//In developement by Scryce Programmer - jesos.org@hotmail.com - Abr 2023
//Repository: https://github.com/JesosCoin/JeSoSCoinCore

using Grpc.Core;
using JesosCoinNode.Others;
using JesosCoinNode.Services;
using NBitcoin;
using System;
using System.Text;
using System.Threading.Tasks;

namespace JesosCoinNode.Grpc
{
    public class TransactionServiceImpl : TransactionService.TransactionServiceBase
    {
        public override Task<Transaction> GetByHash(Transaction req, ServerCallContext context)
        {
            var transaction = ServicePool.DbService.TransactionDb.GetByHash(req.Hash);
            return Task.FromResult(transaction);
        }

        public override Task<TransactionList> GetRangeByAddress(TransactionPaging req, ServerCallContext context)
        {
            var transactions = ServicePool.DbService.TransactionDb.GetRangeByAddress(req.Address, req.PageNumber, req.ResultPerPage);
            var response = new TransactionList();
            response.Transactions.AddRange(transactions);
            return Task.FromResult(response);
        }

        public override Task<TransactionList> GetRange(TransactionPaging req, ServerCallContext context)
        {
            var response = new TransactionList();
            var transactions = ServicePool.DbService.TransactionDb.GetRange(req.PageNumber, req.ResultPerPage);
            response.Transactions.AddRange(transactions);
            return Task.FromResult(response);
        }

        public override Task<TransactionList> GetPoolRange(TransactionPaging req, ServerCallContext context)
        {
            var response = new TransactionList();
            var transactions = ServicePool.DbService.TransactionDb.GetRange(req.PageNumber, req.ResultPerPage);
            response.Transactions.AddRange(transactions);
            return Task.FromResult(response);
        }

        public static bool VerifySignature(Transaction txn)
        {
            var pubKey = new PubKey(txn.PubKey);
            //Jesos
            byte[] Signaturebytes = Encoding.ASCII.GetBytes(txn.Signature);
            return pubKey.Verify(uint256.Parse(txn.Hash), Signaturebytes);
        }

        public override Task<TransactionStatus> Receive(TransactionPost req, ServerCallContext context)
        {
            Console.WriteLine("-- Received TXH with hash: {0}, amount {1}", req.Transaction.Hash, req.Transaction.Amount);

            var transactionHash = JscUtils.GetTransactionHash(req.Transaction);
            if (!transactionHash.Equals(req.Transaction.Hash))
            {
                return Task.FromResult(new TransactionStatus
                {
                    Status = Others.Constants.TXN_STATUS_FAIL,
                    Message = "Invalid Transaction Hash"
                });
            }

            var isSignatureValid = VerifySignature(req.Transaction);
            if (!isSignatureValid)
            {
                return Task.FromResult(new TransactionStatus
                {
                    Status = Others.Constants.TXN_STATUS_FAIL,
                    Message = "Invalid Signature"
                });
            }

            //TODO add more validation here

            ServicePool.DbService.PoolTransactionsDb.Add(req.Transaction);
            return Task.FromResult(new TransactionStatus
            {
                Status = Others.Constants.TXN_STATUS_SUCCESS,
                Message = "Transaction received successfully!"
            });
        }

        public override Task<TransactionStatus> Transfer(TransactionPost req, ServerCallContext context)
        {
            Console.WriteLine("=== Req: {0}", req);

            // Validating hash
            var calculateHash = JscUtils.GetTransactionHash(req.Transaction);
            if (!calculateHash.Equals(req.Transaction.Hash))
            {
                return Task.FromResult(new TransactionStatus
                {
                    Status = Others.Constants.TXN_STATUS_FAIL,
                    Message = "Invalid Transaction Hash"
                });
            }

            Console.WriteLine("=== CalculateHash: {0}", calculateHash);

            // validating signature
            var isSignatureValid = VerifySignature(req.Transaction);
            if (!isSignatureValid)
            {
                return Task.FromResult(new TransactionStatus
                {
                    Status = Others.Constants.TXN_STATUS_FAIL,
                    Message = "Invalid Signature"
                });
            }

            Console.WriteLine("=== isSignatureValid: {0}", isSignatureValid);

            // Check if the transaction is in the pool already
            var txinPool = ServicePool.DbService.PoolTransactionsDb.GetByHash(req.Transaction.Hash);
            if (txinPool != null)
            {
                return Task.FromResult(new TransactionStatus
                {
                    Status = Others.Constants.TXN_STATUS_FAIL,
                    Message = "Double transaction!"
                });
            }

            ServicePool.DbService.PoolTransactionsDb.Add(req.Transaction);

            // broadcast transaction to all peer including myself.
            Task.Run(() => ServicePool.P2PService.BroadcastTransaction(req.Transaction));

            // Response transaction success
            return Task.FromResult(new TransactionStatus
            {
                Status = Others.Constants.TXN_STATUS_SUCCESS,
                Message = "Transaction completed!"
            });
        }
    }
}