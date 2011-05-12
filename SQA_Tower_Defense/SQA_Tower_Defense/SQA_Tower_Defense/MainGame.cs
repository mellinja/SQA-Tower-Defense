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
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public Tower placingTower;
        public Texture2D towerTex, backTex;
        public SpriteFont font, toolTipFont;

        public Interface menu;

        public MouseState mouseState, previousMouseState;
        public KeyboardState boardState, previousKeyboardState;

        public int gridSize;

        public bool rewindingTime;
        public int gameTimer;

        public Map map;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
           // graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

        public void Initialize(int i)
        {
            base.Initialize();
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

        public void LoadContent(int i)
        {
            this.LoadContent();

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
            toolTipFont = Content.Load<SpriteFont>("tooltipfont");
            gridSize = 25;
            gameTimer = 0;
            placingTower = null;
            map = new Map("normal", 100, 1);
            towerTex = Content.Load<Texture2D>("Sprites\\Eiffel");
            backTex = Content.Load<Texture2D>("Sprites\\Blank");
            map.Enemies.Add(new Enemy(100, 10f, "basic", 10, new Rectangle(50, 50, 50, 50)));

            this.menu = new Interface(this.graphics, this.spriteBatch, this.font);
            this.menu.Background = backTex;
            this.menu.TowerTex = towerTex;
            this.menu.ToolTipFont = toolTipFont;
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

        public void Update()
        {

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();



            foreach (Tower t in map.Towers)
                t.Update();
            map.Update();
            UpdateInput();
        }
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            this.Update();

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

            #region Draw Towers and Enemies

            foreach (Tower tower in map.Towers)
            {
                spriteBatch.Draw(towerTex, tower.Location, Color.White);
            }
            foreach (Enemy enemy in map.Enemies)
            {
                spriteBatch.Draw(towerTex, enemy.Location, Color.Red);
                enemy.DrawHealth(backTex, spriteBatch);
            }
            if (placingTower != null)
                spriteBatch.Draw(towerTex, placingTower.Location, Color.White);

            #endregion

            #region Display Tooltips

            foreach (Enemy enemy in map.Enemies)
            {
                if (enemy.Location.Contains(mouseState.X, mouseState.Y))
                {
                    menu.DisplayToolTip(enemy, new Vector2(mouseState.X, mouseState.Y));
                }
            }

            foreach (Tower tower in map.Towers)
            {
                if (tower.Location.Contains(mouseState.X, mouseState.Y))
                {
                    menu.DisplayToolTip(tower, new Vector2(mouseState.X, mouseState.Y));
                }

            }

            if (map.SaveStates.Count > 0)
                menu.Draw(map.SaveStates[map.SaveStates.Count - 1]);

            foreach (Tower tower in menu.Towers)
            {
                if (tower.Location.Contains(mouseState.X, mouseState.Y))
                {
                    menu.DisplayToolTip(tower, new Vector2(mouseState.X, mouseState.Y));
                }
            }



            #endregion

            #region Display Other Text

            if (rewindingTime)
                menu.DisplayRewind();

            #endregion




            spriteBatch.End();


            base.Draw(gameTime);
        }


        public void UpdateInput()
        {
            mouseState = Mouse.GetState();
            boardState = Keyboard.GetState();

            if (placingTower != null)
            {

                placingTower.Location = new Rectangle(mouseState.X - (mouseState.X % gridSize), mouseState.Y - (mouseState.Y % gridSize), placingTower.Location.Width, placingTower.Location.Height);

                if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                {
                    for (int i = 0; i < map.Towers.Count; i++)
                    {

                    }
                    map.PlaceTower(new Tower(placingTower.Name, placingTower.Health, placingTower.AttackDamage, placingTower.Cost, placingTower.Range, placingTower.Location));

                    placingTower = null;
                }



            }
            else
            {
                if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                {
                    foreach (Tower tower in menu.Towers)
                    {
                        if (tower.Location.Contains(mouseState.X, mouseState.Y))
                            placingTower = tower.Clone();
                    }
                }

            }

            if (mouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released)
            {
                for (int i = 0; i < map.Towers.Count; i++)
                {
                    if (map.Towers[i].Location.Contains(mouseState.X, mouseState.Y))
                    {
                        map.SellTower(map.Towers[i]);
                    }
                }
            }

            #region Selecting towers with Keyboard Input
            
            if (boardState.IsKeyDown(Keys.D1) && previousKeyboardState.IsKeyUp(Keys.D1))
            {
                Tower temp = menu.Towers[0];
                placingTower = new Tower(temp.Name, temp.Health, temp.AttackDamage, temp.Cost, temp.Range, new Rectangle(mouseState.X - (mouseState.X % gridSize), mouseState.Y - (mouseState.Y % gridSize), 50, 50));
            }

            if (boardState.IsKeyDown(Keys.D2) && previousKeyboardState.IsKeyUp(Keys.D2))
            {
                Tower temp = menu.Towers[1];
                placingTower = new Tower(temp.Name, temp.Health, temp.AttackDamage, temp.Cost, temp.Range, new Rectangle(mouseState.X - (mouseState.X % gridSize), mouseState.Y - (mouseState.Y % gridSize), 50, 50));

            }

            #endregion

            if (boardState.IsKeyUp(Keys.LeftAlt))
            {
                rewindingTime = false;
                map.Rewinding = false;
                gameTimer++;
                map.SaveNextState();
            }
            if (boardState.IsKeyDown(Keys.LeftAlt))
            {
                map.Rewinding = true;
                rewindingTime = true;
                gameTimer--;
                map.LoadPreviousState();

            }





            previousMouseState = mouseState;
            previousKeyboardState = boardState;



        }

        public bool isMouseVisible
        {
            get { return this.IsMouseVisible; }
        }



    }
}
