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
    class MouseCursor
    {
        Texture2D cursorTexture;
        Vector2 cursorPos;

        public void SetPos(Vector2 pos)
        {
            cursorPos = pos;
        }
        public Vector2 GetPos()
        {
            return cursorPos;
        }
        public void SetTexture(Texture2D tex)
        {
            cursorTexture = tex;
        }
        public Texture2D GetTexture()
        {
            return cursorTexture;
        }
    }
}
