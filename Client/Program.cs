using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var client = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:5001"),
                // Set default version to HTTP/2
                DefaultRequestVersion = new Version(2, 0)
            };

            using var responseMessage = await client.GetAsync("/", HttpCompletionOption.ResponseHeadersRead);


            Console.WriteLine("Headers");
            foreach(var header in responseMessage.Headers)
            {
                Console.WriteLine($"\t{header.Key}: {string.Join(",", header.Value)}");
            }

            Console.WriteLine($"\nBody\n\t{await responseMessage.Content.ReadAsStringAsync()}\n");

            Console.WriteLine("Trailers");
            foreach (var trailer in responseMessage.TrailingHeaders)
            {
                Console.WriteLine($"\t{trailer.Key}: {string.Join(",", trailer.Value)}");
            }

        }
    }
}
