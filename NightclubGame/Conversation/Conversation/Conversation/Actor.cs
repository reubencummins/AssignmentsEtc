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
    class Actor
    {
        public string Name { get; set; }
        public Stat Personality { get; set; }
        public Gender ActorGender { get; set; }
        int patience;


        public Actor(Texture2D texture, Gender actorGender,string name,Stat personality)
        {
            Name = name;
            Personality = personality;
            ActorGender = actorGender;
            patience=3;
            Dialog speech = new Dialog();
        }

        public void Respond(Line lineIn)
        {
            if (Personality == lineIn.LineEffect)
            {
                patience++;
            }
        }

        public void Draw()
        {

        }
    }
}
