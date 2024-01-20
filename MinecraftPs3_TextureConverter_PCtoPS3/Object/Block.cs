using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftPs3_TextureConverter_PCtoPS3.Object
{

    class Block
    {
        public string Nom { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Block(string nom, int x, int y)
        {
            Nom = nom;
            X = x;
            Y = y;
        }
    }
}
