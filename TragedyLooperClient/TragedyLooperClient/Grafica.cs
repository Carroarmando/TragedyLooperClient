using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace TragedyLooperClient
{
    static class Grafica
    {
        public const int LARGHEZZA = 1498;
        public const int ALTEZZA = 1069;
        public static VideoMode Schermo = new VideoMode(LARGHEZZA, ALTEZZA);
        public static RenderWindow Finestra = new RenderWindow(Schermo, "Tragedy Looper");

        public static Sprite mappa = new Sprite(new Texture(@"..\..\..\Immagini\Mappa.png"), new IntRect(0, 0, 1498, 1069));

        public static CircleShape paranoiaShape = new CircleShape(10)
        {
            FillColor = new Color(120, 20, 130),
            OutlineThickness = 2,
            OutlineColor = new Color(90, 10, 120),
        };
        public static CircleShape intrigoShape = new CircleShape(10)
        {
            FillColor = new Color(130, 100, 0),
            OutlineThickness = 2,
            OutlineColor = new Color(60, 60, 0),
        };
        public static CircleShape collaborazioneShape = new CircleShape(10)
        {
            FillColor = new Color(190, 8, 144),
            OutlineThickness = 2,
            OutlineColor = new Color(135, 54, 81),
        };
    }
}
