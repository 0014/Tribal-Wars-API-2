using System;
using System.Net;

namespace Tribalwars.Api.Services.FiddleScripts
{
    public static partial class FiddleScripts
    {

        public static HttpWebResponse Post_2_EnterGame_SetPhpSessid(string auth, string cid)
        {
            HttpWebResponse response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.klanlar.org/");

                request.KeepAlive = true;
                request.Headers.Set(HttpRequestHeader.CacheControl, "max-age=0");
                request.Headers.Add("Upgrade-Insecure-Requests", @"1");
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                request.Referer = "https://www.klanlar.org/";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.8,tr;q=0.6,ht;q=0.4");
                request.Headers.Set(HttpRequestHeader.Cookie, $@"_gat_UA-50308805-1=1; _ga=GA1.2.685439078.1506204738; _gid=GA1.2.1798693462.1506204738; ref=start; cid={cid}; tr_auth={auth}; remember_optout=1");

                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
                else return response;
            }
            catch (Exception)
            {
                if (response != null) response.Close();
                return response;
            }

            return response;
        }
    }
}
