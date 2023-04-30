// Created by I Putu Kusuma Negara
// markbrain2013[at]gmail.com
// 
// UbudKusCoin is free software distributed under the MIT software license,
// Redistribution and use in source and binary forms with or without
// modifications are permitted.

//In developement by Scryce Programmer - jesos.org@hotmail.com - Abr 2023
//Repository: https://github.com/JesosCoin/JeSoSCoinCore

using JeSoSCoinNode.Grpc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JeSoSCoin
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");

            }));


        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseRouting();
            // add support grpc call from web app, Must be added between UseRouting and UseEndpoints
            app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<AccountServiceImpl>().RequireCors("AllowAll");
                endpoints.MapGrpcService<BlockServiceImpl>().RequireCors("AllowAll");
                endpoints.MapGrpcService<PeerServiceImpl>().RequireCors("AllowAll");
                endpoints.MapGrpcService<StakeServiceImpl>().RequireCors("AllowAll");
                endpoints.MapGrpcService<TransactionServiceImpl>().RequireCors("AllowAll");
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(
                        "Communication with gRPC endpoints" +
                        " must be made through a gRPC client.");
                });
            });
        }
    }
}