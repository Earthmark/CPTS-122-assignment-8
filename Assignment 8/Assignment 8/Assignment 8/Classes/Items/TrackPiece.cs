﻿using System;
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
    class TrackPiece
    {
        Texture2D texture;
        Vector2 position;

        public TrackPiece(Texture2D setTexture, Vector2 setPosition)
        {
            texture = setTexture;
            position = setPosition;
        }

        public void draw()
        {
           
        }
    }
}
