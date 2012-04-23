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
    class Car
    {
        enum CarTurnState
        {
            Straight,
            Left,
            Right
        }

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
        public bool isHuman;

        /// <summary>
        /// The Car's current speed, changes often.
        /// </summary>
        public float currentSpeed;

        private CarTurnState turnState;

        /*Stats, changed by changing the type*/
        private static float topSpeed;
        private static float turningSpeed;
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
            allCars = new List<List<Texture2D>>{
                new List<Texture2D>
                {
                    Engine.Game.Content.Load<Texture2D>("blue_straight"),
                    Engine.Game.Content.Load<Texture2D>("blue_left"),
                    Engine.Game.Content.Load<Texture2D>("blue_right"),
                },
                new List<Texture2D>
                {
                    Engine.Game.Content.Load<Texture2D>("green_straight"),
                    Engine.Game.Content.Load<Texture2D>("green_left"),
                    Engine.Game.Content.Load<Texture2D>("green_right"),
                },
                new List<Texture2D>
                {
                    Engine.Game.Content.Load<Texture2D>("yellow_straight"),
                    Engine.Game.Content.Load<Texture2D>("yellow_left"),
                    Engine.Game.Content.Load<Texture2D>("yellow_right"),
                },
                new List<Texture2D>
                {
                    Engine.Game.Content.Load<Texture2D>("red_straight"),
                    Engine.Game.Content.Load<Texture2D>("red_left"),
                    Engine.Game.Content.Load<Texture2D>("red_right"),
                }
            };


            Texture2D skin = allCars[0][0];//0,0 car us used as template, as it has the same size as the other cars.
            // Resources used for drawing
            source = new Rectangle(0, 0, skin.Width, skin.Height);
            carOrigin = new Vector2(skin.Width / 2.0f, skin.Height / 2.0f);
            scale = 1.0f;
            
            topSpeed = 10.0f;
            turningSpeed = 0.1f;
            accel = 0.5f;
            mass = 10.0f;
            friction = 0.1f;
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
        public void update(KeyboardState keyState)
        {
            if (isHuman)
            {
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

            if (keyState.IsKeyDown(Keys.Left))
            {
                angle -= turningSpeed;

                turnState = CarTurnState.Left;
            }
            if (keyState.IsKeyDown(Keys.Right))
            {
                angle += turningSpeed;

                turnState = CarTurnState.Right;
            }
            //acceleration
            if (keyState.IsKeyDown(Keys.Up) && currentSpeed < topSpeed)
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
            }

            if (keyState.IsKeyDown(Keys.Down) && currentSpeed > -topSpeed)
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
    }
}
