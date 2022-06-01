using Infrastructure.Data.Command.Context.Rabbit.v1;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando Subscriber");


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");

            var content = new StringContent(client.BaseAddress.ToString(), Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = client.PutAsync("/insertTransfer", content).Result;

            Console.WriteLine("Status Response: " + response.StatusCode);
            Console.WriteLine("Finalizando Subscriber");
            Console.ReadLine();
        }
    }
}
    

