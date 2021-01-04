using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Project1.enums;

namespace Project1
{
    class Methods
    {
        //Collections collection = new Collections();
        private static List<Clothes> Cart = new List<Clothes>();
        public static void PrintLogo()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"
            ╔═╗┌─┐┌┐ ┌─┐┌┐┌┌─┐
            ║  ├─┤├┴┐├─┤│││├─┤
            ╚═╝┴ ┴└─┘┴ ┴┘└┘┴ ┴
            ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┌┬┐┌─┐┬─┐┌─┐
            ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗ │ │ │├┬┘├┤ 
            ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝ ┴ └─┘┴└─└─┘");
            Console.ResetColor();
            
        }
        public bool Menu()
        {
            Console.Clear();
            PrintLogo();
            Console.WriteLine(@"
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::                                                                ::
            ::   Choose an option:                                            ::
            ::                                                                ::
            ::   1) Customer                                                  ::
            ::   2) Owner                                                     ::
            ::   3) Exit                                                      ::
            ::                                                                ::
            ::   Select an option:                                            ::
            ::                                                                ::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
             ");

            switch (Convert.ToChar(Console.ReadLine()))
            {
                case '1':
                    CustomerMenu();
                    return true;
                case '2':
                    OwnerMenu();
                    return true;
                case '3':

                    //exit
                    return false;
                default:
                    return true;
            }
        }

        public void CustomerMenu()
        {
            Console.Clear();
            GenderSelection();

        }

        public void OwnerMenu()
        {
            Console.WriteLine("This is the owner menu");

        }

        public void GenderSelection()
        {
            PrintLogo();
            Console.WriteLine(@"
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::                                                                ::
            ::   Who are you buying clothes for?                              ::
            ::                                                                ::
            ::   1) Female                                                    ::
            ::   2) Male                                                      ::
            ::   3) Kids                                                      ::
            ::                                                                ::
            ::   Select an option:                                            ::
            ::                                                                ::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ");
            int gender = Convert.ToInt32(Console.ReadLine());
            if (gender == 1)
            {
                FemaleMenu();
            }
            else if (gender == 2)
            {
                MaleMenu();
            }
            else if (gender == 3)
            {
                KidsMenu();
            }
            else
            {
                ErrorMessage("Error! Not a correct input!", 20);
            }
        }

        public static void FemaleMenu()
        {
            Console.Clear();
            
            Collections.FemaleCollection();
          
        }
        public static void MaleMenu()
        {
            Console.Clear();
                        
            Collections.MaleCollection();
            
        }
        public void KidsMenu()
        {
            Console.Clear();

            Collections.KidsCollection();
             
        }

        private static void ErrorMessage(string errorInfo, int sleepTimer)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{errorInfo}");
            Thread.Sleep(sleepTimer);
            Console.ResetColor();
            Console.ReadLine();
        }
        
        public double CartBTW()
        {
            double total = 0;
            int i = 0;
            foreach (var item in Cart)
            {

                total += Cart[i].Price;
                i++;
            }
            total = total / 100 * 21;
            return total;
        }
        public double CartNoBTW()
        {
            double total = 0;
            int i = 0;
            foreach (var item in Cart)
            {

                total += Cart[i].Price;
                i++;
            }
            total = total / 100 * 79;
            return total;
        }
        public double CartTotal()
        {
            double total = 0;
            int i = 0;
            foreach (var item in Cart)
            {

                total += Cart[i].Price;
                i++;
            }
            return total;
        }
    }

}
