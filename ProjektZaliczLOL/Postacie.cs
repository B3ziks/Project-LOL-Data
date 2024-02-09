using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczLOL
{
    [Table("Postacie")]
    public class Postacie : IPostacie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[NotMapped]
        [Column("Nazwa")]
        public string nazwaPostaci { get; set; }
        [Column("Pochodzenie")]
        public string pochodzeniePostaci { get; set; }
        [Column("Klasa")]
        public string klasaPostaci { get; set; }
        [Column("Klasa2")]
        public string klasaPostaci2 { get; set; }
        [Column("Koszt")]
        public int kosztPostaci { get; set; }
        [Column("Obrazeniaps")]
        public int obrazeniaNaSekundePostaci { get; set; }
        [Column("Predkoscat")]
        public decimal predkoscAtakuPostaci { get; set; }
        [Column("Obrazenia")]
        public int obrazeniaPostaci { get; set; }
        [Column("Zycie")]
        public int zyciePostaci { get; set; }
        [Column("Mana")]
        public int manaPostaci { get; set; }
        [Column("Pancerz")]
        public int pancerzPostaci { get; set; }
        [Column("Odpornosc")]
        public int odpornoscPostaci { get; set; }
    }
    public class NotMap : ClassMap<Postacie>
    {
        public NotMap()
        {
            Map(m => m.nazwaPostaci).Name("Champion");
            Map(m => m.pochodzeniePostaci).Name("Origin");
            Map(m => m.klasaPostaci).Name("Class");
            Map(m => m.klasaPostaci2).Name("Class2");
            Map(m => m.kosztPostaci).Name("Cost");
            Map(m => m.obrazeniaNaSekundePostaci).Name("DamagePerSecond");
            Map(m => m.predkoscAtakuPostaci).Name("AttackSpeed");
            Map(m => m.obrazeniaPostaci).Name("Damage");
            Map(m => m.zyciePostaci).Name("HP");
            Map(m => m.manaPostaci).Name("Mana");
            Map(m => m.pancerzPostaci).Name("Armor");
            Map(m => m.odpornoscPostaci).Name("MagicResist");
        }
    }
}
