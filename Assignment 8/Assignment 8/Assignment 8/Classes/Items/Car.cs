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
        #region Attributes
        /*Base Attributes*/
        /// <summary>
        /// Car texture attribute.
        /// </summary>
        private Texture2D skin { get; set; }

        /// <summary>
        /// The Car vector position in the track.
        /// </summary>
        private Vector2 position { get; set; }

        /// <summary>
        /// The Car angle in theta, use math libraries to work out vectors.
        /// </summary>
        private float angle { get; set; }

        /// <summary>
        /// Controls if the Car is NPC or Player driven.
        /// </summary>
        public bool isHuman { get; set; }

        /// <summary>
        /// The Car's current speed, changes often.
        /// </summary>
        private float currentSpeed { get; set; }

        /*Stats, changed by changing the type*/
        private static float topSpeed { get; set; }
        private static float turningSpeed { get; set; }
        private static float accel { get; set; }
        private static float mass { get; set; }

        /*Used to make drawing faster*/
        private static Rectangle source { get; set; }
        private static Vector2 carOrigin { get; set; }
        private static Rectangle dest { get; set; }
        private static float scale { get; set; }
        #endregion

        #region Constructor
        public Car (int skinToUse)
        {
            string carString = "blue_car";
            switch (skinToUse)
            {
                case 1:
                    carString = "green_car";
                    break;
                case 2:
                    carString = "red_car";
                    break;
                case 3:
                    carString = "yellow_car";
                    break;
            }

            skin = Engine.Game.Content.Load<Texture2D>(carString);

            angle = (float)MathHelper.Pi;
            position = new Vector2(50.0f + 20 * skinToUse, 50.0f + 20 * skinToUse);

            // Resources used for drawing
            source = new Rectangle(0, 0, skin.Width, skin.Height);
            carOrigin = new Vector2(skin.Width / 2.0f, skin.Height / 2.0f);
            dest = new Rectangle((int)position.X, (int)position.Y, skin.Width, skin.Height);
            scale = 1.0f;
        }
        #endregion

        #region Draw
        /// <summary>
        /// Draws the car based on its internal attributes,
        /// Uses the Engine. call instead of being in GameTrack
        /// </summary>
        public void draw()
        {
            Engine.SpriteBatch.Draw(skin, position, source, Color.White, 
                angle, carOrigin, scale, SpriteEffects.None, 0);
        }
        #endregion
    }
}
