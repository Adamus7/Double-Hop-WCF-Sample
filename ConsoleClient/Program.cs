using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleClient.WCFServiceSonic;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WCFServiceSonic.Service1Client client = new Service1Client())
            {
                client.ClientCredentials.Windows.ClientCredential.Domain = "yuray2";
                client.ClientCredentials.Windows.ClientCredential.UserName = "adamus";
                client.ClientCredentials.Windows.ClientCredential.Password = "Internet=01!";
                client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                Console.WriteLine(client.GetData(10));
            }
            Console.ReadLine();
        }
    }
}
