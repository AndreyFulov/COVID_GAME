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
    class Tile : Game1
    {
        public Game1 game;

        public Texture2D texture;
        Vector2 position;

        public Tile(string FileName)
        {
            texture = Content.Load<Texture2D>(FileName);
        }
    }
}
