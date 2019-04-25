using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleStarFish.Controles;
using LittleStarFish.MView.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LittleStarFish.States
{
    public class MenuState : State
    {

        private List<Component> _component;

        public MenuState(GameWorld gameWorld, GraphicsDevice graphicsDevice, ContentManager content) : base(gameWorld, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Button");
            var buttonFont = _content.Load<SpriteFont>("Font");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300,200),
                Text = "New Game",
            };
            newGameButton.Click += NewGameButton_Click;

            var loadGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 400),
                Text = "Load Game",
            };
            loadGameButton.Click += LoadGameButton_Click;
            var highScorreButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 600),
                Text = "HighScore",
            };
            highScorreButton.Click += highScorreButton_Click;
            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 800),
                Text = "Quit",
            };
            quitGameButton.Click += QuitGameButton_Click;

            _component = new List<Component>()
            {
                newGameButton,
                loadGameButton,
                highScorreButton,
                quitGameButton,
            };
        }
        
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach(var component in _component)
            {
                component.Draw(gameTime,spriteBatch);
            }
            spriteBatch.End();
        }
        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load game");
        }
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            
            _gameWorld.ChangeState(new Lake(_gameWorld,_graphichsDevice,_content));
        }
        private void highScorreButton_Click(object sender, EventArgs e)
        {

            _gameWorld.ChangeState(new Highscore(_gameWorld, _graphichsDevice, _content));
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
        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _gameWorld.Exit();
        }
    }
}
