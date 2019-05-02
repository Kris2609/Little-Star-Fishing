using System;
using LittleStarFish.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LittleStarFish
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public int score;
        private TimeSpan timeSinceStart;
        Hooked hooked = new Hooked();
        Texture2D _playerTexture;
        Player player;
        SpriteFont Font;
        private float time;
        public static int Width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        public static int Height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
     
        private State _currentState;
        private State _nextState;
        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;
            

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            hooked.LoadContent(Content);
            
            _currentState = new Login(this,GraphicsDevice,Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            if(_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }
            _currentState.Update(gameTime);
            _currentState.PostUpdate(gameTime);
            
            timeSinceStart += gameTime.ElapsedGameTime;
            time = (int)timeSinceStart.Seconds;
            
            hooked.Update(gameTime);
            #region switschase

            //we use switch case to swap gamestates
            //switch (currentState)
            //{
            //    case GameState.menuScreen:
            //        {
            //            if (Keyboard.GetState().IsKeyDown(Keys.NumPad1))
            //            {
            //                currentState = GameState.Lake;
            //            }

            //            break;
            //            //Change current screen state to lake state
            //            //only works in menuscreen state
            //        }
            //    case GameState.Lake:
            //        {
            //            if (Keyboard.GetState().IsKeyDown(Keys.NumPad2) && Points == 1000)
            //            {
            //                currentState = GameState.Dock;
            //            }
            //            if (Keyboard.GetState().IsKeyDown(Keys.NumPad5))
            //            {
            //                currentState = GameState.menuScreen;
            //            }
            //                break;
            //            //Change current screen state to dock state
            //            //only works in lake state
            //        }
            //    case GameState.Dock:
            //        {
            //            if (Keyboard.GetState().IsKeyDown(Keys.NumPad3) && Points == 3000)
            //            {
            //                currentState = GameState.Sea;
            //            }
            //            if (Keyboard.GetState().IsKeyDown(Keys.NumPad5))
            //            {
            //                currentState = GameState.menuScreen;
            //            }
            //            break;
            //            //Change current screen state to sea state
            //            //only works in dock state
            //        }
            //    case GameState.Sea:
            //        {
            //            if (Keyboard.GetState().IsKeyDown(Keys.NumPad4) && Points == 10000)
            //            {
            //                currentState = GameState.EndScreen;
            //            }
            //            if (Keyboard.GetState().IsKeyDown(Keys.NumPad5))
            //            {
            //                currentState = GameState.menuScreen;
            //            }
            //            break;
            //            //Change current screen state to endscreen state
            //            //only works in sea state
            //        }
            //    case GameState.EndScreen:
            //        {
            //            if (Keyboard.GetState().IsKeyDown(Keys.NumPad5))
            //                currentState = GameState.menuScreen;
            //            break;
            //            //Change current screen state to menu state
            //            //only works in endscreen state
            //        }
            //}
            #endregion
            base.Update(gameTime);
        }

        

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);
            _currentState.Draw(gameTime,spriteBatch);

            hooked.Draw(spriteBatch);
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
