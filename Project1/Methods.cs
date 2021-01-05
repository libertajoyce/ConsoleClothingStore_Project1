using System;
using System.Collections.Generic;
using System.Threading;

namespace Project1
{
    internal class Methods
    {
        private Random budgetCard = new Random();
        private static List<Clothes> Cart = new List<Clothes>();
        Stock stock = new Stock();
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
            ::   1) Show catalogue                                            ::
            ::   2) Review order                                              ::
            ::   3) Pay order                                                 ::
            ::   4) Return to main menu                                       ::
            ::                                                                ::
            ::   Select an option:                                            ::
            ::                                                                ::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ");
            int menuChoice = Convert.ToInt32(Console.ReadLine());
            if (menuChoice == 1)
            {
                ShowCatalogue();
            }
            else if (menuChoice == 2)
            {
                ReviewOrder();
            }
            else if (menuChoice == 3)
            {
                Payment();
            }
            else if (menuChoice == 4)
            {
                Menu();
            }
            else
            {
                ErrorMessage("Error! Not a correct input!", 20);
            }
        }

        public void ShowCatalogue()
        {
            PrintLogo();
            Console.WriteLine(@"
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::                                                                ::
            ::   What category do you want to see?                            ::
            ::                                                                ::
            ::   1) T-shirts                                                  ::
            ::   2) Longsleeve                                                ::
            ::   3) Jeans                                                     ::
            ::   4) DressPants                                                ::
            ::   5) Dress                                                     ::
            ::   6) Sweater                                                   ::
            ::   7) Pyjama                                                    ::
            ::   8) Intimates                                                 ::
            ::   9) Misc                                                      ::
            ::   10) Review order                                             ::
            ::   11) Pay order                                                ::
            ::   12) Return to main menu                                      ::
            ::                                                                ::
            ::   Select an option:                                            ::
            ::                                                                ::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ");
            int menuChoice = Convert.ToInt32(Console.ReadLine());
            if (menuChoice < 10)
            {
                Catalogue(Convert.ToString(menuChoice));
                Console.ReadLine();
            }
            else if (menuChoice == 10)
            {
                ReviewOrder();
            }
            else if (menuChoice == 11)
            {
                Payment();
            }
            else if (menuChoice == 12)
            {
                Menu();
            }
            else
            {
                ErrorMessage("Error! Not a correct input!", 20);
            }
        }
        public void Catalogue(string menuChoice)
        {
            Console.Clear();
            PrintLogo();
            PrintBorder();
            Console.WriteLine("");
            stock.ShowItemsFiltered(Convert.ToString(menuChoice));
            Console.WriteLine($"\n               " +
                "Enter the ID number of the item that you want.");
            PrintBorder();
            int userInput = Convert.ToInt32(Console.ReadLine());
            GiveID(userInput);


        }
        
        public void GiveID(int userInput)
        {
            var choice = userInput;
            Console.Clear();
            PrintLogo();
            PrintBorder();
            foreach (var item in stock.Catalogue)
            {
                if (item.ID == choice)
                {
                    Cart.Add(item);
                    Console.WriteLine($"               " +
                    $"You've selected {item.Name} which costs €{ item.Price}");
                }
            }
            PrintBorder();
            ReviewOrder();
        }
       
        public void ReviewOrder()
        {
            Console.Clear();
            PrintLogo();
            PrintBorder();
            Console.WriteLine($"               " +
                $"Your order:");

            foreach (var item in Cart)
            {
                Console.WriteLine($"              " +
                    $"{item.ID}: {item.Name} €{item.Price} \n");
            }
            PrintBorder();
            Console.ReadLine();
        }
        private static void ErrorMessage(string errorInfo, int sleepTimer)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{errorInfo}");
            Thread.Sleep(sleepTimer);
            Console.ResetColor();
            Console.ReadLine();
        }
        public double ClothesBTW()
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
        public double ClothesNoBTW()
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
        public double ClothesTotal()
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
        public void ClothesEnd(Clothes clothes)
        {
            Console.Clear();
            Console.WriteLine($"You selected a {clothes.Name} which costs {clothes.Price}euro.");
            Cart.Add(clothes);
            Console.ReadLine();
        }
        public void Payment()
        {
            
            //double total = CartTotal();
            Console.WriteLine("The total for you order is: {total}");

            int test = budgetCard.Next(0, 5);
            if (test != 4)
            {
                Console.Beep(5000, 200); Console.Beep(5000, 200); Console.Beep(5000, 200); Thread.Sleep(250);
                Console.WriteLine("Transaction passed! Enjoy your new clothes!");
                Console.ReadLine();
            }
            else
            {
                Console.Beep(5000, 600); Console.Beep(5000, 600); Thread.Sleep(250);
                Console.WriteLine("You're too poor for these items. Try somewhere else or remove some items from your cart!");
                Console.ReadLine();
            }
        }
        private double CartTotal()
        {
            throw new NotImplementedException();
        }
        
        public void PrintBorder()
        {
            Console.WriteLine(@"
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            Console.WriteLine();
        }
    }
}