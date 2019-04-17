using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleStarFish
{
    public class Player : GameObject
    {
        private Texture2D playersprite;
        
        private Vector2 position;
        private string name;
        public Player(Texture2D playersprite, Vector2 position)
        {
            this.playersprite = playersprite;
            this.position = position;
            this.name = "Bob";
        }

        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(playersprite, position, Color.White);
        }

    }
    
}