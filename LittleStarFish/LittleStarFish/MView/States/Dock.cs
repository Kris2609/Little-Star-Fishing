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
    public class Dock : State
    {
        Player player;
        SpriteFont Font;
        private Texture2D _playerTexture;
        private Texture2D Store;
        Hooked hooked = new Hooked();
        /// <summary>
        /// DecorationShip 1 - 6
        /// </summary>
        private Texture2D DecorationShip;
        private Texture2D DecorationShip2;
        private Texture2D DecorationShip3;
        private Texture2D DecorationShip4;
        private Texture2D DecorationShip5;
        private Texture2D DecorationShip6;
        private List<Component> _component;
        int[,] map = new int[,]
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},


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
        public int Width
        {
            get { return map.GetLength(1); }

        }
        public int Height
        {
            get { return map.GetLength(0); }
        }
        public Dock(GameWorld gameWorld, GraphicsDevice graphicsDevice, ContentManager content) : base(gameWorld, graphicsDevice, content)
        {
            Texture2D water = content.Load<Texture2D>("water");
            Texture2D ground = content.Load<Texture2D>("ground");
            Texture2D lakeground = content.Load<Texture2D>("lakeground");
            _playerTexture = content.Load<Texture2D>("Fisher_Bob");
            player = new Player(_playerTexture, "Fisher_Bob", content, new Vector2(325, 50));
            Store = content.Load<Texture2D>("Store");
            Font = content.Load<SpriteFont>("Font");

            //Loads DecorationShips
            {
                DecorationShip = content.Load<Texture2D>("DecoShip");
                DecorationShip2 = content.Load<Texture2D>("DecoShip");
                DecorationShip3 = content.Load<Texture2D>("DecoShip");
                DecorationShip4 = content.Load<Texture2D>("DecoShip");
                DecorationShip5 = content.Load<Texture2D>("DecoShip");
                DecorationShip6 = content.Load<Texture2D>("DecoShip");
            }
            AddTexture(water);
            AddTexture(ground);
            
            var buttonTexture = _content.Load<Texture2D>("Ship");
            var backbuttonTexture = _content.Load<Texture2D>("Ship_back");
            var fishingRodTexture = _content.Load<Texture2D>("FishingRod");
            var buttonFont = _content.Load<SpriteFont>("Font");
            
            var nextStageButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(50, 0), //position of the traveling boat

            };
            var backStageButton = new Button(backbuttonTexture, buttonFont)
            {
                Position = Vector2.Zero, //position of the traveling boat

            };
            var fishingButton = new Button(fishingRodTexture, buttonFont)
            {
                Position = new Vector2(100, 0) //position of the fishingButton
                
            };
            nextStageButton.Click += NextStageButton_Click;
            backStageButton.Click += BackStageButton_Click;
            fishingButton.Click += FishingButton_Click;
            _component = new List<Component>()
            {
                nextStageButton,
                backStageButton,
                fishingButton,
                
            };

            
        }

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
                    spritebatch.Draw(texture, new Rectangle(x * 64, y * 64, 64,64), Color.White);
                }
            }
            foreach (var component in _component)
            {
                component.Draw(gameTime, spritebatch);
            }
            //draws the player and his position
            {
                spritebatch.Draw(_playerTexture, new Vector2(325, 150), Color.White);
            }
            //Draws The store
            {
                spritebatch.Draw(Store, new Vector2(20, 70), Color.White);
            }
            //Draws Decoration ships
            {
                spritebatch.Draw(DecorationShip, new Vector2(325, 420), Color.White);
                spritebatch.Draw(DecorationShip, new Vector2(325, 530), Color.White);
                spritebatch.Draw(DecorationShip, new Vector2(325, 670), Color.White);
                spritebatch.Draw(DecorationShip, new Vector2(325, 790), Color.White);
                spritebatch.Draw(DecorationShip, new Vector2(325, 930), Color.White);
                spritebatch.Draw(DecorationShip, new Vector2(200, 930), Color.White);
            }
            hooked.Draw(spritebatch);
            spritebatch.DrawString(Font, $"{player.Name}", new Vector2(1735, 0), Color.Red);
            spritebatch.DrawString(Font, $"Points: {0}", new Vector2(1735, 20), Color.Red);
            spritebatch.End();
        }
        private void NextStageButton_Click(object sender, EventArgs e)
        {

            _gameWorld.ChangeState(new Sea(_gameWorld, _graphichsDevice, _content));
        }
        private void BackStageButton_Click(object sender, EventArgs e)
        {

            _gameWorld.ChangeState(new Lake(_gameWorld, _graphichsDevice, _content));
        }
                
        private void FishingButton_Click(object sender, EventArgs e)
        {
            
        }
        public override void PostUpdate(GameTime gameTime)
        {
            //remove sprite if they are not needen no more
        }

        public override void Update(GameTime gameTime)
        {
            hooked.Fishing(gameTime);
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