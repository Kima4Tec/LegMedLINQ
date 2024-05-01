using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LegMedLINQ
{
    internal class HttpClientTest
    {



        public async Task MainStart()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://jsonplaceholder.typicode.com/todos/1";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseData);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }

        }

    }
}
