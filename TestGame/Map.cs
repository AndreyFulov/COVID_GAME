using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestGame
{
    class Map
    {
        public Tile grass = new Tile("Grass");

        void FillMap()
        {
            int x = grass.game.graphics.PreferredBackBufferWidth / grass.texture.Width;
            int y = grass.game.graphics.PreferredBackBufferHeight / grass.texture.Height;
            int[,] map = new int[x,y];
            for (int i = 0; i < map.Length; i++)
            {
                if(map[i,0] % map[0,i] == 0)
                {

                }
            }
        }
    }
}
