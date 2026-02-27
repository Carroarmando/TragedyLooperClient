using System;
using System.Collections.Generic;
using System.Text;
using static TragedyLooperClient.Abilita;

namespace TragedyLooperClient
{
    public class Ruolo
    {
        public readonly int id;
        public readonly string name;
        public readonly int rifiuto;
        public Dictionary<AbilitaRId, Action<PG>> abilita;
        public Ruolo(RuoloData data)
        {
            id = data.Id;
            name = data.Name;
            rifiuto = data.Rifiuto;
            foreach (AbilitaRId abilita in data.Abilita)
                this.abilita.Add(abilita, abilitaR[abilita]);
        }
        public static Dictionary<int, RuoloData> ruoli = new()
        {
            {0, new RuoloData(0, "Persona", 0, [])},
            {1, new RuoloData(1, "Persona Chiave", 0, [])},
        };
    }
    public record RuoloData(int Id, string Name, int Rifiuto, AbilitaRId[] Abilita);
}