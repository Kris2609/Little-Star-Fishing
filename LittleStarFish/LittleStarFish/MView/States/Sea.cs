using LittleStarFish.Controles;
using LittleStarFish.MView.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleStarFish.States
{
    public class Sea : State
    {
        private SpriteFont Font;
        private Texture2D _playerTexture;
        private Player player;
      
        private List<Component> _component;
        //Tile map of SeaLevel
        private int[,] map = new int[,]
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},



        };
        public int GetIndex(int cellX, int cellY)
        {
            if (cellX < 0 || cellX > Width - 1 || cellY < 0 || cellY > Height - 1)
                return 0;

            return map[cellY, cellX];
        }
        private List<Texture2D> tileTextures = new List<Texture2D>();
        public void AddTexture(Texture2D texture)
        {
            tileTextures.Add(texture);
        }
        //Width of the map
        public int Width
        {
            get { return map.GetLength(1); }

        }
        //Hight of the map
        public int Height
        {
            get { return map.GetLength(0); }
        }
        /// <summary>
        /// The sea level Constructor
        /// </summary>
        /// <param name="gameWorld"></param>
        /// <param name="graphicsDevice"></param>
        /// <param name="content"></param>
        public Sea(GameWorld gameWorld, GraphicsDevice graphicsDevice, ContentManager content) : base(gameWorld, graphicsDevice, content)
        {
            Font = content.Load<SpriteFont>("Font");
            Texture2D water = content.Load<Texture2D>("water");
            Texture2D PalmTree = content.Load<Texture2D>("palme");
            Texture2D lakeground = content.Load<Texture2D>("lakeground");
            _playerTexture = content.Load<Texture2D>("Fisher_Bob_ship");
            player = new Player(_playerTexture, "Fisher_Bob_ship", content, new Vector2(325, 50));
            AddTexture(water);
            AddTexture(PalmTree);
            var buttonTexture = _content.Load<Texture2D>("Ship_back");
            var buttonFont = _content.Load<SpriteFont>("Font");
            
            var backStageButton = new Button(buttonTexture, buttonFont)
            {
                Position = Vector2.Zero, //position of the traveling boat

            };
            
            backStageButton.Click += BackStageButton_Click;
            _component = new List<Component>()
            {
                backStageButton,
                
            };



        }
        /// <summary>
        /// Draw the Sea Level
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spritebatch"></param>
        public override void Draw(GameTime gameTime,SpriteBatch spritebatch)
        {
            spritebatch.Begin();
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    int textureIndex = map[y, x];
                    if (textureIndex == -1)
                    {
                        continue;
                    }
                    Texture2D texture = tileTextures[textureIndex];
                    spritebatch.Draw(texture, new Rectangle(x * 64, y * 64, 64, 64), Color.White);
                }
                foreach (var component in _component)
                {
                    component.Draw(gameTime, spritebatch);
                }
                //Draws the player
                {
                    spritebatch.Draw(_playerTexture, new Vector2(500, 500), Color.White); //draws the player and his position
                    player.Draw(spritebatch);
                }
                
            }
           
            
            spritebatch.End();
        }
        //Enable a BackStageButton
        private void BackStageButton_Click(object sender, EventArgs e)
        {

            _gameWorld.ChangeState(new Dock(_gameWorld, _graphichsDevice, _content));
        }
        

        public override void PostUpdate(GameTime gameTime)
        {
            //remove sprite if they are not needen no more
        }
        /// <summary>
        /// Updates The sea level
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
           
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _gameWorld.ChangeState(new EndScreen(_gameWorld, _graphichsDevice, _content));
            }

            foreach (var component in _component)
            {
                component.Update(gameTime);
            }
        }
    }
}