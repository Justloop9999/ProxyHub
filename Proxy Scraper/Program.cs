using System;
using System.IO;
using System.Net;

namespace Proxy_Scraper
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.Title = Console.Title = "  [ ProxyHub | Proxy Scraper | Made by Justloop ]";
            Console.Clear();
            Console.WriteLine();
            Console.Write("                          ██▓███   ██▀███   ▒█████  ▒██   ██▒▓██   ██▓ ██░ ██  █    ██  ▄▄▄▄   \n");
            Console.Write("                         ▓██░  ██▒▓██ ▒ ██▒▒██▒  ██▒▒▒ █ █ ▒░ ▒██  ██▒▓██░ ██▒ ██  ▓██▒▓█████▄ \n");
            Console.Write("                         ▓██░ ██▓▒▓██ ░▄█ ▒▒██░  ██▒░░  █   ░  ▒██ ██░▒██▀▀██░▓██  ▒██░▒██▒ ▄██\n");
            Console.Write("                         ▒██▄█▓▒ ▒▒██▀▀█▄  ▒██   ██░ ░ █ █ ▒   ░ ▐██▓░░▓█ ░██ ▓▓█  ░██░▒██░█▀  \n");
            Console.Write("                         ▒██▒ ░  ░░██▓ ▒██▒░ ████▓▒░▒██▒ ▒██▒  ░ ██▒▓░░▓█▒░██▓▒▒█████▓ ░▓█  ▀█▓\n");
            Console.Write("                         ▒▓▒░ ░  ░░ ▒▓ ░▒▓░░ ▒░▒░▒░ ▒▒ ░ ░▓ ░   ██▒▒▒  ▒ ░░▒░▒░▒▓▒ ▒ ▒ ░▒▓███▀▒\n");
            Console.Write("                         ░▒ ░       ░▒ ░ ▒░  ░ ▒ ▒░ ░░   ░▒ ░ ▓██ ░▒░  ▒ ░▒░ ░░░▒░ ░ ░ ▒░▒   ░ \n");
            Console.Write("                         ░░         ░░   ░ ░ ░ ░ ▒   ░    ░   ▒ ▒ ░░   ░  ░░ ░ ░░░ ░ ░  ░    ░ \n");
            Console.Write("                                     ░         ░ ░   ░    ░   ░ ░      ░  ░  ░   ░      ░      \n");
            Console.Write("                                                              ░ ░                            ░ \n");
            System.Console.WriteLine();
            Console.WriteLine("                                               ╔═══════════════════════╗                                                        ");
            Console.WriteLine("                                               ║    MADE BY Justloop   ║                                                        ");
            Console.WriteLine("                                               ╚═══════════════════════╝                                                        ");
            System.Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(DateTime.Now.ToString("                                          [dddd | yyyy-MM-dd | HH-mm-ss] \n"));
            System.Console.WriteLine();
            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(" ~ Choose ");
            Console.Write(" [ 1 : SCRAPE | 2 : CHECK ]");
            Console.Write(": ");

            //read which key is pressed
            string answer = Console.ReadLine();



            if (answer == "1")
            {
                try
                {
                    //get proxytype
                    Console.Write(" ~ Which Type ");
                    Console.Write("Of Proxys");
                    Console.Write(" you want to Scrape");
                    Console.Write(" [ HTTP | SOCKS4 | SOCKS5 ]");
                    Console.Write(": ");
                    string proxytype = Console.ReadLine();

                    //get timeout
                    Console.Write(" ~ Timeout ");
                    Console.Write(": ");
                    string timeout = Console.ReadLine();



                    //get proxies from API
                    WebClient wc = new WebClient();
                    var Blockanet = wc.DownloadString(@"https://api.good-proxies.ru/get.php?type%5B" + proxytype + "%5D=on&count=0&ping=" + timeout + "&time=" + timeout + "&key=3269305ce8094af10e5933fe67db8529");
                    var proxyscrape = wc.DownloadString(@"https://api.proxyscrape.com/?request=getproxies&proxytype=" + proxytype + "&timeout=" + timeout + "&country=all");
                    var openproxylist = wc.DownloadString(@"https://api.openproxylist.xyz/" + proxytype + ".txt");

                    //Count how many proxies did scrape
                    long amount = CountLinesInString(proxyscrape + Blockanet + openproxylist);

                    //save
                    string path1 = proxytype + " " + amount + ".txt";
                    string appendText = proxyscrape + Blockanet + openproxylist;
                    File.AppendAllText(path1, appendText);

                    //show proxies in console
                    Console.WriteLine(proxyscrape + Blockanet + openproxylist);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Title = "Scraped" + " " + amount + " " + proxytype + " " + "Proxys Successfully";
                    Console.WriteLine("Scraped" + " " + amount + " " + proxytype + " " + "Proxys Successfully");
                    Console.ReadKey();
                }

                catch
                {
                    
                }


            }

            if (answer == "2")
            {
                    try
                    {
                    Console.WriteLine("Soon...");
                    Console.ReadKey();

                    }

                    catch
                    {

                    }
            }

            else
            {
                Console.WriteLine("Stop Joking And Select a Number");
                Console.ReadKey();
            }

        }


        static long CountLinesInString(string s)
        {
            long count = 0;
            int start = 0;
            while ((start = s.IndexOf('\n', start)) != -1)
            {
                count++;
                start++;
            }
            return count;
        }

    }
}
