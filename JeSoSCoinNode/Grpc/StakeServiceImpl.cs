// Created by I Putu Kusuma Negara
// markbrain2013[at]gmail.com
// 
// Ubudkuscoin is free software distributed under the MIT software license,
// Redistribution and use in source and binary forms with or without
// modifications are permitted.

//In developement by Scryce Programmer - jesos.org@hotmail.com - Abr 2023
//Repository: https://github.com/JesosCoin/JeSoSCoinCore

using Grpc.Core;
using JesosCoinNode.Services;
using System.Threading.Tasks;

namespace JesosCoinNode.Grpc
{
    public class StakeServiceImpl : StakeService.StakeServiceBase
    {
        public override Task<AddStakeStatus> Add(Stake req, ServerCallContext context)
        {
            ServicePool.DbService.StakeDb.AddOrUpdate(req);
            return Task.FromResult(new AddStakeStatus
            {
                Message = "Stake successfully added",
                Status = Others.Constants.TXN_STATUS_SUCCESS,
            });
        }

        public override Task<StakeList> GetRange(StakeParams req, ServerCallContext context)
        {
            var response = new StakeList();
            var stakes = ServicePool.DbService.StakeDb.GetAll();
            response.Stakes.AddRange(stakes.FindAll());
            return Task.FromResult(response);
        }
    }
}