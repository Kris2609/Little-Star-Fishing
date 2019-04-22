using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
       
        
        private string name;

        public string Name { get => name; set => name = value; }
       

        public Player(Texture2D playersprite,string textureName,ContentManager Content,Vector2 position) : base(textureName,Content,position)
        {
            this.playersprite = playersprite;
            this.name = "Bob";
            this.position = new Vector2(325, 50);
        }
        
        public override void Update(GameTime gameTime)
        {
           
        }
        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(playersprite, position, Color.White);
        }

    }
    
}