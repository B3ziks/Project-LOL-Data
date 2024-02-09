using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczLOL
{
    public class PosDane
    {
        public static void ZapiszPostacie(List<Postacie> postacie)
        {
            if (postacie != null)
            {
                using (var db = new PosContext())
                {
                    foreach (Postacie n in postacie)
                    {
                        db.Postacie.Add(n);
                    }
                    db.SaveChanges();
                }
            }
        }
        public static List<Postacie> PobierzPostacie()
        {
            List<Postacie> postacie = null;
            using (var db = new PosContext())
            {
                postacie = db.Postacie.ToList();
            }
            return postacie;
        }
        
        public static List<Postacie> OdczytajPostacieWgPochodzenia(string pochodzenie)
        {
            List<Postacie> postacie = null;
            using (var db = new PosContext())
            {
                postacie = db.Postacie.Where(w => w.pochodzeniePostaci == pochodzenie).ToList();
            }
            Console.WriteLine($"Postacie pochodzące z \"{pochodzenie}\":");
            foreach (Postacie pk in postacie)
            {
                if (pk.pochodzeniePostaci.Contains(pochodzenie) )
                {
                    Console.WriteLine($"{pk.nazwaPostaci}");
                }
            }
            return postacie;
        }
        
        public static List<Postacie> OdczytajPostacieWedlugKosztow(int koszt)
        {
            List<Postacie> postacie = null;
            using (var db = new PosContext())
            {
                postacie = db.Postacie.Where(w => w.kosztPostaci > koszt).ToList();
            }
            Console.WriteLine($"Postacie kosztujące więcej niż {koszt}: ");
            foreach (Postacie pk in postacie)
            {
                if (pk.kosztPostaci > koszt)
                {
                     Console.WriteLine($"{pk.nazwaPostaci}{pk.kosztPostaci}");
                }
            }
            
            return postacie;
        }
        public static List<Postacie> OdczytajPostacieWedlugZycia(int zycieOd, int zycieDo)
        {
            List<Postacie> postacie = null;
            using (var db = new PosContext())
            {
                postacie = db.Postacie.Where(w => w.zyciePostaci > zycieOd && w.zyciePostaci < zycieDo).ToList();
            }
            Console.WriteLine($"Postacie mające zycie pomiędzy {zycieOd} a {zycieDo} życia");
            foreach (Postacie pk in postacie)
            {
                if (pk.zyciePostaci > zycieOd && pk.zyciePostaci < zycieDo)
                {
                    Console.WriteLine($"{pk.nazwaPostaci}");
                }
            }

            return postacie;
        }
        public static List<Postacie> WylosujPostacOPodanejManie(int mana)
        {
            List<Postacie> postacie = null;
            using (var db = new PosContext())
            {
                postacie = db.Postacie.Where(w => w.manaPostaci == mana).ToList();
            }
            Console.WriteLine($"Losowa postać mająca {mana} many:");
            var random = new Random();

            int index = random.Next(postacie.Count);
            Console.WriteLine(postacie[index].nazwaPostaci);

            return postacie;
        }
        public static List<Postacie> OdczytajPostacieWedlugDefensywy()
        {
            List<Postacie> postacie = null;
            using (var db = new PosContext())
            {
                postacie = db.Postacie.Where(w => w.pancerzPostaci > w.obrazeniaNaSekundePostaci || w.pancerzPostaci < w.obrazeniaNaSekundePostaci).ToList();
            }
            Console.WriteLine($"Postacie mające więcej pancerza niż obrażeń:");
            foreach (Postacie pk in postacie)
            {
                if (pk.pancerzPostaci > pk.obrazeniaNaSekundePostaci)
                {
                    Console.WriteLine($"{pk.nazwaPostaci}");
                }
            }
            Console.WriteLine($"\nPostacie mające więcej obrażeń niż pancerza:");
            foreach (Postacie pk in postacie)
            {
                if (pk.obrazeniaNaSekundePostaci > pk.pancerzPostaci )
                {
                    Console.WriteLine($"{pk.nazwaPostaci}");
                }
            }
            return postacie;
        }
        public static List<Postacie> OdczytajPostacieWedlugPredkosciAtaku()
        {
            List<Postacie> postacie = null;

            using (var db = new PosContext())
            {
                postacie = db.Postacie.ToList();
            }
            var a = postacie.Max(w => w.predkoscAtakuPostaci);
            var b = postacie.Min(w => w.predkoscAtakuPostaci);

            Console.WriteLine($"\nPostacie z największą prędkością ataku ({decimal.Round(a, 2)}):");
            foreach (Postacie pk in postacie)
            {
                if (pk.predkoscAtakuPostaci == a)
                {
                    Console.WriteLine($"{pk.nazwaPostaci}");
                }
            }
            Console.WriteLine($"\nPostacie z najmniejszą prędkością ataku ({decimal.Round(b,2)}):");
            foreach (Postacie pk in postacie)
            {
                if (pk.predkoscAtakuPostaci == b)
                {
                    Console.WriteLine($"{pk.nazwaPostaci}");
                }
            }

            return postacie;
        }
    }
}
