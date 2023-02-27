using System;
using System.Net.Http;
using System.Text;

namespace ConsolClientAPI
{
    class Sass
    {
        public static void space()
        {
            Console.WriteLine("");
            for (int i = 0; i < 237; i++)
            {
                Console.Write("_");
            }
        }

    }
    internal class Program
    {
        static HttpClient? httpClient;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //GET
            httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:7131/WeatherForecast");
            Console.WriteLine(response);
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            Sass.space();
            //POST
            string newRecord = "{\r\n  \"id\": 1,\r\n  \"date\": \"07.02.2023\",\r\n  \"degree\": -5,\r\n  \"location\": \"Москва\"\r\n}";
            var stringContent = new StringContent(newRecord, Encoding.UTF8, "application/json");
            response = await httpClient.PostAsync("https://localhost:7131/WeatherForecast", stringContent);
            Console.WriteLine(response);

            Sass.space();
            //1 повтор GET            response = await httpClient.GetAsync("https://localhost:7131/WeatherForecast");
            Console.WriteLine(response);
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            Sass.space();
            //PUT
            string updateRecord= "{\r\n  \"id\": 6,\r\n  \"date\": \"07.02.2023\",\r\n  \"degree\": -5,\r\n  \"location\": \"Жытомир\"\r\n}";
            stringContent = new StringContent(updateRecord, Encoding.UTF8, "application/json");
            response = await httpClient.PutAsync("https://localhost:7131/WeatherForecast", stringContent);

            Sass.space();
            //2 повтор GET
            response = await httpClient.GetAsync("https://localhost:7131/WeatherForecast");
            Console.WriteLine(response);
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            Sass.space();
            //DELETE
            response = await httpClient.DeleteAsync("https://localhost:7131/WeatherForecast?id=6");
            Console.WriteLine(response);

            Sass.space();
            //3 повтор GET
            response = await httpClient.GetAsync("https://localhost:7131/WeatherForecast");
            Console.WriteLine(response);
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            Sass.space();
            //GetFound(niggers)
            var id = Console.ReadLine();
            response = await httpClient.GetAsync("https://localhost:7131/WeatherForecast?index=" + id);
            Console.WriteLine(await response.Content.ReadAsStringAsync());

        }
    }
}