using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczLOL
{
    public interface IPostacie
    {
        string nazwaPostaci { get; set; }
        string pochodzeniePostaci { get; set; }
        string klasaPostaci { get; set; }
        string klasaPostaci2 {get;set;}
        int kosztPostaci { get; set; }
        int obrazeniaNaSekundePostaci { get; set; }
        decimal predkoscAtakuPostaci { get; set; }
        int obrazeniaPostaci { get; set; } 
        int zyciePostaci { get; set; }
        int manaPostaci { get; set; }
        int pancerzPostaci { get; set; }
        int odpornoscPostaci { get; set; }

    }
}
