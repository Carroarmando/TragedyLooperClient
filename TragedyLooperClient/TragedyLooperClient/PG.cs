using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using static TragedyLooperClient.Abilita;

namespace TragedyLooperClient
{
    public class PG
    {
        public readonly int id;
        public readonly string name;
        public int paranoia = 1;
        public int collaborazione = 1;
        public int intrigo = 1;
        public readonly int limite_paranoia;
        public readonly string[] tag;
        public Ruolo ruolo;
        public bool isAlive = true, protetto = false;
        public Dictionary<AbilitaPGId, Action<PG>> abilita = new Dictionary<AbilitaPGId, Action<PG>>();
        public int partenza;

        public Sprite? image;

        public PG(PGData data)
        {
            id = data.id;
            name = data.name;
            limite_paranoia = data.limite_paranoia;
            tag = data.tag;
            foreach (AbilitaPGId abilita in data.abilita)
                this.abilita.Add(abilita, abilitaPG[abilita]);
            partenza = data.partenza;

            if (File.Exists(@$"..\..\..\Immagini\{name}.png"))
                image = new Sprite(new Texture(@$"..\..\..\Immagini\{name}.png"), new IntRect(0, 0, 140, 200));
            else
                image = null;
        }
        public static PG[] Personaggi(int[] id)
        {
            List<PG> personaggi = new List<PG>();
            foreach (int i in id)
                personaggi.Add(new PG(PG.personaggi[i]));
            return personaggi.ToArray();
        }
        public static Dictionary<int, PGData> personaggi = new Dictionary<int, PGData>()
        {
            { 1, new PGData(1, "Giovane Studente", 2, ["studente", "ragazzo"], [AbilitaPGId.ParanoiaStudenteLuogo], 4) },
            { 2, new PGData(2, "Giovane Studentessa", 3, ["studente", "ragazza"], [AbilitaPGId.ParanoiaStudenteLuogo], 4) },
            { 3, new PGData(3, "Figlia Benestante", 1, ["studente", "ragazza"], [AbilitaPGId.CollaborazioneLuogo3], 4) },
            { 4, new PGData(4, "Rappresentante di Classe", 3, ["studente", "ragazza"], [AbilitaPGId.LeaderCarta], 4) },
            { 5, new PGData(5, "Ragazzo del Mistero", 3,["studente", "ragazzo"],[AbilitaPGId.RivelaRuoloMistero], 4) },
            { 6, new PGData(6, "Sacerdotessa", 2, ["studente", "ragazza"], [AbilitaPGId.IntrigoSantuario, AbilitaPGId.RivelaRuoloLuogo], 2) },
            { 7, new PGData(7, "Extraterrestre", 2, ["ragazza"], [AbilitaPGId.UccidiPersonaggioLuogo, AbilitaPGId.ResuscitaPersonaggioLuogo], 2) },
            { 8, new PGData(8, "Divinita", 3,["uomo", "donna"],[AbilitaPGId.RivelaColpevoleIncidente, AbilitaPGId.IntrigoPersonaggioLuogo], 2) },
            { 9, new PGData(9, "Agente di Polizia", 3,["adulto", "uomo"],[AbilitaPGId.RivelaColpevoleIncidenteAvvenuto, AbilitaPGId.SegnalinoExtra], 3) },
            { 10, new PGData(10, "Impiegato", 2,["adulto", "uomo"],[AbilitaPGId.RivelaRuolo], 3) },
            { 11, new PGData(11, "Informatrice", 3,["adulto", "donna"],[AbilitaPGId.NominaTrama], 3) },
            { 12, new PGData(12, "Idol", 2,["studente", "ragazza"],[AbilitaPGId.ParanoiaLuogo, AbilitaPGId.CollaborazioneLuogo4], 3) },
            { 13, new PGData(13, "Giornalista", 2,["adulto", "uomo"],[AbilitaPGId.PiuParanoia, AbilitaPGId.PiuIntrigoPersonaggioLuogo], 3) },
            { 14, new PGData(14, "Boss", 4,["adulto", "uomo"],[AbilitaPGId.RivelaRuoloTerritorio], 3) },
            { 15, new PGData(15, "Dottore", 2,["adulto", "uomo"],[AbilitaPGId.PiuMenoParanoiaLuogo, AbilitaPGId.MuoviPaziente], 1) },
            { 16, new PGData(16, "Paziente", 2, ["ragazzo"], [], 1) },
            { 17, new PGData(17, "Infermiera", 3,["adulto", "uomo"],[AbilitaPGId.ParanoiaPanicoLuogo], 1) },
            { 18, new PGData(18, "Assistente", 1,["adulto", "donna"],[AbilitaPGId.NoIncidenti], 0) },
        };
    }
    public record PGData(int id, string name, int limite_paranoia, string[] tag, AbilitaPGId[] abilita, int partenza);
}