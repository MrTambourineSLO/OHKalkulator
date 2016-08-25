using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace OhKalkulator.Models
{
    public class DnevnikPrehranjevanja
    {
        public int Id { get; set; }
        public DateTime? Datum { get; set; }
        public TipObroka TipObroka { get; set; }
        public Obrok Obrok { get; set; }
        public ApplicationUser Uporabnik { get; set; }




    }

    public enum TipObroka
    {
        Zajtrk = 1,
        Kosilo = 2,
        Vecerja = 3,
        Malica = 4
    }
}