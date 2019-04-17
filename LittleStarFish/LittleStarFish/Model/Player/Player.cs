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
        private int score;
        public Player(Texture2D playersprite)
        {
            this.playersprite = playersprite;
        }

        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(playersprite, new Vector2(325, 50.5f), Color.White);
        }

    }
    
}