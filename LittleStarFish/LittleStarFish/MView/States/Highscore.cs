using LittleStarFish.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleStarFish.MView.States
{
   public class Highscore : State
    {
        private Controller controller;
       
        public SpriteFont textFont;
        
        public Highscore(GameWorld gameWorld, GraphicsDevice graphicsDevice, ContentManager content) : base(gameWorld, graphicsDevice, content)
        {
            controller = new Controller();
            textFont = _content.Load<SpriteFont>("Font");

           

        }
        public override void Draw(GameTime gameTime, SpriteBatch spritebatch)
        {
            
            spritebatch.Begin();
            spritebatch.DrawString(textFont,controller.getBait(), Vector2.Zero, Color.Black);
            spritebatch.End();
        }
        public override void PostUpdate(GameTime gameTime)
        {
            //remove sprite if they are not needen no more
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
