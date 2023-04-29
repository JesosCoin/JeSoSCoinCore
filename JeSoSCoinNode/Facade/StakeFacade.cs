// Created by I Putu Kusuma Negara
// markbrain2013[at]gmail.com
// 
// Ubudkuscoin is free software distributed under the MIT software license,
// Redistribution and use in source and binary forms with or without
// modifications are permitted.

using System;
using JeSoSCoinNode.Grpc;
using JeSoSCoinNode.Services;

namespace JeSoSCoinNode.Facade
{
    public class StakeFacade
    {
        public StakeFacade()
        {
            Console.WriteLine("--- Stake innitialized.");
        }

        public Stake GetMaxStake()
        {
            return ServicePool.DbService.StakeDb.GetMax();
        }

        public void AddOrUpdate(Stake stake)
        {
            ServicePool.DbService.StakeDb.AddOrUpdate(stake);
        }
    }
}