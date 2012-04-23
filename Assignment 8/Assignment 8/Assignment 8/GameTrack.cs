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
            { 
                car.update();
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
                cars[0].currentSpeed *= -(1);
                cars[3].currentSpeed *= -(1);
            }
            if (Collision.CarToCar((int)cars[1].position.X, (int)cars[1].position.Y, (int)Car.source.Width, (int)Car.source.Height, (int)cars[3].position.X, (int)cars[3].position.Y, (int)Car.source.Width, (int)Car.source.Height))
            {
                cars[0].currentSpeed *= -(1);
                cars[3].currentSpeed *= -(1);
            }
            if (Collision.CarToCar((int)cars[2].position.X, (int)cars[2].position.Y, (int)Car.source.Width, (int)Car.source.Height, (int)cars[3].position.X, (int)cars[3].position.Y, (int)Car.source.Width, (int)Car.source.Height))
            {
                cars[0].currentSpeed *= -(1);
                cars[3].currentSpeed *= -(1);
            }
       
            

            ////run through the list of cars and check if they are human (only way input is gathered
            //foreach (Car car in cars)
            //{
            //    if (car.isHuman)
            //    {
            //        //create a new instance for keyboard state and check for arrow keys
            //        KeyboardState newState = Keyboard.GetState();
            //        //Left arrow makes negative angle, Right arrow a positive one
            //        if (newState.IsKeyDown(Keys.Left))
            //        {
            //            car.angle -= 0.1f;
            //        }
            //        else if (newState.IsKeyDown(Keys.Right))
            //        {
            //            car.angle += 0.1f;
            //        }
            //        //Up arrow adds to the car's position, Down arrow subtracts from it.
            //        //Create new Vector2 for momentum with the angles from above, then add the current speed, update position
            //        if (newState.IsKeyDown(Keys.Up))
            //        {
            //            Vector2 momentum = new Vector2((float)Math.Cos(car.angle), (float)Math.Sin(car.angle));
            //            momentum *= car.currentSpeed;
            //            car.position += momentum;
            //        }
            //        else if (newState.IsKeyDown(Keys.Down))
            //        {
            //            Vector2 momentum = new Vector2((float)Math.Cos(car.angle), (float)Math.Sin(car.angle));
            //            momentum *= car.currentSpeed;
            //            car.position -= momentum;
            //        }
            //        oldState = newState;
            //    }
            //}
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Engine.SpriteBatch.Begin();
            //call drawing methods after this

            //draw background

            //draw track

            //draw cars
            foreach (Car car in cars)
            { car.draw(); }

            //call drawing methods before this
            Engine.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
