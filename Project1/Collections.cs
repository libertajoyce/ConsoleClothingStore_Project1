﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class Collections
    {
        
        public static void FemaleCollection()
        {
            Methods.PrintLogo();
            Console.WriteLine(@"
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::                                                                ::
            ::   What kind of clothes do you want to see?                     ::
            ::                                                                ::
            ::   1) Tops                                                      ::
            ::   2) Pants                                                     ::
            ::   3) Underwear                                                 ::
            ::                                                                ::
            ::   Select an option:                                            ::
            ::                                                                ::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ");
            Stock stock = new Stock();
            stock.ReadDataFromFile($"C:/Users/emmad/source/repos/Project1/Project1/Inventory.txt");
            Console.ReadLine();
        }
        
        public static void MaleCollection()
        {
            
            Methods.PrintLogo();
            Console.WriteLine(@"
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::                                                                ::
            ::   What kind of clothes do you want to see?                     ::
            ::                                                                ::
            ::   1) Tops                                                      ::
            ::   2) Pants                                                     ::
            ::   3) Underwear                                                 ::
            ::                                                                ::
            ::   Select an option:                                            ::
            ::                                                                ::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ");
        }
        
        public static void KidsCollection()
        {
            Methods.PrintLogo();
            Console.WriteLine(@"
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::                                                                ::
            ::   Who are you buying clothes for?                              ::
            ::                                                                ::
            ::   1)Tops                                                       ::
            ::   2)Pants                                                      ::
            ::   3)Underwear                                                  ::
            ::                                                                ::
            ::   Select an option:                                            ::
            ::                                                                ::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            ");
        }
        
    }
}