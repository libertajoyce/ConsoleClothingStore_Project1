using System;
using System.Threading;

namespace Project1
{
    internal class Methods
    {
        private Random budgetCard = new Random();
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
            MenuSelection();
        }

        public void OwnerMenu()
        {
            Console.WriteLine("This is the owner menu");
        }

        public void MenuSelection()
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
            ::   4) Review order                                              ::
            ::   5) Pay order                                                 ::
            ::   6) Return to main menu                                       ::
            ::                                                                ::
            ::   Select an option:                                            ::
            ::                                                                ::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ");
            int menuChoice = Convert.ToInt32(Console.ReadLine());
            if (menuChoice == 1)
            {
                FemaleMenu();
            }
            else if (menuChoice == 2)
            {
                MaleMenu();
            }
            else if (menuChoice == 3)
            {
                KidsMenu();
            }
            else if (menuChoice == 4)
            {
                ReviewOrder();
            }
            else if (menuChoice == 5)
            {
                Payment();
            }
            else if (menuChoice == 6)
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

        public void Payment()
        {
            
            double total = CartTotal();
            Console.WriteLine($"The total for you order is: ");
            string paymentChoice = Console.ReadLine();

            int test = budgetCard.Next(0, 5);
            if (test != 4)
            {
                Console.Beep(5000, 500); Console.Beep(5000, 500); Thread.Sleep(250);
                Console.WriteLine("Transaction passed! Enjoy your new clothes!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You're too poor for these items. Try somewhere else or remove some from your cart!");
                Console.ReadLine();
            }
        }
        private double CartTotal()
        {
            throw new NotImplementedException();
        }
        public void ReviewOrder()
        {
            throw new NotImplementedException();
        }
    }
}