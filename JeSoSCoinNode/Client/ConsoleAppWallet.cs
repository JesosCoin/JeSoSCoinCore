// Created by I Putu Kusuma Negara
// markbrain2013[at]gmail.com
// 
// Ubudkuscoin is free software distributed under the MIT software license,
// Redistribution and use in source and binary forms with or without
// modifications are permitted.

//In developement by Scryce Programmer - jesos.org@hotmail.com - Abr 2023
//Repository: https://github.com/JesosCoin/JeSoSCoinCore

using Grpc.Net.Client;
using static JesosCoinNode.Grpc.AccountService;
using static JesosCoinNode.Grpc.BlockService;
using static JesosCoinNode.Grpc.TransactionService;

namespace JesosCoinNode.JesosCoinWallet
{
    public class ConsoleAppWallet
    {
        public readonly AccountServiceClient _accountService;
        public readonly BlockServiceClient _blockService;
        public readonly TransactionServiceClient _transactionService;

        public string strKey = string.Empty;
        public int intSelection = 0;

        //private Wallet _accountExt;

        public ConsoleAppWallet(GrpcChannel channel)
        {
            _accountService = new AccountServiceClient(channel);
            _blockService = new BlockServiceClient(channel);
            _transactionService = new TransactionServiceClient(channel);

            _accountService = new AccountServiceClient(channel);
            _blockService = new BlockServiceClient(channel);
            _transactionService = new TransactionServiceClient(channel);

            //.ConsoleTerminalUser.MenuItem();
            //GetInput();
        }



    }
}