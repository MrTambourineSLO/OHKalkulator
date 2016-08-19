using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OhKalkulator.Models
{
    public class PripravljenaJed
    {
        public PripravljenaJed()
        {
            Zivila = new List<Zivilo>();
        }
        public int Id { get; set; }
        public string Ime { get; set; }
        public ICollection<Zivilo> Zivila { get; set; }
        public ICollection<Obrok> Obroki { get; set; } 
    }
}