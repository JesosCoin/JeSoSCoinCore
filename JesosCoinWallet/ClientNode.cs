using Grpc.Net.Client;
using JesosCoinNode.Grpc;
using JesosCoinNode.JesosCoinWallet;
using JesosCoinNode.Others;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using static JesosCoinNode.Grpc.AccountService;
using static JesosCoinNode.Grpc.BlockService;
using static JesosCoinNode.Grpc.TransactionService;

namespace JesosCoinWallet.ClientNode
{
    public class ClientNode
    {
        public static AccountServiceClient _accountService;
        public static BlockServiceClient _blockService;
        public static TransactionServiceClient _transactionService;

        public string strKey = string.Empty;
        public int intSelection = 0;

        public static Wallet _accountExt = new Wallet();

        public JscUtils jscUtils = new JscUtils();


        public ClientNode(GrpcChannel channel)
        {
            _accountService = new AccountServiceClient(channel);
            _blockService = new BlockServiceClient(channel);
            _transactionService = new TransactionServiceClient(channel);

            //_accountService = new BAccountServiceClient(channel);
            //_blockService = new BlockServiceClient(channel);
            //_transactionService = new TransactionServiceClient(channel);
        }

        public static bool DoSendBulkTx()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\nTransfer Coin");
                Console.WriteLine("Time: {0}", DateTime.Now);
                Console.WriteLine("======================");

                Console.WriteLine("Sender address:");
                string sender = _accountExt.GetAddress();
                Console.WriteLine(sender);

                Console.WriteLine("\nPlease enter the recipient address!:");
                string recipient = Console.ReadLine();

                Console.WriteLine("\nPlease enter the number of Tx!:");
                string strNumOfTx = Console.ReadLine();

                double amount = 0.0001d;
                float fee = 0.0001f;

                if (string.IsNullOrEmpty(sender) ||
                    string.IsNullOrEmpty(strNumOfTx) ||
                    string.IsNullOrEmpty(recipient))
                {
                    Console.WriteLine("\n\nError, Please input all data: sender, recipient, amount and fee!\n");
                    return false;
                }

                var response = _accountService.GetByAddress(new Account());
                var senderBalance = response.Balance;
                var numOfTx = int.Parse(strNumOfTx);

                if ((numOfTx * amount + fee) > senderBalance)
                {
                    Console.WriteLine("\nError! The sender ({0}) does not have enough balance!", sender);
                    Console.WriteLine("Sender's balance is {0}", senderBalance);
                    return false;
                }

                for (int i = 0; i < numOfTx; i++)
                {
                    Console.Write(i + "- ");
                    SendCoin(_accountExt.GetAddress(), recipient, amount, fee);
                    System.Threading.Thread.Sleep(50);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                return false;
            }
            return true;
        }

        public static bool SendCoin(string sender, string recipient, double amount, float fee)
        {

            JesosCoinNode.Grpc.Transaction newTxn = new JesosCoinNode.Grpc.Transaction();


            newTxn.Sender = sender;
            newTxn.TimeStamp = JscUtils.GetTime();
            newTxn.Recipient = recipient;
            newTxn.Amount = amount;
            newTxn.Fee = fee;
            newTxn.Height = 0;
            newTxn.TxType = "Transfer";


            var transactionPost = new TransactionPost
            {
                SendingFrom = "Console Wallet",
                Transaction = newTxn
            };

            string TxnHash = JscUtils.GetTransactionHash(transactionPost.Transaction);
            var signature = _accountExt.Sign(TxnHash);
            newTxn.Hash = TxnHash;
            newTxn.Signature = signature;

            var transferRequest = new TransactionPost
            {
                SendingFrom = "Console Wallet",
                Transaction = newTxn
            };

            try
            {
                var transferResponse = _transactionService.Transfer(transferRequest);
                if (transferResponse.Status.ToLower() == "success")
                {
                    Console.WriteLine("== Success == ");
                }
                else
                {
                    Console.WriteLine("Error: {0}", transferResponse.Message);
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                return false;
            }
            return true;
        }

        public static bool DoShowAccountInfo()
        {
            try
            {
                WalletInfo();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public static bool DoSendCoin()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\nTransfer Coin");
                Console.WriteLine("Time: {0}", DateTime.Now);
                Console.WriteLine("======================");

                Console.WriteLine("Sender address:");
                string sender = _accountExt.GetAddress();
                Console.WriteLine(sender);

                Console.WriteLine("\nPlease enter the recipient address!:");
                string recipient = Console.ReadLine();

                Console.WriteLine("\nPlease enter the amount (number)!:");
                string strAmount = Console.ReadLine();

                Console.WriteLine("\nPlease enter fee (number)!:");
                string strFee = Console.ReadLine();
                double amount;

                if (string.IsNullOrEmpty(sender) ||
                    string.IsNullOrEmpty(recipient) ||
                    string.IsNullOrEmpty(strAmount) ||
                    string.IsNullOrEmpty(strFee))
                {
                    Console.WriteLine("\n\nError, Please input all data: sender, recipient, amount and fee!\n");
                    return false;
                }

                if (!double.TryParse(strAmount, out amount))
                {
                    Console.WriteLine("\nError! You have inputted the wrong value for  the amount!");
                    return false;
                }

                if (!float.TryParse(strFee, out var fee))
                {
                    Console.WriteLine("\nError! You have inputted the wrong value for the fee!");
                    return false;
                }

                var response = _accountService.GetByAddress(new Account
                {
                    Address = sender
                });

                var senderBalance = response.Balance;

                if ((amount + fee) > senderBalance)
                {
                    Console.WriteLine("\nError! Sender ({0}) does not have enough balance!", sender);
                    Console.WriteLine("Sender balance is {0}", senderBalance);
                    return false;
                }

                var NewTxn = new Transaction
                {
                    Sender = _accountExt.GetAddress(),
                    TimeStamp = JscUtils.GetTime(),
                    Recipient = recipient,
                    Amount = amount,
                    Fee = fee,
                    Height = 0,
                    TxType = "Transfer",
                    PubKey = _accountExt.GetKeyPair().PublicKeyHex,
                };

                var TxnHash = JscUtils.GetTransactionHash(NewTxn);
                var signature = _accountExt.Sign(TxnHash);

                NewTxn.Hash = TxnHash;
                NewTxn.Signature = signature;

                var transferRequest = new TransactionPost
                {
                    SendingFrom = "Console Wallet",
                    Transaction = NewTxn
                };

                try
                {
                    var transferResponse = _transactionService.Transfer(transferRequest);
                    if (transferResponse.Status.ToLower() == "success")
                    {
                        DateTime utcDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(Convert.ToDouble(NewTxn.TimeStamp));

                        Console.Clear();
                        Console.WriteLine("\n\n\n\nTransaction has been sent to the Blockchain!");
                        Console.WriteLine("Timestamp: {0}", utcDate.ToLocalTime());
                        Console.WriteLine("Sender: {0}", NewTxn.Sender);
                        Console.WriteLine("Recipient {0}", NewTxn.Recipient);
                        Console.WriteLine("Amount: {0}", NewTxn.Amount);
                        Console.WriteLine("Fee: {0}", NewTxn.Fee);
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Please, wait the transaction processing!");
                    }
                    else
                    {
                        Console.WriteLine("Error: {0}", transferResponse.Message);
                    }
                }
                catch
                {
                    Console.WriteLine("\nError! Please check the UbudKusCoin Node, it needs to be running!");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;

        }

        public static bool DoRestore()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Restore Wallet");
                Console.WriteLine("Please enter 12 words passphrase:");

                string secret = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(secret))
                    Console.WriteLine("\n\nError, please input your 12 words passphrase!\n");
                _accountExt = new Wallet(secret);
                WalletInfo();
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid passphrase!");
                Console.WriteLine(e.Message);
                return false;
            }
            return true;

        }

        public static bool DoCreateAccount()
        {
            try
            {
                _accountExt = new Wallet();
                //ServicePool.DbService.Wa.Add(_accountExt.);
                WalletInfo();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static bool WalletInfo()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n\n\nYour Wallet");
                Console.WriteLine("======================");
                Console.WriteLine("\nADDRESS:\n{0}", _accountExt.GetAddress());
                Console.WriteLine("\nPUBLIC KEY:\n{0}", _accountExt.GetKeyPair().PublicKeyHex);
                Console.WriteLine("\nPASSPHRASE 12 words:\n{0}", _accountExt.Passphrase);
                Console.WriteLine("\n - - - - - - - - - - - - - - - - - - - - - - ");
                Console.WriteLine("*** Store your passphrase in a safe place! And please don't tell it to anyone!  ***");
                Console.WriteLine("*** If you lose your passphrase, your money will be lost!    ***");
                Console.WriteLine("*** Use your secret number to restore your account!              ***");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static bool DoGetTransactionHistory()
        {
            try
            {
                string address = _accountExt.GetAddress();
                if (string.IsNullOrWhiteSpace(address))
                {
                    Console.WriteLine("\n\nError, the address is empty, please create an account first!\n");
                    return false;
                }

                Console.Clear();
                Console.WriteLine("Transaction History for {0}", address);
                Console.WriteLine("Time: {0}", DateTime.Now);
                Console.WriteLine("======================");

                try
                {
                    Console.WriteLine("OK");

                    var response = _transactionService.GetRangeByAddress(new TransactionPaging
                    {
                        Address = address,
                        PageNumber = 1,
                        ResultPerPage = 50
                    });

                    Console.WriteLine("=== Response");

                    if (response != null && response.Transactions != null)
                    {
                        foreach (var Txn in response.Transactions)
                        {
                            Console.WriteLine("Hash        : {0}", Txn.Hash);
                            Console.WriteLine("Timestamp   : {0}", JscUtils.ToDateTime(Txn.TimeStamp));
                            Console.WriteLine("Sender      : {0}", Txn.Sender);
                            Console.WriteLine("Recipient   : {0}", Txn.Recipient);
                            Console.WriteLine("Amount      : {0}", Txn.Amount.ToString("N", CultureInfo.InvariantCulture));
                            Console.WriteLine("Fee         : {0}", Txn.Fee.ToString("N4", CultureInfo.InvariantCulture));
                            Console.WriteLine("--------------\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n---- No records found! ---");
                    }
                }
                catch
                {
                    Console.WriteLine("\nError! Please check your UbudKusCoin Node, it needs to be running!");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public static bool DoGetBalance()
        {
            try
            {
                string address = _accountExt.GetAddress();
                if (string.IsNullOrEmpty(address))
                {
                    Console.WriteLine("\n\nError, the address is empty, please create an account first!\n");
                    return false;
                }

                Console.Clear();
                Console.WriteLine("Balance for {0}", address);
                Console.WriteLine("Time: {0}", DateTime.Now);
                Console.WriteLine("======================");
                try
                {
                    var response = _accountService.GetByAddress(new Account
                    {
                        Address = address
                    });
                    Console.WriteLine("Balance: {0}", response.Balance.ToString("N", CultureInfo.InvariantCulture));
                    return true;
                }
                catch
                {
                    Console.WriteLine("\nError! Please check your UbudKusCoin Node, it needs to be running!");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static bool ShowLastBlock()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\nLast Block");
                Console.WriteLine("- Time: {0}", DateTime.Now);
                Console.WriteLine("======================");

                var block = _blockService.GetLast(new EmptyRequest());
                PrintBlock(block);

                Console.WriteLine("--------------\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(" error!, {0}", "Please check the UbudKusCoin node. It needs to be running!");
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public static bool ShowFirstBlock()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\nGenesis Block");
                Console.WriteLine("Time: {0}", DateTime.Now);
                Console.WriteLine("======================");

                var block = _blockService.GetFirst(new EmptyRequest());

                PrintBlock(block);

                Console.WriteLine("--------------\n");
            }
            catch
            {
                Console.WriteLine(" error!, {0}", "Please check the UbudKusCoin node. It needs to be running!");
                return false;
            }
            return true;
        }

        public static bool PrintBlock(Block block)
        {
            try
            {
                Console.WriteLine("Height        : {0}", block.Height);
                Console.WriteLine("Version       : {0}", block.Version);
                Console.WriteLine("Timestamp     : {0}", JscUtils.ToDateTime(block.TimeStamp));
                Console.WriteLine("Hash          : {0}", block.Hash);
                Console.WriteLine("Merkle Hash   : {0}", block.MerkleRoot);
                Console.WriteLine("Prev. Hash    : {0}", block.PrevHash);
                Console.WriteLine("Validator     : {0}", block.Validator);
                Console.WriteLine("Difficulty    : {0}", block.Difficulty);
                Console.WriteLine("Num of Txs    : {0}", block.NumOfTx);
                Console.WriteLine("Total Amount  : {0}", block.TotalAmount);
                Console.WriteLine("Total Fee     : {0}", block.TotalReward);
                Console.WriteLine("Size          : {0}", block.Size);
                Console.WriteLine("Build Time    : {0}", block.BuildTime);

                var transactions = JsonConvert.DeserializeObject<List<Transaction>>(block.Transactions);
                Console.WriteLine("Transactions: ");
                foreach (var Txn in transactions)
                {
                    Console.WriteLine("   ID          : {0}", Txn.Hash);
                    Console.WriteLine("   Timestamp   : {0}", JscUtils.ToDateTime(Txn.TimeStamp));
                    Console.WriteLine("   Sender      : {0}", Txn.Sender);
                    Console.WriteLine("   Recipient   : {0}", Txn.Recipient);
                    Console.WriteLine("   Amount      : {0}", Txn.Amount.ToString("N", CultureInfo.InvariantCulture));
                    Console.WriteLine("   Fee         : {0}", Txn.Fee.ToString("N4", CultureInfo.InvariantCulture));
                    Console.WriteLine("   - - - - - - ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public static bool ShowAllBlocks()
        {
            try
            {

                Console.Clear();
                Console.WriteLine("\n\n\n Showing All Blocks from Blockchain");
                Console.WriteLine("Time: {0}", DateTime.Now);
                Console.WriteLine("======================");
                Console.WriteLine("\nPlease enter the page number:");

                // validate input
                string strPageNumber = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(strPageNumber))
                {
                    Console.WriteLine("\n\nError, Please input the page number!\n");
                    return false;
                }

                if (!int.TryParse(strPageNumber, out var pageNumber))
                {
                    Console.WriteLine("\n\nError, page is not a number!\n");
                    return false;
                }


                var response = _blockService.GetRange(new BlockParams
                {
                    PageNumber = pageNumber,
                    ResultPerPage = 5
                });

                foreach (var block in response.Blocks)
                {
                    PrintBlock(block);
                    Console.WriteLine("--------------\n");
                }
            }
            catch
            {
                Console.WriteLine(" error!, {0}", "Please check the JesosCoin node, it needs to be running!");
                return false;
            }
            return true;
        }

    }
}
