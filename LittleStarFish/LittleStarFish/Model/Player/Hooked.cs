using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace LittleStarFish
{
    public class Hooked
    {
        
        private static Vector2 position = new Vector2(200,300);
        private static Vector2 hookposition = new Vector2(200, 250);
        private static Texture2D texture;
        private static Texture2D hooktexture;
        public bool hookingfish = false;
        public bool wasfishingsucsesful;
        private int timer = 10;
        private int hp;
        public int HP { get; set; }
        private int speed;
        private bool hittop;
        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("hooking");
            hooktexture = Content.Load<Texture2D>("hook");
            HP = 430;
        }
        
        public void Moveup(GameTime gametime)
        {
            position.Y += speed;
        }
        private void Movedown(GameTime gametime)
        {
            position.Y -= speed;
        }
        public  Rectangle CollisionBoxhook
        {
            get
            {
                return new Rectangle((int)hookposition.X, (int)hookposition.Y, hooktexture.Width, hooktexture.Height);
            }
        }
        public  Rectangle CollisionBox
        {
            get
            {
               return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }
        }
        public void Update(GameTime gameTime)
        {
            if (CollisionBox.Intersects(CollisionBoxhook))
            {
                HP--;
            }
            if (hookingfish == false)
            {
               if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                hookingfish = true;
                HP = 400;
                position = new Vector2(200, 300);
                hookposition = new Vector2(200, 250);
                hittop = true;
                timer = 10;
            }
            }
           
            if (hookingfish == true)
            {
                if (Keyboard.GetState().IsKeyUp(Keys.W))
                {
                hookposition.Y += 2;
                }
                if (Keyboard.GetState().IsKeyUp(Keys.S))
                {
                hookposition.Y -= 2;
                }

                if (hittop == true)
                {
                    speed = 2;
                    Movedown(gameTime);
                }
                else
                {
                    Moveup(gameTime);
                }


                if (position.Y == 300)
                {
                    speed = 0;
                    timer -= 1;
                    hittop = true;
                }
                if (position.Y == 200)
                {
                    hittop = false;
                    timer -= 1;

                }
                if (HP <= 0)
                {
                    wasfishingsucsesful = true;
                    hookingfish = false;
                    
                }
                if (timer == 0)
                {
                    hookingfish = false;
                    wasfishingsucsesful = false;
                }
            }
            if (wasfishingsucsesful == true)
            {
                
            }


            
        }

            public void Draw(SpriteBatch spriteBatch)
        {
            if (hookingfish == true)
            {
                spriteBatch.Begin();
             spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.Draw(hooktexture, hookposition, Color.White);
                spriteBatch.End();
            }
            
        }
    }
}