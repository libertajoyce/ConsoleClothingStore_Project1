using System;

namespace Project1
{
    internal class Collections
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