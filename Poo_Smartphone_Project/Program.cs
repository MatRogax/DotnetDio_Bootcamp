using ConsoleApp1.DotnetDio_Bootcamp.Poo_Smartphone_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DotnetDio_Bootcamp.Poo_Smartphone_Project
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Smartphone Nokia: ");
            Smartphone nokia = new Nokia(numero: "123457",modelo:"Modelo 1",imei: "2121212121",memoria: 128);
            nokia.Ligar();
            nokia.InstalarAplicativo("Instagram");

            Console.WriteLine("\n\n");

            Console.WriteLine("Smatphone Iphone:");
            Smartphone iphone = new Iphone(numero: "7654321", modelo: "Modelo 2", imei: "11111111111", memoria: 256);
            iphone.ReceberLigacao();
            iphone.InstalarAplicativo("Whatsapp");

        }
    }
}
