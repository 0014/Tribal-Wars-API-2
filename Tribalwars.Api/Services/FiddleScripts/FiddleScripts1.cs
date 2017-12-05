using System;
using System.IO;
using System.Net;

namespace Tribalwars.Api.Services.FiddleScripts
{
    public static partial class FiddleScripts
    {
        public static HttpWebResponse Post_1_EnterGame_SetAuth(string userName, string password)
        {
            HttpWebResponse response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.klanlar.org/page/auth");

                request.KeepAlive = true;
                request.Accept = "*/*";
                request.Headers.Add("Origin", @"https://www.klanlar.org");
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Referer = "https://www.klanlar.org/";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.8,tr;q=0.6,ht;q=0.4");
                request.Headers.Set(HttpRequestHeader.Cookie, @"_gat_UA-50308805-1=1; _ga=GA1.2.867929121.1506202966; _gid=GA1.2.335671345.1506202966");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = $@"username={userName}&password={password}&remember=1";
                byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(body);
                request.ContentLength = postBytes.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(postBytes, 0, postBytes.Length);
                stream.Close();

                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
                else return null;
            }
            catch (Exception)
            {
                if (response != null) response.Close();
                return null;
            }

            return response;
        }
    }
}
