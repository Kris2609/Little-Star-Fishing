using LittleStarFish.Controles;
using LittleStarFish.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleStarFish
{
    public class Login : State
    {
        private List<Component> _component;

        public Login(GameWorld gameWorld, GraphicsDevice graphicsDevice, ContentManager content) : base(gameWorld, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Button");
            var buttonFont = _content.Load<SpriteFont>("Font");

            var userNameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(600, 200),
                Text = "UserName",
            };
            var loginButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(1450, 700),
                Text = "Login",
            };
            var passWordButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(600, 400),
                Text = "PassWord",
            };
            var quitButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(1450, 900),
                Text = "Quit",
            };
            loginButton.Click += LoginButton_Click;
            passWordButton.Click += PassWordButton_Click;
            quitButton.Click += QuitButton_Click;
            userNameButton.Click += UserNameButton_Click;
            _component = new List<Component>()
            {
                loginButton,
                passWordButton,
                quitButton,
                userNameButton,
            };
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {

            _gameWorld.ChangeState(new MenuState(_gameWorld, _graphichsDevice, _content));
        }
        private void UserNameButton_Click(object sender, EventArgs e)
        {

            _gameWorld.ChangeState(new UserName(_gameWorld, _graphichsDevice, _content));
        }
        private void PassWordButton_Click(object sender, EventArgs e)
        {

            _gameWorld.ChangeState(new Password(_gameWorld, _graphichsDevice, _content));
        }
        private void QuitButton_Click(object sender, EventArgs e)
        {

            _gameWorld.Exit();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach (var component in _component)
            {
                component.Draw(gameTime, spriteBatch);
            }
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
           
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