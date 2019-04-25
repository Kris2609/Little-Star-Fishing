using LittleStarFish.Controles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleStarFish.States
{
    public class Sea : State
    {
        SpriteFont Font;
        Texture2D _playerTexture;
        Player player;
        private List<Component> _component;
        int[,] map = new int[,]
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
        public int Width
        {
            get { return map.GetLength(1); }

        }
        public int Height
        {
            get { return map.GetLength(0); }
        }

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
            var fishingRodTexture = _content.Load<Texture2D>("FishingRod");

            var backStageButton = new Button(buttonTexture, buttonFont)
            {
                Position = Vector2.Zero, //position of the traveling boat

            };
            var fishingButton = new Button(fishingRodTexture, buttonFont)
            {
                Position = new Vector2(100, 0) //position of the fishingButton
            };
            backStageButton.Click += BackStageButton_Click;
            _component = new List<Component>()
            {
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
                    spritebatch.Draw(texture, new Rectangle(x * 64, y * 64, 64, 64), Color.White);
                }
                foreach (var component in _component)
                {
                    component.Draw(gameTime, spritebatch);
                }
                spritebatch.Draw(_playerTexture, new Vector2(500,500), Color.White); //draws the player and his position

            }
            spritebatch.DrawString(Font, $"{player.Name}", new Vector2(1735, 0), Color.Red);
            spritebatch.DrawString(Font, $"Points: {0}", new Vector2(1735, 20), Color.Red);
            spritebatch.End();
        }
        private void BackStageButton_Click(object sender, EventArgs e)
        {

            _gameWorld.ChangeState(new Dock(_gameWorld, _graphichsDevice, _content));
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
            foreach (var component in _component)
            {
                component.Update(gameTime);
            }
        }
    }
}