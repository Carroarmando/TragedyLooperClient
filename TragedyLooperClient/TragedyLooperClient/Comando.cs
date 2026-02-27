using System;
using System.Collections.Generic;
using System.Text;

namespace TragedyLooperClient
{
    public class Comando
    {
        public string Azione { get; set; }
        public int? IdPersonaggio { get; set; }
        public string? NomeAbilita { get; set; }
        public int? IdLuogo { get; set; }
        public int? IdCarta { get; set; }
        public int? IdRuolo { get; set; }
        public int? IdSegnalino { get; set; }
        public bool? Conferma { get; set; }
        public int? IdGiocatore { get; set; }
    }
}
