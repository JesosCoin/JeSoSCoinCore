// Created by I Putu Kusuma Negara
// markbrain2013[at]gmail.com
// 
// Ubudkuscoin is free software distributed under the MIT software license,
// Redistribution and use in source and binary forms with or without
// modifications are permitted.

//In developement by Scryce Programmer - jesos.org@hotmail.com - Abr 2023
//Repository: https://github.com/JesosCoin/JeSoSCoinCore

using JesosCoinNode.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace JesosCoinNode.Others
{
    public class JscUtils
    {

        public JscUtils()
        {
        }

        //public static string GenHash(string data)
        //{
        //    byte[] bytes = Encoding.UTF8.GetBytes(data);
        //    byte[] hash = SHA256.Create().ComputeHash(bytes);
        //    return JscUtils.ToHexString(hash).ToLower();
        //}

        //public static DateTime ToDateTime(long unixTime)
        //{
        //    DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        //    return dtDateTime.AddSeconds(unixTime).ToLocalTime();
        //}

        //public static long GetTime()
        //{
        //    long epochTicks = new DateTime(1970, 1, 1).Ticks;
        //    long nowTicks = DateTime.UtcNow.Ticks;
        //    return (nowTicks - epochTicks) / TimeSpan.TicksPerSecond;
        //}

        //public static string StringToHex(string data)
        //{
        //    byte[] bytes = Encoding.UTF8.GetBytes(data);
        //    return BytesToHex(bytes);
        //}

        //public static string BytesToHex(byte[] bytes)
        //{
        //    return JscUtils.ToHexString(bytes).ToLower();
        //}

        //public static byte[] HexToBytes(string hex)
        //{
        //    int NumberChars = hex.Length;
        //    byte[] bytes = new byte[NumberChars / 2];
        //    for (int i = 0; i < NumberChars; i += 2)
        //    {
        //        bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        //    }

        //    return bytes;
        //}

        public string GetTransactionHash(Transaction txn)
        {
            return GenHash(GenHash($"{txn.TimeStamp}{txn.Sender}{txn.Amount}{txn.Fee}{txn.Recipient}"));
        }



        public static string GenHash(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] hash = SHA256.Create().ComputeHash(bytes);
            return BytesToHex(hash);
        }

        //public static byte[] GenHashBytes(string data)
        //{
        //    byte[] bytes = Encoding.UTF8.GetBytes(data);
        //    byte[] hash = SHA256.Create().ComputeHash(bytes);
        //    return hash;
        //}

        //public static string GenHashHex(string hex)
        //{
        //    byte[] bytes = HexToBytes(hex);
        //    byte[] hash = SHA256.Create().ComputeHash(bytes);
        //    return BytesToHex(hash);
        //}


        /// <summary>
#pragma warning disable CS1570 // XML comment has badly formed XML

        
#pragma warning disable CS1570 // XML comment has badly formed XML
/// </summary>
        /// <param name="str"></param>
        /// <returns></returns>

        public static string BytesToHex(byte[] bytes)
#pragma warning restore CS1570 // XML comment has badly formed XML
#pragma warning restore CS1570 // XML comment has badly formed XML
        {
            var sb = new StringBuilder();

            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString().ToLower();
        }

        //public static string ToHexString(string str)
        //{
        //    var sb = new StringBuilder();

        //    var bytes = Encoding.Unicode.GetBytes(str);
        //    foreach (var t in bytes)
        //    {
        //        sb.Append(t.ToString("X2"));
        //    }

        //    return sb.ToString().ToLower();
        //}

        public static string ToHexString(byte[] bytes)
        {
            var sb = new StringBuilder();

            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString().ToLower();
        }

        //public static string FromHexString(string hexString)
        //{
        //    var bytes = new byte[hexString.Length / 2];
        //    for (var i = 0; i < bytes.Length; i++)
        //    {
        //        bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
        //    }

        //    return Encoding.Unicode.GetString(bytes).ToLower();
        //}


        public static byte[] HexToBytes(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }

        public static DateTime ToDateTime(long unixTime)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTime).ToLocalTime();
            return dtDateTime;
        }

        public static long GetTime()
        {
            long epochTicks = new DateTime(1970, 1, 1).Ticks;
            long nowTicks = DateTime.UtcNow.Ticks;
            long tmStamp = ((nowTicks - epochTicks) / TimeSpan.TicksPerSecond);
            return tmStamp;
        }

        public static string CreateMerkleRoot(string[] txsHash)
        {
            while (true)
            {
                if (txsHash.Length == 0)
                {
                    return string.Empty;
                }

                if (txsHash.Length == 1)
                {
                    return txsHash[0];
                }

                List<string> newHashList = new List<string>();

                int len = (txsHash.Length % 2 != 0) ? txsHash.Length - 1 : txsHash.Length;

                for (int i = 0; i < len; i += 2)
                {
                    newHashList.Add(DoubleHash(txsHash[i], txsHash[i + 1]));
                }

                if (len < txsHash.Length)
                {
                    newHashList.Add(DoubleHash(txsHash[^1], txsHash[^1]));
                }

                txsHash = newHashList.ToArray();
            }
        }

         public static string DoubleHash(string leaf1, string leaf2)
        {
            byte[] leaf1Byte = HexToBytes(leaf1);
            byte[] leaf2Byte = HexToBytes(leaf2);

            var concatHash = leaf1Byte.Concat(leaf2Byte).ToArray();
            SHA256 sha256 = SHA256.Create();
            byte[] sendHash = sha256.ComputeHash(sha256.ComputeHash(concatHash));

            return BytesToHex(sendHash).ToLower();
        }

        public static double GetTotalFees(List<Transaction> txns)
        {
            return txns.AsEnumerable().Sum(x => x.Fee);
        }

        public static double GetTotalAmount(List<Transaction> txns)
        {
            return txns.AsEnumerable().Sum(x => x.Amount);
        }

        public static string GetTransactionHashStatic(Transaction txn)
        {
            return GenHash(GenHash(txn.TimeStamp + txn.Sender + txn.Amount + txn.Fee + txn.Recipient));
        }
    }
}