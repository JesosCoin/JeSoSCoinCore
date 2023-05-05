// Created by I Putu Kusuma Negara
// markbrain2013[at]gmail.com
// 
// Ubudkuscoin is free software distributed under the MIT software license,
// Redistribution and use in source and binary forms with or without
// modifications are permitted.

//In developement by Scryce Programmer - jesos.org@hotmail.com - Abr 2023
//Repository: https://github.com/JesosCoin/JeSoSCoinCore

using JesosCoinNode.DB;
using LiteDB;
using System;

namespace JesosCoinNode.Services
{
    public class DbService
    {
        private readonly LiteDatabase DB_BLOCK;
        private readonly LiteDatabase DB_ACCOUNT;
        private readonly LiteDatabase DB_TRANSACTION;
        private readonly LiteDatabase DB_TRANSACTION_POOL;
        private readonly LiteDatabase DB_PEER;
        private readonly LiteDatabase DB_STAKE;

        public BlockDb BlockDb { get; set; }
        public TransactionDb TransactionDb { get; set; }
        public PeerDb PeerDb { get; set; }
        public AccountDb AccountDb { get; set; }
        public PoolTransactionsDb PoolTransactionsDb { get; set; }
        public StakeDb StakeDb { get; set; }



        public DbService()
        {
            try
            {
                if (!System.IO.Directory.Exists(@"DbFiles"))
                    System.IO.Directory.CreateDirectory(@"DbFiles");

                DB_BLOCK = InitializeDatabase(@"DbFiles//block.db");
                DB_ACCOUNT = InitializeDatabase(@"DbFiles//account.db");
                DB_TRANSACTION = InitializeDatabase(@"DbFiles//transaction.db");
                DB_TRANSACTION_POOL = InitializeDatabase(@"DbFiles//transaction_pool.db");
                DB_STAKE = InitializeDatabase(@"DbFiles//stake.db");
                DB_PEER = InitializeDatabase(@"DbFiles//peer.db");
            }
            catch (Exception e)
            {
                Console.WriteLine("--- Fail to initialize DB Service with error: {0}.", e.Message);
            }
        }

        public LiteDatabase InitializeDatabase(string path)
        {
            return new LiteDatabase(path);
        }

        public void Start()
        {
            try
            {
                Console.WriteLine("--- DB Service is starting.");
                BlockDb = new BlockDb(DB_BLOCK);
                AccountDb = new AccountDb(DB_ACCOUNT);
                TransactionDb = new TransactionDb(DB_ACCOUNT);
                PoolTransactionsDb = new PoolTransactionsDb(DB_TRANSACTION_POOL);
                StakeDb = new StakeDb(DB_STAKE);
                PeerDb = new PeerDb(DB_PEER);
                Console.WriteLine("--- DB Service is ready.");
            }
            catch (Exception e)
            {
                Console.WriteLine("--- DB Service fail to start with error: {0}.", e.Message);
            }
        }

        //public void Stop()
        //{
        //    try
        //    {
        //        Console.WriteLine("--- DB Service is stopping.");
        //        DB_BLOCK.Dispose();
        //        DB_STAKE.Dispose();
        //        DB_TRANSACTION.Dispose();
        //        DB_TRANSACTION_POOL.Dispose();
        //        DB_PEER.Dispose();
        //        DB_ACCOUNT.Dispose();
        //        Console.WriteLine("--- DB Service has been disposed.");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("--- DB Service fail to stop with error: {0}.", e.Message);
        //    }
        //}
    }
}