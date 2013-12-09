using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace AnimatedSprite
{
    class rocket : Sprite
    {

            public enum ROCKETSTATE { STILL, FIRING, EXPOLODING };
            ROCKETSTATE rocketState = ROCKETSTATE.STILL;
            protected Game myGame;
            protected float RocketVelocity = 10.0f;
            Vector2 textureCenter;
            Vector2 Target;
            Sprite explosion;
            float ExplosionTimer = 0;
            float ExplosionVisibleLimit = 500;
            Vector2 StartPosition;
           

            public ROCKETSTATE RocketState
            {
                get { return rocketState; }
                set { rocketState = value; }
            }

            public Sprite Explosion
            {
                get { return explosion; }
                set { explosion = value; }
            }

            public rocket(Game g, Texture2D texture, Sprite rocketExplosion, Vector2 userPosition, int framecount) 
                : base(g,texture,userPosition,framecount)
            {
                Target = Vector2.Zero;
                myGame = g;
                textureCenter = new Vector2(texture.Width/2,texture.Height/2);
                explosion =  rocketExplosion;
                explosion.position -= textureCenter;
                explosion.Visible = false;
                StartPosition = position;
                RocketState = ROCKETSTATE.STILL;
                
            }
            public override void Update(GameTime gametime)
            {
                switch (rocketState)
                {
                    case ROCKETSTATE.STILL:
                        this.Visible = false;
                        explosion.Visible = false;
                        break;
                    // Using Lerp here could use target - pos and normalise for direction and then apply
                    // Velocity
                    case ROCKETSTATE.FIRING:
                        this.Visible = true;                       
                        position = Vector2.SmoothStep(position, Target, 0.02f * RocketVelocity);
                        if (Vector2.Distance(position, Target) < 20)
                            rocketState = ROCKETSTATE.EXPOLODING;
                        break;
                    case ROCKETSTATE.EXPOLODING:
                        Visible = false;
                        explosion.position = Target;
                        explosion.Visible = true;
                        break;
                }
                // if the explosion is visible then just play the animation and count the timer
                if (explosion.Visible)
                {
                    explosion.Update(gametime);
                    ExplosionTimer += gametime.ElapsedGameTime.Milliseconds;
                }
                // if the timer goes off the explosion is finished
                if (ExplosionTimer > ExplosionVisibleLimit)
                {
                    explosion.Visible = false;
                    ExplosionTimer = 0;
                    rocketState = ROCKETSTATE.STILL;
                }

                base.Update(gametime);
            }
            public void fire(Vector2 SiteTarget)
            {
                if (rocketState == ROCKETSTATE.STILL)
                {
                    rocketState = ROCKETSTATE.FIRING;
                    Target = SiteTarget;
                    Vector2 direction = position - Target;
                    //direction.Normalize(); // Magnitude does not matter for angle calculation
                    angleOfRotation = (float)Math.Atan2(direction.Y, direction.X);
                }

            }   
            public override void Draw(SpriteBatch spriteBatch)
            {
                base.Draw(spriteBatch);
                //spriteBatch.Begin();
                //spriteBatch.Draw(spriteImage, position, SourceRectangle,Color.White);
                //spriteBatch.End();
                if (explosion.Visible)
                    explosion.Draw( spriteBatch);
                

            }

    }
}
