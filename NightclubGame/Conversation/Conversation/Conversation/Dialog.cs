using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Conversation
{
    class Dialog: Conversation.Sprite
    {
        public string Text { get; set; }
        public SpriteFont Font { get; set; }

        public Dialog(Texture2D texture,SpriteFont font)
            : base(texture,new Vector2(550,450),0)
        {
            Font = font;
            Text = "...";
        }



        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.Begin();
            spriteBatch.DrawString(Font,Text,(position),Color.White);
            spriteBatch.End();
        }
    }
}
