using System;
using System.Collections.Generic;
using System.Text;
using System.IO; 

namespace _4OsaÜlesandeid
{
    public class Class1
    {
        public static void LisaLemmikRoog(string failitee)
        {
            Console.Write("Sisesta oma lemmik Itaalia toit: ");
            string toit = Console.ReadLine();

            
            string retseptidFail = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Retseptid.txt");

            try
            {
                using (StreamWriter writer = new StreamWriter(retseptidFail, true))
                {
                    writer.WriteLine(toit);
                }
                Console.WriteLine("toit on edukalt salvestatud!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Faili salvestamisel tekkis viga: " + ex.Message);
            }
        }

        public static void KuvatudMenyy(string failitee)
        {
            string retseptidFail = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Retseptid.txt");

            try
            {
                if (File.Exists(retseptidFail))
                {
                    string sisu = File.ReadAllText(retseptidFail);
                    Console.WriteLine("Kõik salvestatud road:");
                    Console.WriteLine(sisu);
                }
                else
                {
                    Console.WriteLine("Faili Retseptid.txt ei ole olemas.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Faili lugemisel tekkis viga: " + ex.Message);
            }
        }

        public static List<string> MuudaKoostisosad(string failitee)
        {
            string koostisosadFail = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Koostisosad.txt");
            List<string> koostisosad = new List<string>();

            try
            {
                if (File.Exists(koostisosadFail))
                {
                    koostisosad = new List<string>(File.ReadAllLines(koostisosadFail));

                    if (koostisosad.Count > 0)
                        koostisosad[0] = "Kvaliteetne oliiviõli";

                    koostisosad.Remove("Ketšup");

                    Console.WriteLine("Uuendatud koostisosade nimekiri:");
                    foreach (var item in koostisosad)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Faili töötlemisel tekkis viga: " + ex.Message);
            }

            return koostisosad;
        }

        public static void OtsiKoostisosa(List<string> koostisosad)
        {
            Console.Write("Sisesta koostisosa, mida soovid retseptist otsida: ");
            string otsitav = Console.ReadLine();

            if (koostisosad.Contains(otsitav))
            {
                Console.WriteLine("Koostisosa on olemas!");
            }
            else
            {
                Console.WriteLine("See koostisosa puudub retseptist.");
            }
        }

        public static void SalvestaKoostisosad(string failitee, List<string> koostisosad)
        {
            try
            {
                File.WriteAllLines(failitee, koostisosad);
                Console.WriteLine("Uus retsept on edukalt faili salvestatud!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Faili salvestamisel tekkis viga: " + ex.Message);
            }
        }

        public static void KuvaMenuuFailist(string failitee)
        {
            List<Tuple<string, string, double>> menyyList = new List<Tuple<string, string, double>>();

            try
            {
                if (File.Exists(failitee))
                {
                    string[] read = File.ReadAllLines(failitee);

                    foreach (string rida in read)
                    {
                        string[] osad = rida.Split(';');
                        if (osad.Length == 3)
                        {
                            string nimi = osad[0];
                            string koostisosad = osad[1];
                            double hind = double.Parse(osad[2]);
                            menyyList.Add(Tuple.Create(nimi, koostisosad, hind));
                        }
                    }

                    Console.WriteLine("\nItaalia restorani menuu:\n");
                    foreach (var roog in menyyList)
                    {
                        Console.WriteLine(roog.Item1.PadRight(30) + " " + roog.Item3 + " €");
                        Console.WriteLine("  Koostisosad: " + roog.Item2);
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Menüü lugemisel tekkis viga: " + ex.Message);
            }
        }
    }
}

