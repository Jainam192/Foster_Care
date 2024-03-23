using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace FosterCare.Models
{
    public class Comman
    {
        public static void sendsms(string body, string mobileNumber, string TempID)
        {
            HttpWebResponse response = null;
            try
            {
                string url = "http://smsera.in/sendsms.jsp?user=elixatin&password=145b33174bXX&senderid=IGPUDR&mobiles=" + mobileNumber + "&sms=" + body + "&tempid=" + TempID;
                WebRequest request = WebRequest.Create(url);
                response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                Encoding ec = Encoding.GetEncoding("utf-8");
                StreamReader reader = new StreamReader(stream, ec);
                string result = reader.ReadToEnd();
                Console.WriteLine(result);
                reader.Close();
                stream.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }
            finally
            {
                if (response != null)
                    response.Close();
            }
        }
    }
}