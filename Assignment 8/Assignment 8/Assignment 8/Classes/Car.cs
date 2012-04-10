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
    /// <summary>
    /// Controls a Car's attributes and model
    /// </summary>
    enum CarType : byte
    {
        SmallCar,
        Truck,
        Semi
    }

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
            /// <summary>
            /// 
            /// </summary>
            public static float turningSpeed { get; private set; }
            public static float accel { get; private set; }
            public float mass { get; private set; }
            //master setter for above values.

        /// <summary>
        /// Changes car attributes based on what is chosen.
        /// </summary>
        public CarType carType
        {
            get
            {
                return carType;
            }
            set
            {
                carType = value;
                
                switch(value)
                {//TODO: make these actual values
                    case CarType.Semi:
                        topSpeed = 10.0f;
                        turningSpeed = 10.0f;
                        accel = 10.0f;
                        mass = 10.0f;
                        break;

                    case CarType.SmallCar:
                        topSpeed = 10.0f;
                        turningSpeed = 10.0f;
                        accel = 10.0f;
                        mass = 10.0f;
                        break;

                    case CarType.Truck:
                        topSpeed = 10.0f;
                        turningSpeed = 10.0f;
                        accel = 10.0f;
                        mass = 10.0f;
                        break;
                }
            }
        }

        /// <summary>
        /// Uses the carType attribute to find correct texture string.
        /// </summary>
        /// <returns>Texture ID string</returns>
        public string modelString()
        {
            switch (carType)
            {
                case CarType.Semi:
                    return "Semi";

                case CarType.SmallCar:
                    return "SmallCar";

                case CarType.Truck:
                    return "Truck";

                default:
                    throw new ArgumentOutOfRangeException ("carType contained an unknown value")
            }
        }

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
