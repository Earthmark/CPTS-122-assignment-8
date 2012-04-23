using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Assignment_8
{
    enum CarTurnState
    {
        Straight,
        Left,
        Right
    }

    enum CarController
    {
        Nothing,
        Player1,
        Player2
    }

    enum ControlKey
    {
        Up,
        Down,
        Left,
        Right
    }

    class Car
    {
        #region Attributes
        /*Base Attributes*/

        /// <summary>
        /// The Car vector position in the track.
        /// </summary>
        public Vector2 position;

        /// <summary>
        /// The Car angle in theta, use math libraries to work out vectors.
        /// </summary>
        public float angle;

        /// <summary>
        /// Controls if the Car is NPC or Player driven.
        /// </summary>
        public CarController controller;

        /// <summary>
        /// The Car's current speed, changes often.
        /// </summary>
        public float currentSpeed;

        private CarTurnState turnState;

        /*Stats, changed by changing the type*/
        private static float topSpeed;
        private static float turningSpeed;
        private static float turningSpeedMinStart;
        private static float accel;
        private static float mass;
        private static float friction;

        /*Car models*/
        private static List<List<Texture2D>> allCars;

        /*Used to make drawing faster*/
        private static Rectangle source;
        private static Vector2 carOrigin;
        private static float scale;

        private static int totalCarNum;
        private int carNum;
        #endregion

        #region Constructor
        static Car()
        {
            allCars = new List<List<Texture2D>> {
                new List<Texture2D> {
                    Engine.Game.Content.Load<Texture2D>("Cars/Blue/blue_straight"),
                    Engine.Game.Content.Load<Texture2D>("Cars/Blue/blue_left"),
                    Engine.Game.Content.Load<Texture2D>("Cars/Blue/blue_right"),
                },
                new List<Texture2D> {
                    Engine.Game.Content.Load<Texture2D>("Cars/Green/green_straight"),
                    Engine.Game.Content.Load<Texture2D>("Cars/Green/green_left"),
                    Engine.Game.Content.Load<Texture2D>("Cars/Green/green_right"),
                },
                new List<Texture2D> {
                    Engine.Game.Content.Load<Texture2D>("Cars/Yellow/yellow_straight"),
                    Engine.Game.Content.Load<Texture2D>("Cars/Yellow/yellow_left"),
                    Engine.Game.Content.Load<Texture2D>("Cars/Yellow/yellow_right"),
                },
                new List<Texture2D> {
                    Engine.Game.Content.Load<Texture2D>("Cars/Red/red_straight"),
                    Engine.Game.Content.Load<Texture2D>("Cars/Red/red_left"),
                    Engine.Game.Content.Load<Texture2D>("Cars/Red/red_right"),
                }
            };


            Texture2D skin = allCars[0][0];//0,0 car us used as template, as it has the same size as the other cars.
            // Resources used for drawing
            source = new Rectangle(0, 0, skin.Width, skin.Height);
            carOrigin = new Vector2(skin.Width / 2.0f, skin.Height / 2.0f);
            scale = 1.0f;
            
            topSpeed = 10.0f;
            turningSpeed = 0.1f;
            turningSpeedMinStart = 2.5f;
            accel = 0.5f;
            friction = 0.1f;
            mass = 10.0f;
        }

        public Car ()
        {
            carNum = totalCarNum;
            totalCarNum++;

            angle = (float)MathHelper.Pi;
            position = new Vector2(50.0f + 20 * carNum, 50.0f + 20 * carNum);
        }
        #endregion

        #region Draw
        /// <summary>
        /// Draws the car based on its internal attributes,
        /// Uses the Engine. call instead of being in GameTrack
        /// </summary>
        public void draw()
        {
            Engine.SpriteBatch.Draw(allCars[carNum][(int)turnState], position, source, Color.White, 
                angle, carOrigin, scale, SpriteEffects.None, 0);
        }
        #endregion

        #region Update
        public void update()
        {
            if (controller != CarController.Nothing)
            {
                KeyboardState keyState = Keyboard.GetState();

                humanUpdate(keyState);
            }
            else
            {
                computerUpdate();
            }

            positionUpdate();
        }

        private void humanUpdate(KeyboardState keyState)
        {
            //turning
            turnState = CarTurnState.Straight;

            if (keyState.IsKeyDown(interfaceKey(ControlKey.Left)))
            {
                if (currentSpeed > 0)
                {
                    angle -= currentSpeed < turningSpeedMinStart ? turningSpeed * (currentSpeed / turningSpeedMinStart) : turningSpeed;
                }
                else if (currentSpeed < 0)
                {
                    angle += currentSpeed > -turningSpeedMinStart ? turningSpeed * (-currentSpeed / turningSpeedMinStart) : turningSpeed;
                }

                turnState = CarTurnState.Left;
            }
            if (keyState.IsKeyDown(interfaceKey(ControlKey.Right)))
            {
                if (currentSpeed > 0)
                {
                    angle += currentSpeed < turningSpeedMinStart ? turningSpeed * (currentSpeed / turningSpeedMinStart) : turningSpeed;
                }
                else if (currentSpeed < 0)
                {
                    angle -= currentSpeed > -turningSpeedMinStart ? turningSpeed * (-currentSpeed / turningSpeedMinStart) : turningSpeed;
                }

                turnState = CarTurnState.Right;
            }
            //acceleration

            //used to stop the car and prevent a flip thing where the car cant actually stop.
            bool causedFriction = false;

            if (keyState.IsKeyDown(interfaceKey(ControlKey.Up)) && currentSpeed < topSpeed)
            {
                currentSpeed += accel;

                if (currentSpeed > topSpeed)
                {
                    currentSpeed = topSpeed;
                }
            }
            else if (currentSpeed > 0)
            {
                currentSpeed -= friction;
                causedFriction = true;
            }

            if (keyState.IsKeyDown(interfaceKey(ControlKey.Down)) && currentSpeed > -topSpeed)
            {
                currentSpeed -= accel;

                if (currentSpeed < -topSpeed)
                {
                    currentSpeed = -topSpeed;
                }
            }
            else if (currentSpeed < 0)
            {
                currentSpeed += friction;

                if (causedFriction)
                {
                    currentSpeed = 0;
                }
            }
        }

        private void computerUpdate()
        {

        }

        private void positionUpdate()
        {
            position.X += (float)(currentSpeed * Math.Cos(angle));
            position.Y += (float)(currentSpeed * Math.Sin(angle));
        }
        #endregion

        private Keys interfaceKey(ControlKey key)
        {
            switch (controller)
            {
                case CarController.Player1:
                    switch (key)
                    {
                        case ControlKey.Up:
                            return Keys.Up;
                        case ControlKey.Down:
                            return Keys.Down;
                        case ControlKey.Left:
                            return Keys.Left;
                        case ControlKey.Right:
                            return Keys.Right;
                    }
                    break;
                case CarController.Player2:
                    switch (key)
                    {
                        case ControlKey.Up:
                            return Keys.W;
                        case ControlKey.Down:
                            return Keys.S;
                        case ControlKey.Left:
                            return Keys.A;
                        case ControlKey.Right:
                            return Keys.D;
                    }
                    break;
            }

            //should never be called
            return Keys.Escape;
        }
    }
}
