using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OhKalkulator.Models
{
    public class Zivilo
    {
        public int Id { get; set; }
        public int SifraGorenje { get; set; }
        public string Ime { get; set; }
        public int TezaVGramih { get; set; }
        public decimal OhKoeficient { get; set; }
        //public DomacaMera DomacaMera { get; set; }
        //public KategorijaZivila KategorijaZivila { get; set; }
    }
}