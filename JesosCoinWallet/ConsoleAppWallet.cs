// Created by I Putu Kusuma Negara
// markbrain2013[at]gmail.com
// 
// Ubudkuscoin is free software distributed under the MIT software license,
// Redistribution and use in source and binary forms with or without
// modifications are permitted.

//In developement by Scryce Programmer - jesos.org@hotmail.com - Abr 2023
//Repository: https://github.com/JesosCoin/JeSoSCoinCore

using Grpc.Net.Client;
using System;
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

        private Wallet _accountExt;

        public ConsoleAppWallet(GrpcChannel channel)
        {
            _accountService = new AccountServiceClient(channel);
            _blockService = new BlockServiceClient(channel);
            _transactionService = new TransactionServiceClient(channel);

            _accountService = new AccountServiceClient(channel);
            _blockService = new BlockServiceClient(channel);
            _transactionService = new TransactionServiceClient(channel);

            MenuItem();
            GetInput();
        }

        public void MenuItem()
        {
            if (_accountExt == null)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n");
                Console.WriteLine("                    Jesos Coin Client ");
                Console.WriteLine("============================================================");
                Console.WriteLine("  Client not connected to Node.");
                Console.WriteLine("============================================================");
                Console.WriteLine("  Address: {0}", _accountExt.GetAddress());
                Console.WriteLine("============================================================");
                Console.WriteLine("                    1. Create Account");
                Console.WriteLine("                    2. Restore Account");
                Console.WriteLine("                    3. Send Coin");
                Console.WriteLine("                    4. Check Balance");
                Console.WriteLine("                    5. Transaction History");
                Console.WriteLine("                    6. Account Info");
                Console.WriteLine("                    7. Send Bulk Tx");
                Console.WriteLine("                    8. First Block");
                Console.WriteLine("                    9. Last Block");
                Console.WriteLine("                    10. Show Last Block");
                Console.WriteLine("                    11. Show All Block");
                Console.WriteLine("                    12. Exit");
                Console.WriteLine("------------------------------------------------------------");
            }
        }


        public void GetInput()
        {
            strKey = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(strKey))
            {
                if (strKey.Length <= 3)
                {
                    if (int.TryParse(strKey, out int intSelection))
                    {
                        intSelection = int.Parse(strKey);

                        while (intSelection <= 12)
                        {
                            switch (intSelection)
                            {
                                case 1:
                                    DoCreateAccount(); //
                                    break;
                                case 2:
                                    DoRestore();
                                    break;
                                case 3:
                                    DoSendCoin();
                                    break;
                                case 4:
                                    DoGetBalance();
                                    break;
                                case 5:
                                    DoGetTransactionHistory();
                                    break;
                                case 6:
                                    DoShowAccountInfo();
                                    break;
                                case 7:
                                    DoSendBulkTx();
                                    break;
                                case 8:
                                    ShowFirstBlock();
                                    break;
                                case 9:
                                    ShowLastBlock();
                                    break;
                                case 11:
                                    ShowAllBlocks();
                                    break;
                                case 12:
                                    Exit();
                                    break;
                            }

                            if (intSelection != 0)
                            {
                                Console.WriteLine("\n===== Press enter to continue! =====");
                                if (!string.IsNullOrWhiteSpace(strKey))
                                {
                                    MenuItem();
                                }
                            }

                            Console.WriteLine("\n**** Please select a menu item!!! *****");
                            MenuItem();
                            GetInput();

                            if (intSelection != 0)
                            {
                                Console.WriteLine("\n===== Press enter to continue! =====");
                                string strKey = Console.ReadLine();
                                if (strKey != null)
                                {
                                    MenuItem();
                                }
                            }

                            Console.WriteLine("\n**** Please select menu!!! *****");

                            intSelection = 0;
                            GetInput();
                            MenuItem();
                        }
                    }
                    else
                    {
                        Console.WriteLine("                    Wrong menu item.");
                        MenuItem();
                        GetInput();
                    }
                }
                else
                {
                    Console.WriteLine("                    Wrong menu item.");
                    MenuItem();
                    GetInput();
                }
            }
            else
            {
                Console.WriteLine("                    Wrong menu item.");
                MenuItem();
                GetInput();
            }

        }

        public bool Exit()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n\nApplication closed!\n");
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

    }
}