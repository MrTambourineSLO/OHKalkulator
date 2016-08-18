using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OhKalkulator.Models
{
    public class KategorijaZivila
    {
        public KategorijaZivila()
        {
            Zivila = new List<Zivilo>();
        }
        public int Id { get; set; }
        public string Ime { get; set; }
        public ICollection<Zivilo> Zivila { get; set; }

        
    }
}