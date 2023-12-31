using System;
using System.Net.Http;

namespace Blazor_test14.Client.Util
{
    public class PublicClient
    {
        public HttpClient Client { get; }

        public PublicClient(HttpClient httpClient)
        {
            Client = httpClient;
        }
    }
}
