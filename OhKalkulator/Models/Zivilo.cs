﻿using System;
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
        //OhKoeficient predstavlja decimalno število gramOh/gramŽivila
        public decimal OhKoeficient { get; set; }
        // Število OH v dani količini živila se lahko izračuna iz OhKoeficienta ter Teže v gramih

        //public DomacaMera DomacaMera { get; set; }
        //public KategorijaZivila KategorijaZivila { get; set; }
    }
}