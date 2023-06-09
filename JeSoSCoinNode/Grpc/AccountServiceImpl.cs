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
    public class AccountServiceImpl : AccountService.AccountServiceBase
    {
        public override Task<AccountList> GetRange(AccountParams request, ServerCallContext context)
        {
            var accounts = ServicePool.DbService.AccountDb.GetRange(request.PageNumber, request.ResultPerPage);
            var response = new AccountList();
            response.Accounts.AddRange(accounts);
            return Task.FromResult(response);
        }

        public override Task<Account> GetByAddress(Account request, ServerCallContext context)
        {
            var account = ServicePool.DbService.AccountDb.GetByAddress(request.Address);
            return Task.FromResult(account);
        }

        public override Task<Account> GetByPubKey(Account request, ServerCallContext context)
        {
            var account = ServicePool.DbService.AccountDb.GetByPubKey(request.PubKey);
            return Task.FromResult(account);
        }
    }
}