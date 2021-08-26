using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace UI.Commons
{
    public static class RestsharpHelper
    {
        private const int _timeout = -1;

        #region Generic

        public static T Get<T>(string url, Dictionary<string, string> headers = null) => GetResult<T>(url, Method.GET, null, headers);

        public static T Post<T>(string url, object requestObject, string token, Dictionary<string, string> headers = null) => GetResult<T>(url, Method.POST, token, requestObject, headers);

        public static T Put<T>(string url, object requestObject, Dictionary<string, string> headers = null) => GetResult<T>(url, Method.PUT, null, requestObject, headers);

        public static T Delete<T>(string url, object requestObject, Dictionary<string, string> headers = null) => GetResult<T>(url, Method.DELETE, null, requestObject, headers);

        private static T GetResult<T>(string url, Method method, string token, object requestObject = null, Dictionary<string, string> headers = null)
        {
            try
            {
                var client = new RestClient(Constants.baseUrl)
                {
                    Timeout = _timeout
                };
                var request = new RestRequest(url, method)
                {

                    RequestFormat = DataFormat.Json,
                    Timeout = _timeout
                };
                if (!string.IsNullOrEmpty(token))
                {
                    request.AddHeader("Authorization", "Bearer" + " " + token);
                }
                if (headers != null)
                    foreach (var header in headers)
                        request.AddHeader(header.Key, header.Value);

                if (requestObject != null)
                {
                    request.AddHeader("Content-Type", "application/json");
                    request.AddJsonBody(requestObject);
                }

                var response = client.Execute(request);
                if (response.StatusCode != 0)
                    return JsonConvert.DeserializeObject<T>(response.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                else
                    return default;
            }
            catch (System.Exception)
            {
                return default;
            }
        }

        #endregion Generic
    }
}