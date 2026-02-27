using System;
using System.Collections.Generic;
using System.Text;
using static TragedyLooperClient.Grafica;

namespace TragedyLooperClient
{
    public class GameState
    {
        public bool giocoInCorso = false;

        public int giorno, giorni;
        public int ciclo, cicli;

        private PG[] personaggi = [];
        public Luogo[] Luoghi;

        public PG[] Personaggi
        {
            get => personaggi;
            set
            {
                personaggi = value;
                foreach (PG pg in personaggi)
                    Luoghi[pg.partenza - 1].personaggi.Add(pg);
            }
        }

        public PG? personaggio_puntato = null;

        public PG GetPGById(int id)
        {
            return Personaggi.First(p => p.id == id);
        }
        public Luogo GetLuogoById(int id)
        {
            return Luoghi.First(l => l.id == id);
        }
        public Luogo? GetLuogoByPG(PG pg)
        {
            foreach (Luogo luogo in Luoghi)
                if (luogo.personaggi.Contains(pg))
                    return luogo;
            return null;
        }

        public enum Scena
        {
            inizio_ciclo,
            inizio_giorno,
            posizionamento_carte,
            risoluzione_carte,
            attivazione_abilita,
            inicidenti,
            fine_giorno,
            fine_ciclo,
            finale_negativo,
            fine_gioco
        }

        #region singleton
        static private object _lock = new();
        static private GameState? instance = null;
        static public GameState Instance
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new GameState();
                    return instance;
                }
            }
        }
        public static void Reset()
        {
            lock (_lock)
                instance = null;
        }
        private GameState()
        {
            Luoghi = [new (1, "Ospedale"), new (2, "Santuario"), new (3, "Citta"), new (4, "Scuola")];
        }
        #endregion
    }
}
