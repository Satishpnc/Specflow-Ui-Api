using RestSharp;
using System.Collections.Generic;

namespace ApiLibrary
{
    public class ApiHelper
    {
        public static IRestResponse CreateRequest(object payload, string method, RestClient restClient, string resource)
        {
            RestRequest request = new RestRequest();
            var dict = new Dictionary<string, string>
            {
                { "Content-Type", "application/json; charset=utf-8" }
            };
            request.AddHeaders(dict);
            switch (method)
            {
                case Methods.GET:
                    request.Method = Method.GET;
                    break;
                case Methods.POST:
                    request.AddJsonBody(payload);
                    request.Method = Method.POST;
                    break;
                case Methods.PUT:
                    request.AddJsonBody(payload);
                    request.Method = Method.PUT;
                    break;
                case Methods.DELETE:
                    request.AddJsonBody(payload);
                    request.Method = Method.DELETE;
                    break;
            }
            request.Resource = resource;
            IRestResponse response = restClient.Execute(request);
            return response;
        }

      
    }

    public static class Methods
    {
        public const string GET = "GET";
        public const string POST = "POST";
        public const string PUT = "PUT";
        public const string DELETE = "DELETE";
    }
}
