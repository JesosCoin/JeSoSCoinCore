using System;
using System.Collections.Generic;
using System.Text;

namespace JesosCoinNode.UserInterface
{
    public static class ConsoleTerminalUser
    {
        public static void MenuItem()
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


        public static void GetInput()
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

        public static bool Exit()
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
