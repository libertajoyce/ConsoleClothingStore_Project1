using System;
using System.Collections.Generic;
using System.Threading;

namespace Project1
{
    internal class Methods
    {
        private Random budgetCard = new Random();
        public static List<Clothes> Cart = new List<Clothes>();
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
                    Environment.Exit(0);
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

        public bool OwnerMenu()
        {
            AdminManager managing = new AdminManager();
            Console.WriteLine("Enter the number of the option you want to select:\n1. Add to inventory.\n2. Remove from inventory\n3. Go back to main menu.");
            string ownerChoice = Console.ReadLine();
            switch (Convert.ToChar(ownerChoice))
            {
                case '1':
                    AddToInventory();
                    return true;

                case '2':
                    RemoveFromInventory();
                    return true;

                case '3':
                    Menu();
                    return false;

                default:
                    ErrorMessage("Wrong Selection!",20);
                    return true;
            }
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
        public void AddToInventory()
        {
            stock.OwnerWriteText();
        }
        public void RemoveFromInventory()
        {
            stock.OwnerDeleteText();
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
            WhiteSpace();
            Console.WriteLine($"Enter the ID number of the item that you want.");
            PrintBorder();
            int userInput = Convert.ToInt32(Console.ReadLine());
            GiveID(userInput);
            ShowCatalogue();
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
        }

        public void ReviewOrder()
        {
            Console.Clear();
            PrintLogo();
            PrintBorder();
            WhiteSpace();
            Console.WriteLine($"Your order:");
            double total = CartTotal();
            foreach (var item in Cart)
            {
                WhiteSpace();
                Console.WriteLine($"{item.ID}: {item.Name} €{item.Price} \n");
            }
            WhiteSpace();
            Console.WriteLine($"The total of your order is €{total}");
            WhiteSpace();
            Console.WriteLine($"Excl 21% BTW: €{Math.Round(ClothesNoBTW(), 2)}");
            WhiteSpace();
            Console.WriteLine($"21% BTW: €{Math.Round(ClothesBTW(), 2)}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            WhiteSpace();
            Console.WriteLine("Press 'D' to delete an item:");
            Console.ResetColor();
            if (Console.ReadKey().Key == ConsoleKey.D)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                WhiteSpace();
                Console.WriteLine("Enter the item number that you want to remove:");
                Console.ResetColor();
                int remove = Convert.ToInt32(Console.ReadLine());
                foreach (var item in stock.Catalogue)
                {
                    if (item.ID == remove)
                    {
                        Cart.Remove(item);
                        WhiteSpace();
                        Console.WriteLine($"The item has been removed.");
                        Console.ReadLine();
                    }
                }
                WhiteSpace();
                Console.WriteLine($"Updated total order: €{Math.Round(CartTotal(), 2)} including 21% BTW.");
            }
            WhiteSpace();
            Console.WriteLine("To go back to the catalogue, press enter:");
            Console.ResetColor();
            PrintBorder();
            Console.ReadLine();
            ShowCatalogue();
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
            Console.Clear();
            PrintLogo();
            PrintBorder();
            double total = CartTotal();
            WhiteSpace();
            Console.WriteLine($"The total for you order is: {Math.Round(total, 2)}");

            int test = budgetCard.Next(0, 5);
            if (test < 4)
            {
                Console.Beep(5000, 150); Console.Beep(5000, 150); Console.Beep(5000, 150); Thread.Sleep(250);
                WhiteSpace();
                Console.WriteLine("Transaction passed! Enjoy your new clothes!");
                PrintBorder();
                Console.ReadLine();
                PrintTicket();
            }
            else
            {
                Console.Beep(5000, 800); Console.Beep(5000, 800); Thread.Sleep(250);
                WhiteSpace();
                Console.WriteLine("You're too poor for these items. Try somewhere else or remove some items from your cart!");
                PrintBorder();
                Console.ReadLine();
                ReviewOrder();
            }
            
        }

        private double CartTotal()
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

        private void PrintTicket()
        {
            Console.Clear();
            PrintLogo();
            PrintBorder();
            WhiteSpace();
            Console.WriteLine($"Ticket:\n");
            WhiteSpace();
            Console.WriteLine($"Excl 21% BTW: €{Math.Round(ClothesNoBTW(), 2)}");
            WhiteSpace();
            Console.WriteLine($"21% BTW: €{Math.Round(ClothesBTW(), 2)}");
            WhiteSpace();
            Console.WriteLine($"The total of your order is €{CartTotal()}");
            Console.WriteLine(@"
                ──────▄▀▄─────▄▀▄──────
                ─────▄█░░▀▀▀▀▀░░█▄─────
                ─▄▄──█░░░░░░░░░░░█──▄▄─
                █▄▄█─█░░▀░░┬░░▀░░█─█▄▄█
             Thank you for your purrrchase!");
            PrintBorder();
            Console.ReadLine();
            Environment.Exit(0);
        }

        public void PrintBorder()
        {
            Console.WriteLine(@"
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            Console.WriteLine();
        }

        public void WhiteSpace()
        {
            Console.Write("               ");
        }
    }
}