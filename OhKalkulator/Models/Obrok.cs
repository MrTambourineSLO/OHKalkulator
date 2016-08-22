using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OhKalkulator.Models
{
    public class Obrok
    {
        public Obrok()
        {
            PripravljeneJedi = new  List<PripravljenaJed>();
            DodatnaZivila = new List<Zivilo>();
        }
        public int Id { get; set; }
        public string ImeObroka { get; set; }

        public ICollection<PripravljenaJed> PripravljeneJedi { get; set; }
        public ICollection<Zivilo> DodatnaZivila { get; set; }

    }
}