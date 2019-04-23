using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleStarFish
{
    public class Ship : GameObject
    {
        
        private Texture2D sprite;
        public Ship(Texture2D sprite, string textureName,ContentManager Content, Vector2 position) : base(textureName,Content,position)
        {
            this.sprite = sprite;
            position = new Vector2(475, 50);
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, Color.White);
        }
    }
}