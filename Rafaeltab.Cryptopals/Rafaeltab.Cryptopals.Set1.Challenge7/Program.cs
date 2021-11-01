using Rafaeltab.Cryptopals.Set1.Common;
using System.Text;

var fileContent = File.ReadAllText("7.txt");

var key = Encoding.UTF8.GetBytes("YELLOW SUBMARINE");
var input = Convert.FromBase64String(fileContent);

var res = Aes128ECB.Decrypt(input, key);

Console.WriteLine(Encoding.UTF8.GetString(res));