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
        private enum gameState {Lake, Sea, Dock, EndScreen }
        private gameState currentState = gameState.Lake; //set the default state
        public int Points { get; private set; }
        /// <summary>
        /// The GameStates Constructor
        /// </summary>
        /// <param name="gameWorld"></param>
        /// <param name="graphicsDevice"></param>
        /// <param name="content"></param>
        public GameState(GameWorld gameWorld, GraphicsDevice graphicsDevice, ContentManager content) : base(gameWorld, graphicsDevice, content)
        {
            _gameWorld = gameWorld;
        }
        /// <summary>
        /// Draws the GS
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            #region States test
            KeyboardState ks = Keyboard.GetState();
            _gameWorld.GraphicsDevice.Clear(Color.Black);
            

            if (currentState == gameState.Lake)
            {
                _gameWorld.GraphicsDevice.Clear(Color.Black);
                if (ks.IsKeyDown(Keys.NumPad1))
                {
                    currentState = gameState.Dock;
                }
            }
            if (currentState == gameState.Dock)
            {
                _gameWorld.GraphicsDevice.Clear(Color.Blue);
                if (ks.IsKeyDown(Keys.NumPad2))
                {
                    currentState = gameState.Sea;
                }
            }
            if (currentState == gameState.Sea)
            {
                _gameWorld.GraphicsDevice.Clear(Color.Red);
                if (ks.IsKeyDown(Keys.NumPad3))
                {
                    currentState = gameState.EndScreen;
                }
            }
            if (currentState == gameState.EndScreen)
            {
                _gameWorld.GraphicsDevice.Clear(Color.Pink);
            }
            #endregion
        }
        /// <summary>
        /// PostUpdate GS
        /// </summary>
        /// <param name="gameTime"></param>
        public override void PostUpdate(GameTime gameTime)
        {
            
        }
        /// <summary>
        /// Update the GS
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            #region switschase

            //we use switch case to swap gamestates
            switch (currentState)
                {
                    case gameState.Lake:
                        {
                            if (Keyboard.GetState().IsKeyDown(Keys.NumPad2) && Points == 1000)
                            {
                                currentState = gameState.Dock;
                            }
                            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                            {
                            
                            }
                            break;
                            //Change current screen state to dock state
                            //only works in lake state
                        }
                    case gameState.Dock:
                        {
                            if (Keyboard.GetState().IsKeyDown(Keys.NumPad3) && Points == 3000)
                            {
                                currentState = gameState.Sea;
                            }
                            if (Keyboard.GetState().IsKeyDown(Keys.NumPad5))
                            {
                            //go to menu or quit
                        }
                        break;
                            //Change current screen state to sea state
                            //only works in dock state
                        }
                    case gameState.Sea:
                        {
                            if (Keyboard.GetState().IsKeyDown(Keys.NumPad4) && Points == 10000)
                            {
                                currentState = gameState.EndScreen;
                            }
                            if (Keyboard.GetState().IsKeyDown(Keys.NumPad5))
                            {
                            //go to menu or quit
                        }
                        break;
                            //Change current screen state to endscreen state
                            //only works in sea state
                        }
                    case gameState.EndScreen:
                        {
                            if (Keyboard.GetState().IsKeyDown(Keys.NumPad5))
                        {
                            //go to menu or quit
                        }

                        break;
                            //Change current screen state to menu state
                            //only works in endscreen state
                        }
                }
                #endregion
        }
    }
}
