using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace UpcomingConsole
{
    class Program
    {
        static String cookie = "SESSa4c564b873aecda55b12a530bf2ece51=f3640c044cec27532c19b005899eb055;";
        static void Main(string[] args)
        {
            Console.WriteLine("Upcoming");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://app.schoology.com/home/upcoming_ajax");
            request.Headers.Add(HttpRequestHeader.Cookie, cookie);
            request.Method = "GET";
            request.Accept = "text/html";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.79 Safari/537.36 Edge/14.14393";
            request.Host = "app.schoology.com";
            request.Referer = "https://app.schoology.com/home";
            request.Headers.Add("X-NewRelic-ID:Vw8OWVNACwUCXVdQ");
            request.Headers.Add("X-Requested-With:XMLHttpRequest");
            WebResponse response = request.GetResponse();
            var str = new StreamReader(response.GetResponseStream()).ReadToEnd().Replace("\\r", "").Replace("\\n", "");
            response.Close();
            Regex reg = new Regex("/assignment.+?/a");
            foreach (Match stri in reg.Matches(str))
            {
                Console.WriteLine("https://app.schoology.com" + stri.Value.Replace("\\", "").Replace("u0022u003E", "     ").Replace("u003C/a", ""));
            }
            Console.WriteLine("");
            Console.WriteLine("Overdue Submissions");

            //Overdue Submissions
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://app.schoology.com/home/overdue_submissions_ajax");
            req.Headers.Add(HttpRequestHeader.Cookie, cookie);
            req.Method = "GET";
            req.Accept = "text/html";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.79 Safari/537.36 Edge/14.14393";
            req.Host = "app.schoology.com";
            req.Referer = "https://app.schoology.com/home";
            req.Headers.Add("X-NewRelic-ID:Vw8OWVNACwUCXVdQ");
            req.Headers.Add("X-Requested-With:XMLHttpRequest");
            response = req.GetResponse();
            str = new StreamReader(response.GetResponseStream()).ReadToEnd().Replace("\\r", "").Replace("\\n", "");
            response.Close();
            reg = new Regex("/assignment.+?/a");
            foreach (Match stri in reg.Matches(str))
            {
                Console.WriteLine("https://app.schoology.com" + stri.Value.Replace("\\", "").Replace("u0022u003E", "     ").Replace("u003C/a", ""));
            }
            Console.WriteLine("done");
            string exit = null;
            while ((exit=Console.ReadLine()) != exit)
            {
                Console.WriteLine("input \"exit\" to quit");
            }
        }
    }
}
