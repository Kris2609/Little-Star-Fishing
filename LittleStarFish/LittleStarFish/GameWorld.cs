using Microsoft.Xna.Framework;
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
        Level level = new Level();
        Dock dock;
        Sea sea;
        Lake lake;
        Player player;
        Ship ship;
        private int score = 0;
        SpriteFont scoreList;

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = level.Height * 32;
            graphics.PreferredBackBufferWidth = level.Width * 32;
            graphics.ApplyChanges();
            IsMouseVisible = true;
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
            //Player
            Texture2D shipTexture = Content.Load<Texture2D>("Ship");
            Texture2D playerTexture = Content.Load<Texture2D>("Fisher_Bob");
            //Texture2D playerTextureThrowing = Content.Load<Texture2D>("Fisher_Bob_Ship");
            Texture2D playerTextureWithBoat = Content.Load<Texture2D>("Fisher_Bob_ship");
            //Texture2D playerTextureWithBoatThrowing = Content.Load<Texture2D>("Fisher_Bob_Ship_Throwing");
            player = new Player();
            ship = new Ship(shipTexture);
            lake = new Lake(playerTexture);
            dock = new Dock(playerTexture);
            sea = new Sea(playerTextureWithBoat);
            scoreList = Content.Load<SpriteFont>("ScoreList");
            //Order of the tiles in the map
            Texture2D water = Content.Load<Texture2D>("water");
            Texture2D ground = Content.Load<Texture2D>("ground");
            Texture2D lakeground = Content.Load<Texture2D>("lakeground");
            lake.AddTexture(water);
            lake.AddTexture(lakeground);
            dock.AddTexture(water);
            dock.AddTexture(ground);
            sea.AddTexture(water);
            sea.AddTexture(ground);
            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            player.Update(gameTime);
            ship.Update(gameTime);
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            lake.Draw(spriteBatch);
            lake.DrawPlayer(spriteBatch);
            dock.Draw(spriteBatch);
            dock.Drawplayer(spriteBatch);
            sea.Draw(spriteBatch);
            sea.DrawShip(spriteBatch);
            player.Draw(spriteBatch);
            ship.Draw(spriteBatch);
            spriteBatch.DrawString(scoreList,$"{player.Name} Score: {score}", Vector2.Zero, Color.LightGray);
            
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
