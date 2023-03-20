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

namespace BearShell
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
            //Get Domain to be looked up. 
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("ATTENTION! The dig command is not properly implemented yet. \n Displaying the result of your query can take up to 1 minute. \nPlease wait until all results have been returned. After that you can execute a different command.");
            Console.ResetColor();

            //Letting the user choose if the command should be executed
            Console.WriteLine("Type OK to continue, type halt to stop the further execution of the command.");
            string agree = Console.ReadLine();
            if (agree == "OK")
            {
                Console.WriteLine("Enter a domain to be looked up.");
                string toobelookedup = Console.ReadLine();

                //Lookup and defining the type of records to be looked up.
                var lookup = new LookupClient();
                var result = await lookup.QueryAsync(toobelookedup, QueryType.A);
                var resultAAAA = await lookup.QueryAsync(toobelookedup, QueryType.AAAA);
                var resultCNAME = await lookup.QueryAsync(toobelookedup, QueryType.CNAME);
                var resultPTR = await lookup.QueryAsync(toobelookedup, QueryType.PTR);
                var resultNS = await lookup.QueryAsync(toobelookedup, QueryType.NS);
                var resultMX = await lookup.QueryAsync(toobelookedup, QueryType.MX);
                var resultSOA = await lookup.QueryAsync(toobelookedup, QueryType.SOA);
                var resultTXT = await lookup.QueryAsync(toobelookedup, QueryType.TXT);

                //Return results
                var record = result.Answers.ARecords().FirstOrDefault();
                var recordAAAA = resultAAAA.Answers.AaaaRecords().FirstOrDefault();
                var recordCNAME = resultCNAME.Answers.CnameRecords().FirstOrDefault();
                var recordPTR = resultPTR.Answers.PtrRecords().FirstOrDefault();
                var recordNS = resultNS.Answers.NsRecords().FirstOrDefault();
                var recordMX = resultMX.Answers.MxRecords().FirstOrDefault();
                var recordSOA = resultSOA.Answers.SoaRecords().FirstOrDefault();
                var recordTXT = resultTXT.Answers.TxtRecords().FirstOrDefault();

                var ip = record?.Address;

                //Write results 
                Console.WriteLine("Your query returned the following results: ");
                Console.WriteLine(record);
                Console.WriteLine(recordAAAA);
                Console.WriteLine(recordCNAME);
                Console.WriteLine(recordPTR);
                Console.WriteLine(recordNS);
                Console.WriteLine(recordMX);
                Console.WriteLine(recordSOA);
                Console.WriteLine(recordTXT);
            }

            else
            {
                Console.WriteLine("Execution of command has been terminated. Press a key to continue.");
                Console.ReadKey();
                Program.Main();
            }
        }
    }
}
