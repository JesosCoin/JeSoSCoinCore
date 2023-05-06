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
using System.Threading.Tasks;

namespace JesosCoinNode.Grpc
{
    public class PeerServiceImpl : PeerService.PeerServiceBase
    {
        public override Task<AddPeerReply> Add(Peer request, ServerCallContext context)
        {
            var response = new AddPeerReply();
            return Task.FromResult(response);
        }

        public override Task<NodeState> GetNodeState(NodeParam request, ServerCallContext context)
        {
            ServicePool.FacadeService.Peer.Add(new Peer
            {
                Address = request.NodeIpAddress,
                IsBootstrap = false,
                IsCanreach = true,
                LastReach = JscUtils.GetTime(),
                TimeStamp = JscUtils.GetTime()
            });

            var nodeState = ServicePool.FacadeService.Peer.GetNodeState();
            return Task.FromResult(nodeState);
        }
    }
}