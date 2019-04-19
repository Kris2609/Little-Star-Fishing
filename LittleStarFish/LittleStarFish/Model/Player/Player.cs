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
        private Vector2 position = new Vector2(325, 50);
        private string name;

        public string Name { get => name; set => name = value; }

        public Player(Texture2D playersprite)
        {
            this.playersprite = playersprite;
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