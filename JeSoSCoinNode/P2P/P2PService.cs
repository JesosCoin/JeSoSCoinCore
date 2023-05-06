// Created by I Putu Kusuma Negara
// markbrain2013[at]gmail.com
// 
// Ubudkuscoin is free software distributed under the MIT software license,
// Redistribution and use in source and binary forms with or without
// modifications are permitted.

//In developement by Scryce Programmer - jesos.org@hotmail.com - Abr 2023
//Repository: https://github.com/JesosCoin/JeSoSCoinCore

using Grpc.Net.Client;
using JesosCoinNode.Grpc;
using JesosCoinNode.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using static JesosCoinNode.Grpc.BlockService;
using static JesosCoinNode.Grpc.PeerService;
using static JesosCoinNode.Grpc.StakeService;
using static JesosCoinNode.Grpc.TransactionService;

namespace JesosCoinNode.P2P
{
    /// <summary>
    /// This class for communicating with other peer, such as to broadcasting block,
    /// broadcasting transaction, downloading block.
    /// </summary>
    public class P2PService
    {
        public ServicePool servicePool = new ServicePool();

        public P2PService()
        {
        }

        public void Start()
        {
            //Console.WriteLine("--- P2P service is starting");
            // do some task
            Console.WriteLine("--- P2P service is ready");
        }



#pragma warning disable CS1572 // XML comment has a param tag, but there is no parameter by that name
        /// <summary>
        /// Do Braodcast a block to all peer in known peers
        /// </summary>
        /// <param name="block"></param>
        public void BroadcastBlock(Grpc.Block broadcastBlock)
#pragma warning restore CS1572 // XML comment has a param tag, but there is no parameter by that name
        {
            var knownPeers = servicePool.FacadeService.Peer.GetKnownPeers();
            var nodeAddress = servicePool.FacadeService.Peer.NodeAddress;

            Parallel.ForEach(knownPeers, peer =>
            {
                if (!nodeAddress.Equals(peer.Address))
                {
                    Console.WriteLine("--- BroadcastBlock to {0}", peer.Address);
                    GrpcChannel channel = GrpcChannel.ForAddress(peer.Address);
                    var blockService = new BlockServiceClient(channel);
                    try
                    {
                        var response = blockService.Add(broadcastBlock);
                        Console.WriteLine("--- BroadcastBlock Done ");
                    }
                    catch
                    {
                        Console.WriteLine("--- BroadcastBlock Fail ");
                    }
                }
            });
        }


        /// <summary>
        /// Do Broadcast a stake to all peer in known peers
        /// </summary>
        /// <param name="stake"></param>
        public void BroadcastStake(Stake stake)
        {
            var knownPeers = servicePool.FacadeService.Peer.GetKnownPeers();
            var nodeAddress = servicePool.FacadeService.Peer.NodeAddress;
            Parallel.ForEach(knownPeers, peer =>
            {
                if (!nodeAddress.Equals(peer.Address))
                {
                    Console.WriteLine("--- BroadcastStake to {0}", peer.Address);
                    GrpcChannel channel = GrpcChannel.ForAddress(peer.Address);
                    var stakeService = new StakeServiceClient(channel);
                    try
                    {
                        var response = stakeService.Add(stake);
                        Console.WriteLine("--- BroadcastStake Done");
                    }
                    catch
                    {
                        Console.WriteLine("--- BroadcastStake Fail");
                    }
                }
            });
        }

        /// <summary>
        /// Do broadcast a transaction to all peer in known peers
        /// </summary>
        /// <param name="tx"></param>
        public void BroadcastTransaction(Grpc.Transaction tx)
        {
            var knownPeers = servicePool.FacadeService.Peer.GetKnownPeers();
            var nodeAddress = servicePool.FacadeService.Peer.NodeAddress;
            Parallel.ForEach(knownPeers, peer =>
            {
                if (!nodeAddress.Equals(peer.Address))
                {
                    Console.WriteLine("--- BroadcastTransaction to {0}", peer.Address);
                    GrpcChannel channel = GrpcChannel.ForAddress(peer.Address);
                    var txnService = new TransactionServiceClient(channel);
                    try
                    {
                        var response = txnService.Receive(new TransactionPost
                        {
                            SendingFrom = nodeAddress,
                            Transaction = tx
                        });
                        if (response.Status == Others.Constants.TXN_STATUS_SUCCESS)
                        {
                            Console.WriteLine("--- BroadcastTransaction Done");
                        }
                        else
                        {
                            Console.WriteLine("--- BroadcastTransaction Fail");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("--- BroadcastTransaction Fail");
                    }
                }
            });
        }


        /// <summary>
        /// Sincronizing blocks from all peer in known peers
        /// </summary>
        /// <param name="blockService"></param>
        /// <param name="lastBlockHeight"></param>
        /// <param name="peerHeight"></param>
        private void DownloadBlocks(BlockServiceClient blockService, long lastBlockHeight, long peerHeight)
        {
            try
            {
                Console.WriteLine("--- Reading remaing blocks: {0}.", lastBlockHeight);

                BlockList response = blockService.GetRemains(new StartingParam { Height = lastBlockHeight });
                var blocks = response.Blocks.ToList();
                blocks.Reverse();
                long lastHeight = 0L;

                foreach (var block in blocks)
                {
                    try
                    {
                        DbService dbService = new DbService();

                        Console.WriteLine("--- Download block: {0}.", block.Height);
                        var status = dbService.BlockDb.Add(block);
                        lastHeight = block.Height;
                        Console.WriteLine("--- Download blocks Done.");
                    }
                    catch
                    {
                        Console.WriteLine("--- Download blocks Fail.");
                    }
                }

                if (lastHeight < peerHeight)
                {
                    DownloadBlocks(blockService, lastHeight, peerHeight);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("--- Download blocks Fail with error: {0}.", e.Message);
            }
        }


#pragma warning disable CS1587 // XML comment is not placed on a valid language element
        /// <summary>
        /// Checking in db if new peer already in DB
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        //private bool IsNewPeer(string address)
        //{
        //    try
        //    {
        //        var knownPeers = ServicePool.FacadeService.Peer.GetKnownPeers();
        //        foreach (var peer in knownPeers)
        //        {
        //            if (address == peer.Address)
        //            {
        //                Console.WriteLine("--- Peer Knowed: {0}.", peer.Address);
        //            }
        //            else
        //            {
        //                Console.WriteLine("--- New Peer Founded: {0}.", peer.Address);
        //                AddPeer(peer);
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("--- Error to Add Peer: {0}.", e.Message);
        //    }

        //    return false;
        //}


#pragma warning disable CS1587 // XML comment is not placed on a valid language element
        /// <summary>
        /// Adding in db if new peer already in network
        /// </summary>
        /// <param name="NewPeer"></param>
        /// <returns></returns>
        //private bool AddPeer(Peer NewPeer)
        //{
        //    try
        //    {
        //        var knownPeers = ServicePool.FacadeService.Peer.GetKnownPeers();
        //        foreach (var peer in knownPeers)
        //        {
        //            if (NewPeer.Address != peer.Address)
        //            {
        //                ServicePool.FacadeService.Peer.Add(peer);
        //                Console.WriteLine("--- Peer Added: {0}.", peer.Address);
        //                return true;
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("--- Error to Add Peer: {0}.", e.Message);
        //    }

        //    return false;
        //}


        /// <summary>
        /// Sincronize blockchain states, make block height same with other peer
        /// </summary>
        public bool SyncState()
#pragma warning restore CS1587 // XML comment is not placed on a valid language element
#pragma warning restore CS1587 // XML comment is not placed on a valid language element
        {
            var knownPeers = servicePool.FacadeService.Peer.GetKnownPeers();
            var nodeAddress = servicePool.FacadeService.Peer.NodeAddress;

            //synchronizing peer
            foreach (var peer in knownPeers)
            {
                if (!nodeAddress.Equals(peer.Address))
                {
                    Console.WriteLine("--- Sync state to {0}.", peer.Address);
                    try
                    {
                        GrpcChannel channel = GrpcChannel.ForAddress(peer.Address);
                        var peerService = new PeerServiceClient(channel);
                        var peerState = peerService.GetNodeState(new NodeParam { NodeIpAddress = nodeAddress });

                        // add peer to db
                        foreach (var newPeer in peerState.KnownPeers)
                        {
                            servicePool.FacadeService.Peer.Add(newPeer);
                            Console.WriteLine("--- Peer Added: {0}.", newPeer.Address);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("--- Fail to Sync State: {0}.", e.Message);
                    }
                }
            }

            // synchronizing blocks
            knownPeers = servicePool.FacadeService.Peer.GetKnownPeers();
            foreach (var peer in knownPeers)
            {
                if (!nodeAddress.Equals(peer.Address))
                {
                    try
                    {
                        GrpcChannel channel = GrpcChannel.ForAddress(peer.Address);
                        var peerService = new PeerServiceClient(channel);
                        var peerState = peerService.GetNodeState(new NodeParam { NodeIpAddress = nodeAddress });

                        // local block height
                        var lastBlockHeight = servicePool.DbService.BlockDb.GetLast().Height;
                        var blockService = new BlockServiceClient(channel);
                        if (lastBlockHeight < peerState.Height)
                        {
                            DownloadBlocks(blockService, lastBlockHeight, peerState.Height);
                            Console.WriteLine("--- Downloading Block: {0}.", peerState.Height);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("--- Fail to Sync Blocks: {0}.", e.Message);
                        return false;
                    }
                }
            }

            Console.WriteLine("--- Sync Done.");
            return true;
        }
    }
}