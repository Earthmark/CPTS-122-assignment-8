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
    enum CarType : byte
    {
        SmallCar,
        Truck,
        Semi
    }

    class Car
    {
        /*Base Attributes*/
        //car sprite
        public Texture2D carSkin { get; private set; }
        //car position
        public Vector2 position { get; set; }
        //car angle in theta
        public float angle { get; set; }
        //true if player controled, false if NPC
        public bool isHuman { get; set; }
        //current car speed
        private float curSpeed { get; set; }

        /*Stats, changed by changing the type*/
        private float topSpeed { get; set; }
        private float turningSpeed { get; set; }
        private float accel { get; set; }
        //master setter for above values
        private CarType carType
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
                        topSpeed = 0.0f;
                        turningSpeed = 0.0f;
                        accel = 0.0f;
                        break;

                    case CarType.SmallCar:
                        topSpeed = 0.0f;
                        turningSpeed = 0.0f;
                        accel = 0.0f;
                        break;

                    case CarType.Truck:
                        topSpeed = 0.0f;
                        turningSpeed = 0.0f;
                        accel = 0.0f;
                        break;
                }
            }
        }

        //sets car skin, used in texture initalization
        public void setSkin(Texture2D carTexture)
        {
            carSkin = carTexture;
        }

        //used to set car origin position, helpful so rotation works correctly
        public Vector2 getCarOrigin()
        {
            return new Vector2(carSkin.Width / 2, carSkin.Height / 2);
        }
    }
}
