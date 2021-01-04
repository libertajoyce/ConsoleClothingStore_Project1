using System;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
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
