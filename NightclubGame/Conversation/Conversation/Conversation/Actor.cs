using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Conversation
{
    
    enum Stat { angry, sad, desperate,  }
    enum Gender { male, female }
    class Actor : Sprite
    {
        public string Name { get; set; }
        public Stat Personality { get; set; }
        public Gender ActorGender { get; set; }
        int patience;
        Dialog speech;


        public Actor(Texture2D texture, Gender actorGender,string name,Stat personality,Texture2D dialogTexture,SpriteFont dialogFont):base(texture,new Vector2(50,50),0)
        {
            Name = name;
            Personality = personality;
            ActorGender = actorGender;
            patience=3;
            speech = new Dialog(dialogTexture,dialogFont);
        }

        public void Respond(Line lineIn)
        {
            if (Personality == lineIn.LineEffect)
            {
                patience++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(spriteImage,new Rectangle(50,50,spriteImage.Width,spriteImage.Height), Color.White);
            speech.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
