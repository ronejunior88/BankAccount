using Infrastructure.Data.Command.Context.Rabbit.v1;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando Subscriber");


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("//localhost:5000/insertTransfer");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/insertTransfer").Result;

            Console.WriteLine("Finalizando Subscriber");
            Console.ReadLine();
        }
    }
}
    

