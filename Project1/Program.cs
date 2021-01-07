using System;
using System.Text;

namespace Project1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Methods methode = new Methods();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = methode.Menu();
            }
            Console.ReadLine();
        }
    }
}