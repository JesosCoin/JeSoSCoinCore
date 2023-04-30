// Created by I Putu Kusuma Negara
// markbrain2013[at]gmail.com
// 
// Ubudkuscoin is free software distributed under the MIT software license,
// Redistribution and use in source and binary forms with or without
// modifications are permitted.

//In developement by Scryce Programmer - jesos.org@hotmail.com - Abr 2023
//Repository: https://github.com/JesosCoin/JeSoSCoinCore

using System;
using Grpc.Net.Client;

namespace JesosCoinNode.JesosCoinWallet
{
    class Program
    {
        static void Main()
        {
            DotNetEnv.Env.Load();
            DotNetEnv.Env.TraversePath().Load();

            //var NODE_ADDRESS = DotNetEnv.Env.GetString("NODE_ADDRESS");
            var serverAddress = "http://localhost:5002";
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            //GrpcChannel channel = GrpcChannel.ForAddress(NODE_ADDRESS);
            GrpcChannel channel = GrpcChannel.ForAddress(serverAddress);
            _ = new ConsoleAppWallet(channel);

            
        }
    }
}