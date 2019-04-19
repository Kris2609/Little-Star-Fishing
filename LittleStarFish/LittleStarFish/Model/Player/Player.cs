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
        private int point;
        private Texture2D playersprite;
        private Vector2 position;
        
        private string name;

        public string Name { get => name; set => name = value; }
        public Vector2 Position { get => position; set => position = value; }

        public Player(Texture2D playersprite)
        {
            this.playersprite = playersprite;
            this.name = "Bob";
            this.position = new Vector2(325, 50);
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