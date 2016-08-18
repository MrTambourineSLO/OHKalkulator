using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OhKalkulator.Models
{
    public class DomacaMera
    {
        public DomacaMera()
        {
            Zivila = new List<Zivilo>();
        }
        public int Id { get; set; }
        // ImeMere je lahko recimo, žlica, šeflja, skodelica itd, lahko tudi cm (če gre za premer, recimo pice)
        public string ImeMere { get; set; }
        // Razmerje se nanaša na "domačo" enoto
        // npr: 1/2[Kolicina] kosa[ImeMere], 1/6[Kolicina] štruce[ImeMere], 38[Kolicina] cm2[ImeMere]...
        public decimal Razmerje { get; set; }
       

        public ICollection<Zivilo> Zivila { get; set; }
    }
}