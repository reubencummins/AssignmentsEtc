using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Week_8_Lab_1
{
    public static class debugPrint
    {
        public static bool On = false;

        public static void display(Vector2 position, 
            SpriteFont font, 
            SpriteBatch spriteBatch,
            string text)
        {
            if (On)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(font, text, position, Color.White);
                spriteBatch.End();
            }

        }

    }
}
