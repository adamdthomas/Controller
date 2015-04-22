using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace HalloweenController_v0._0._1.DAL
{
    //Class used to hit restful web services
    public static class REST
    {
        //Set session ID. Default to blank
        private static string Session = "";
        private static string Auth = "";

        public class RestResponse
        {
            public string ResponseText { get; private set; }
            public string Status { get; private set; }

            public RestResponse(string Response, string StatusCode)
            {
                ResponseText = Response;
                Status = StatusCode;
            }

        }
        public static bool POST(string POSTurl, string PostData, string ContentType)
        {
            //Setup
            bool PostSuccess = false;

            try
            {
                HttpWebRequest request = SetupRequest(POSTurl, "POST", ContentType);
                var data = Encoding.ASCII.GetBytes(PostData);
                request.ContentLength = data.Length;

                //Write request stream
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                    PostSuccess = true;
                }
            }
            catch (Exception e)
            {
                PostSuccess = false;
                MyMethods.WriteToLog(e.ToString());
                //throw;
            }
            return PostSuccess;

            //Pull data from request
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Return
            //return InterpretResponse(response);
        }

        public static RestResponse GET(string POSTurl, string ContentType)
        {
            //Setup
            HttpWebRequest request = SetupRequest(POSTurl, "GET", ContentType);

            //Pull data from request
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Return
            return InterpretResponse(response);
        }

        public static void Dispose()
        {
            Session = "";
            Auth = "";
        }


        //Private Worker
        private static HttpWebRequest SetupRequest(string URL, string Method, string ContentType)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = Method;
            if (ContentType != "")
                request.ContentType = ContentType;
            //if (Session != "" && Auth != "")
            //{
            //    Uri target = new Uri(URL);
            //    request.CookieContainer = new CookieContainer();
            //    request.CookieContainer.Add(new Cookie("ASP.NET_SessionId", Session) { Domain = target.Host });
            //    request.CookieContainer.Add(new Cookie("AbsgAuth", Auth) { Domain = target.Host });
            //}
            //Stop from redirecting
            //request.AllowAutoRedirect = false;

            return request;
        }

        private static RestResponse InterpretResponse(HttpWebResponse WebResponse)
        {

            //Set session
            try
            {
                //Set clean session and auth values
                string[] temp = WebResponse.Headers["Set-Cookie"].Split(char.Parse(","));
                Session = temp[0].Replace("ASP.NET_SessionId=", "").Replace("; path=/; HttpOnly", "");
                Auth = temp[1].Replace("AbsgAuth=", "").Replace("; path=/", "");
            }
            catch (Exception) { };

            //Get response
            string responseString = new StreamReader(WebResponse.GetResponseStream()).ReadToEnd();

            //Build return object
            RestResponse rr = new RestResponse(responseString, WebResponse.StatusCode.ToString());
            WebResponse.Close();

            //Return
            return rr;
        }
    }
}