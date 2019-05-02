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
        
        private Texture2D playersprite;
        public int score;
        SpriteFont Font;
        
        
        
        private string name;

        public string Name { get => name; set => name = value; }


        public Player(Texture2D playersprite, string textureName, ContentManager Content, Vector2 position) : base(textureName,Content,position)
        {
            Font = Content.Load<SpriteFont>("Font");
            this.playersprite = playersprite;
            this.name = "Bob";
            this.position = new Vector2(325, 50);
        }
        
        public override void Update(GameTime gameTime)
        {
           
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            
            //spriteBatch.Draw(playersprite, position, Color.White);
            spriteBatch.DrawString(Font, $"Name: {Name}", new Vector2(1735, 0), Color.Red);
        }

    }
    
}