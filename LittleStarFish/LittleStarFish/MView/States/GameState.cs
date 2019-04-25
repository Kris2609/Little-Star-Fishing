using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LittleStarFish.States
{
    public class GameState : State
    {
       protected new GameWorld _gameWorld;   
        

        public int Points { get; private set; }

        public GameState(GameWorld gameWorld, GraphicsDevice graphicsDevice, ContentManager content) : base(gameWorld, graphicsDevice, content)
        {
            _gameWorld = gameWorld;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
