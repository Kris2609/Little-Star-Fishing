﻿using LittleStarFish.Controles;
using LittleStarFish.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleStarFish.MView.States
{
    class EndScreen : State
    {
        private Controller controller;
        private Player player;
        private SpriteFont Font;
        private Texture2D _playerTexture;
        private Hooked hooked;
        public int getscore { get { return hooked.score; } }
        
        
        private List<Component> _component;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameWorld"></param>
        /// <param name="graphicsDevice"></param>
        /// <param name="content"></param>
        public EndScreen(GameWorld gameWorld, GraphicsDevice graphicsDevice, ContentManager content) : base(gameWorld, graphicsDevice, content)
        {
            controller = new Controller();
            Font = content.Load<SpriteFont>("Font");
            player = new Player(_playerTexture, "Fisher_Bob", content, new Vector2(500, 60));
            var buttonTexture = _content.Load<Texture2D>("Button");
            var buttonFont = _content.Load<SpriteFont>("Font");


            var saveScoreButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(600, 600),
                Text = "Save Score to highscore",

            };
            saveScoreButton.Click += SaveScoreButton_Click;
            
           
            _component = new List<Component>()
            {
                saveScoreButton,
                
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveScoreButton_Click(object sender, EventArgs e)
        {

           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spritebatch"></param>
        public override void Draw(GameTime gameTime, SpriteBatch spritebatch)
        {
            
            spritebatch.Begin();
            spritebatch.DrawString(Font, "Best score" + controller.getBestscore(), new Vector2(600, 400), Color.White);
            spritebatch.DrawString(Font, "you'r score" + controller.getNewHighscore(), new Vector2(600, 500), Color.White);
            foreach (var component in _component)
            {
                component.Draw(gameTime, spritebatch);
            }
            
           
            spritebatch.End();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void PostUpdate(GameTime gameTime)
        {

            //remove sprite if they are not needen no more
        }
        /// <summary>
        /// Update the game from the EndScreen scene
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
           
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                _gameWorld.ChangeState(new MenuState(_gameWorld, _graphichsDevice, _content));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                _gameWorld.ChangeState(new MenuState(_gameWorld, _graphichsDevice, _content));
            }

            foreach (var component in _component)
            {
                component.Update(gameTime);
            }

        }
    }
}
