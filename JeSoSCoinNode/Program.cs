// Created by I Putu Kusuma Negara
// markbrain2013[at]gmail.com
// 
// Ubudkuscoin is free software distributed under the MIT software license,
// Redistribution and use in source and binary forms with or without
// modifications are permitted.

//In developement by Scryce Programmer - jesos.org@hotmail.com - Abr 2023
//Repository: https://github.com/JesosCoin/JeSoSCoinCore

using JeSoSCoin;
using JeSoSCoinNode.P2P;
using JeSoSCoinNode.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace JeSoSCoinNode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DotNetEnv.Env.Load();
            DotNetEnv.Env.TraversePath().Load();

            ServicePool.Add(
                new WalletService(),
                new DbService(),
                new FacadeService(),
                new MintingService(),
                new P2PService()
            );
            ServicePool.Start();

            // grpc
            IHost host = CreateHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSystemd()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options =>
                    {
                        try
                        {
                            var GRPC_PORT = DotNetEnv.Env.GetInt("GRPC_PORT");
                            Console.WriteLine("--- Opening GRPC Port {0}.", GRPC_PORT);
                            options.ListenAnyIP(GRPC_PORT, listenOptions => listenOptions.Protocols = HttpProtocols.Http2); //grpc
                            Console.WriteLine("---  GRPC Port {0} open sucessfully.", GRPC_PORT);
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine("--- GRPC Port Open Fail {0}.", e.Message);
                        }


                        try
                        {
                            var GRPC_WEB_PORT = DotNetEnv.Env.GetInt("GRPC_WEB_PORT");
                            Console.WriteLine("--- Opening GRPC Web Port {0}.", GRPC_WEB_PORT);
                            options.ListenAnyIP(GRPC_WEB_PORT, listenOptions => listenOptions.Protocols = HttpProtocols.Http1AndHttp2); //webapi
                            Console.WriteLine("---  GRPC Web Port {0} open sucessfully.", GRPC_WEB_PORT);
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine("--- GRPC Web Port Open Fail {0}.", e.Message);
                        }
                    });

                    // start
                    webBuilder.UseStartup<Startup>()
                        //   .ConfigureLogging(loggingBuilder => loggingBuilder.ClearProviders());
                        .ConfigureLogging((Action<WebHostBuilderContext, ILoggingBuilder>)((hostingContext, logging) =>
                        {
                            // logging.AddConfiguration((IConfiguration)hostingContext.Configuration.GetSection("Logging"));
                            // logging.AddConsole();
                            // logging.AddDebug();
                            // logging.AddEventSourceLogger();
                            logging.ClearProviders();
                        }));
                    //===
                });
    }
}