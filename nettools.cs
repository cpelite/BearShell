using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using DnsClient;
using DnsClient.Protocol;

namespace BärShell
{
    public class ping
    {
        public static void init()
        {
            try
            {
                Ping myPing = new Ping();
                //Get host to be pinged, ip addr. only!
                Console.WriteLine("Please enter an IP address to send a ping to.");
                string pingip = Console.ReadLine();
                PingReply reply = myPing.Send(pingip, 1000);

                if (reply != null)
                {
                    Console.WriteLine("Status :  " + reply.Status + " \n Time : " + reply.RoundtripTime.ToString() + " \n Address : " + reply.Address);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Ping failed!");
            }
        }
    }

    public class nalo
    {
        public static void init()
        {
            //Get hostname to be looked up
            Console.WriteLine("Enter a hostname to be looked up: ");
            string hostname = Console.ReadLine();
            //Perform the lookup
            IPHostEntry host = Dns.GetHostEntry(hostname);
            Console.WriteLine($"The entered hostname({hostname}) returns the following ip-adresses:");
            foreach (IPAddress address in host.AddressList)
            {
                Console.WriteLine($"    {address}");
            }
        }
    }

    public class dig
    {
        public static async void init()
        {
            //define variables / string 
            Console.WriteLine("Enter a domain to be looked up.");
            string tobelookedup = Console.ReadLine();
            var lookup = new LookupClient();
            var result = await lookup.QueryAsync(tobelookedup, QueryType.A);

            var record = result.Answers.ARecords().FirstOrDefault();
            var ip = record?.Address;

            Console.WriteLine(record);
        }
    }
}
