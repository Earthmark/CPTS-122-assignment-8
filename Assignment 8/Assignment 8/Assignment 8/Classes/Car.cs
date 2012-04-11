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
        /*Base Attributes*/
            /// <summary>
            /// Car texture attribute.
            /// </summary>
            public Texture2D skin { get; set; }

            /// <summary>
            /// The Car vector position in the track.
            /// </summary>
            public Vector2 position { get; set; }

            /// <summary>
            /// The Car angle in theta, use math libraries to work out vectors.
            /// </summary>
            public float angle { get; set; }

            /// <summary>
            /// Controls if the Car is NPC or Player driven.
            /// </summary>
            public bool isHuman { get; set; }

            /// <summary>
            /// The Car's current speed, changes often.
            /// </summary>
            public float currentSpeed { get; set; }

        /*Stats, changed by changing the type*/
            /// <summary>
            /// Nearly static attribute of top speed.
            /// </summary>
            public static float topSpeed { get; private set; }
            public static float turningSpeed { get; private set; }
            public static float accel { get; private set; }
            public static float mass { get; private set; }
            //master setter for above values.

        /// <summary>
        /// Corrects the rotation offset
        /// </summary>
        /// <returns>Center point of the car</returns>
        public Vector2 carOrigin()
        {
            return new Vector2(skin.Width / 2, skin.Height / 2);
        }
    }
}
