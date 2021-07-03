using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace posttest
{
				class Program
				{
								static void Main(string[] args)
								{
												WebRequest request = (WebRequest)HttpWebRequest.Create("https://app.schoology.com/login");
												request.Method = "POST";
												Stream stream = request.GetRequestStream();
												string poststr = "mail:jeffreyyao%40outlook.com,form_id:s_user_login_form,pass:953264261jeffrey";
												byte[] b = Encoding.UTF8.GetBytes(poststr);
												stream.Write(b, 0, b.Length);
												String output = request.GetResponse().Headers.Get("Cookie");
												Console.WriteLine(output);
												Console.ReadKey();
								}
				}
}
