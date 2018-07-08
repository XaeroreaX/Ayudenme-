using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace elMain
{
    class Program
    {
        static void Main(string[] args)
        {


            Storage<Fruta> storage = new Storage<Fruta>(10);


           storage += new Manzana(ConsoleColor.Red, 0.58f, "bolivinaria");

           storage += new Platano(ConsoleColor.Yellow, .23f, "Argentina");

            Console.WriteLine(storage.ToString());

            

            Console.ReadKey();


            Console.Clear();

            Console.WriteLine(storage.SerializarXML());

            Console.ReadKey();

        }
    }
}
