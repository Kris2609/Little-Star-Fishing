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
        Texture2D _playerTexture;
        int[,] map = new int[,]
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
            {0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,},
            {0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,},
            {0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},



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
            Texture2D water = content.Load<Texture2D>("water");
            Texture2D ground = content.Load<Texture2D>("ground");
            Texture2D lakeground = content.Load<Texture2D>("lakeground");
            _playerTexture = content.Load<Texture2D>("Fisher_Bob");
            Player player = new Player(_playerTexture, "Fisher_Bob", content, new Vector2(325, 50));
            AddTexture(water);
            AddTexture(ground);


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
                    spritebatch.Draw(texture, new Rectangle(x * 32, y * 32, 32, 32), Color.White);
                }
            }
            spritebatch.Draw(_playerTexture, new Vector2(200, 50), Color.White);
            spritebatch.End();
        }
        public override void PostUpdate(GameTime gameTime)
        {
            //remove sprite if they are not needen no more
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Escape))
            {
                _gameWorld.ChangeState(new MenuState(_gameWorld, _graphichsDevice, _content));
            }
        }
    }
}