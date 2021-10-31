using System;
using System.IO;
using System.Net;
using System.Xml.Linq;

namespace Soap
{
    public static class XDocumentExtensions
    {
        public static string Send(this XDocument envelope, string url, string action) 
        {
            HttpWebRequest webRequest = SoapService.CreateWebRequest(url, action);
            SoapService.InsertSoapEnvelopeIntoWebRequest(envelope, webRequest);
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);
            asyncResult.AsyncWaitHandle.WaitOne();
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    return rd.ReadToEnd();
                }             
            }
        }
    }
}
