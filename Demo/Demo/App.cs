using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Demo.Engine;

namespace Demo
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class App : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Vector2 fontPos;
        Vector2 fontPos2;
        Vector2 fontPos3;
        Vector2 fontPos4;
        Vector2 fontPos5;
        Vector2 fontPos6;
        Vector2 fontPos7;
        Vector2 fontPos8;
        GameState gameState;

        bool isFlash;

        public App()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            gameState = new GameState("Alberto Taco Shop", 100);
            isFlash = false;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Courier New");
            fontPos = new Vector2(graphics.GraphicsDevice.Viewport.Width/20, graphics.GraphicsDevice.Viewport.Height/10);
            fontPos2 = new Vector2(graphics.GraphicsDevice.Viewport.Width / 20, graphics.GraphicsDevice.Viewport.Height / 10 + 100);
            fontPos3 = new Vector2(graphics.GraphicsDevice.Viewport.Width / 20, graphics.GraphicsDevice.Viewport.Height / 10 + 125);
            fontPos4 = new Vector2(graphics.GraphicsDevice.Viewport.Width / 20, graphics.GraphicsDevice.Viewport.Height / 10 + 150);
            fontPos5 = new Vector2(graphics.GraphicsDevice.Viewport.Width / 20, graphics.GraphicsDevice.Viewport.Height / 10 + 200);
            fontPos6 = new Vector2(graphics.GraphicsDevice.Viewport.Width / 20, graphics.GraphicsDevice.Viewport.Height / 10 + 225);
            fontPos7 = new Vector2(graphics.GraphicsDevice.Viewport.Width / 20, graphics.GraphicsDevice.Viewport.Height / 10 + 275);
            fontPos8 = new Vector2(graphics.GraphicsDevice.Viewport.Width / 20, graphics.GraphicsDevice.Viewport.Height / 10 + 350);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            gameState.update(gameTime.ElapsedGameTime.Milliseconds, ref isFlash);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightBlue);

            base.Draw(gameTime); 

            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Welcome to " + gameState.getStoreName() + "!", fontPos, Color.Black);
            spriteBatch.DrawString(font, "Settlement Name: " + gameState.getCurrentSettlementName(), fontPos2, Color.Olive);
            spriteBatch.DrawString(font, "Numbers of customer in store: " + gameState.getCustomerCountInStore(), fontPos3, Color.Olive);
            spriteBatch.DrawString(font, "Numbers of customer in line: " + gameState.getCustomerCountInLine(), fontPos4, Color.Olive);
            spriteBatch.DrawString(font, "Customer in store: " + gameState.getCustomerInStoreList(), fontPos5, Color.BurlyWood);
            spriteBatch.DrawString(font, "Customer in line: " + gameState.getCustomerInLineList(), fontPos6, Color.BurlyWood);
            
            if (isFlash)
            {
                spriteBatch.DrawString(font, "This is current time: " + gameTime.TotalGameTime.TotalSeconds.ToString(), fontPos7, Color.Red);
            }
            else
            {
                spriteBatch.DrawString(font, "Wait for it...", fontPos7, Color.Black);
            }
            spriteBatch.End();

            base.Draw(gameTime);       
        }
    }
}
