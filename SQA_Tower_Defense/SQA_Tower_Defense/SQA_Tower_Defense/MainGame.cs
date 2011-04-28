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

namespace SQA_Tower_Defense
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Tower placingTower;
        Texture2D towerTex;
        SpriteFont font;

        MouseState previousMouseState;
        KeyboardState previousKeyboardState;

        int gridSize;

        //rewinding
        int gameTimer;

        Map map;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;
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
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            this.IsMouseVisible = true;
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("font");
            gridSize = 25;
            gameTimer = 0;
            placingTower = new Tower("", 10, 10, 10, 10, new Rectangle(0, 0, 50, 50));
            map = new Map("normal", 100, 1);
            towerTex = Content.Load<Texture2D>("Sprites\\Eiffel");
            map.Enemies.Add(new Enemy(10, 10f, "basic", 10, new Rectangle(50, 50, 50, 50)));
            
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

            map.Update();

            foreach (Tower t in map.Towers)
                t.Update();
            UpdateInput();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "" + previousMouseState, new Vector2(50, 50), Color.Firebrick);
            if (map.Money > 0)
                spriteBatch.DrawString(font, "Money: " + map.Money, new Vector2(50, 100), Color.Firebrick);
            else
                spriteBatch.DrawString(font, "Out of money!", new Vector2(50, 100), Color.Firebrick);
            for (int i = 0; i < map.Towers.Count; i++)
            {
                spriteBatch.Draw(towerTex, map.Towers[i].Location, Color.White);
            }
            for (int i = 0; i < map.Enemies.Count; i++)
                spriteBatch.Draw(towerTex, map.Enemies[i].Location, Color.Red);
            
            spriteBatch.DrawString(font, "Time: " + ((gameTimer - (gameTimer % 30))/30), new Vector2(50, 75), Color.Firebrick);
            spriteBatch.DrawString(font, "Saves: " + map.SaveStates.Count, new Vector2(50, 150), Color.Firebrick);
            if(previousKeyboardState.IsKeyDown(Keys.LeftAlt))
                spriteBatch.DrawString(font, "Rewinding.",new Vector2(300, 75), Color.HotPink);
            if(placingTower != null)
            spriteBatch.Draw(towerTex, placingTower.Location, Color.White);
            
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }


        protected void UpdateInput()
        {
            MouseState mouseState = Mouse.GetState();
            KeyboardState boardState = Keyboard.GetState();

            if (placingTower != null)
            {

                placingTower.Location = new Rectangle(mouseState.X - (mouseState.X % gridSize), mouseState.Y - (mouseState.Y % gridSize), placingTower.Location.Width, placingTower.Location.Height);

                if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                {
                    for (int i = 0; i < map.Towers.Count; i++)
                    {
                        
                    }
                    map.PlaceTower(new Tower("", 10, 10, 10, 100, placingTower.Location));

                    placingTower = null;
                }

              }

           if (mouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released)
            {
                for (int i = 0; i < map.Towers.Count; i++)
                {
                    if (mouseState.X > map.Towers[i].Location.X && mouseState.X < map.Towers[i].Location.X + map.Towers[i].Location.Width && mouseState.Y > map.Towers[i].Location.Y
                        && mouseState.Y < map.Towers[i].Location.Y + map.Towers[i].Location.Height)
                    {
                        map.SellTower(map.Towers[i]);
                    }
                }
            }

            if(boardState.IsKeyDown(Keys.D1) && previousKeyboardState.IsKeyUp(Keys.D1))
            {
                placingTower = new Tower("", 10, 10, 10, 100, new Rectangle(mouseState.X - (mouseState.X % gridSize), mouseState.Y - (mouseState.Y % gridSize), 50, 50));
            }

            if (boardState.IsKeyUp(Keys.LeftAlt))
            {

                for (int i = 0; i < map.Enemies.Count; i++)
                    map.Enemies[i].Move();
                gameTimer++;
                map.SaveNextState();
            }
            if (boardState.IsKeyDown(Keys.LeftAlt))
            {
                
                gameTimer--;
                map.LoadPreviousState();
                
            }





                previousMouseState = mouseState;
                previousKeyboardState = boardState;

            

        }



        }
    }
