using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczLOL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Postacie> wszystkiePostacie = new List<Postacie>();
            PobierzPostacie(@"Pliki\tftchar.csv", wszystkiePostacie);

            Console.WriteLine("********* Wprowadzenie listy postaci do bazy *******");
            
            //PosDane.ZapiszPostacie(wszystkiePostacie);
            Console.WriteLine("********* Pobranie listy postaci z bazy *******");
            List<Postacie> zBazy = PosDane.PobierzPostacie();
            //
            Console.WriteLine($"\n********* ODCZYTANIE POSTACI WEDŁUG POCHODZENIA *******\n");
            List<Postacie> wgPochodzenia = PosDane.OdczytajPostacieWgPochodzenia("Void");
            //Console.Write(string.Join(System.Environment.NewLine, postacie.Inv));
            Postacie postacie = new Postacie();
            //
            Console.WriteLine($"=================\nłącznie: {wgPochodzenia.Count}");
            Console.WriteLine($"\n********* ODCZYTANIE POSTACI WEDŁUG KOSZTÓW *******\n");
            List<Postacie> wgKosztow = PosDane.OdczytajPostacieWedlugKosztow(2);
            Console.WriteLine($"=================\nłącznie: {wgKosztow.Count}");
            //
            Console.WriteLine($"\n********* ODCZYTANIE POSTACI WEDŁUG ŻYCIA *******\n");
            List<Postacie> wgZycia = PosDane.OdczytajPostacieWedlugZycia(400,600);
            Console.WriteLine($"=================\nłącznie: {wgZycia.Count}");
            //
            Console.WriteLine($"\n********* ODCZYTANIE POSTACI WEDŁUG MANY *******\n");
            List<Postacie> wgMany = PosDane.WylosujPostacOPodanejManie(75);
          //  Console.WriteLine($"=================\nłącznie: {wgMany.Count}");
            //
            Console.WriteLine($"\n********* ODCZYTANIE POSTACI WEDŁUG DEFENSYWY/ATAKU *******\n");
            List<Postacie> wgDefensywy = PosDane.OdczytajPostacieWedlugDefensywy();
            //Console.WriteLine($"=================\nłącznie: {wgDefensywy.Count}");
            Console.WriteLine($"\n********* ODCZYTANIE POSTACI WEDŁUG PRĘDKOŚCI ATAKU *******\n");
            List<Postacie> wgPredkosci = PosDane.OdczytajPostacieWedlugPredkosciAtaku();
            //Console.WriteLine($"=================\nłącznie: {wgDefensywy.Count}");

            Console.ReadKey();
        }

        public static List<Postacie> PobierzPostacie(string plik, List<Postacie> postacie)
        {
            List<Postacie> listaPostaci = null;
            if (File.Exists(plik))
            {
                using (var reader = new StreamReader(plik))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<NotMap>();
                    listaPostaci = csv.GetRecords<Postacie>().ToList();
                    if (postacie != null)
                        postacie.AddRange(listaPostaci);
                }
            }
            return listaPostaci;
        }
    }
}
