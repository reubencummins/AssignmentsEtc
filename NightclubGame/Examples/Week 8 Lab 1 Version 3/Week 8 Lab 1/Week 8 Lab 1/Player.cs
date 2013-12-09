using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace AnimatedSprite
{
        class Player : Sprite
        {
            protected Game myGame;
            protected float playerVelocity = 6.0f;
            protected rocket myRocket;
            protected CrossHair Site;
            Vector2 centrePos;
            protected Vector2 previousPosition;

            public Vector2 CentrePos
            {
                get { return position + new Vector2(spriteWidth/ 2, spriteHeight / 2); }
                
            }

            
            public Player(Game g, Texture2D texture, Vector2 userPosition, int framecount) 
                : base(g,texture,userPosition,framecount)
            {
                myGame = g;
                Site = new CrossHair(g, g.Content.Load<Texture2D>("CrossHair"), userPosition, 1);
                
            }

            public void loadRocket(rocket r)
            {
                myRocket = r;
            }


        public override void Update(GameTime gameTime)
        {
           
            Viewport gameScreen = myGame.GraphicsDevice.Viewport;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                this.position += new Vector2(1, 0) * playerVelocity;
                CameraRect.X += (int)playerVelocity;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                this.position += new Vector2(-1, 0) * playerVelocity;
                CameraRect.X -= (int)playerVelocity;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                this.position += new Vector2(0, -1) * playerVelocity;
                CameraRect.Y -= (int)playerVelocity;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                this.position += new Vector2(0, 1) * playerVelocity;
                CameraRect.Y += (int)playerVelocity;
            }
            
            // Rotate Character
            if (Keyboard.GetState().IsKeyDown(Keys.X))
            {
                angleOfRotation += 0.1f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                angleOfRotation -= 0.1f;
            }
            // check for site change
            
            Site.Update(gameTime);
            // Whenever the rocket is still and loaded it follows the player posiion
            if (myRocket != null && myRocket.RocketState == rocket.ROCKETSTATE.STILL)
                myRocket.position = this.CentrePos;
            // if a roecket is loaded
            if (myRocket != null)
            {
                // fire the rocket and it looks for the target
                if(Keyboard.GetState().IsKeyDown(Keys.Space))
                    myRocket.fire(Site.position);
            }

            // Make sure the player stays in the bounds see previous lab for details
            position = Vector2.Clamp(position, Vector2.Zero,
                                            new Vector2(gameScreen.Width - spriteWidth,
                                                        gameScreen.Height - spriteHeight));
            
            // Update the Camera with respect to the players new position
            //Vector2 delta = cam.Pos - this.position;
            //cam.Pos += delta;
            
            if (myRocket != null)
                myRocket.Update(gameTime);
            // Update the players site
            Site.Update(gameTime);
            // call Sprite Update to get it to animated 
            base.Update(gameTime);
        }
            
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            Site.Draw(spriteBatch);
            if (myRocket != null && myRocket.RocketState != rocket.ROCKETSTATE.STILL)
                    myRocket.Draw(spriteBatch);
            
        }

    }
}
