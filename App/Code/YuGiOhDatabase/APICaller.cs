using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace YuGiOhDatabase
{
    public static class APICaller
    {
        public static HttpClient APIClient { get; set; }

        // Set a new HTTPClient set for recieving JSON objects.
        public static void InitializeClient()
        {
            if(APIClient == null)
            {
                APIClient = new HttpClient();

                APIClient.DefaultRequestHeaders.Accept.Clear();
                APIClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
    }
}
