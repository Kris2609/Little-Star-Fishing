using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleStarFish
{
    public class Ship : GameObject
    {
        private int point;
        private bool isActive;
        private Vector2 position;
        private Texture2D sprite;
        public Ship(Texture2D sprite)
        {
            this.sprite = sprite;
            this.position = new Vector2(475, 50);
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, Color.White);
        }
    }
}