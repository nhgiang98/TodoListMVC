﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TodoListMVC.Common
{
    public class EncryptHelper
    {
        public static string Encrypt(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                result.Append(hashBytes[i].ToString("X2"));
            }
            return result.ToString();
        }
    }
}