﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Conversation
{
    class Sprite
    {
        //sprite texture and position
        protected Texture2D spriteImage;

        public Texture2D SpriteImage
        {
            get { return spriteImage; }
            set { spriteImage = value; }
        }
        public Vector2 position;

        //the number of frames in the sprite sheet
        //the current fram in the animation
        //the time between frames
        int numberOfFrames = 0;
        int currentFrame = 0;
        int mililsecondsBetweenFrames = 100;
        float timer = 0f;

        //the width and height of our texture
        public int spriteWidth = 0;
        public int spriteHeight = 0;

        //the source of our image within the sprite sheet to draw
        Rectangle sourceRectangle;
        
        

        public Sprite(Texture2D texture,Vector2 userPosition, int framecount)
        {
            spriteImage = texture;
            position = userPosition;
            numberOfFrames = framecount;
            spriteHeight = spriteImage.Height;
            spriteWidth = spriteImage.Width / framecount;
        }


        public virtual void Update(GameTime gametime)
        {
            timer += (float)gametime.ElapsedGameTime.Milliseconds;

            //if the timer is greater then the time between frames, then animate
                    if (timer > mililsecondsBetweenFrames)
                    {
                        //moce to the next frame
                        currentFrame++;

                        //if we have exceed the number of frames
                        if (currentFrame > numberOfFrames - 1)
                        {
                            currentFrame = 0;
                        }
                        //reset our timer
                        timer = 0f;
                    }
            //set the source to be the current frame in our animation
                    sourceRectangle = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);
            }
        public bool collisionDetect(Sprite otherSprite)
        {
            Rectangle myBound = new Rectangle((int)this.position.X, (int)this.position.Y, this.spriteWidth, this.spriteHeight);
            Rectangle otherBound = new Rectangle((int)otherSprite.position.X, (int)otherSprite.position.Y, otherSprite.spriteWidth, this.spriteHeight);
            if (myBound.Intersects(otherBound))
                return true;

            return false;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //draw the sprite , specify the postion and source for the image withtin the sprite sheet
            spriteBatch.Begin();
            spriteBatch.Draw(spriteImage, position,sourceRectangle, Color.White);
            spriteBatch.End();
        }       

    }
}
