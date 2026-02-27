using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static TragedyLooperClient.Grafica;

namespace TragedyLooperClient
{
    public class Gioco
    {
        public Gioco(int giorni, int cicli, PG[] pg)
        {
            GameState.Reset();
            GameState.Instance.Personaggi = pg;
            GameState.Instance.giorni = giorni;
            GameState.Instance.cicli = cicli;
        }
        public void InizioGioco()
        {
            GameState.Instance.giocoInCorso = true;

            Finestra.MouseButtonPressed += MouseClick;
            Finestra.MouseMoved += MouseMoved;

            while (Finestra.IsOpen && GameState.Instance.giocoInCorso)
            {
                Finestra.Clear();
                Disegna();
                Finestra.DispatchEvents();
                Finestra.Display();
            }
        }

        private void MouseMoved(object? sender, MouseMoveEventArgs e) //centro: 746 534
        {
            int x = e.X, y = e.Y;
            {
                for (int i = 0; i < GameState.Instance.Luoghi.Length; i++)
                {
                    for (int j = 0; j < GameState.Instance.Luoghi[i].personaggi.Count; j++)
                    {
                        var pos = new Vector2f(
                            (i % 2) * 746 + j * 160 + 60,
                            (i < 2 ? 0 : 534) + 190
                        );

                        float left = pos.X;
                        float top = pos.Y;

                        if (x >= left &&
                            x <= left + 140 &&
                            y >= top &&
                            y <= top + 200)
                        {
                            GameState.Instance.personaggio_puntato = GameState.Instance.Luoghi[i].personaggi[j];
                            Logger.WriteLine("Hover su " + GameState.Instance.personaggio_puntato.name, (int)Logger.Grades.Trace);
                            return;
                        }
                    }
                }
                GameState.Instance.personaggio_puntato = null;
                Logger.WriteLine("Hover su none", (int)Logger.Grades.Trace);
            } // verifica se passa sopra un personaggio
        }

        private void MouseClick(object? sender, MouseButtonEventArgs e) //centro: 746 534
        {
            Console.WriteLine(e.X + " " + e.Y);
        }

        void Disegna() //centro: 746 534
        {
            // Immagine mappa
            Finestra.Draw(mappa);

            //personaggi
            for (int i = 0; i < 4; i++)
            {
                Luogo luogo = GameState.Instance.Luoghi[i];
                for (int j = 0; j < luogo.personaggi.Count; j++)
                {
                    PG pg = luogo.personaggi[j];
                    //if (j == 0)
                    //pg.isAlive = false;
                    Sprite image = pg.image;
                    image.Position = new Vector2f((i % 2) * 746 + j * (image.Texture.Size.X + 20) + 60, (i < 2 ? 0 : 534) + 190);
                    if (!pg.isAlive)
                        image.Rotation = 90;
                    else
                        image.Rotation = 0;
                    Finestra.Draw(image);

                    for (int k = 0; k < pg.paranoia; k++)
                    {
                        paranoiaShape.Position = new Vector2f(pg.image.Position.X - pg.image.Origin.X + 7 * k + 25,
                                                             pg.image.Position.Y - paranoiaShape.Radius * 4 + 75);
                        Finestra.Draw(paranoiaShape);
                    }
                    for (int k = 0; k < pg.intrigo; k++)
                    {
                        intrigoShape.Position = new Vector2f(pg.image.Position.X - pg.image.Origin.X + 7 * k + 25,
                                                             pg.image.Position.Y - intrigoShape.Radius * 2 + 80);
                        Finestra.Draw(intrigoShape);
                    }
                    for (int k = 0; k < pg.collaborazione; k++)
                    {
                        collaborazioneShape.Position = new Vector2f(pg.image.Position.X - pg.image.Origin.X + 7 * k + 25,
                                                             pg.image.Position.Y + 85);
                        Finestra.Draw(collaborazioneShape);
                    }
                }
            }
        }
    }
}
