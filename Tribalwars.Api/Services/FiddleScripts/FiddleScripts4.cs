using System;
using System.IO;
using System.Net;

namespace Tribalwars.Api.Services.FiddleScripts
{
    public static partial class FiddleScripts
    {
        public static HttpWebResponse Post_2_EnterWorld_SetIo(string auth, string cid)
        {
            HttpWebResponse response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://tr43.klanlar.org:8082/socket.io/?sessid=8b26c1f260df&village_id=12680&screen=overview&EIO=3&transport=polling&t=Lwmp9Fj&sid=TpRHQaPzFRqcT_a9DmgD");

                request.KeepAlive = true;
                request.Headers.Add("Origin", @"https://tr43.klanlar.org");
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36";
                request.ContentType = "text/plain;charset=UTF-8";
                request.Accept = "*/*";
                request.Referer = "https://tr43.klanlar.org/game.php?screen=overview&intro";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.8,tr;q=0.6,ht;q=0.4");
                request.Headers.Set(HttpRequestHeader.Cookie, $@"io=TpRHQaPzFRqcT_a9DmgD; _gat_UA-50308805-1=1; cid={cid}; tr_auth={auth}; _dc_gtm_UA-50308805-1=1; _ga=GA1.2.685439078.1506204738; _gid=GA1.2.1798693462.1506204738; _dc_gtm_UA-1897727-23=1; sid=0%3A8b26c1f260df; global_village_id=12680; mobile=0; ref5425586=player_invite_email; __utmt=1; __utma=37502309.685439078.1506204738.1506204751.1506204751.1; __utmb=37502309.1.10.1506204751; __utmc=37502309; __utmz=37502309.1506204751.1.1.utmcsr=klanlar.org|utmccn=(referral)|utmcmd=referral|utmcct=/");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = @"7:40/game";
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
