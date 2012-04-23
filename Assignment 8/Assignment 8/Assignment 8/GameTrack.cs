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

namespace Assignment_8
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameTrack : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        //use static item for sprite batch.
        Car[] cars;
        TrackManager trackManager = new TrackManager();
        Collision collision;

        KeyboardState oldState;
        
        public GameTrack()
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
            Engine.Initialize(this, graphics);
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 600;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            cars = new Car[4];

            base.Initialize();

            oldState = Keyboard.GetState();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
                //handled in Engine.cs


            cars[0] = new Car();
            cars[1] = new Car();
            cars[2] = new Car();
            cars[3] = new Car();

            cars[0].controller = CarController.Player1;
            cars[1].controller = CarController.Player2;
            cars[2].controller = CarController.Player2;
            cars[3].controller = CarController.Player2;

            trackManager.loadTrack1();

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

            // TODO: Add your update logic here
            UpdateInput();

            base.Update(gameTime);
        }

        //Updating input from keyboard
        private void UpdateInput()
        {

            //KeyboardState newState = Keyboard.GetState();

            foreach (Car car in cars)
            { car.update(); }

            foreach (Car car in cars)
            {
                foreach (Car collideCar in cars)
                {
                    if ( !(car.Equals(collideCar)) )
                    {
                        if (Collision.CarToCar(car, collideCar))
                        {
                        }
                    }
                }
            }

            if (Collision.CarToCar((int)cars[0].position.X, (int)cars[0].position.Y, (int)Car.source.Width, (int)Car.source.Height, (int)cars[1].position.X, (int)cars[1].position.Y, (int)Car.source.Width, (int)Car.source.Height))
            {
                cars[0].currentSpeed *= -(1);
                cars[1].currentSpeed *= -(1);
            }
            if (Collision.CarToCar((int)cars[0].position.X, (int)cars[0].position.Y, (int)Car.source.Width, (int)Car.source.Height, (int)cars[2].position.X, (int)cars[2].position.Y, (int)Car.source.Width, (int)Car.source.Height))
            {
                cars[0].currentSpeed *= -(1);
                cars[2].currentSpeed *= -(1);
            }
            if (Collision.CarToCar((int)cars[0].position.X, (int)cars[0].position.Y, (int)Car.source.Width, (int)Car.source.Height, (int)cars[3].position.X, (int)cars[3].position.Y, (int)Car.source.Width, (int)Car.source.Height))
            {
                cars[0].currentSpeed *= -(1);
                cars[3].currentSpeed *= -(1);
            }
            if (Collision.CarToCar((int)cars[1].position.X, (int)cars[1].position.Y, (int)Car.source.Width, (int)Car.source.Height, (int)cars[2].position.X, (int)cars[2].position.Y, (int)Car.source.Width, (int)Car.source.Height))
            {
                cars[1].currentSpeed *= -(1);
                cars[2].currentSpeed *= -(1);
            }
            if (Collision.CarToCar((int)cars[1].position.X, (int)cars[1].position.Y, (int)Car.source.Width, (int)Car.source.Height, (int)cars[3].position.X, (int)cars[3].position.Y, (int)Car.source.Width, (int)Car.source.Height))
            {
                cars[1].currentSpeed *= -(1);
                cars[3].currentSpeed *= -(1);
            }
            if (Collision.CarToCar((int)cars[2].position.X, (int)cars[2].position.Y, (int)Car.source.Width, (int)Car.source.Height, (int)cars[3].position.X, (int)cars[3].position.Y, (int)Car.source.Width, (int)Car.source.Height))
            {
                cars[2].currentSpeed *= -(1);
                cars[3].currentSpeed *= -(1);
            }
       
            

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            Engine.SpriteBatch.Begin();
            //call drawing methods after this

            //draw background

            //draw track
            trackManager.drawTrack();

            //draw cars
            foreach (Car car in cars)
            { car.draw(); }

            //call drawing methods before this
            Engine.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
