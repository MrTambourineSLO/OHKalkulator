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
            Obroki = new List<Obrok>();
        }
        public int Id { get; set; }
        public string Ime { get; set; }
        public ICollection<Zivilo> Zivila { get; set; }
        public ICollection<Obrok> Obroki { get; set; }
        //Vsako Pripravljeno jed si lasti po en uporabnik
        public string UporabnikId { get; set; }
        public ApplicationUser Uporabnik { get; set; }
    }
}