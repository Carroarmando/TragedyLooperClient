using System;
using System.Collections.Generic;
using System.Text;

namespace TragedyLooperClient
{
    public class Luogo
    {
        public readonly int id;
        public readonly string name;
        public int intrigo = 0;
        public List<PG> personaggi = new List<PG>();
        public Luogo(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
