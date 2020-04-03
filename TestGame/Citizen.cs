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
    public class Citizen : Game1
    {
        SpriteBatch spriteBatch;
        public Texture2D citizenTexture;
        Vector2 citizenPosition;

        public void SetPos(Vector2 pos)
        {
            citizenPosition = pos;
        }
        public Vector2 GetPos()
        {
            return citizenPosition;
        }

        public Texture2D GetTexture()
        {
            return citizenTexture;
        }
        public void SetTexture(Texture2D texture)
        {
            citizenTexture = texture;
        }
    }
}
