using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TestGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 
    public class Game1 : Game
    {
        Random rnd = new Random();

        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D doctorTexture;
        Vector2 doctorPosition;
        float doctorSpeed;
        Citizen citizen1;
        Citizen[] citizens;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        //Курсор
        MouseCursor cursor = new MouseCursor();

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            cursor.SetPos(new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2));

            doctorPosition = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
            doctorSpeed = 100f;
            citizen1 = new Citizen();
            citizens = new Citizen[10];
            citizen1.SetPos(new Vector2(rnd.Next(0,graphics.PreferredBackBufferWidth),rnd.Next(0,graphics.PreferredBackBufferHeight)));
            for(int i = 0; i < citizens.Length;i++)
            {
                citizens[i] = new Citizen();
                citizens[i].SetPos(new Vector2(rnd.Next(0, graphics.PreferredBackBufferWidth), rnd.Next(0, graphics.PreferredBackBufferHeight)));
            }

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // TODO: use this.Content to load your game content here

            cursor.SetTexture(Content.Load<Texture2D>("cursor"));
            doctorTexture = Content.Load<Texture2D>("doctor");

            citizen1.SetTexture(Content.Load<Texture2D>("citizen"));
            for(int i = 0; i < citizens.Length; i++)
            {
                citizens[i].SetTexture(Content.Load<Texture2D>("citizen"));
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var mstate = Mouse.GetState();
            cursor.SetPos(mstate.Position.ToVector2());


            var kstate = Keyboard.GetState();
            if(kstate.IsKeyDown(Keys.W))
            {
                doctorPosition.Y = doctorPosition.Y - doctorSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.S))
            {
                doctorPosition.Y = doctorPosition.Y + doctorSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.A))
            {
                doctorPosition.X = doctorPosition.X - doctorSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.D))
            {
                doctorPosition.X = doctorPosition.X + doctorSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (doctorPosition.X > graphics.PreferredBackBufferWidth - doctorTexture.Width / 2)
                doctorPosition.X = graphics.PreferredBackBufferWidth - doctorTexture.Width / 2;
            else if (doctorPosition.X < doctorTexture.Width / 2)
                doctorPosition.X = doctorTexture.Width / 2;

            if (doctorPosition.Y > graphics.PreferredBackBufferHeight - doctorTexture.Height / 2)
                doctorPosition.Y = graphics.PreferredBackBufferHeight - doctorTexture.Height / 2;
            else if (doctorPosition.Y < doctorTexture.Height / 2)
                doctorPosition.Y = doctorTexture.Height / 2;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(doctorTexture, doctorPosition, null, Color.White,0f,new Vector2(doctorTexture.Width / 2, doctorTexture.Height / 2),Vector2.One, SpriteEffects.None, 0f);
            for(int i = 0; i<citizens.Length;i++)
            {
                spriteBatch.Draw(citizens[i].GetTexture(), citizens[i].GetPos(), Color.White);
            }


            //ВСЕГДА ПОСЛЕДНИМ!!!
            spriteBatch.Draw(cursor.GetTexture(), cursor.GetPos(), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
