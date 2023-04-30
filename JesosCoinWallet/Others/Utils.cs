// Created by I Putu Kusuma Negara
// markbrain2013[at]gmail.com
// 
// Ubudkuscoin is free software distributed under the MIT software license,
// Redistribution and use in source and binary forms with or without
// modifications are permitted.

//In developement by Scryce Programmer - jesos.org@hotmail.com - Abr 2023
//Repository: https://github.com/JesosCoin/JeSoSCoinCore

using System;
using System.Security.Cryptography;
using System.Text;
using JesosCoinNode.Grpc;
using JeSoSCoinNode.Others;

namespace JesosCoinNode.JesosCoinWallet.Others
{
    public static class Utils
    {
        public static string GenHash(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] hash = SHA256.Create().ComputeHash(bytes);
            return JscUtils.ToHexString(hash).ToLower();
        }

        public static DateTime ToDateTime(long unixTime)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dtDateTime.AddSeconds(unixTime).ToLocalTime();
        }

        public static long GetTime()
        {
            long epochTicks = new DateTime(1970, 1, 1).Ticks;
            long nowTicks = DateTime.UtcNow.Ticks;
            return (nowTicks - epochTicks) / TimeSpan.TicksPerSecond;
        }
        
        public static string StringToHex(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            return BytesToHex(bytes);
        }

        public static string BytesToHex(byte[] bytes)
        {
            return JscUtils.ToHexString(bytes).ToLower();
        }

        public static byte[] HexToBytes(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }

            return bytes;
        }

        public static string GetTransactionHash(Transaction txn)
        {
            return GenHash(GenHash($"{txn.TimeStamp}{txn.Sender}{txn.Amount}{txn.Fee}{txn.Recipient}"));
        }
    }
}