using System;
using System.Collections.Generic;
using System.IO;

namespace _4OsaÜlesandeid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int valik = 1;
            List<string> koostisosad = new List<string>();
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            while (valik != 0)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Lisa lemmikroog");
                Console.WriteLine("2 - Näita retsepte");
                Console.WriteLine("3 - Muuda koostisosad");
                Console.WriteLine("4 - Otsi koostisosa");
                Console.WriteLine("5 - Salvesta koostisosad");
                Console.WriteLine("6 - Näita menuu");
                Console.WriteLine("0 - Välju");

                Console.Write("Vali number: ");
                valik = Convert.ToInt32(Console.ReadLine());

                switch (valik)
                {
                    case 1:
                        Class1.LisaLemmikRoog(basePath);
                        break;

                    case 2:
                        Class1.KuvatudMenyy(basePath);
                        break;

                    case 3:
                        koostisosad = Class1.MuudaKoostisosad(basePath);
                        break;

                    case 4:
                        Class1.OtsiKoostisosa(koostisosad);
                        break;

                    case 5:
                        string fail = Path.Combine(basePath, "Koostisosad.txt");
                        Class1.SalvestaKoostisosad(fail, koostisosad);
                        break;

                    case 6:
                        string menuuFail = Path.Combine(basePath, "Menuu.txt");
                        Class1.KuvaMenuuFailist(menuuFail);
                        break;

                    case 0:
                        Console.WriteLine("Programm lõpetatud");
                        break;

                    default:
                        Console.WriteLine("Vale valik");
                        break;
                }
            }
        }
    }
}