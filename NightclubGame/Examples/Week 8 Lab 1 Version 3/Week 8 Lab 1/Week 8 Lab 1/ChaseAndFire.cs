using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimatedSprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Week_8_Lab_1
{
    class ChaseAndFire
    {
        Player p;
        ChasingEnemy myEnemy;
        SpriteFont debug;

        public ChaseAndFire(Game g)
        {
            myEnemy = new ChasingEnemy(g,
                g.Content.Load<Texture2D>("Dragon_strip3"),
                new Vector2(40, 40), 3);
            //Sprite _site = new Sprite(g,g.Content.Load<Texture2D>("fireball_strip4"),Vector2.Zero,4);
            debug = g.Content.Load<SpriteFont>("debug");
            debugPrint.On = true;
            Sprite _explosion = new Sprite(g,g.Content.Load<Texture2D>("explosion_strip8"),Vector2.Zero,8);
            rocket _rocket = new rocket(g, g.Content.Load<Texture2D>("fireball_strip4"), _explosion, Vector2.Zero, 4);
            p = new Player(g, g.Content.Load<Texture2D>("wizard_strip3"), new Vector2(400, 400), 3);
            p.loadRocket(_rocket);
        }

        public void Update(GameTime t)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    debugPrint.On = !debugPrint.On;

            p.Update(t);
            myEnemy.follow(p);
            myEnemy.Update(t);
        }

        public void Draw(SpriteBatch s)
        {
            Vector2 direction = p.position - myEnemy.position;
            string debugText = "X " + direction.X.ToString();
            debugText += " Y " + direction.Y.ToString();

            debugPrint.display(new Vector2(10, 10), debug, s, debugText);

            p.Draw(s);
            myEnemy.Draw(s);
        }
    }
}
