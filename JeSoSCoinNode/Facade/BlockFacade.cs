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
using JesosCoinNode.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace JesosCoinNode.Facade
{
    public class BlockFacade
    {
        //minter will selected by random
        private readonly Random rnd;

        public ServicePool servicePool = new ServicePool();

        public BlockFacade()
        {
            rnd = new Random();

            Initialize();
            Console.WriteLine("--- Block innitialized.");
        }

        private void Initialize()
        {
            var blocks = servicePool.DbService.BlockDb.GetAll();
            if (blocks.Count() < 1)
            {
                // create genesis block
                CreateGenesis();
            }
        }

        /// <summary>
        /// Create genesis block, the first block in blockchain
        /// </summary>
        public void CreateGenesis()
        {
            var startTimer = DateTime.UtcNow.Millisecond;

            //Assume Genesis will start on 2022
            var genesisTicks = new DateTime(2022, 5, 29).Ticks;
            long epochTicks = new DateTime(1970, 1, 1).Ticks;
            long timeStamp = (genesisTicks - epochTicks) / TimeSpan.TicksPerSecond;

            // for genesis bloc we set creator with first of Genesis Account
            //var genesisAccounts = servicePool.FacadeService.Account.GetGenesis();
            var nodeAccountAddresss = servicePool.WalletService.GetAddress();

            // crate genesis transaction
            var genesisTransactions = servicePool.FacadeService.Transaction.CreateGenesis();
            var block = new Block
            {
                Height = 1,
                TimeStamp = timeStamp,
                PrevHash = "-",
                Transactions = JsonSerializer.Serialize(genesisTransactions),
                Validator = nodeAccountAddresss,
                Version = 1,
                NumOfTx = genesisTransactions.Count,
                TotalAmount = JscUtils.GetTotalAmount(genesisTransactions),
                TotalReward = JscUtils.GetTotalFees(genesisTransactions),
                MerkleRoot = CreateMerkleRoot(genesisTransactions),
                ValidatorBalance = 0,
                Difficulty = 1,
                Nonce = 1
            };

            var blockHash = GetBlockHash(block);
            block.Hash = blockHash;
            block.Signature = servicePool.WalletService.Sign(blockHash);

            //block size
            block.Size = JsonSerializer.Serialize(block).Length;

            // get build time    
            var endTimer = DateTime.UtcNow.Millisecond;
            block.BuildTime = endTimer - startTimer;

            // update accoiunt table
            servicePool.FacadeService.Account.UpdateBalanceGenesis(genesisTransactions);

            // add genesis block to blockchain
            servicePool.DbService.BlockDb.Add(block);
        }

        /// <summary>
        /// Create new Block
        /// </summary>
        public void New(Stake stake)
        {
            var startTimer = DateTime.UtcNow.Millisecond;

            // get transaction from pool
            var poolTransactions = servicePool.DbService.PoolTransactionsDb.GetAll();
            var wallet = servicePool.WalletService;

            // get last block before sleep
            var lastBlock = servicePool.DbService.BlockDb.GetLast();
            var nextHeight = lastBlock.Height + 1;
            var prevHash = lastBlock.Hash;

            // var validator = ServicePool.FacadeService.Stake.GetValidator();
            var transactions = servicePool.FacadeService.Transaction.GetForMinting(nextHeight);
            var minterAddress = stake.Address;
            var minterBalance = stake.Amount;
            var timestamp = JscUtils.GetTime();

            var block = new Block
            {
                Height = nextHeight,
                TimeStamp = timestamp,
                PrevHash = prevHash,
                Transactions = JsonSerializer.Serialize(transactions),
                Difficulty = 1, //GetDifficullty(),
                Validator = minterAddress,
                Version = 1,
                NumOfTx = transactions.Count,
                TotalAmount = JscUtils.GetTotalAmount(transactions),
                TotalReward = JscUtils.GetTotalFees(transactions),
                MerkleRoot = CreateMerkleRoot(transactions),
                ValidatorBalance = minterBalance,
                Nonce = rnd.Next(100000),
            };

            var blockHash = GetBlockHash(block);
            block.Hash = blockHash;
            block.Signature = servicePool.WalletService.Sign(blockHash);

            //PrintBlock(block);

            //block size
            block.Size = JsonSerializer.Serialize(block).Length;

            // get build time    
            var endTimer = DateTime.UtcNow.Millisecond;
            block.BuildTime = (endTimer - startTimer);

            servicePool.FacadeService.Account.UpdateBalance(transactions);

            // move pool to to transactions db
            servicePool.FacadeService.Transaction.AddBulk(transactions);

            // clear mempool
            servicePool.DbService.PoolTransactionsDb.DeleteAll();

            //add block to db
            servicePool.DbService.BlockDb.Add(block);

            // broadcast block          
            Task.Run(() => servicePool.P2PService.BroadcastBlock(block));
        }

        public string GetBlockHash(Block block)
        {
            var strSum = block.Version + block.PrevHash + block.MerkleRoot + block.TimeStamp + block.Difficulty + block.Validator;
            return JscUtils.GenHash(strSum);
        }

        private string CreateMerkleRoot(List<Transaction> txns)
        {
            return JscUtils.CreateMerkleRoot(txns.Select(tx => tx.Hash).ToArray());
        }


#pragma warning disable CS1587 // XML comment is not placed on a valid language element
        /// <summary>
        /// When receive a block from peer, validate it before insert to DB
        /// </summary>
        //public bool IsValidBlock(Block block)
        //{
        //    var lastBlock = ServicePool.DbService.BlockDb.GetLast();

        //    //compare block height with prev
        //    if (block.Height != (lastBlock.Height + 1))
        //    {
        //        return false;
        //    }

        //    //compare block hash with prev block hash
        //    if (block.PrevHash != lastBlock.Hash)
        //    {
        //        return false;
        //    }

        //    //validate hash
        //    if (block.Hash != GetBlockHash(block))
        //    {
        //        return false;
        //    }

        //    //compare timestamp
        //    if (block.TimeStamp <= lastBlock.TimeStamp)
        //    {
        //        return false;
        //    }

        //    return true;
        //}
    }
#pragma warning restore CS1587 // XML comment is not placed on a valid language element
}