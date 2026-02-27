using System;
using System.Collections.Generic;
using System.Text;

namespace TragedyLooperClient
{
    static public class Abilita
    {
        #region abilità pg
        static void ParanoiaStudenteLuogo(PG pg)
        {
            if (pg.collaborazione < 2 || rifiutaAbilita(pg)) return;

            PG[] studenti;
            Luogo? luogo = GameState.Instance.GetLuogoByPG(pg);
            if (luogo == null) return;
            studenti = luogo.personaggi.Where(p => p.tag.Contains("studente") && p != pg && p.isAlive && p.paranoia > 0).ToArray();
            if (studenti.Length == 0)
                return;

            PG studente;
            {
                studente = studenti[0];
            } // scelta dello studente da parte del giocatore

            studente.paranoia--;
        }
        private static void CollaborazioneLuogo3(PG pg)
        {
            if(pg.collaborazione < 3 || rifiutaAbilita(pg)) return;
            Luogo? luogo = GameState.Instance.GetLuogoByPG(pg);
            if (luogo == null || (luogo.id < 3)) return;
            PG[] personaggi = luogo.personaggi.Where(p => p.isAlive).ToArray();

            PG personaggio;
            {
                personaggio = personaggi[0];
            } // scelta dello studente da parte del giocatore

            personaggio.collaborazione++;
        }
        private static void CollaborazioneLuogo4(PG pg)
        {
            if (pg.collaborazione < 4 || rifiutaAbilita(pg)) return;
            Luogo? luogo = GameState.Instance.GetLuogoByPG(pg);
            if (luogo == null) return;
            PG[] personaggi = luogo.personaggi.Where(p => p.isAlive && p != pg).ToArray();
            if (personaggi.Length == 0)
                return;

            PG personaggio;
            {
                personaggio = personaggi[0];
            } // scelta dello studente da parte del giocatore

            personaggio.collaborazione++;
        }
        private static void ResuscitaPersonaggioLuogo(PG pg)
        {
            if (pg.collaborazione < 5 || rifiutaAbilita(pg)) return;
            Luogo? luogo = GameState.Instance.GetLuogoByPG(pg);
            if (luogo == null) return;
            PG[] personaggi = luogo.personaggi.Where(p => !p.isAlive).ToArray();
            if (personaggi.Length == 0)
                return;

            PG personaggio;
            {
                personaggio = personaggi[0];
            } // scelta dello studente da parte del giocatore

            personaggio.isAlive = true;
        }
        private static void UccidiPersonaggioLuogo(PG pg)
        {
            if (pg.collaborazione < 4 || rifiutaAbilita(pg)) return;
            Luogo? luogo = GameState.Instance.GetLuogoByPG(pg);
            if (luogo == null) return;
            PG[] personaggi = luogo.personaggi.Where(p => p.isAlive).ToArray();

            PG personaggio;
            {
                personaggio = personaggi[0];
            } // scelta dello studente da parte del giocatore

            personaggio.isAlive = false;
        }
        private static void RivelaRuoloLuogo(PG pg)
        {
            if (pg.collaborazione < 5 || rifiutaAbilita(pg)) return;
            Luogo? luogo = GameState.Instance.GetLuogoByPG(pg);
            if (luogo == null) return;
            List<PG> personaggi = luogo.personaggi;

            PG personaggio;
            {
                personaggio = personaggi[0];
            } // scelta dello studente da parte del giocatore

            {
                Console.WriteLine(personaggio.ruolo.name);
            } // rivelazione del ruolo del personaggio scelto da parte del giocatore
        }
        private static void IntrigoSantuario(PG pg)
        {
            if (pg.collaborazione < 3 || rifiutaAbilita(pg)) return;
            Luogo? luogo = GameState.Instance.GetLuogoByPG(pg);
            if (luogo == null || luogo.id != 2) return;
            luogo.intrigo--;
        }
        private static void RivelaRuoloMistero(PG pg)
        {
            if (pg.collaborazione < 3 || GameState.Instance.ciclo < 2) return;

            {
                Console.WriteLine(pg.ruolo.name);
            } // rivelazione del ruolo del personaggio
        }
        private static void LeaderCarta(PG pg) // da fare dopo aver definito il mazzo di carte e le regole per l'utilizzo delle stesse
        {
            // il leader riprende in mano una carta utilizzabile una sola volta (tra quelle già usate)
        }
        private static void ParanoiaLuogo(PG pg)
        {
            if (pg.collaborazione < 3 || rifiutaAbilita(pg)) return;

            PG[] personaggi;
            Luogo? luogo = GameState.Instance.GetLuogoByPG(pg);
            if (luogo == null) return;
            personaggi = luogo.personaggi.Where(p => p != pg && p.isAlive && p.paranoia > 0).ToArray();
            if (personaggi.Length == 0)
                return;

            PG personaggio;
            {
                personaggio = personaggi[0];
            } // scelta dello studente da parte del giocatore

            personaggio.paranoia--;
        }
        private static void NominaTrama(PG pg) // da fare dopo aver definito le trame e le regole per l'utilizzo delle stesse
        {
            // i protagonisti nominano una trama, poi il master ne nomina una attiva diversa da quella nominata
        }
        private static void RivelaRuolo(PG pg)
        {
            if (pg.collaborazione < 3 || rifiutaAbilita(pg)) return;

            {
                Console.WriteLine(pg.ruolo.name);
            } // rivelazione del ruolo del personaggio
        }
        private static void SegnalinoExtra(PG pg)
        {
            if (pg.collaborazione < 5 || rifiutaAbilita(pg)) return;

            PG[] personaggi;
            Luogo? luogo = GameState.Instance.GetLuogoByPG(pg);
            if (luogo == null) return;
            personaggi = luogo.personaggi.Where(p => p.isAlive).ToArray();
            if (personaggi.Length == 0)
                return;

            PG personaggio;
            {
                personaggio = personaggi[0];
            } // scelta dello studente da parte del giocatore

            personaggio.protetto = true;
        }
        private static void RivelaColpevoleIncidenteAvvenuto(PG pg) // da fare dopo aver definito le regole per gli incidenti
        {
            // rivela il colpevole di un incidente avvenuto in questo ciclo
        }
        private static void IntrigoPersonaggioLuogo(PG pg)
        {
            if (pg.collaborazione < 5 || rifiutaAbilita(pg)) return;

            PG[] personaggi;
            Luogo? luogo = GameState.Instance.GetLuogoByPG(pg);
            if (luogo == null) return;
            personaggi = luogo.personaggi.Where(p => p.isAlive && p.intrigo > 0).ToArray();
            if (personaggi.Length == 0)
                return;

            PG personaggio;
            bool sceltoLuogo = false;
            {
                personaggio = personaggi[0];
            } // scelta del personaggio o del luogo da parte del giocatore

            if (sceltoLuogo) luogo.intrigo--;
            else personaggio.intrigo--;
        }
        private static void RivelaColpevoleIncidente(PG pg) // da fare dopo aver definito le regole per gli incidenti
        {
            // rivela il colpevole di un incidente
        }
        private static void NoIncidenti(PG pg)
        {
            // in questo ciclo il pg non innesca più nessun incidente
        }
        private static void ParanoiaPanicoLuogo(PG pg)
        {
            if (pg.collaborazione < 2) return;

            PG[] personaggi;
            Luogo? luogo = GameState.Instance.GetLuogoByPG(pg);
            if (luogo == null) return;
            personaggi = luogo.personaggi.Where(p => p != pg && p.isAlive && p.paranoia > 0 && p.paranoia >= p.limite_paranoia).ToArray();
            if (personaggi.Length == 0)
                return;

            PG personaggio;
            {
                personaggio = personaggi[0];
            } // scelta dello studente da parte del giocatore

            personaggio.paranoia--;
        }
        private static void MuoviPaziente(PG pg) // da fare dopo aver definito le regole per i movimenti
        {
            // il paziente può uscire dall'ospedale in questo ciclo
        }
        private static void PiuMenoParanoiaLuogo(PG pg)
        {
            if (pg.collaborazione < 2 || rifiutaAbilita(pg)) return;

            PG[] personaggi;
            Luogo? luogo = GameState.Instance.GetLuogoByPG(pg);
            if (luogo == null) return;
            personaggi = luogo.personaggi.Where(p => p != pg && p.isAlive).ToArray();
            if (personaggi.Length == 0)
                return;

            PG personaggio;
            bool sceltoAumentare = false;
            {
                personaggio = personaggi[0];
            } // scelta del personaggio e se aumentare o levare paranoia da parte del giocatore

            if (sceltoAumentare) personaggio.paranoia++;
            else personaggio.paranoia--;
        }
        private static void RivelaRuoloTerritorio(PG pg) // da fare dopo aver definito le regole per il territorio del boss
        {
            // rivela il ruolo di un personaggio nel territorio del boss
        }
        private static void PiuIntrigoPersonaggioLuogo(PG pg)
        {
            if (pg.collaborazione < 2 || rifiutaAbilita(pg)) return;

            PG[] personaggi;
            Luogo? luogo = GameState.Instance.GetLuogoByPG(pg);
            if (luogo == null) return;
            personaggi = luogo.personaggi.Where(p => p.isAlive).ToArray();
            if (personaggi.Length == 0)
                return;

            PG personaggio;
            bool sceltoLuogo = false;
            {
                personaggio = personaggi[0];
            } // scelta del personaggio o del luogo da parte del giocatore

            if (sceltoLuogo) luogo.intrigo++;
            else personaggio.intrigo++;
        }
        private static void PiuParanoia(PG pg)
        {
            if (pg.collaborazione < 2 || rifiutaAbilita(pg)) return;

            PG[] personaggi;
            personaggi = GameState.Instance.Personaggi.Where(p => p != pg && p.isAlive).ToArray();
            if (personaggi.Length == 0)
                return;

            PG personaggio;
            {
                personaggio = personaggi[0];
            } // scelta dello studente da parte del giocatore

            personaggio.paranoia++;
        }
        public static Dictionary<AbilitaPGId, Action<PG>> abilitaPG = new()
        {
            { AbilitaPGId.ParanoiaStudenteLuogo, pg => ParanoiaStudenteLuogo(pg) },
            { AbilitaPGId.CollaborazioneLuogo3, pg => CollaborazioneLuogo3(pg) },
            { AbilitaPGId.LeaderCarta, pg => LeaderCarta(pg) },
            { AbilitaPGId.RivelaRuoloMistero, pg => RivelaRuoloMistero(pg) },
            { AbilitaPGId.IntrigoSantuario, pg => IntrigoSantuario(pg) },
            { AbilitaPGId.RivelaRuoloLuogo, pg => RivelaRuoloLuogo(pg) },
            { AbilitaPGId.UccidiPersonaggioLuogo, pg => UccidiPersonaggioLuogo(pg) },
            { AbilitaPGId.ResuscitaPersonaggioLuogo, pg => ResuscitaPersonaggioLuogo(pg) },
            { AbilitaPGId.RivelaColpevoleIncidente, pg => RivelaColpevoleIncidente(pg) },
            { AbilitaPGId.IntrigoPersonaggioLuogo, pg => IntrigoPersonaggioLuogo(pg) },
            { AbilitaPGId.RivelaColpevoleIncidenteAvvenuto, pg => RivelaColpevoleIncidenteAvvenuto(pg) },
            { AbilitaPGId.SegnalinoExtra, pg => SegnalinoExtra(pg) },
            { AbilitaPGId.RivelaRuolo, pg => RivelaRuolo(pg) },
            { AbilitaPGId.NominaTrama, pg => NominaTrama(pg) },
            { AbilitaPGId.ParanoiaLuogo, pg => ParanoiaLuogo(pg) },
            { AbilitaPGId.CollaborazioneLuogo4, pg => CollaborazioneLuogo4(pg) },
            { AbilitaPGId.PiuParanoia, pg => PiuParanoia(pg) },
            { AbilitaPGId.PiuIntrigoPersonaggioLuogo, pg => PiuIntrigoPersonaggioLuogo(pg) },
            { AbilitaPGId.RivelaRuoloTerritorio, pg => RivelaRuoloTerritorio(pg) },
            { AbilitaPGId.PiuMenoParanoiaLuogo, pg => PiuMenoParanoiaLuogo(pg) },
            { AbilitaPGId.MuoviPaziente, pg => MuoviPaziente(pg) },
            { AbilitaPGId.ParanoiaPanicoLuogo, pg => ParanoiaPanicoLuogo(pg) },
            { AbilitaPGId.NoIncidenti, pg => NoIncidenti(pg) }
        };
        public enum AbilitaPGId
        {
            ParanoiaStudenteLuogo,
            CollaborazioneLuogo3,
            LeaderCarta,
            RivelaRuoloMistero,
            IntrigoSantuario,
            RivelaRuoloLuogo,
            UccidiPersonaggioLuogo,
            ResuscitaPersonaggioLuogo,
            RivelaColpevoleIncidente,
            IntrigoPersonaggioLuogo,
            RivelaColpevoleIncidenteAvvenuto,
            SegnalinoExtra,
            RivelaRuolo,
            NominaTrama,
            ParanoiaLuogo,
            CollaborazioneLuogo4,
            PiuParanoia,
            PiuIntrigoPersonaggioLuogo,
            RivelaRuoloTerritorio,
            PiuMenoParanoiaLuogo,
            MuoviPaziente,
            ParanoiaPanicoLuogo,
            NoIncidenti
        }

        static bool rifiutaAbilita(PG pg)
        {
            return false;
        }

        #endregion
        #region abilità ruolo
        public static Dictionary<AbilitaRId, Action<PG>> abilitaR = new()
        {
            { AbilitaRId.ParanoiaStudenteLuogo, pg => ParanoiaStudenteLuogo(pg) },
            { AbilitaRId.CollaborazioneLuogo3, pg => CollaborazioneLuogo3(pg) },
            { AbilitaRId.LeaderCarta, pg => LeaderCarta(pg) },
            { AbilitaRId.RivelaRuoloMistero, pg => RivelaRuoloMistero(pg) },
            { AbilitaRId.IntrigoSantuario, pg => IntrigoSantuario(pg) },
            { AbilitaRId.RivelaRuoloLuogo, pg => RivelaRuoloLuogo(pg) },
            { AbilitaRId.UccidiPersonaggioLuogo, pg => UccidiPersonaggioLuogo(pg) },
            { AbilitaRId.ResuscitaPersonaggioLuogo, pg => ResuscitaPersonaggioLuogo(pg) },
            { AbilitaRId.RivelaColpevoleIncidente, pg => RivelaColpevoleIncidente(pg) },
            { AbilitaRId.IntrigoPersonaggioLuogo, pg => IntrigoPersonaggioLuogo(pg) },
            { AbilitaRId.RivelaColpevoleIncidenteAvvenuto, pg => RivelaColpevoleIncidenteAvvenuto(pg) },
            { AbilitaRId.SegnalinoExtra, pg => SegnalinoExtra(pg) },
            { AbilitaRId.RivelaRuolo, pg => RivelaRuolo(pg) },
            { AbilitaRId.NominaTrama, pg => NominaTrama(pg) },
            { AbilitaRId.ParanoiaLuogo, pg => ParanoiaLuogo(pg) },
            { AbilitaRId.CollaborazioneLuogo4, pg => CollaborazioneLuogo4(pg) },
            { AbilitaRId.PiuParanoia, pg => PiuParanoia(pg) },
            { AbilitaRId.PiuIntrigoPersonaggioLuogo, pg => PiuIntrigoPersonaggioLuogo(pg) },
            { AbilitaRId.RivelaRuoloTerritorio, pg => RivelaRuoloTerritorio(pg) },
            { AbilitaRId.PiuMenoParanoiaLuogo, pg => PiuMenoParanoiaLuogo(pg) },
            { AbilitaRId.MuoviPaziente, pg => MuoviPaziente(pg) },
            { AbilitaRId.ParanoiaPanicoLuogo, pg => ParanoiaPanicoLuogo(pg) },
            { AbilitaRId.NoIncidenti, pg => NoIncidenti(pg) }
        };
        public enum AbilitaRId
        {
            ParanoiaStudenteLuogo,
            CollaborazioneLuogo3,
            LeaderCarta,
            RivelaRuoloMistero,
            IntrigoSantuario,
            RivelaRuoloLuogo,
            UccidiPersonaggioLuogo,
            ResuscitaPersonaggioLuogo,
            RivelaColpevoleIncidente,
            IntrigoPersonaggioLuogo,
            RivelaColpevoleIncidenteAvvenuto,
            SegnalinoExtra,
            RivelaRuolo,
            NominaTrama,
            ParanoiaLuogo,
            CollaborazioneLuogo4,
            PiuParanoia,
            PiuIntrigoPersonaggioLuogo,
            RivelaRuoloTerritorio,
            PiuMenoParanoiaLuogo,
            MuoviPaziente,
            ParanoiaPanicoLuogo,
            NoIncidenti
        }
        #endregion
    }
}