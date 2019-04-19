using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleStarFish
{
    public class Ship
    {
        private Vector2 position;
        private Texture2D sprite;
        public Ship(Texture2D sprite)
        {
            this.sprite = sprite;
            this.position = new Vector2(100, 35);
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