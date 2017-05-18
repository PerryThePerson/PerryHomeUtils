using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;



namespace ImageSearchLib
{
    public class GoogleImageSearch
    {

        public static string SearchImage(string searchTerm)
        {

            string html = GetHtmlCode(searchTerm);
            string url = GetUrls(html);
            return url;
        }

        private static string GetHtmlCode(String topic)
        {


            string url = "https://www.google.com/search?q=" + topic + "&tbm=isch";
            string data = "";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";

            var response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                    return "";
                using (var sr = new StreamReader(dataStream))
                {
                    data = sr.ReadToEnd();
                }
            }
            return data;
        }

        private static string GetUrls(string html)
        {

            int ndx = html.IndexOf("\"ou\"", StringComparison.Ordinal);
            ndx = html.IndexOf("\"", ndx + 4, StringComparison.Ordinal);
            ndx++;
            int ndx2 = html.IndexOf("\"", ndx, StringComparison.Ordinal);
            string url = html.Substring(ndx, ndx2 - ndx);
            var urls = url;
            ndx = html.IndexOf("\"ou\"", ndx2, StringComparison.Ordinal);
            return urls;
        }
    }
}



