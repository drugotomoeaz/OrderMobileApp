using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Xamarin.Forms;

namespace OrderMobileApp.Services
{
    public enum RequestTo
    {
        GetClients,
        GetProducts,
        SendOrder
    }

    public static class DataRequester
    {
        private readonly static AddressBook _addressSource = DependencyService.Get<IConfig>().GetAddressBook();

        private static Dictionary<RequestTo, string> _addressBook = new Dictionary<RequestTo, string>()
        {
            { RequestTo.GetClients , _addressSource.AddressToGetClients },
            { RequestTo.GetProducts , _addressSource.AddressToGetProducts },
            { RequestTo.SendOrder , _addressSource.AddressToSendOrder },
        };

        public static string MakeRequest(RequestTo recipient, string requestBody)
        {
            var request = HttpWebRequest.Create(_addressBook[recipient]);
            request.Method = "POST";

            var data = Encoding.UTF8.GetBytes(requestBody);
            request.ContentType = "text/plain";
            request.ContentLength = data.Length;
            var newStream = request.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("error code: " + response.StatusCode.ToString());
                }
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}
