using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace ConsumirCir
{
    class Program
    {
        private static string _urlBase;

        private static void ConsultarCir(HttpClient client, string id)
        {
            HttpResponseMessage response = client.GetAsync(
                _urlBase + "api/Cir/" + id).Result;

            Console.WriteLine();
            if (response.StatusCode == HttpStatusCode.OK)
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            else
                Console.WriteLine("Favor efetuar logon novamente!");

            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath("C:\\Projetos\\Core\\Cir\\ConsumirCir\\ConsumirCir")
                 .AddJsonFile($"appsettings.json");
            var config = builder.Build();

            _urlBase = config.GetSection("API_Access:UrlBase").Value;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage respToken = client.PostAsync(
                    _urlBase + "login", new StringContent(
                        JsonConvert.SerializeObject(new
                        {
                            UserID = config.GetSection("API_Access:UserID").Value,

                        }), Encoding.UTF8, "application/json")).Result;

                string conteudo =
                    respToken.Content.ReadAsStringAsync().Result;
                Console.WriteLine(conteudo);

                if (respToken.StatusCode == HttpStatusCode.OK)
                {
                    Token token = JsonConvert.DeserializeObject<Token>(conteudo);
                    if (token.Authenticated)
                    {
                        client.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", token.AccessToken);

                        ConsultarCir(client, "100030010070");
                        ConsultarCir(client, "144441010706");

                    }
                }
            }

            Console.WriteLine("\nFinalizado!");
            Console.ReadKey();
        }
    }
}
