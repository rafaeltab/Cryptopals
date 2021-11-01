// See https://aka.ms/new-console-template for more information
using Rafaeltab.Cryptopals.Set2.Common;
using System.Text;

Console.WriteLine(Encoding.UTF8.GetString(Padding.PKCS7(Encoding.UTF8.GetBytes("YELLOW SUBMARINE"),20)));
